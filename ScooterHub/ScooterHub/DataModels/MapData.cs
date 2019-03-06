using System;
using System.Collections.Generic;
using System.Text;

namespace ScooterHub.DataModels
{
    public class MapData
    {
        public Double[] coordinates { get; private set; }

        public MapData()
        {
            coordinates = new Double[2];
            coordinates[0] = 32.774209;
            coordinates[1] = -117.070028;
        }
    }
}
