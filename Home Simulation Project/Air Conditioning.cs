using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulation_Project
{
    class Air_Conditioning : ITEM
    {
        private int coolingCapacity;
        public int CoolingCapacity { get { return coolingCapacity; } set { coolingCapacity = value; } }
        private int heatingCapacity;
        public int HeatingCapacity { get { return heatingCapacity; } set { heatingCapacity = value; } }
        private int degree;
        public int Degree { get { return degree; } set { degree = value; } }

        public int run()
        {
            try
            {
                string deg = Microsoft.VisualBasic.Interaction.InputBox("Please select degree (1-35) : ", "Degree Choose", "1", 250, 250);
                if (int.Parse(deg) > 0 && int.Parse(deg) < 36)
                {
                    System.Windows.Forms.MessageBox.Show("Air conditioning was opened! Degree : " + deg);
                    return Convert.ToInt32(deg);
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

        public int stop()
        {
            try
            {
                System.Windows.Forms.MessageBox.Show("Air conditioning is stopping...");
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
