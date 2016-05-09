using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulation_Project
{
    class Television : ITEM
    {
        Wall_Plug wp = new Wall_Plug();

        private string resolution;
        public string Resolution { get { return resolution; } set { resolution = value; } }
        private string panelType;
        public string PanelType { get { return panelType; } set { panelType = value; } }
        private int channel;
        public int Channel { get { return channel; } set { channel = value; } }

        public int run()
        {
            try
            {
                wp.runForMach();
                string ch = Microsoft.VisualBasic.Interaction.InputBox("Please select channel (1-99) :", "Channel Choose", "1", 250, 250);
                if (int.Parse(ch) > 0 && int.Parse(ch) < 100)
                {
                    System.Windows.Forms.MessageBox.Show("Television was opened! Channel : " + ch);
                    return Convert.ToInt32(ch);
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
                System.Windows.Forms.MessageBox.Show("Television is stopping...");
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
