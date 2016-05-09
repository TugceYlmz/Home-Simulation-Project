using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulation_Project
{
    class Dishwasher : ITEM
    {
        Wall_Plug wp = new Wall_Plug();
        Tap tp = new Tap();

        private int capacity;
        public int Capacity { get { return capacity; } set { capacity = value; } }
        private int noOfProgram;
        public int NoOfProgram { get { return noOfProgram; } set { noOfProgram = value; } }

        public int run()
        {
            try
            {
                wp.runForMach();
                tp.runForMach();
                string pro = Microsoft.VisualBasic.Interaction.InputBox("Select program 1 or 2 : \n 1 : Intensive 65°C \n 2 : Eco 50°C", "Program Choose ", "1", 250, 250);
                if (int.Parse(pro) > 0 && int.Parse(pro) < 3)
                {
                    System.Windows.Forms.MessageBox.Show("Dishwasher is running! Program : " + pro);
                    return Convert.ToInt32(pro);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("You have entered an invalid value!");
                    tp.stop();
                    wp.stop();
                    return 0;
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("An error has occurred!");
                tp.stop();
                wp.stop();
                return 0;
            }
        }

        public int stop()
        {
            try
            {
                System.Windows.Forms.MessageBox.Show("Dishwasher is stopping!...");
                tp.stop();
                wp.stop();
                return 0;
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("An error has occurred!");
                tp.stop();
                wp.stop();
                return 0;
            }
        }
    }
}
