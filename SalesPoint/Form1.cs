using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalesPoint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        decimal total = 0;


        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            int qty = 0;
            if (cboProduct.SelectedIndex == -1)
            {
                MessageBox.Show("PLEASE SELECT A PRODUCT!");
                cboProduct.Focus();
                return;
            }
            //
            if (!string.IsNullOrEmpty(txtQty.Text))
            {
                try
                {

                    qty = int.Parse(txtQty.Text);
                    total = total + decimal.Parse((2.5 * qty) + "");
                    txtDue.Text = total.ToString();
                }
                catch (Exception eex)
                {

                    MessageBox.Show("Invalid quantity",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(eex.Message + " occurred in btnAddtoCart");
                    return;
                }

            }
            else if (string.IsNullOrEmpty(txtQty.Text))
            {
                MessageBox.Show("Please specify qty!");
                txtQty.Focus();
                return;
            }

            string item = cboProduct.Text;
            decimal price = 2.5m;

            decimal ExtPrice = price * qty;

            string[] cartline = {
                                     item, 
                                     price.ToString("F2"),
                                     qty.ToString(),
                                     ExtPrice.ToString("F2")
                                 };

            dataGridView1.Rows.Add(cartline);

            ClearEntry();


        }

        private void ClearEntry()
        {
            cboProduct.SelectedIndex = -1;
            txtQty.Text = "";
        }

        private void txtDue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int qty = int.Parse(txtQty.Text);
                string item = cboProduct.Text;
                decimal price = 2.5m;
                decimal ExtPrice = price * qty;
            }

            catch (Exception ex)
            {
                MessageBox.Show("INCORRECT ENTRY");
            }
        }





        private void btnFinish_Click_1(object sender, EventArgs e)
        {


            decimal paid = decimal.Parse((txtPaid.Text) + "");
            if (paid >= total)
            {

                decimal change = paid - total;
                txtChange.Text = change.ToString();
                MessageBox.Show("TRANSACTION COMPLETED");
            }
            else
            {

                MessageBox.Show("PAYMENT IS LOWER THAN TOTAL AMOUNT");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

       
      


    }
}
