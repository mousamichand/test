using System;
using System.Collections.Generic;

namespace PragueParking
{
    public class Car : Vehicle
    {
        public int size = 4;
        public string color;

        public Car(Vehicle fordon,string  color) : base (fordon.regnr, 4)
        {

             this.color = color;
        }
    }
}
