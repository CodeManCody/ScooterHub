﻿using ScooterHub.DataModels;
using ScooterHub.DataModels.Bird;
using ScooterHub.DataModels.Lime;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ScooterHub.ViewModels
{
    public class MapVM
    {
        private BirdData birdData;
        private LimeData limeData;
        private MapData data;
        private LimeAPI limeAPI;
        public Xamarin.Forms.Maps.Map map { get; private set; }
        private Xamarin.Essentials.Location currentLocation { get; set; }
        public MapVM()
        {
            data = new MapData();
            createMap();
            
            //birdData = new BirdData();
            limeData = new LimeData();

            //addPins();
        }

        private void addPins()
        {
            /*
            foreach (double[] location in data.coordinates)
            {
                var position = new Position(location[0], location[1]); // Latitude, Longitude

                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = "custom pin",
                    Address = "custom detail info"
                };

                map.Pins.Add(pin);
            }
            */

            foreach (Bike scooter in limeData.limeAPI.data.attributes.bikes)
            {
                var position = new Position(scooter.attributes.latitude, scooter.attributes.longitude);

                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = "Lime scooter",
                    Address = "custom detail info"
                };

                map.Pins.Add(pin);
    
            }
        }
        private void createMap()
        {
            /* can't test on laptop...will test on real phone
            Task.Run(async () =>
            {
                await getCurrentLocation();
            });
            */

            map = new Xamarin.Forms.Maps.Map(
                MapSpan.FromCenterAndRadius(
                        //new Position(currentLocation.Latitude, currentLocation.Longitude), Distance.FromMiles(0.3)))
                        new Position(32.774209, -117.070028), Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
        }

        private async Task getCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                currentLocation = await Geolocation.GetLocationAsync(request);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}