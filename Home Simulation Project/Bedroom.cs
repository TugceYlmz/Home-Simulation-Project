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
    public partial class Bedroom : Form
    {
        int _state;
        Light lamp = new Light(); //create new light
        Television tv = new Television(); //create new television
        Wall_Plug wp = new Wall_Plug(); //create new wall plug
        Air_Conditioning ac = new Air_Conditioning(); //create new air conditioning
        XmlDocument xmlDoc = new XmlDocument(); //create new xml document

        public Bedroom()
        {
            InitializeComponent();
        }

        private void Bedroom_Load(object sender, EventArgs e)
        {
            XmlItemLoad(); //XmlItemLoad function calls and describes items

            ReadStateFromTxt(); //ReadStateFromTxt function calls and items controls run or stop

            CommonColorControl(); //CommonColorControl function calls and changes color of item on program load

            ObjectDetails(); //ObjectDetails function calls and writes to screen details
        }

        private void lampRun(object sender, EventArgs e)//lamp run
        {
            if (lamp.Brightness > 0)
            {
                MessageBox.Show("Already running!");
            }
            else if (lamp.Brightness == 0)
            {
                lamp.Brightness = lamp.run();

                #region save state
                File.WriteAllText("saves\\bd01.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\bd01.txt");
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
                    label1.ForeColor = Color.Green;
                    label2.ForeColor = Color.Green;
                    label3.ForeColor = Color.Green;
                    label4.ForeColor = Color.Green;
                    label5.ForeColor = Color.Green;
                    label4.Text = "Brightness  : " + Convert.ToString(lamp.Brightness);
                }
            }
        }
        private void lampStop(object sender, EventArgs e)//lamp stop
        {
            if (lamp.Brightness == 0)
            {
                MessageBox.Show("Already stopped!");
            }
            else if (lamp.Brightness > 0)
            {
                lamp.Brightness = lamp.stop();

                #region save state
                File.WriteAllText("saves\\bd01.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\bd01.txt");
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
                    label1.ForeColor = Color.Red;
                    label2.ForeColor = Color.Red;
                    label3.ForeColor = Color.Red;
                    label4.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label4.Text = "Power  : " + Convert.ToString(lamp.Brightness);
                }
            }
        }

        private void tvRun(object sender, EventArgs e)//television run
        {
            if (tv.Channel > 0)
            {
                MessageBox.Show("Already running!");
            }
            else if (tv.Channel == 0)
            {
                tv.Channel = tv.run();

                #region save state
                File.WriteAllText("saves\\bd02.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\bd02.txt");
                    writeFile.WriteLine(tv.Channel);
                    writeFile.Flush();
                    writeFile.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion

                if (tv.Channel > 0)
                {
                    label6.ForeColor = Color.Green;
                    label7.ForeColor = Color.Green;
                    label8.ForeColor = Color.Green;
                    label9.ForeColor = Color.Green;
                    label10.ForeColor = Color.Green;
                    label11.ForeColor = Color.Green;
                    label12.ForeColor = Color.Green;
                    label12.Text = "Channel  : " + Convert.ToString(tv.Channel);
                }
            }
        }
        private void tvStop(object sender, EventArgs e)//television stop
        {
            if (tv.Channel == 0)
            {
                MessageBox.Show("Already stopped!");
            }
            else if (tv.Channel > 0)
            {
                tv.Channel = tv.stop();

                #region save state
                File.WriteAllText("saves\\bd02.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\bd02.txt");
                    writeFile.WriteLine(tv.Channel);
                    writeFile.Flush();
                    writeFile.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion

                if (tv.Channel == 0)
                {
                    label6.ForeColor = Color.Red;
                    label7.ForeColor = Color.Red;
                    label8.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    label10.ForeColor = Color.Red;
                    label11.ForeColor = Color.Red;
                    label12.ForeColor = Color.Red;
                    label12.Text = "Channel  : " + Convert.ToString(tv.Channel);
                }
            }
        }

        private void wpRun(object sender, EventArgs e)//wall plug run
        {
            if (_state > 0)
            {
                MessageBox.Show("Already running!");
            }
            else if (_state == 0)
            {
                _state = wp.run();


                #region save state
                File.WriteAllText("saves\\bd03.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\bd03.txt");
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
                    label14.ForeColor = Color.Green;
                    label15.ForeColor = Color.Green;
                    label16.ForeColor = Color.Green;
                    label17.ForeColor = Color.Green;
                    label18.ForeColor = Color.Green;
                }
            }
        }
        private void wpStop(object sender, EventArgs e)//wall plug stop
        {
            if (_state == 0)
            {
                MessageBox.Show("Already stopped!");
            }
            else if (_state > 0)
            {
                _state = wp.stop();

                #region save state
                File.WriteAllText("saves\\bd03.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\bd03.txt");
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
                    label14.ForeColor = Color.Red;
                    label15.ForeColor = Color.Red;
                    label16.ForeColor = Color.Red;
                    label17.ForeColor = Color.Red;
                    label18.ForeColor = Color.Red;
                }
            }
        }

        private void acRun(object sender, EventArgs e)//air conditioning run
        {
            if (ac.Degree > 0)
            {
                MessageBox.Show("Already running!");
            }
            else if (ac.Degree == 0)
            {
                ac.Degree = ac.run();

                #region save state
                File.WriteAllText("saves\\bd04.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\bd04.txt");
                    writeFile.WriteLine(ac.Degree);
                    writeFile.Flush();
                    writeFile.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion

                if (ac.Degree > 0)
                {
                    label19.ForeColor = Color.Green;
                    label20.ForeColor = Color.Green;
                    label21.ForeColor = Color.Green;
                    label22.ForeColor = Color.Green;
                    label23.ForeColor = Color.Green;
                    label24.ForeColor = Color.Green;
                    label25.ForeColor = Color.Green;
                    label25.Text = "Channel  : " + Convert.ToString(ac.Degree);
                }
            }
        }
        private void acStop(object sender, EventArgs e)//air conditioning stop
        {
            if (ac.Degree == 0)
            {
                MessageBox.Show("Already stopped!");
            }
            else if (ac.Degree > 0)
            {
                ac.Degree = ac.stop();

                #region save state
                File.WriteAllText("saves\\bd04.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\bd04.txt");
                    writeFile.WriteLine(ac.Degree);
                    writeFile.Flush();
                    writeFile.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion

                if (ac.Degree == 0)
                {
                    label19.ForeColor = Color.Red;
                    label20.ForeColor = Color.Red;
                    label21.ForeColor = Color.Red;
                    label22.ForeColor = Color.Red;
                    label23.ForeColor = Color.Red;
                    label24.ForeColor = Color.Red;
                    label25.ForeColor = Color.Red;
                    label25.Text = "Channel  : " + Convert.ToString(ac.Degree);
                }
            }
        }

        public void XmlItemLoad()
        {
            xmlDoc.Load("XML\\bedroom.xml");
            foreach (XmlNode node in xmlDoc.GetElementsByTagName("lamp"))
            {
                lamp.Brand = node["brand"].InnerText;
                lamp.Model = node["model"].InnerText;
                lamp.MadeIn = node["madein"].InnerText;
                lamp.ID = int.Parse(node["id"].InnerText);
            }
            foreach (XmlNode node in xmlDoc.GetElementsByTagName("TV"))
            {
                tv.Brand = node["brand"].InnerText;
                tv.Model = node["model"].InnerText;
                tv.MadeIn = node["madein"].InnerText;
                tv.ID = int.Parse(node["id"].InnerText);
                tv.PanelType = node["paneltype"].InnerText;
                tv.Resolution = node["resolution"].InnerText;
            }
            foreach (XmlNode node in xmlDoc.GetElementsByTagName("AC"))
            {
                ac.Brand = node["brand"].InnerText;
                ac.Model = node["model"].InnerText;
                ac.MadeIn = node["madein"].InnerText;
                ac.ID = int.Parse(node["id"].InnerText);
                ac.CoolingCapacity = int.Parse(node["coolingcapacity"].InnerText);
                ac.HeatingCapacity = int.Parse(node["heatingcapacity"].InnerText);
            }
            foreach (XmlNode node in xmlDoc.GetElementsByTagName("WP"))
            {
                wp.Brand = node["brand"].InnerText;
                wp.Model = node["model"].InnerText;
                wp.MadeIn = node["madein"].InnerText;
                wp.Type = node["type"].InnerText;
                wp.ID = int.Parse(node["id"].InnerText);
            }
        }
        public void ReadStateFromTxt()
        {
            try
            {
                string line = null;
                TextReader readFile = new StreamReader("saves\\bd01.txt");
                line = readFile.ReadToEnd();
                lamp.Brightness = int.Parse(line);
                readFile.Close();
                readFile = null;

                readFile = new StreamReader("saves\\bd02.txt");
                line = readFile.ReadToEnd();
                tv.Channel = int.Parse(line);
                readFile.Close();
                readFile = null;

                readFile = new StreamReader("saves\\bd03.txt");
                line = readFile.ReadToEnd();
                _state = int.Parse(line);
                readFile.Close();
                readFile = null;

                readFile = new StreamReader("saves\\bd04.txt");
                line = readFile.ReadToEnd();
                ac.Degree = int.Parse(line);
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
                label1.ForeColor = Color.Green;
                label2.ForeColor = Color.Green;
                label3.ForeColor = Color.Green;
                label4.ForeColor = Color.Green;
                label5.ForeColor = Color.Green;
            }
            if (tv.Channel > 0)
            {
                label6.ForeColor = Color.Green;
                label7.ForeColor = Color.Green;
                label8.ForeColor = Color.Green;
                label9.ForeColor = Color.Green;
                label10.ForeColor = Color.Green;
                label11.ForeColor = Color.Green;
                label12.ForeColor = Color.Green;
            }
            if (_state > 0)
            {
                label14.ForeColor = Color.Green;
                label15.ForeColor = Color.Green;
                label16.ForeColor = Color.Green;
                label17.ForeColor = Color.Green;
                label18.ForeColor = Color.Green;
            }
            if (ac.Degree > 0)
            {
                label19.ForeColor = Color.Green;
                label20.ForeColor = Color.Green;
                label21.ForeColor = Color.Green;
                label22.ForeColor = Color.Green;
                label23.ForeColor = Color.Green;
                label24.ForeColor = Color.Green;
                label25.ForeColor = Color.Green;
            }
        }
        public void ObjectDetails()
        {
            #region lamp - object details
            label1.Text = "Brand  : " + (lamp.Brand);
            label2.Text = "Model  : " + (lamp.Model);
            label3.Text = "Made In : " + (lamp.MadeIn);
            label4.Text = "Brightness  : " + Convert.ToString(lamp.Brightness);
            label5.Text = "ID     : " + Convert.ToString(lamp.ID);
            #endregion

            #region tv - object details
            label6.Text = "Brand : " + (tv.Brand);
            label7.Text = "Model : " + (tv.Model);
            label8.Text = "Panel Type : " + (tv.PanelType);
            label9.Text = "Resolution : " + (tv.Resolution);
            label10.Text = "Made In : " + (tv.MadeIn);
            label11.Text = "ID     : " + Convert.ToString(tv.ID);
            label12.Text = "Channel : " + Convert.ToString(tv.Channel);
            #endregion

            #region wall_plug - object details
            label14.Text = "Brand : " + (wp.Brand);
            label15.Text = "Model : " + (wp.Model);
            label16.Text = "Made In : " + (wp.MadeIn);
            label17.Text = "ID : " + Convert.ToString(wp.ID);
            label18.Text = "Type : " + (wp.Type);
            #endregion

            #region air_conditioning - object details
            label19.Text = "Brand : " + (ac.Brand);
            label20.Text = "Model : " + (ac.Model);
            label21.Text = "Made In : " + (ac.MadeIn);
            label22.Text = "ID     : " + Convert.ToString(ac.ID);
            label23.Text = "Cooling Capacity : " + Convert.ToString(ac.CoolingCapacity);
            label24.Text = "Heating Capacity : " + Convert.ToString(ac.HeatingCapacity);
            label25.Text = "Degree : " + Convert.ToString(ac.Degree);
            #endregion
        }
    }
}
