using System;
using System.Collections.Generic;

namespace PragueParking
{
    public class ParkeringPlats
    {
        public int size { get; private set; }
        public int availableSize { get; private set; }

        private List<Vehicle> Fordon;


        public List<Vehicle> FordonA {
            get
            {

                return Fordon;
            }
                
                }

        public ParkeringPlats()
        {
            size = 4;
            availableSize = 4;
            Fordon = new List<Vehicle>();

        }

        public bool AddFordon(int typeOfVehicle, Vehicle fordon,string color, string brand)
        
        {
            



            if (typeOfVehicle == 1)
            {
                Car Bil = new Car(fordon,color);
                Fordon.Add(Bil);
                availableSize = availableSize - Bil.size;
                return true;
            }
            if (typeOfVehicle == 2)
            {
                MC MB = new MC(fordon, brand);
                Fordon.Add(MB);
                availableSize = availableSize - MB.size;
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool RemoveVehicle(int positionOfParkingPlace, string regnum)
        {
            bool vehicleRemoved = false; // Remove or not ?
            int removePos = -1;          // Position to remove it from
            bool isCar = false;         // Is it a CAR that we remove ?

            int i = 0;

            foreach (Vehicle k in Fordon)
            {
                if (k.regnr == regnum)
                {
                    removePos = i;
                    
                 

                    if (k.size == 4)
                    {
                        isCar = true; // is CAR !
                    }

                    if (k.size == 2)
                    {
                        isCar = false; // is MC !
                    }
                }

                i++; // Increment position manually as we use foreach
            }

            if (removePos != -1)
            {
                Fordon.RemoveAt(removePos); // Remove it from list

                if (isCar == true)
                {
                    availableSize = availableSize + 4; // add free size equivalent to the size of a car
                }

                else
                    availableSize = availableSize + 2; // add free size equivalet to the size of an MC

                vehicleRemoved = true; // YES! Removed!
            }

            else
                vehicleRemoved = false; // Not removed

            return vehicleRemoved;

        }
      

        public List<Vehicle> ContentFordon2()
        {
           

            return Fordon;
        }

        public int FindFordon(int positionOfParkingPlace, string regnum)
        {
            //int positionOfFoundVehicle = 0;

            foreach (Vehicle k in Fordon)
            {
                if (k.regnr == regnum)
                {
                    return positionOfParkingPlace;
                }
            }

            return -1;
        }


    }
}
