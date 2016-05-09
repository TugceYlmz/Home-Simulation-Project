using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulation_Project
{
    class Wall_Plug : ITEM
    {
        private string type;
        public string Type { get { return type; } set { type = value; } }

        public int run()
        {
            try
            {
                System.Windows.Forms.MessageBox.Show("Wall plug was opened! ");
                return 1;
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
                System.Windows.Forms.MessageBox.Show("Wall plug was opened!");
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
                System.Windows.Forms.MessageBox.Show("Wall plug was closed! ");
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
