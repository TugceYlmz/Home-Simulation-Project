using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;


namespace Home_Simulation_Project
{
    public partial class Bathroom : Form
    {
        int _state, _curRunnig;
        Light lamp = new Light(); //create new light
        Tap tp = new Tap(); //create tap
        Wall_Plug wp = new Wall_Plug(); //create new wall plug 
        Washing_Machine wm = new Washing_Machine(); //create new washing machine 
        XmlDocument xmlDoc = new XmlDocument(); //create new xml document

        public Bathroom()
        {
            InitializeComponent();
        }

        private void Bathroom_Load(object sender, EventArgs e)
        {
            XmlItemLoad(); //XmlItemLoad function calls and describes items

            ReadStateFromTxt(); //ReadStateFromTxt function calls and items controls run or stop

            CommonColorControl(); //CommonColorControl function calls and changes color of item on program load

            ObjectDetails(); //ObjectDetails function calls and writes to screen details
        }

        private void lampRun(object sender, EventArgs e)//Light run
        {
            if (lamp.Brightness > 0)
            {
                MessageBox.Show("Already running!");
            }
            else if (lamp.Brightness == 0)
            {
                lamp.Brightness = lamp.run();

                #region save state
                File.WriteAllText("saves\\bt01.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\bt01.txt");
                    writeFile.WriteLine(lamp.Brightness);
                    writeFile.Flush();
                    writeFile.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion

                if (lamp.Brightness > 0)
                {
                    label25.ForeColor = Color.Green;
                    label26.ForeColor = Color.Green;
                    label27.ForeColor = Color.Green;
                    label28.ForeColor = Color.Green;
                    label18.ForeColor = Color.Green;
                    label28.Text = "Brightness  : " + Convert.ToString(lamp.Brightness);
                }
            }
        }
        private void lampStop(object sender, EventArgs e)//Light stop
        {
            if (lamp.Brightness == 0)
            {
                MessageBox.Show("Already stopped!");
            }
            else if (lamp.Brightness > 0)
            {
                lamp.Brightness = lamp.stop();

                #region save state
                File.WriteAllText("saves\\bt01.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\bt01.txt");
                    writeFile.WriteLine(lamp.Brightness);
                    writeFile.Flush();
                    writeFile.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion

                if (lamp.Brightness == 0)
                {
                    label25.ForeColor = Color.Red;
                    label26.ForeColor = Color.Red;
                    label27.ForeColor = Color.Red;
                    label28.ForeColor = Color.Red;
                    label18.ForeColor = Color.Red;
                    label28.Text = "Brightness  : " + Convert.ToString(lamp.Brightness);
                }
            }
        }

        private void wpRun(object sender, EventArgs e)//Wall_Plug run
        {
            if (_state > 0)
            {
                MessageBox.Show("Already running!");
            }
            else if (_state == 0)
            {
                _state = wp.run();

                #region save state
                File.WriteAllText("saves\\bt02.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\bt02.txt");
                    writeFile.WriteLine(_state);
                    writeFile.Flush();
                    writeFile.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion

                if (_state > 0)
                {
                    label1.ForeColor = Color.Green;
                    label2.ForeColor = Color.Green;
                    label3.ForeColor = Color.Green;
                    label4.ForeColor = Color.Green;
                    label5.ForeColor = Color.Green;
                }
            }
        }
        private void wpStop(object sender, EventArgs e)//Wall_Plug stop
        {
            if (_state == 0)
            {
                MessageBox.Show("Already stopped!");
            }
            else if (_state > 0)
            {
                _state = wp.stop();


                #region save state
                File.WriteAllText("saves\\bt02.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\bt02.txt");
                    writeFile.WriteLine(_state);
                    writeFile.Flush();
                    writeFile.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion

                if (_state == 0)
                {
                    label1.ForeColor = Color.Red;
                    label2.ForeColor = Color.Red;
                    label3.ForeColor = Color.Red;
                    label4.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                }
            }
        }

        private void tpRun(object sender, EventArgs e)//Tap run
        {
            if (tp.FlowRate > 0)
            {
                MessageBox.Show("Already running!");
            }
            else if (tp.FlowRate == 0)
            {
                tp.FlowRate = tp.run();

                #region save state
                File.WriteAllText("saves\\bt03.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\bt03.txt");
                    writeFile.WriteLine(tp.FlowRate);
                    writeFile.Flush();
                    writeFile.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion

                if (tp.FlowRate > 0)
                {
                    label6.ForeColor = Color.Green;
                    label7.ForeColor = Color.Green;
                    label8.ForeColor = Color.Green;
                    label9.ForeColor = Color.Green;
                    label10.ForeColor = Color.Green;
                    label10.Text = "Flow Rate : " + Convert.ToString((tp.FlowRate));
                }
            }
        }
        private void tpStop(object sender, EventArgs e)//Tap stop
        {
            if (tp.FlowRate == 0)
            {
                MessageBox.Show("Already stopped!");
            }
            else if (tp.FlowRate > 0)
            {
                tp.FlowRate = tp.stop();

                #region save state
                File.WriteAllText("saves\\bt03.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\bt03.txt");
                    writeFile.WriteLine(tp.FlowRate);
                    writeFile.Flush();
                    writeFile.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion

                if (tp.FlowRate == 0)
                {
                    label6.ForeColor = Color.Red;
                    label7.ForeColor = Color.Red;
                    label8.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    label10.ForeColor = Color.Red;
                    label10.Text = "Flow Rate : " + Convert.ToString((tp.FlowRate));
                }
            }
        }

        private void wmRun(object sender, EventArgs e)//Washing_Machine run
        {
            if (_curRunnig > 0)
            {
                MessageBox.Show("Already running!");
            }
            else if (_curRunnig == 0)
            {
                _curRunnig = wm.run();

                #region save state
                File.WriteAllText("saves\\bt04.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\bt04.txt");
                    writeFile.WriteLine(_curRunnig);
                    writeFile.Flush();
                    writeFile.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion

                if (_curRunnig > 0)
                {
                    label11.ForeColor = Color.Green;
                    label12.ForeColor = Color.Green;
                    label13.ForeColor = Color.Green;
                    label14.ForeColor = Color.Green;
                    label15.ForeColor = Color.Green;
                    label16.ForeColor = Color.Green;
                    label16.Text = "No Of Program : " + Convert.ToString((wm.NoOfProgram = 5)) + "\nCurrently running : " + Convert.ToString((_curRunnig));
                }
            }
        }
        private void wmStop(object sender, EventArgs e)//Washing_Machine stop
        {
            if (_curRunnig == 0)
            {
                MessageBox.Show("Already stopped!");
            }
            else if (_curRunnig > 0)
            {
                _curRunnig = wm.stop();

                #region save state
                File.WriteAllText("saves\\bt04.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\bt04.txt");
                    writeFile.WriteLine(_curRunnig);
                    writeFile.Flush();
                    writeFile.Close();

                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion

                if (_curRunnig == 0)
                {
                    label11.ForeColor = Color.Red;
                    label12.ForeColor = Color.Red;
                    label13.ForeColor = Color.Red;
                    label14.ForeColor = Color.Red;
                    label15.ForeColor = Color.Red;
                    label16.ForeColor = Color.Red;
                    label16.Text = "No Of Program : " + Convert.ToString((wm.NoOfProgram = 5)) + "\nCurrently running : " + Convert.ToString((_curRunnig));
                }
            }
        }

        public void XmlItemLoad()
        {
            xmlDoc.Load("XML\\bathroom.xml");
            foreach (XmlNode node in xmlDoc.GetElementsByTagName("lamp"))
            {
                lamp.Brand = node["brand"].InnerText;
                lamp.Model = node["model"].InnerText;
                lamp.MadeIn = node["madein"].InnerText;
                lamp.ID = int.Parse(node["id"].InnerText);
            }
            foreach (XmlNode node in xmlDoc.GetElementsByTagName("WP"))
            {
                wp.Brand = node["brand"].InnerText;
                wp.Model = node["model"].InnerText;
                wp.MadeIn = node["madein"].InnerText;
                wp.Type = node["type"].InnerText;
                wp.ID = int.Parse(node["id"].InnerText);
            }
            foreach (XmlNode node in xmlDoc.GetElementsByTagName("TP"))
            {
                tp.Brand = node["brand"].InnerText;
                tp.Model = node["model"].InnerText;
                tp.MadeIn = node["madein"].InnerText;
                tp.ID = int.Parse(node["id"].InnerText);
            }
            foreach (XmlNode node in xmlDoc.GetElementsByTagName("WM"))
            {
                wm.Brand = node["brand"].InnerText;
                wm.Model = node["model"].InnerText;
                wm.MadeIn = node["madein"].InnerText;
                wm.ID = int.Parse(node["id"].InnerText);
                wm.Capacity = int.Parse(node["capacity"].InnerText);
                wm.NoOfProgram = int.Parse(node["noofprogram"].InnerText);
            }
        }
        public void ReadStateFromTxt()
        {
            try
            {
                string line = null;
                TextReader readFile = new StreamReader("saves\\bt01.txt");
                line = readFile.ReadToEnd();
                lamp.Brightness = int.Parse(line);
                readFile.Close();
                readFile = null;

                readFile = new StreamReader("saves\\bt02.txt");
                line = readFile.ReadToEnd();
                _state = int.Parse(line);
                readFile.Close();
                readFile = null;

                readFile = new StreamReader("saves\\bt03.txt");
                line = readFile.ReadToEnd();
                tp.FlowRate = int.Parse(line);
                readFile.Close();
                readFile = null;

                readFile = new StreamReader("saves\\bt04.txt");
                line = readFile.ReadToEnd();
                _curRunnig = int.Parse(line);
                readFile.Close();
                readFile = null;

            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void CommonColorControl()
        {
            if (lamp.Brightness > 0)
            {
                label25.ForeColor = Color.Green;
                label26.ForeColor = Color.Green;
                label27.ForeColor = Color.Green;
                label28.ForeColor = Color.Green;
                label18.ForeColor = Color.Green;
            }
            if (_state > 0)
            {
                label1.ForeColor = Color.Green;
                label2.ForeColor = Color.Green;
                label3.ForeColor = Color.Green;
                label4.ForeColor = Color.Green;
                label5.ForeColor = Color.Green;
            }
            if (tp.FlowRate > 0)
            {
                label6.ForeColor = Color.Green;
                label7.ForeColor = Color.Green;
                label8.ForeColor = Color.Green;
                label9.ForeColor = Color.Green;
                label10.ForeColor = Color.Green;
            }
            if (_curRunnig > 0)
            {
                label11.ForeColor = Color.Green;
                label12.ForeColor = Color.Green;
                label13.ForeColor = Color.Green;
                label14.ForeColor = Color.Green;
                label15.ForeColor = Color.Green;
                label16.ForeColor = Color.Green;
            }
        }
        public void ObjectDetails()
        {
            #region lamp - object details
            label25.Text = "Brand  : " + (lamp.Brand);
            label26.Text = "Model  : " + (lamp.Model);
            label27.Text = "Made In : " + (lamp.MadeIn);
            label28.Text = "Brightness  : " + Convert.ToString(lamp.Brightness);
            label18.Text = "ID     : " + Convert.ToString(lamp.ID);
            #endregion

            #region wall_plug - object details
            label1.Text = "Brand : " + (wp.Brand);
            label2.Text = "Model : " + (wp.Model);
            label3.Text = "Made In : " + (wp.MadeIn);
            label4.Text = "ID : " + Convert.ToString(wp.ID);
            label5.Text = "Type : " + (wp.Type);
            #endregion

            #region tap - object details
            label6.Text = "Brand : " + (tp.Brand);
            label7.Text = "Model : " + (tp.Model);
            label8.Text = "Made In : " + (tp.MadeIn);
            label9.Text = "ID : " + Convert.ToString(tp.ID);
            label10.Text = "Flow Rate : " + Convert.ToString(tp.FlowRate);
            #endregion

            #region washing_machine - object details

            label11.Text = "Brand : " + (wm.Brand);
            label12.Text = "Model : " + (wm.Model);
            label13.Text = "Made In : " + (wm.MadeIn);
            label14.Text = "ID : " + Convert.ToString(wm.ID);
            label15.Text = "Capacity : " + Convert.ToString(wm.Capacity) + " Kg";
            label16.Text = "No Of Program : " + Convert.ToString(wm.NoOfProgram) + "\nCurrently running : " + Convert.ToString(_curRunnig);
            #endregion
        }
    }
}

