using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulation_Project
{
    class Washing_Machine : ITEM
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
                string pro = Microsoft.VisualBasic.Interaction.InputBox("Select program (1-6) : \n 1 : Cotton, linen or normal \n 2 : Permanent press, casual \n 3 : Colors \n 4 : Quick or speed wash  \n 5 : Delicates, hand-wash, wool ", "Program Choose", "1", 250, 250);
                if (int.Parse(pro) > 0 && int.Parse(pro) < 6)
                {
                    System.Windows.Forms.MessageBox.Show("Washing machine is running! Program : " + pro);
                    return int.Parse(pro);
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
                System.Windows.Forms.MessageBox.Show("Washing machine is stopping!...");
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
