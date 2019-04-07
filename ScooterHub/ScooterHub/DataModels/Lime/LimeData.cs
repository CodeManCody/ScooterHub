using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace ScooterHub.DataModels.Lime
{
    public class LimeData
    {
        const string PHONE_NUM = ""; // ex: 16195555555
        const string NE_LAT = "32.777734";
        const string NE_LONG = "-117.0709506";
        const string SW_LAT = "32.773503";
        const string SW_LONG = "-117.0754787";


        static LimeData()
        {
            Task.Run(async () =>
            {
                await RunLimeAsync();
            });
        }

        // Lime ====================================================================================
        static async Task RunLimeAsync()
        {
            /* This call will send a token to your phone. In order for this to work you must
             * have a Lime account registered to your PHONE_NUM.
             * You should run this line by itself to get a token texted to you.
             * Then uncomment the rest of this method and comment the line below to actually 
             * run the demo.
             * Put the code you get texted in the GetLimeAuthAsync() call. */
            await GetLimeRegisterTokenAsync(PHONE_NUM);

            /*
            // Auth
            LimeAuth auth = new LimeAuth();
            auth = await GetLimeAuthAsync(PHONE_NUM, "527544");

            // Make sure we have a valid token
            if (string.IsNullOrEmpty(auth.token))
                throw new Exception("Failed to get proper Lime Auth Token");
            
            // Use our token to call main Lime API to get a list of scooters
            LimeAPI api = new LimeAPI();
            api = await GetLimeScootersAsync(auth.token, auth.cookie, NE_LAT, NE_LONG, SW_LAT, SW_LONG,
                LATITUDE, LONGITUDE);

            // Print out info for each scooter found
            Console.WriteLine($"Found {api.data.attributes.bikes.Count} scooters!\n");
            foreach (var scooter in api.data.attributes.bikes)
                Console.WriteLine($"Scooter {scooter.id}:\n    " +
                    $"Lat: {scooter.attributes.latitude}, " +
                    $"Long: {scooter.attributes.longitude}, " +
                    $"Battery: {scooter.attributes.battery_level}\n");
            */
        }

        static async Task<Object> GetLimeRegisterTokenAsync(string phoneNum)
        {
            HttpClient client = new HttpClient();
            string url = $"https://web-production.lime.bike/api/rider/v1/login?phone=%2B{phoneNum}";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(content);
            }
            else
                throw new Exception("LimeRegisterAPI request rejected (Bad params?)");

            return new Object();
        }

        static async Task<LimeAuth> GetLimeAuthAsync(string phoneNum, string limeCode)
        {
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            HttpClient client = new HttpClient(handler);
            string url = "https://web-production.lime.bike/api/rider/v1/login";
            LimeAuth auth = null;
            /* HTTP post request to api
               Here our data is sent to the API */
            HttpResponseMessage response = await client.PostAsync(url,
                new StringContent($"{{\"login_code\": \"{limeCode}\", \"phone\": \"+{phoneNum}\"}}", Encoding.UTF8, "application/json"));

            // If we got a successful response...
            if (response.IsSuccessStatusCode)
            {
                // ...store response in a string
                var content = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(content);
                // Take that string and put it into our LimeAuth data structure
                auth = JsonConvert.DeserializeObject<LimeAuth>(content);

                IEnumerable<Cookie> responseCookies = cookies.GetCookies(new Uri(url, UriKind.Absolute)).Cast<Cookie>();
                foreach (Cookie cookie in responseCookies)
                    //Console.WriteLine(cookie.Name + ": " + cookie.Value);
                    if (cookie.Name == "_limebike-web_session") auth.cookie = cookie.Value;
            }
            else if ((int)response.StatusCode == 429)
                throw new Exception("Lime: Too Many Requests (Rate Limited)");
            else // Response unsuccessful
                throw new Exception("LimeAuthAPI request rejected (Bad params?)");

            return auth;
        }

        static async Task<LimeAPI> GetLimeScootersAsync(string token, string cookie, string neLat,
            string neLong, string swLat, string swLong, string latitude, string longitude)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseCookies = false;
            HttpClient client = new HttpClient(handler);
            string url = $"https://web-production.lime.bike/api/rider/v1/views/map?ne_lat={neLat}&ne_lng={neLong}&sw_lat={swLat}&sw_lng={swLong}&user_latitude={latitude}&user_longitude={longitude}&zoom=16";
            LimeAPI api = null;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Add("Cookie", $"_limebike-web_session={cookie}");

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(content);
                api = JsonConvert.DeserializeObject<LimeAPI>(content);
            }
            else if ((int)response.StatusCode == 429)
                throw new Exception("Lime: Too Many Requests (Rate Limited)");
            else
                throw new Exception("LimeAuthAPI request rejected (Bad params?)");

            return api;
        }
    }
}
