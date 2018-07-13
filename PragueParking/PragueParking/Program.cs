using System;
using System.Collections.Generic;

namespace PragueParking
{
    class MainClass
    {
        // Hello Mousami!
       
       //Hi Jonas how are you

        //Start of Menu
        public static void DisplayMenu()
        {
            Parkering Park = new Parkering();

            while (true)
            {

                Console.WriteLine("=====================================");
                Console.WriteLine("========= Prague Parking 2.0 ========");
                Console.WriteLine("=====================================");
                Console.WriteLine("=         Choose an option:         =");
                Console.WriteLine("=====================================");
                Console.WriteLine("= 1. Register the vehicle               =");
                Console.WriteLine("= 2. Remove vehicle                 =");
                Console.WriteLine("= 3. Find vehicle                   =");
                Console.WriteLine("= 4. Move vehicle                   =");
                Console.WriteLine("= 5. Current Parking Status         =");
                Console.WriteLine("= 6. Clear the screen               =");
                Console.WriteLine("= 7. Exit the  Application               =");
                Console.WriteLine("=====================================");
                Console.WriteLine();




                //Menu selection

                bool menuResult = int.TryParse(Console.ReadLine(), out int menuSelection);
                
                string regnr;
                string color;
                string brand;
                int typeOfSearch;

                switch (menuSelection)
                {
                    case 1: // Register a Vehicle

                        Console.WriteLine("Select the type of Vehicle: ");
                        Console.WriteLine("1. For a Car ");
                        Console.WriteLine("2. For a MC ");
                        
                        int typeOfVehicle = int.Parse(Console.ReadLine());

                        switch (typeOfVehicle)
                        {
                            case 1://Add Car
                                Console.Write("Enter the Registration Number: ");
                                regnr = Console.ReadLine().ToUpper();
                                Console.Write("Enter the color of the Car: ");
                                color = Console.ReadLine().ToUpper();

                                Park.AddVehicle(typeOfVehicle, regnr, color, "");//brand = "" due to constructor parameter requirement
                                Console.ReadLine();
                                
                                break;
                            
                            case 2://Add MB
                                Console.Write("Enter the Registration Number: ");
                                regnr = Console.ReadLine().ToUpper();
                                Console.Write("Enter the brand of the MC: ");
                                brand = Console.ReadLine().ToUpper();

                                Park.AddVehicle(typeOfVehicle, regnr, "", brand);// color = "" due to contructor parameter requirement
                                Console.ReadLine();
                                break;

                            case 3:
                                
                                break;
                                
                            
                        }
                        break;

                    case 2:
                        Console.Write("Enter the Registration Number: ");
                        regnr = Console.ReadLine().ToUpper();

                        bool vehicleIsRemoved = false;

                        vehicleIsRemoved = Park.RemoveVehicle(regnr);

                        if (vehicleIsRemoved == true)
                        {
                            Console.WriteLine("Your vehicle has been removed.");
                        }

                        else
                            Console.WriteLine("Your vehicle was not found in the parking lot.");

                        break;

                    case 3:
                        Console.Write("Enter the Registration Number: ");
                        regnr = Console.ReadLine().ToUpper();

                        int retIfFound = 0;

                        retIfFound = Park.FindVehicle(regnr); // position of vehicle (or -1 if not found) in retIfFound after call)

                        if (retIfFound != -1) // if vehicle found
                        {
                            Console.WriteLine("Vehicle found at parking place {0}", retIfFound + 1); // vehicle position found at +1
                        }

                        else
                            Console.WriteLine("Vehicle not found in parking lot."); // if vehicle not found

                        break;

                    
                    case 4:
                        Console.WriteLine("Select the type of Vehicle: ");
                        Console.WriteLine("1. For a Car ");
                        Console.WriteLine("2. For a MC ");
                        typeOfVehicle = int.Parse(Console.ReadLine());
                        Console.Write("Enter the Registration Number: ");
                        regnr = Console.ReadLine().ToUpper();
                        Console.Write("Select the position to move: ");
                        int position = int.Parse(Console.ReadLine());
                        if (typeOfVehicle == 1)
                        {
                            Park.MoveVehicle(regnr, position, typeOfVehicle);
                            Console.ReadLine();
                        }
                        if (typeOfVehicle == 2)
                        {
                            Park.MoveVehicle(regnr, position, typeOfVehicle);
                            Console.ReadLine();
                        }
                        break;
                        
                    case 5:
                        
                        Console.WriteLine("1. To display all ");
                        Console.WriteLine("2. To display by one position ");
                        typeOfSearch = int.Parse(Console.ReadLine());
                        int pos = 0;
                        if (typeOfSearch == 2)
                        {
                            Console.Write("Enter the desired position: ");
                            pos = int.Parse(Console.ReadLine());  
                        }
                        Park.Content2(typeOfSearch, pos);
                        Park.CalculateSlots();
                        Console.WriteLine("Avalible full slots {0}", Park.availableSlots);
                        Console.WriteLine("Avalible parcial slots {0}", Park.parcialSlots);

                        break;

                    case 6:
                        Console.Clear();
                        break;

                    case 7:
                        Environment.Exit(1);
                        break;
                }

            }
        }
        //End of Menu
        public static void Main(string[] args)
        {
            
            DisplayMenu();
        }
       
    }
}
