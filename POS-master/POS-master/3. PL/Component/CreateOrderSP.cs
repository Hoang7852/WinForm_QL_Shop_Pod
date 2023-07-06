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
    public partial class CreateOrderSP : UserControl
    {
        private double _cost;

        public event EventHandler OnSelect = null;
        public CreateOrderSP()
        {
            InitializeComponent();
        }
        private void guna2Panel1_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);

        }

        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }
        public double Cost { get => _cost; set { _cost = value; lblCost.Text = _cost.ToString("C2"); } }
        public Image Icon { get => imgImage.Image; set => imgImage.Image = value; }


    }
}
