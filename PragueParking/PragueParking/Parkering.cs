using System;
using System.Collections.Generic;
namespace PragueParking
{
    public class Parkering
    {
        public int availableSlots;
        public int parcialSlots;
        private ParkeringPlats[] ParkingSpace;  //Declaring the array...populating below
        public Parkering()
        {
            ParkingSpace = new ParkeringPlats[100];
            for (int i = 0; i <= ParkingSpace.Length - 1; i++)
            {
                ParkingSpace[i] = new ParkeringPlats();
            }
        }
        public void AddVehicle(int typeOfVehicle, string regnr, string color, string brand)
        {
            bool addFordonReturn;
            int tempSize = DefineSize(typeOfVehicle);
            for (int i = 0; i <= ParkingSpace.Length - 1; i++)
            {
                if (ParkingSpace[i].availableSize >= tempSize)
                {
                    Vehicle fordon = new Vehicle(regnr, 0);

                    addFordonReturn = ParkingSpace[i].AddFordon(typeOfVehicle, fordon, color, brand);//Call AddFordon to add the Vehicle
                    if (typeOfVehicle == 1)
                    {
                        if (addFordonReturn == true)
                        {
                            Console.WriteLine("Car " + regnr + " with color " + color + " added to slot " + (i + 1));
                        }
                        else
                        {
                            Console.WriteLine("Parking is full");
                        }
                    }
                    if (typeOfVehicle == 2)
                        if (addFordonReturn == true)
                        {
                            Console.WriteLine("Motocycle " + regnr + " with brand " + brand + " added to slot " + (i + 1));
                        }
                        else
                        {
                            Console.WriteLine("Parking is full");
                        }
                    Console.ReadLine();
                    return;
                }
            }
        }
        public int DefineSize(int vehicleType)
        {
            if (vehicleType == 1)
            {
                return 4;
            }
            if (vehicleType == 2)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
        public int FindVehicle(string regnr)
        {
            for (int i = 0; i <= ParkingSpace.Length - 1; i++)
            {
                int positionOfParkingPlace = i;
                int retIfFound = ParkingSpace[i].FindFordon(positionOfParkingPlace, regnr);
                if (retIfFound != -1)
                {
                    return positionOfParkingPlace;
                }
            }
            return -1;
        }
        public void Content2(int typeSearch, int spot)//Method to return all the vehicles that exists in the Parking by slot
        {
            if (typeSearch == 1)
            {

                for (int z = 0; z <= ParkingSpace.Length - 1; z++)
                {
                    if (ParkingSpace[z].availableSize != 4)
                    {
                        foreach (Vehicle v in ParkingSpace[z].ContentFordon2())
                        {
                            if (v.size == 4)
                            {
                                Console.WriteLine("CAR " + v.regnr + " is parked at slot " + (z + 1));
                            }
                            if (v.size == 2)
                            {
                                Console.WriteLine("MC " + v.regnr + " is parked at slot " + (z + 1));
                            }
                        }

                    }
                }
            }
            Console.ReadLine();
            if (typeSearch == 2)
            {
                foreach (Vehicle v in ParkingSpace[spot - 1].ContentFordon2())
                {
                    if (v.size == 4)
                    {
                        Console.WriteLine("CAR " + v.regnr + " is parked at slot " + (spot));
                    }
                    if (v.size == 2)
                    {
                        Console.WriteLine("MC " + v.regnr + " is parked at slot " + (spot
                            ));
                    }
                }
            }
        }
        public bool RemoveVehicle(string regnr)
        {
            bool vehicleIsRemoved = false;
            for (int i = 0; i <= ParkingSpace.Length - 1; i++)
            {
                int positionOfParkingPlace = i;
                DateTime entryTime;
                DateTime exitTime = DateTime.Now;
                //DateTime entryTime;
                TimeSpan span;
                if (ParkingSpace[i].FordonA.Count != 0)
                {

                    if (ParkingSpace[i].FordonA[0].regnr.Equals(regnr) && ParkingSpace[i].FordonA.Count != 0)
                    {
                        entryTime = ParkingSpace[i].FordonA[0].parkingTime;
                        span = exitTime.Subtract(entryTime);
                        // Console.WriteLine(exitTime);
                        Console.WriteLine("Vehicle stayed for: " + span.Hours + ":" + span.Minutes + ":" + span.Seconds);
                    }
                    else if (ParkingSpace[i].FordonA.Count == 2)
                    {
                        if (ParkingSpace[i].FordonA[1].regnr.Equals(regnr))
                        {
                            entryTime = ParkingSpace[i].FordonA[1].parkingTime;
                            span = exitTime.Subtract(entryTime);
                            //Console.WriteLine(exitTime);
                            //Console.WriteLine(exitTime);
                            Console.WriteLine("Vehicle stayed for: " + span.Hours + ":" + span.Minutes + ":" + span.Seconds);
                        }
                    }
                }
                bool retIfRemoved = ParkingSpace[i].RemoveVehicle(positionOfParkingPlace, regnr);
                if (retIfRemoved == true)
                {
                    //TimeSpan span = exitTime.Subtract(entryTime);


                    //Console.WriteLine("Vehicle stayed for: " + span.Hours + ":" + span.Minutes + ":" + span.Seconds);
                    vehicleIsRemoved = true;
                    break;

                }
            }
            return vehicleIsRemoved;
        }
        public bool MoveVehicle(string regnr, int position, int typeOfVehicle)
        {
            int result = FindVehicle(regnr);
            if (result != -1)
            {
                for (int s = 0; s <= ParkingSpace.Length - 1; s++)
                {
                    if ((s + 1) == position)
                    {
                        if (typeOfVehicle == 1)//if its a CAR
                        {
                            if (ParkingSpace[s].availableSize == 4)
                            {
                                Vehicle fordon = new Vehicle(regnr, 0);
                                Car C1 = (Car)ParkingSpace[result].FordonA[0];

                                RemoveVehicle(regnr);
                                ParkingSpace[s].AddFordon(typeOfVehicle, fordon, C1.color, "");

                                Console.WriteLine("CAR " + regnr + "was moved to position " + position);
                                Console.ReadLine();
                                return true;
                            }
                            else
                            {
                                Console.WriteLine("The position is not available");
                            }
                        }
                        if (typeOfVehicle == 2)
                        {
                            if (ParkingSpace[s].availableSize >= 2)
                            {
                                Vehicle fordon = new Vehicle(regnr, 0);
                                MC M1 = (MC)ParkingSpace[result].FordonA[0];
                                string brandName = M1.brand;
                                if (M1.regnr != regnr)
                                {
                                    MC M2 = (MC)ParkingSpace[result].FordonA[1];
                                    brandName = M2.brand;
                                }

                                RemoveVehicle(regnr);
                                ParkingSpace[s].AddFordon(typeOfVehicle, fordon, "", brandName);

                                Console.WriteLine("MC " + regnr + "was moved to position " + position);
                                Console.ReadLine();
                                return true;
                            }
                            else
                            {
                                Console.WriteLine("The position is not available");
                            }
                        }
                    }
                }
            }
            else
                Console.WriteLine("Vehicle not yet parked");
            return false;
        }
        public void CalculateSlots()
        {
            availableSlots = 100;
            parcialSlots = 400;
            for (int i = 0; i <= ParkingSpace.Length - 1; i++)
            {

                if (ParkingSpace[i].availableSize == 0)
                {
                    availableSlots--;
                    parcialSlots = parcialSlots - 4;

                }
                else if (ParkingSpace[i].availableSize == 2)
                {

                    parcialSlots = parcialSlots - 2;
                }

            }
        }


    }
}
