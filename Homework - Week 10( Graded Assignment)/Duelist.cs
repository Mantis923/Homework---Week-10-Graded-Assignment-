using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework___Week_10__Graded_Assignment_
{
    class Duelist
    {
        private String name;
        private double accuracy;
        private Boolean alive;
        Random random = new Random();
        public Duelist(string n, double accurate, bool alive)
        {
            name = n;
            accuracy = accurate;
            alive = true;
        }

        public string Name { get => name; set => name = value; } 
        public double Accurate { get => accuracy; set => accuracy = value; }
        public bool Alive { get => alive; set => alive = value; }
        
       
         public void ShootAtTarget(Duelist dead)
        {
            
           double shooterAccuracy = random.NextDouble();
            if (shooterAccuracy < accuracy)
                dead.alive = false;
        }

    }
}
