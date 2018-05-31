using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
    

namespace l_Bit
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            
            InitializeComponent();
            int Parcent = 0;
            float Voltage = 7.734f, maxV = 8.4f, minV = 6.0f, minH = 16.0f, maxH = 74, result = 0.0f, Hour = 0.0f, HOUR = 0.0f;
            result = (Voltage - minV) / (maxV - minV) * 100;
            Parcent = (int)result;
            label1.Text = Parcent.ToString("G20") + "%";
            HOUR = (float)bassbit.Volume/100;
            Hour = (maxH * (result / 100) * (HOUR - 1) * (-1)) + minH * (result/100);
            Hour = (int)Hour;
            label3.Text = Hour.ToString("G20") + "  Hour";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SerialPort port;
            string[] ports = SerialPort.GetPortNames();
            port = new SerialPort();
            int num = 3;
            try
            {
                port.PortName = ports[num];
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.Parity = System.IO.Ports.Parity.None;
                port.StopBits = System.IO.Ports.StopBits.One;
                port.ReadTimeout = 50000;
                port.WriteTimeout = 50000;
                port.Open();
            }
            catch (Exception p)
            {
                Console.WriteLine("ERROR: невозможно открыть порт:" + p.ToString());
                return;
            }
            if (checkBox1.Checked)
            {
                    string value = "0";           
                    port.Write(value);                                              
                    port.Close();
            }
            else
            {
                string value = "1";
                port.Write(value);
                port.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
