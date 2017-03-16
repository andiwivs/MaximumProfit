using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thomas.MaximumProfit.Core;

namespace Thomas.MaximumProfit.Client
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            var prices = new List<int>();
            int price;

            string[] rawParts = txtPrices.Text.Split(new char[] { ',' });

            foreach (string rawPart in rawParts)
            {
                var part = rawPart.Trim();

                if (int.TryParse(rawPart, out price))
                    prices.Add(price);
            }

            var evaluator = new ProfitEvaluator();
            int maxProfit = evaluator.GetMaxProfit(prices.ToArray());

            MessageBox.Show($"Max profit possible: {maxProfit}");
        }
    }
}
