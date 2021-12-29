using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        string[] mod1options = new string[] { "1saniye", "2saniye", "3saniye" };
        string[] mod2options = new string[] { "slow", "romantic", "disco" };

        int red, green, blue = 0;
        int tick = 0;


        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "afCtYBz0zWi4i9meDHeeXtOBB54uixf8sW40LZ3V",
            BasePath = "https://iotusingcsharpandfirebase-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        private async void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                MessageBox.Show("Connected");
            }

            mod1combo.Items.AddRange(mod1options);
            mod2combo.Items.AddRange(mod2options);

            redbar.Enabled = false;
            greenbar.Enabled = false;
            bluebar.Enabled = false;
            mod4red.Enabled = false;
            mod4green.Enabled = false;
            mod4blue.Enabled = false;

            Check();


            async void Check()
            {
                while (true)
                {
                    await Task.Delay(1000);
                    FirebaseResponse res = await client.GetAsync(@"SelectedMod4/Mod4Activity");
                    Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(res.Body.ToString());
                    UpdateRTB(data);

                }

            }

            void UpdateRTB(Dictionary<string, string> record)
            {
                textBox1.Text = record.ElementAt(0).Key + ":" + record.ElementAt(0).Value;
            }

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "Activity:1")
            {
                mod4red.Enabled = true;
                mod4green.Enabled = true;
                mod4blue.Enabled = true;
                mod1combo.Enabled = false;
                mod2combo.Enabled = false;
                mod3.Enabled = false;
                redbar.Value = 11;
                greenbar.Value = 93;
                bluebar.Value = 175;
            }

            else
            {
                mod4red.Enabled = false;
                mod4green.Enabled = false;
                mod4blue.Enabled = false;
                mod1combo.Enabled = true;
                mod2combo.Enabled = true;
                mod3.Enabled = true;
            }

        }

        private void mod1combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            mod2combo.Enabled = false;
            mod3.Enabled = false;
            redbar.Enabled = false;
            greenbar.Enabled = false;
            bluebar.Enabled = false;
            mod4red.Enabled = false;
            mod4green.Enabled = false;
            mod4blue.Enabled = false;
        }

        private void mod2combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            mod1combo.Enabled = false;
            mod3.Enabled = false;
            redbar.Enabled = false;
            greenbar.Enabled = false;
            bluebar.Enabled = false;
            mod4red.Enabled = false;
            mod4green.Enabled = false;
            mod4blue.Enabled = false;
        }

        private void mod3_Click(object sender, EventArgs e)
        {
            redbar.Enabled = true;
            greenbar.Enabled = true;
            bluebar.Enabled = true;
            mod1combo.Enabled = false;
            mod2combo.Enabled = false;
            mod4red.Enabled = false;
            mod4green.Enabled = false;
            mod4blue.Enabled = false;

        }

        private void btn_Click(object sender, EventArgs e)
        {
            int indx = mod1combo.SelectedIndex + 1;
            int indx1 = mod2combo.SelectedIndex + 1;

            if (mod1combo.SelectedIndex != -1)
            {
                indx = mod1combo.SelectedIndex + 2;
            }

            if (mod2combo.SelectedIndex != -1)
            {
                indx1 = mod2combo.SelectedIndex + 5;
            }

            string mods = "Mod1 & Mod2";
            string mod3s = "Mod3";
            string mod4s = "Mod4";

            SelectedMods std = new SelectedMods()
            {
                Mod1 = indx,
                Mod2 = indx1,

            };

            var setter = client.Set("SelectedMod1&2/" + mods, std);

            SelectedMod3 std1 = new SelectedMod3()
            {
                Mod3Red = redbar.Value,
                Mod3Green = greenbar.Value,
                Mod3Blue = bluebar.Value
            };

            var setter1 = client.Set("SelectedMod3/" + mod3s, std1);

            SelectedMod42 std3 = new SelectedMod42()
            {
                Mod4tick = tick
            };

            var setter2 = client.Set("SelectedMod4/" + mod4s, std3);


            if (mod1combo.SelectedIndex != -1)
            {
                mod1combo.SelectedIndex = -1;

            }

            if (mod2combo.SelectedIndex != -1)
            {
                mod2combo.SelectedIndex = -1;

            }


        }
        private void redbar_Scroll(object sender, EventArgs e)
        {
            Controls.Add(redbar);
            redbar.SmallChange = 1;
            red = redbar.Value;
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(red, green, blue);
        }

        private void greenbar_Scroll(object sender, EventArgs e)
        {
            Controls.Add(greenbar);
            greenbar.SmallChange = 1;
            green = greenbar.Value;
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(red, green, blue);
        }
        private void bluebar_Scroll(object sender, EventArgs e)
        {
            Controls.Add(bluebar);
            bluebar.SmallChange = 1;
            blue = bluebar.Value;
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(red, green, blue);
        }
        private void mod4red_Click(object sender, EventArgs e)
        {

            tick = 8;
            mod1combo.Enabled = false;
            mod2combo.Enabled = false;
            mod3.Enabled = false;

        }

        private void mod4green_Click(object sender, EventArgs e)
        {
            tick = 9;
            mod1combo.Enabled = false;
            mod2combo.Enabled = false;
            mod3.Enabled = false;
        }


        private void mod4blue_Click(object sender, EventArgs e)
        {
            tick = 10;
            mod1combo.Enabled = false;
            mod2combo.Enabled = false;
            mod3.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rstbtn_Click(object sender, EventArgs e)
        {
            mod2combo.Enabled = true;
            mod1combo.Enabled = true;
            mod3.Enabled = true;
            mod1combo.SelectedIndex = -1;
            mod2combo.SelectedIndex = -1;
            red = 0;
            green = 0;
            blue = 0;
            redbar.Value = 11;
            greenbar.Value = 93;
            bluebar.Value = 175;
            redbar.Enabled = false;
            greenbar.Enabled = false;
            bluebar.Enabled = false;
            tick = 0;



        }

    }
}


