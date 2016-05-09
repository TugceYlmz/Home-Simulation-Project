using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulation_Project
{
    class Light : ITEM
    {
        private int brightness;
        public int Brightness { get { return brightness; } set { brightness = value; } }

        public int run()
        {
            try
            {
                string br = Microsoft.VisualBasic.Interaction.InputBox("Please select brightness (1-9) :", "Brightness Choose", "1", 250, 250);
                if (int.Parse(br) > 0 && int.Parse(br) < 10)
                {
                    System.Windows.Forms.MessageBox.Show("Lamp brightness is : " + br + " and lamp is open");
                    return Convert.ToInt32(br);
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
                System.Windows.Forms.MessageBox.Show("Lamp is stopping...");
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
