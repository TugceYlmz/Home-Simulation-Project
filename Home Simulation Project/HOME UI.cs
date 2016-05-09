using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home_Simulation_Project
{
    public partial class Form1 : Form
    {
        ROOM room1 = new ROOM("Living Room");
        ROOM room2 = new ROOM("Kitchen");
        ROOM room3 = new ROOM("Bedroom");
        ROOM room4 = new ROOM("Bathroom");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = room1.RoomName;
            button2.Text = room2.RoomName;
            button3.Text = room3.RoomName;
            button4.Text = room4.RoomName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Living_Room"] == null)
            {
                room1.openRoom("LivingRoom");
            }
            else
                MessageBox.Show("The room is already open!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Kitchen"] == null)
            {
                room2.openRoom("Kitchen");
            }
            else
                MessageBox.Show("The room is already open!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Bedroom"] == null)
            {
                room3.openRoom("Bedroom");
            }
            else
                MessageBox.Show("The room is already open!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Bathroom"] == null)
            {
                room4.openRoom("Bathroom");
            }
            else
                MessageBox.Show("The room is already open!");
        }
    }
}
