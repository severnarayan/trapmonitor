using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;

namespace VilcomNetworkMonitor
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public int frames;

        public int counter;

        private void Form6_Load(object sender, EventArgs e)
        {
           

        }

        private void Form6_Shown(object sender, EventArgs e)
        {
          
        }

        private void OnFrameChanged(object sender, EventArgs e)
        {
         
            
        }

        private void Form6_Activated(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.ImageAnimator.StopAnimate(pictureBox1.Image, OnFrameChanged);
        }

     
    }
}
