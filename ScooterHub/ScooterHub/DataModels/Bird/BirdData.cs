using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;


namespace ScooterHub.DataModels.Bird
{
    public class BirdData
    {
        const string DEVICE_ID = "123E4567-E89B-12D3-A456-426655440070";
        const string EMAIL = "mytestemail12345@gmail.com";
        const string LATITUDE = "32.7744339"; // Campus
        const string LONGITUDE = "-117.0693269";
        const string RADIUS = "25";

        public BirdAPI birdAPI;

        static HttpClient client = new HttpClient();

        public BirdData()
        {
            birdAPI = new BirdAPI();
        }

        public async Task RunAsync()
        {
            // Try to get bird auth token
            // Run our async Task which calls the Bird Auth API to get our auth token
            BirdAuth auth = new BirdAuth();

            /* 1. In BirdData.cs, change the EMAIL
             * 2. In BirdData.cs, uncomment the line:  Preferences.Clear();
             * 3. In LimeData.cs, change PHONE_NUM to your phone number 
             * 4. In LimeData.cs, in RunLimeAsync() method, comment out everything except:  await GetLimeRegisterTokenAsync(PHONE_NUM);
             * 5. Run project
             * 6. In BirdData.cs, comment out the line:  Preferences.Clear(); 
             * 7. In LimeData.cs, change TOKEN to the one texted to you 
             * 8. In LimeData.cs, comment out the await line and uncomment the rest of the RunLimeAsync() method 
             * 9. Now you can keep running the project over and over without having to change emails, tokens, etc. */
            //Preferences.Clear();

            if (Preferences.ContainsKey("authToken"))
            {
                auth.token = Preferences.Get("authToken", "default_value");
            }
            else
            {
                auth = await GetBirdAuthAsync(DEVICE_ID, EMAIL);
                Preferences.Set("authToken", auth.token);
            }


            // Make sure we have a valid token
            if (string.IsNullOrEmpty(auth.token))
                throw new Exception("Failed to get proper Bird Auth Token");

            // Use our token to call main Bird API to get a list of scooters
            //BirdAPI api = new BirdAPI();
            birdAPI = await GetBirdScootersAsync(auth.token, LATITUDE, LONGITUDE, RADIUS);

            // Print out info for each scooter found
            System.Diagnostics.Debug.WriteLine($"Found {birdAPI.birds.Count} scooters!\n");
            foreach (var scooter in birdAPI.birds)
                System.Diagnostics.Debug.WriteLine($"Scooter {scooter.id}:\n    " +
                    $"Lat: {scooter.location.latitude}, " +
                    $"Long: {scooter.location.longitude}, " +
                    $"Battery: {scooter.battery_level}%\n");
        }

        static async Task<BirdAuth> GetBirdAuthAsync(string deviceId, string email)
        {
            string url = "https://api.bird.co/user/login";
            BirdAuth auth = null;
            // Add required headers
            client.DefaultRequestHeaders.Add("Device-id", deviceId);
            client.DefaultRequestHeaders.Add("Platform", "ios");
            /* HTTP post request to api
               Here our data is sent to the API */
            HttpResponseMessage response = await client.PostAsync(url,
                new StringContent($"{{\"email\": \"{email}\"}}", Encoding.UTF8, "application/json"));

            // If we got a successful response...
            if (response.IsSuccessStatusCode)
            {
                // ...store response in a string
                var content = await response.Content.ReadAsStringAsync();
                // Take that string and put it into our BirdAuth data structure
                auth = JsonConvert.DeserializeObject<BirdAuth>(content);
            }
            else // Response unsuccessful
                throw new Exception("BirdAuthAPI request rejected (Bad params?)");

            return auth;
        }

        static async Task<BirdAPI> GetBirdScootersAsync(string token, string latitude, string longitude, string radius)
        {
            string url = $"https://api.bird.co/bird/nearby?latitude={latitude}&longitude={longitude}&radius={radius}";
            BirdAPI api = null;
            client.DefaultRequestHeaders.Add("Authorization", $"Bird {token}");
            client.DefaultRequestHeaders.Add("Device-id", DEVICE_ID);
            client.DefaultRequestHeaders.Add("App-Version", "4.27.1.0");
            client.DefaultRequestHeaders.Add("Location",
                                             $"{{\"latitude\":{latitude}," +
                                             $"\"longitude\":{longitude}," +
                                             $"\"altitude\":500," +
                                             $"\"accuracy\":100," +
                                             $"\"speed\":-1," +
                                             $"\"heading\":-1}}");
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                api = JsonConvert.DeserializeObject<BirdAPI>(content);
            }
            else
                throw new Exception("BirdAPI request rejected (Bad params?)");

            return api;
        }
    }
}