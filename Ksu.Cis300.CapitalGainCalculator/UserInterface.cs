/* UserInterface.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.CapitalGainCalculator
{
    /// <summary>
    /// A user interface for a simple captial gain calculator for a single stock commodity.
    /// </summary>
    public partial class UserInterface : Form
    {        
        //store currently owned stocks
        Queue<decimal> q = new Queue<decimal>();
        //transit shares + cost of each
        NumericUpDown x = new NumericUpDown();

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
            
        }

        
      

        private void uxBuy_Click(object sender, EventArgs e)
        {
            x.Value += 1;
            Array a = q.ToArray<decimal>();
            //Each iteration of the loop should enqueue the cost of the share to the queue. 
            for (int j = (int)uxNumber.Value; j >= 0; j--)
            {
                q.Enqueue(uxCost.Increment);
            }
            //TextBox giving the number of shares owned needs to be updated with the number of costs in the queue.
            uxOwned.Text = q.Count.ToString();
        }

        private void uxSell_Click(object sender, EventArgs e)
        {
            if (uxNumber.Value > q.Count)
            {
                MessageBox.Show("Insufficient Shares :(");
            }
            else if (q.Count == 0) {MessageBox.Show("Ya broke, bruh"); }
            else
            {
                // initialize a decimal to the value in the TextBox giving the net capital gain
                decimal dec = Convert.ToDecimal(uxGain.Text);
            }
            //a loop to iterate once for each share sold. 
            for (int j = (int)uxNumber.Value; j >=0; j-- )
            {
                //remove the original purchase cost of the share from the queue,
                decimal tempQ= 0;
                tempQ = q.Dequeue();

                //add the difference between the selling cost and the original purchase cost to the accumulated capital gain.
                if (tempQ > (int)uxCost.Value)
                {
                    uxGain.Text += (tempQ - uxCost.Value);
                }
                else if (tempQ == (int)uxCost.Value) { uxGain.Text = "0.0"; }
                else { uxGain.Text += (uxCost.Value - tempQ); }
                // OG Purchase - Sell cost = Gain
            }
            uxOwned.Text = uxGain.Text;
            //uxGain.Text = 


        }
    }
}
