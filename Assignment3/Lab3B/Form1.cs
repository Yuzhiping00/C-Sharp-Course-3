/*
Class: Form1.cs
Author: Zhiping Yu
Student# : 000822513
Date:   October 16, 2020
Purpose: This class is one subclass of Form and it displays controls in the forms and responds to any requests from user,
         such as add service, calculate the total price, reset the form and exit the program.
         
I, Zhiping Yu, 000822513 certify that this material is my original work.  
No other person's work has been used without due acknowledgement.

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

namespace Lab3B
{
    public partial class Form1 : Form
    {
        decimal totalPrice = 0; // total price user has to pay
        decimal servicePrice = 0; // service fee for different services
        /// <summary>
        /// Constuctor    set up the controls on the form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Only after user selects one of services from the service listbox, use can activate the add service button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serviceLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(serviceLB.SelectedIndex != -1) // condition is that user select a service
            {
                addBtn.Enabled = true; // activate the add service button
            }
        }
        /// <summary>
        /// After user clicked add service button at first time, the calculate total price button will be activated,
        /// while the hairdresser combo box will be deactivated. On the top of that, the hairdresser's name, service's 
        /// name will be added to the charged items list box and the price of them will be added to price list box. 
        /// The user is allowed to add any services once a time after first time, 
        /// but he is not able to select any hairdresser. In addition, the service's name and
        ///  price will be added to charged item and price list boxes seperately. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            
            if (hairdresserCB.Enabled == true) { // the condition is that the hairdresser combo box is enabled
                if (hairdresserCB.SelectedIndex == 0)
                {
                    chargedItemsLB.Items.Add(hairdresserCB.SelectedItem);
                   // priceLB.Items.Add("$30.00");
                    totalPrice += 30;
                    priceLB.Items.Add(totalPrice.ToString("C"));
                } else if (hairdresserCB.SelectedIndex == 1)
                {
                    chargedItemsLB.Items.Add(hairdresserCB.SelectedItem);
                    totalPrice += 45;

                    priceLB.Items.Add(totalPrice.ToString("C"));
                    //  priceLB.Items.Add("$45.00");
                } else if (hairdresserCB.SelectedIndex == 2)
                {
                    chargedItemsLB.Items.Add(hairdresserCB.SelectedItem);
                    //priceLB.Items.Add("$40.00");
                    totalPrice += 40;

                    priceLB.Items.Add(totalPrice.ToString("C"));
                } else if (hairdresserCB.SelectedIndex == 3)
                {
                    chargedItemsLB.Items.Add(hairdresserCB.SelectedItem);
                    //priceLB.Items.Add("$50.00");
                    totalPrice += 50;

                    priceLB.Items.Add(totalPrice.ToString("C"));
                }
                else
                {
                    chargedItemsLB.Items.Add(hairdresserCB.SelectedItem);
                    // priceLB.Items.Add("$55.00");
                    totalPrice += 55;
                    priceLB.Items.Add(totalPrice.ToString("C"));
                }
        }
            if(serviceLB.SelectedIndex == 0)// user selects one of the services
            {
                chargedItemsLB.Items.Add(serviceLB.SelectedItem);
                // priceLB.Items.Add("$30.00");
                totalPrice += 30;
                servicePrice = 30;
                priceLB.Items.Add(servicePrice.ToString("C"));
            }
            else if (serviceLB.SelectedIndex == 1)
            {
                chargedItemsLB.Items.Add(serviceLB.SelectedItem);
                //priceLB.Items.Add("$20.00");
                totalPrice += 20;
                servicePrice = 20;
                priceLB.Items.Add(servicePrice.ToString("C"));
            }
            else if (serviceLB.SelectedIndex == 2)
            {
                chargedItemsLB.Items.Add(serviceLB.SelectedItem);
                // priceLB.Items.Add("$40.00");
                totalPrice += 40;
                servicePrice = 40;

                priceLB.Items.Add(servicePrice.ToString("C"));
            }
            else if (serviceLB.SelectedIndex == 3)
            {
                chargedItemsLB.Items.Add(serviceLB.SelectedItem);
                // priceLB.Items.Add("$50.00");
                totalPrice += 50;
                servicePrice = 50;

                priceLB.Items.Add(servicePrice.ToString("C"));
            }
            else if(serviceLB.SelectedIndex == 4)
            {
                chargedItemsLB.Items.Add(serviceLB.SelectedItem);
                // priceLB.Items.Add("$200.00");
                totalPrice += 200;
                servicePrice = 200;
                priceLB.Items.Add(servicePrice.ToString("C"));
            }
            else
            {
                chargedItemsLB.Items.Add(serviceLB.SelectedItem);
                // priceLB.Items.Add("$60.00");
                totalPrice += 60;
                servicePrice = 60;
                priceLB.Items.Add(servicePrice.ToString("C"));
            }
            hairdresserCB.Enabled = false; // deactivate the hairdresser combo box
            calculateBtn.Enabled = true; // activate the calculate button after first adding service

        }
        /// <summary>
        /// Calcalute the total price customer has to pay and convert it to string and store it into the total price
        /// text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculateBtn_Click(object sender, EventArgs e)
        {

            totalPriceTB.Text = totalPrice.ToString("C");
        }
        /// <summary>
        /// After user clicks reset button, the hairdresser combo box should be activated, the first entry in the box
        /// should be selected and set focus for the combo box. Then select nothing in the service list box. What's more,
        /// the content in the charged items price list boxes should be cleared. The data in the total price text box
        /// should be cleard as well. The total price should be set to 0. Finally, add service and calculate total
        /// price buttons should be set to unenabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetBtn_Click(object sender, EventArgs e)
        {
            
            hairdresserCB.Enabled = true;
            hairdresserCB.Focus();
            hairdresserCB.SelectedIndex = 0;
            serviceLB.SelectedIndex = -1;
            addBtn.Enabled = false;
            calculateBtn.Enabled = false;
            chargedItemsLB.Items.Clear();
            priceLB.Items.Clear();
            totalPriceTB.Clear();
            totalPrice = 0;
        }
        /// <summary>
        /// when the exit button is clicked, the application will end and form is closed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
