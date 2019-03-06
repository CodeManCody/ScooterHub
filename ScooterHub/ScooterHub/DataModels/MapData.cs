using System;
using System.Collections.Generic;
using System.Text;

namespace ScooterHub.DataModels
{
    public class MapData
    {
        public HashSet<double[]> coordinates { get; private set; }

        public MapData()
        {
            coordinates = new HashSet<double[]>();
            loadData();
        }

        private void loadData()
        {
            double[] scooter = new double[2];
            scooter[0] = 32.774209;
            scooter[1] = -117.070028;
            coordinates.Add(scooter);
        }
    }
}
