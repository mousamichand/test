using System;
namespace PragueParking
{
    public class MC : Vehicle
    {
        public int size =  2;
        public string brand;

        public MC(Vehicle fordon, string brand) : base(fordon.regnr,2)
        {

            this.brand = brand;

        }
    }
}
