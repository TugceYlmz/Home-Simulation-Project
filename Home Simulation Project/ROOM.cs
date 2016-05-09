using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulation_Project
{
    class ROOM
    {
        public ROOM(string rn) {
            this.roomName = rn;
        }

        private string roomName;
        public string RoomName { get { return roomName; } set { roomName = value; } }

        public void openRoom(string rmName)
        {
            switch (rmName)
            {
                case "LivingRoom":
                    {
                        Living_Room lvopen = new Living_Room();
                        lvopen.Show();
                        break;
                    }
                case "Kitchen":
                    {
                        Kitchen ktopen = new Kitchen();
                        ktopen.Show();
                        break;
                    }
                case "Bedroom":
                    {
                        Bedroom bropen = new Bedroom();
                        bropen.Show();
                        break;
                    }
                case "Bathroom":
                    {
                        Bathroom btopen = new Bathroom();
                        btopen.Show();
                        break;
                    }
                default: System.Windows.Forms.MessageBox.Show("An error has occurred!");
                    break;
            }
        }
    }
}
