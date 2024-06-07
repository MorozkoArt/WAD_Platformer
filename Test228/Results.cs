using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test228
{
    public partial class Results : Form
    {
        public bool restart;
        public bool new_urow;
        public int restart_or_new_urow;
        Image image;
        Image image2;

        public Results(int restart_or_new_urow)
        {
            InitializeComponent();
            this.restart_or_new_urow = restart_or_new_urow;
            restart = false;
            image = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\ФОн\\6yoy.gif");
            image2 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\ФОн\\Win.gif");
            button2.Text = "Exit";
            if (restart_or_new_urow == 1)
            {
                pictureBox1.Image = image;
                Yes.Text = "Restart";
            }
            else if (restart_or_new_urow == 2)
            {
                pictureBox1.Image = image2;
                Yes.Text = "Next lwl";
            }
            else if (restart_or_new_urow == 3)
            {
                pictureBox1.Image = image2;
                Yes.Visible = false;
            }
        }

        private void Results_Load(object sender, EventArgs e)
        {

        }

        private void Yes_Click(object sender, EventArgs e)
        {
            if(restart_or_new_urow == 1)
            {
                restart = true;
            }
            else if (restart_or_new_urow == 2)
            {
                new_urow = true;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public bool get_restart()
        {
            return restart;
        }
        public bool get_new_urow()
        {
            return new_urow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Results_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
