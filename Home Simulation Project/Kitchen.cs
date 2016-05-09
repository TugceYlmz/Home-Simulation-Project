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
    public partial class Kitchen : Form
    {
        int _state, _curRunnig;
        Light lamp = new Light(); //create new light
        Wall_Plug wp = new Wall_Plug(); //create new wall plug
        Dishwasher dw = new Dishwasher(); //create new dishwasher
        Tap tp = new Tap(); //create new tap
        Oven ovn = new Oven(); //create new oven
        XmlDocument xmlDoc = new XmlDocument(); //create new xml document

        public Kitchen()
        {
            InitializeComponent();
        }

        private void Kitchen_Load(object sender, EventArgs e)
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
                File.WriteAllText("saves\\kit01.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\kit01.txt");
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
                File.WriteAllText("saves\\kit01.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\kit01.txt");
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
                File.WriteAllText("saves\\kit02.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\kit02.txt");
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
                    label6.ForeColor = Color.Green;
                    label7.ForeColor = Color.Green;
                    label8.ForeColor = Color.Green;
                    label9.ForeColor = Color.Green;
                    label10.ForeColor = Color.Green;
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
                File.WriteAllText("saves\\kit02.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\kit02.txt");
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
                    label6.ForeColor = Color.Red;
                    label7.ForeColor = Color.Red;
                    label8.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    label10.ForeColor = Color.Red;
                }
            }
        }

        private void dwRun(object sender, EventArgs e)//Dishwasher run
        {
            if (_curRunnig > 0)
            {
                MessageBox.Show("Already running!");
            }
            else if (_curRunnig == 0)
            {
                _curRunnig = dw.run();

                #region save state
                File.WriteAllText("saves\\kit03.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\kit03.txt");
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
                    label16.Text = "No Of Program : " + Convert.ToString((dw.NoOfProgram = 2)) + "\nCurrently running : " + Convert.ToString((_curRunnig));
                }
            }
        }
        private void dwStop(object sender, EventArgs e)//Dishwasher stop
        {
            if (_curRunnig == 0)
            {
                MessageBox.Show("Already stopped!");
            }
            else if (_curRunnig > 0)
            {
                _curRunnig = dw.stop();

                #region save state
                File.WriteAllText("saves\\kit03.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\kit03.txt");
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
                    label16.Text = "No Of Program : " + Convert.ToString((dw.NoOfProgram = 2)) + "\nCurrently running : " + Convert.ToString((_curRunnig));
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
                File.WriteAllText("saves\\kit04.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\kit04.txt");
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
                    label17.ForeColor = Color.Green;
                    label18.ForeColor = Color.Green;
                    label19.ForeColor = Color.Green;
                    label20.ForeColor = Color.Green;
                    label21.ForeColor = Color.Green;
                    label21.Text = "Flow Rate : " + Convert.ToString((tp.FlowRate));
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
                File.WriteAllText("saves\\kit04.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\kit04.txt");
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
                    label17.ForeColor = Color.Red;
                    label18.ForeColor = Color.Red;
                    label19.ForeColor = Color.Red;
                    label20.ForeColor = Color.Red;
                    label21.ForeColor = Color.Red;
                    label21.Text = "Flow Rate : " + Convert.ToString((tp.FlowRate));
                }
            }
        }

        private void ovnRun(object sender, EventArgs e)//Oven run
        {
            if (ovn.Temperature > 0)
            {
                MessageBox.Show("Already running!");
            }
            else if (ovn.Temperature == 0)
            {
                ovn.Temperature = ovn.run();

                #region save state
                File.WriteAllText("saves\\kit05.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\kit05.txt");
                    writeFile.WriteLine(ovn.Temperature);
                    writeFile.Flush();
                    writeFile.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion

                if (ovn.Temperature > 0)
                {
                    label22.ForeColor = Color.Green;
                    label23.ForeColor = Color.Green;
                    label24.ForeColor = Color.Green;
                    label25.ForeColor = Color.Green;
                    label26.ForeColor = Color.Green;
                    label27.ForeColor = Color.Green;
                    label27.Text = "Temperature : " + Convert.ToString(ovn.Temperature);
                }
            }
        }
        private void ovnStop(object sender, EventArgs e)//Oven stop
        {
            if (ovn.Temperature == 0)
            {
                MessageBox.Show("Already stopped!");
            }
            else if (ovn.Temperature > 0)
            {
                ovn.Temperature = ovn.stop();

                #region save state
                File.WriteAllText("saves\\kit05.txt", String.Empty);
                try
                {
                    TextWriter writeFile = new StreamWriter("saves\\kit05.txt");
                    writeFile.WriteLine(ovn.Temperature);
                    writeFile.Flush();
                    writeFile.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion

                if (ovn.Temperature == 0)
                {
                    label22.ForeColor = Color.Red;
                    label23.ForeColor = Color.Red;
                    label24.ForeColor = Color.Red;
                    label25.ForeColor = Color.Red;
                    label26.ForeColor = Color.Red;
                    label27.ForeColor = Color.Red;
                    label27.Text = "Temperature : " + Convert.ToString(ovn.Temperature);
                }
            }
        }

        public void XmlItemLoad()
        {
            xmlDoc.Load("XML\\kitchen.xml");
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
            foreach (XmlNode node in xmlDoc.GetElementsByTagName("DW"))
            {
                dw.Brand = node["brand"].InnerText;
                dw.Model = node["model"].InnerText;
                dw.MadeIn = node["madein"].InnerText;
                dw.ID = int.Parse(node["id"].InnerText);
                dw.Capacity = int.Parse(node["capacity"].InnerText);
                dw.NoOfProgram = int.Parse(node["noofprogram"].InnerText);
            }
            foreach (XmlNode node in xmlDoc.GetElementsByTagName("TP"))
            {
                tp.Brand = node["brand"].InnerText;
                tp.Model = node["model"].InnerText;
                tp.MadeIn = node["madein"].InnerText;
                tp.ID = int.Parse(node["id"].InnerText);
            }
            foreach (XmlNode node in xmlDoc.GetElementsByTagName("Oven"))
            {
                ovn.Brand = node["brand"].InnerText;
                ovn.Model = node["model"].InnerText;
                ovn.MadeIn = node["madein"].InnerText;
                ovn.ID = int.Parse(node["id"].InnerText);
                ovn.Type = node["type"].InnerText;
            }
        }
        public void ReadStateFromTxt()
        {
            try
            {
                string line = null;
                TextReader readFile = new StreamReader("saves\\kit01.txt");
                line = readFile.ReadToEnd();
                lamp.Brightness = int.Parse(line);
                readFile.Close();
                readFile = null;

                readFile = new StreamReader("saves\\kit02.txt");
                line = readFile.ReadToEnd();
                _state = int.Parse(line);
                readFile.Close();
                readFile = null;

                readFile = new StreamReader("saves\\kit03.txt");
                line = readFile.ReadToEnd();
                _curRunnig = int.Parse(line);
                readFile.Close();
                readFile = null;

                readFile = new StreamReader("saves\\kit04.txt");
                line = readFile.ReadToEnd();
                tp.FlowRate = int.Parse(line);
                readFile.Close();
                readFile = null;

                readFile = new StreamReader("saves\\kit05.txt");
                line = readFile.ReadToEnd();
                ovn.Temperature = int.Parse(line);
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
            if (_state > 0)
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
            if (tp.FlowRate > 0)
            {
                label17.ForeColor = Color.Green;
                label18.ForeColor = Color.Green;
                label19.ForeColor = Color.Green;
                label20.ForeColor = Color.Green;
                label21.ForeColor = Color.Green;
            }
            if (ovn.Temperature > 0)
            {
                label22.ForeColor = Color.Green;
                label23.ForeColor = Color.Green;
                label24.ForeColor = Color.Green;
                label25.ForeColor = Color.Green;
                label26.ForeColor = Color.Green;
                label27.ForeColor = Color.Green;
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

            #region wall_plug - object details
            label6.Text = "Brand : " + (wp.Brand = "Schneider");
            label7.Text = "Model : " + (wp.Model = "Asfora");
            label8.Text = "Made In : " + (wp.MadeIn = "Germany");
            label9.Text = "ID : " + Convert.ToString((wp.ID = 2002));
            label10.Text = "Type : " + (wp.Type = "Grounded");

            #endregion

            #region dishwasher - object details
            label11.Text = "Brand : " + (dw.Brand);
            label12.Text = "Model : " + (dw.Model);
            label13.Text = "Made In : " + (dw.MadeIn);
            label14.Text = "ID : " + Convert.ToString(dw.ID);
            label15.Text = "Capacity : " + Convert.ToString(dw.Capacity) + " Dinner Set";
            label16.Text = "No Of Program : " + Convert.ToString(dw.NoOfProgram) + "\nCurrently running : " + Convert.ToString((_curRunnig));
            #endregion

            #region tap - object details
            label17.Text = "Brand : " + (tp.Brand);
            label18.Text = "Model : " + (tp.Model);
            label19.Text = "Made In : " + (tp.MadeIn);
            label20.Text = "ID : " + Convert.ToString(tp.ID);
            label21.Text = "Flow Rate : " + Convert.ToString(tp.FlowRate);
            #endregion

            #region oven - object details
            label22.Text = "Brand : " + (ovn.Brand);
            label23.Text = "Model : " + (ovn.Model);
            label24.Text = "Made In : " + (ovn.MadeIn);
            label25.Text = "ID : " + Convert.ToString(ovn.ID);
            label26.Text = "Type : " + (ovn.Type);
            label27.Text = "Temperature : " + Convert.ToString(ovn.Temperature);
            #endregion
        }

    }
}
