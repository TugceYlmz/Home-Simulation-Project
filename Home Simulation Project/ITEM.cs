using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulation_Project
{
    abstract class ITEM
    {
         private string brand;
         public string Brand { get { return brand; } set { brand = value; } }
         private string model;
         public string Model { get { return model; } set { model = value; } }
         private string madeIn;
         public string MadeIn { get { return madeIn; } set { madeIn = value; } }
         private int iD;
         public int ID { get { return iD; } set { iD = value; } }

        public void run()
        { 
        
        }

        public void stop()
        { 
        
        }
    }
}
