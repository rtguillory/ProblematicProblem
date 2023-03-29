using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem

{
    public class Program 
    {
        
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        //static List<string> activities = new List<string>() { "Movies", "Paintball", "Wine Tasting" };  //shorter list for testing
        static void Main(string[] args)
        {   
            Random rng = new Random();
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            //var contResponse = Console.ReadLine().ToLower();
            cont = (Console.ReadLine().ToLower() == "yes") ? true : false;

            if(!cont)
                Console.WriteLine("Come back when you are ready to get an activity!");
            
            while (cont)
            {

                Console.WriteLine();

                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();

                Console.Write("What is your age? ");
                int userAge = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (userAge < 21) { activities.Remove("Wine Tasting"); }

                Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                bool seeList = (Console.ReadLine().ToLower() == "sure") ? true : false;

                if (seeList)
                {
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();

                    Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                    bool addToList = (Console.ReadLine().ToLower() == "yes") ? true : false;
                    Console.WriteLine();

                    while (addToList)
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);
                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }
                        Console.WriteLine();

                        Console.WriteLine("Would you like to add more? yes/no: ");
                        addToList = (Console.ReadLine().ToLower() == "yes") ? true : false;
                    }
                }
                bool cont2 = true;
                while (cont2)
                {
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(100);
                    }
                    Console.WriteLine();
                    Console.Write("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(100);
                    }
                    Console.WriteLine();
                    int randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber];
                        //removed wine tasting above if age was less than 21 so this is no longer needed
                    //if (userAge < 21 && randomActivity == "Wine Tasting")
                    //{
                    //    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    //    Console.WriteLine("Picking something else!");
                    //    activities.Remove(randomActivity);
                     //        randomNumber = rng.Next(activities.Count);
                    //        randomActivity = activities[randomNumber];
                    //    } 
                    //}
                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();
                    cont2 = (Console.ReadLine().ToLower() == "redo") ? true : false;

                    if (!cont2)
                    {
                        Console.WriteLine("Enjoy your activity!");
                        cont = false;
                    }
                    else 
                    {
                        //Remove activities so duplicates do not show up when redoing
                        if (activities.Count > 1 )
                        {
                            activities.Remove(randomActivity);
                        }
                        else
                        {
                            //stop when all activities have been offered
                            Console.WriteLine("There are no further activities.  Please begin again.");
                            cont = false;
                            cont2 = false;
                        }
                            
                    }
                    
                }
            }
               
            Console.ReadLine();

            
        }
    }
}
