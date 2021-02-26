using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace prjSpiCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool chk()
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "" || comboBox6.Text == "" || comboBox7.Text == "" || grade1.Text == "" || grade2.Text == "" || grade3.Text == "" || grade4.Text == "" || grade5.Text == "" || grade6.Text == "" || grade7.Text == "")
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chk())
            {
                MessageBox.Show("All fields are required !","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            int totcredit = int.Parse(comboBox1.Text.ToString()) + int.Parse(comboBox2.Text.ToString()) + int.Parse(comboBox3.Text.ToString()) + int.Parse(comboBox4.Text.ToString()) + int.Parse(comboBox5.Text.ToString()) + int.Parse(comboBox6.Text.ToString()) + int.Parse(comboBox7.Text.ToString());
            float sum = 0;
            String tmp;
            bool res = false;
            String msg="";

            ComboBox[] crdList = {comboBox1,comboBox2,comboBox3,comboBox4,comboBox5,comboBox6,comboBox7};
            ComboBox[] grdList = {grade1,grade2,grade3,grade4,grade5,grade6,grade7};

            for (int i = 0; i < 7; i++)
            {
                if (grdList[i].Text == "FF")
                    res = true;

                tmp = grdList[i].Text;
                sum += (int.Parse(crdList[i].Text) * ((tmp == "AA") ? 10 : (tmp == "AB") ? 9 : (tmp == "BB") ? 8 : (tmp == "BC") ? 7 : (tmp == "CC") ? 6 : 0));
            }
            if (res == true)
            {
                //lblmsg.ForeColor = Color.Red;
                msg = "Sorry, You have not cleared exam !\n";
            }
            else
            {
                //lblmsg.ForeColor = Color.Green;
                msg = "Congratulations !\nyou have passed the exam !\n";
            }
            msg += "Your SPI is : " + Convert.ToString(sum / totcredit);
            MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = GetDefaultBrowserPath();
            p.StartInfo.Arguments = "http://www.facebook.com/rashmin.javiya";
            p.Start();
        }
        private static string GetDefaultBrowserPath()
        {
            string key = @"htmlfile\shell\open\command";
            RegistryKey registryKey =
            Registry.ClassesRoot.OpenSubKey(key, false);
            // get default browser path
            return ((string)registryKey.GetValue(null, null)).Split('"')[1];
        }
    }
}