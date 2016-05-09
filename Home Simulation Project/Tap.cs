using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulation_Project
{
    class Tap : ITEM
    {
        private int flowRate;
        public int FlowRate { get { return flowRate; } set { flowRate = value; } }

        public int run()
        {
            try
            {
                string fr = Microsoft.VisualBasic.Interaction.InputBox("Please select flow rate (1-20) : ", "Tap Flow Rate Choose", "1", 250, 250);
                if (int.Parse(fr) > 0 && int.Parse(fr) < 20)
                {
                    System.Windows.Forms.MessageBox.Show("Tap was opened! Flow rate : " + fr);
                    return Convert.ToInt32(fr);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("You have entered an invalid value!");
                    return 0;
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("An error has occurred!");
                return 0;
            }
        }

        public void runForMach()
        {
            try
            {
                System.Windows.Forms.MessageBox.Show("Tap was opened!");
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("An error has occurred!");
            }
        }

        public int stop()
        {
            try
            {
                System.Windows.Forms.MessageBox.Show("Water is stopping...");
                return 0;
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("An error has occurred!");
                return 0;
            }
        }
    }
}
