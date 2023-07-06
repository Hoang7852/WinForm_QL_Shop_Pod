using _3._PL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._PL.Component
{
    public partial class KhachHangSearch : UserControl
    {
        public KhachHangSearch()
        {
            InitializeComponent();
        }

        public event EventHandler OnSelect = null;

        public string Name { get => lblName.Text; set => lblName.Text = value; }
        public string Phone { get => lblPhone.Text; set => lblPhone.Text = value; }
        public Image Icon { get => imgImage.Image; set => imgImage.Image = value; }
        public string Rank { get => lblRank.Text; set => lblRank.Text = value; }


        private void panel1_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
