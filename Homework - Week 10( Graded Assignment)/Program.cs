using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework___Week_10__Graded_Assignment_
{
    class Program
    {
        /// <summary>
        /// In the land of Puzzlevania, Aaron, Bob, and Charlie had an argument over which one of them was the greatest puzzler of all time. 
        /// To end the argument once and for all, 
        /// they agreed on a duel to the death. Aaron was a poor shooter and only hit his target with a probability of 1/3.  Bob was a bit better and hit his target with 
        /// a probability of ½. Charlie was an expert marksman and hit 99.5% of his shots.  A hit means a kill and the person hit drops out of the duel.
        ///To compensate for the inequities in their marksmanship skills the three decided that they would fire in turns, 
        ///starting with Aaron, followed by Bob, and then by Charlie.The cycle would repeat until there was one man standing, 
        ///and that mans would be the Greatest Duelist of All-Time.An obvious and reasonable strategy is for each man to shoot at the most accurate shooter still alive, 
        ///on the grounds that this shooter is the deadliest and has the best chance of hitting back.
        ///Write a program to simulate the duel using this stragety.
        ///Your program should use random numbers and the probabilities given in the problem to 
        ///determine whether a shooter hits the target.  Create a class named Duelist that contains the dueler’s name and shooting accuracy, 
        ///a Boolean indicating whether the dueler is still alive, and a method ShootAtTarget(Duelist target) 
        ///that sets the target to dead if the dueler hits his target(using a random number and the shooting accuracy) and does nothing otherwise.
        /// Use properties for your Duelist class.
        ///Once you can simulate a single duel, add a loop to your program that simulates 10,000 duels.
        ///Count the number of times that each contestant wins and print the probability of winning 
        ///for each contestant(ie for Aaron your program might output “Aaron won 3595/10000 duels or 35.95%).
        ///An alternate strategy is for Aaron to intentionally miss on his first shot.Modify the program to accommodate this new strategy and 
        ///output the probability of winning for each contestant.Which strategy is better for Aaron: to intentionally miss on the first shot or to try and hit the best shooter? 
        ///Who has the best chance or winning, the best shooter or the worst shooter?
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int ArrCount = 0;
            int BobCount = 0;
            int ChuckCount = 0;
            bool LastStanding;
            //int BullE = 0; should i have him??


            Duelist Arron = new Duelist("Arron", 0.33, true);
            Duelist Bob = new Duelist("Bob", 0.55, true);
            Duelist Chuck = new Duelist("Charles", 0.995, true);
            // Duelist Bulleye = new Duelist("BullsEye", 1.0, true); //should I include this will it help?
            for (int i = 0; i < 10000; i++)
            {
                Arron.Alive = true;
                Bob.Alive = true;
                Chuck.Alive = true;
                LastStanding = false;
                do
                {
                    // Arron shoots and checks if others are alive

                    if (Arron.Alive == true)
                    {
                        if (Bob.Alive == true)
                        {
                            Arron.ShootAtTarget(Bob);
                        }
                        else
                            Arron.ShootAtTarget(Chuck);
                        if (Bob.Alive == false && Chuck.Alive == false)
                        {
                            LastStanding = true;
                        }
                    }
                    // Bob shoots and checks if others are alive
                    if (Bob.Alive == true)
                    {
                        if (Arron.Alive == true)
                        {
                            Bob.ShootAtTarget(Arron);
                        }
                        else
                            Bob.ShootAtTarget(Chuck);
                        if (Arron.Alive == false && Chuck.Alive == false)
                        {
                            LastStanding = true;
                        }
                    }
                    // Charlie shoots and checks if others are alive
                    if (Chuck.Alive == true)
                    {
                        if (Arron.Alive == true)
                        {
                            Chuck.ShootAtTarget(Arron);
                        }
                        else
                            Chuck.ShootAtTarget(Bob);
                        if (Arron.Alive == false && Bob.Alive == false)
                        {
                            LastStanding = true;
                        }
                    }
                } while (LastStanding == false);
                if (Arron.Alive == true)
                    ArrCount++;
                else if (Bob.Alive == true)
                    BobCount++;
                else
                    ChuckCount++;

            }
            Console.WriteLine(" Arron won " + ArrCount + " out of 10,000 duels "
                                + (ArrCount / 10000.0) * (100.0) + "%");
            Console.WriteLine(" Bob won " + BobCount + " out of 10,000 duels "
                                + (BobCount / 10000.0) * (100.0) + "%");
            Console.WriteLine(" Charles won " + ChuckCount + " out of 10,000 duels "
                                + (ChuckCount / 10000.0) * (100.0) + "%");
            Console.ReadLine();
        }
    }
}
