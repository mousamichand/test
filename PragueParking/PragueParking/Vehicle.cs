using System;
using System.Collections.Generic;

namespace PragueParking
{
    public class Vehicle
    {
        public int size;
        public string regnr;
        public DateTime parkingTime;

        public Vehicle(string regnr, int size)//Constructor
        {
            this.regnr = regnr;
            this.size = size;
            parkingTime = DateTime.Now;

        }


    }
}