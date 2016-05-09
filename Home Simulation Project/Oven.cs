using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulation_Project
{
    class Oven : ITEM
    {
        private string type;
        public string Type { get { return type; } set { type = value; } }
        private int temperature;
        public int Temperature { get { return temperature; } set { temperature = value; } }

        Wall_Plug wp = new Wall_Plug();

        public int run()
        {
            try
            {
                wp.runForMach();
                string temp = Microsoft.VisualBasic.Interaction.InputBox("Please select temperature (1-5) : ", "Temperature Choose", "1", 250, 250);
                if (int.Parse(temp) > 0 && int.Parse(temp) < 6)
                {
                    System.Windows.Forms.MessageBox.Show("Oven was opened! temperature : " + temp);
                    return int.Parse(temp);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("You have entered an invalid value!");
                    wp.stop();
                    return 0;
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("An error has occurred!");
                wp.stop();
                return 0;
            }
        }

        public int stop()
        {
            try
            {
                System.Windows.Forms.MessageBox.Show("Oven is stopping...");
                wp.stop();
                return 0;
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("An error has occurred!");
                wp.stop();
                return 0;
            }
        }
    }
}
