 /*********************************************************************************
 * Peter Zorzonello
 * Final Project
 * Cyber Cafe Menue
 * December 9, 2014
 * Version 1.0
 * Copyright 2014
 * Visaul Programming I
 **********************************************************************************/

////////////////////////////////image sources////////////////////////////////////////////
//Letters from:http://graphicriver.net/item/tech-letters/547603
//Icon from: Noctuline (Marija Gidanovic),http://www.veryicon.com/icons/application/morning-pleasure/coffee-extensionmanager.html
//Splash background from: http://crownpointcoffee.com/good-news-for-coffee-lovers/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Final_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //gbobal variables, accesed by mutipla buttons or functions
        DateTime dt = DateTime.Now;
        SortedList<int, string> recept = new SortedList<int,string>();
        decimal total = 0;
        int receptNum = 1;
        TextWriter tw;
        decimal receved = 0;
        int tranNumber = 1;
        bool inRemoveMode = false;

        //when the form is loading play the splashscreen
        private void Form1_Load(object sender, EventArgs e)
        {
            Splash SplashScreen = new Splash();
            SplashScreen.ShowDialog(); 
        }

        /////////////////////buttons that add drinks to the order////////////////////////

        //the following buttons (except Espresso becasue it has one size/price)
        //call the function GetPriceandItem to add the correct item to the recept
        private void btnEspress_Click(object sender, EventArgs e)
        {
            try
            {            
                    if (rdoSmall.Checked == true)
                    {
                        recept.Add(tranNumber, "Sm_Espresso");
                    }
                    else if (rdoMed.Checked == true)
                    {
                        MessageBox.Show("Please inform the customer, espresso is one size");
                        recept.Add(tranNumber, "Sm_Espresso");
                    }
                    else
                    {
                        MessageBox.Show("Please inform the customer, espresso is one size");
                        recept.Add(tranNumber, "Sm_Espresso");
                    }
                    tranNumber++;
                    UpdateOrder();              
            }
            catch
            {
                MessageBox.Show("Error item already on your recept.");
            }
        }
        private void btnLatte_Click(object sender, EventArgs e)
        {
            AddDrinks("Sm_Latte", "Md_Latte", "Lg_Latte");
        }
        private void btnCap_Click(object sender, EventArgs e)
        {
            AddDrinks("Sm_Cappuccino", "Md_Cappuccino", "Lg_Cappuccino");
        }
        private void btnCoffee_Click(object sender, EventArgs e)
        {
            AddDrinks("Sm_Coffee", "Md_Coffee", "Lg_Coffee");
        }   
        private void btnIcedCoff_Click(object sender, EventArgs e)
        {
            AddDrinks("Sm_Iced_Coffee", "Md_Iced_Coffee", "Lg_Iced_Coffee");
        }
        private void btnVLatte_Click(object sender, EventArgs e)
        {
            AddDrinks("Sm_Vanilla_Latte", "Md_Vanilla_Latte", "Lg_Vanilla_Latte");
        }
        private void btnTea_Click(object sender, EventArgs e)
        {
            AddDrinks("Sm_Tea", "Md_Tea","Lg_Tea");
        }
        private void btnIcedTea_Click(object sender, EventArgs e)
        {
            AddDrinks("Sm_Iced_Tea","Md_Iced_Tea", "Lg_Iced_Tea");
        }
        private void btnMocha_Click(object sender, EventArgs e)
        {
            AddDrinks("Sm_Mocha", "Md_Mocha","Lg_Mocha");
        }
        private void btnPSL_Click(object sender, EventArgs e)
        {
            AddDrinks("Sm_PSL", "Md_PSL", "Lg_PSL");
        }


        /////////////////////buttons that add food to the order////////////////////////

        //the following buttons call the function AddFoodItems 
        //to add the correct item to the recept
        private void btnChoCookie_Click(object sender, EventArgs e)
        {
            AddFoodItems("Choco_Chip_Cookie");
        }
        private void btnBrownie_Click(object sender, EventArgs e)
        {
            AddFoodItems("Brownie");
        }
        private void btnCroissant_Click(object sender, EventArgs e)
        {
            AddFoodItems("Croissant");
        }
        private void btnScone_Click(object sender, EventArgs e)
        {
            AddFoodItems("Scone");
        }
        private void btnMuffin_Click(object sender, EventArgs e)
        {
            AddFoodItems("Muffin");
        }    

        /////////////////////Functionality Buttons/////////////////////////////////

        //when the cashier is trying to leave it will prompt them
        //to have the manager enter a pasword to allow them to quit the application
        //calls anouter form with the password manager
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Sign_Out passform = new Sign_Out();
            passform.ShowDialog();
        }

        //click this button to turn the form into a payment screen
        private void btnPay_Click(object sender, EventArgs e)
        {
            //switches the screen to pay mode
            btnBrownie.Visible = false;
            btnCap.Visible = false;
            btnChoCookie.Visible = false;
            btnCoffee.Visible = false;
            btnCroissant.Visible = false;
            btnEspress.Visible = false;
            btnIcedCoff.Visible = false;
            btnIcedTea.Visible = false;
            btnLatte.Visible = false;
            btnMocha.Visible = false;
            btnMuffin.Visible = false;
            btnPSL.Visible = false;
            btnScone.Visible = false;
            btnTea.Visible = false;
            btnVLatte.Visible = false;
            groupBox1.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label3.Visible = false;
            txtNotes.Visible = false;
            btnPay.Visible = false;
            lblTotal.Visible = false;
            label2.Visible = false;

            lblTotalDue.Visible = true;
            lblPrice.Visible = true;
            lblReceved.Visible = true;
            lblAmountReceved.Visible = true;
            lblChange.Visible = true;
            lblChangeDue.Visible = true;
            btnSignOut.Enabled = false;
            

            btnExact.Visible = true;
            btnExact.Text = total.ToString("c");
            btn5.Visible = true;
            btn10.Visible = true;
            btn15.Visible = true;
            btn20.Visible = true;
            label6.Visible = true;
            txtOther.Visible = true;
            btnPayOut.Visible = true;
            btnBack.Visible = true;
            btnRemoveMode.Enabled = false;

            lblPrice.Text = total.ToString("c");
        }

        //click this button to return to the Order Screen
        private void btnBack_Click(object sender, EventArgs e)
        {
            //switches the screen to OrderMode
            ToOrder();
        }

  
        //////////////////////Helping Methods//////////////////////////////////////////

        //Helping Method. Takes the Value from the KeyValuePare, but it MUST
        //be converted into a string first. Returns the price of that item.
        //takes in amtToAdd, a vaule set to 0 and returs it's replacemt.
        private static decimal GetPriceFromItem(decimal amtToAdd, string temp)
        {
            if (temp == "Sm_Latte")
            {
                amtToAdd = 2.90m;
            }
            else if (temp == "Md_Latte")
            {
                amtToAdd = 3.60m;
            }
            else if (temp == "Lg_Latte")
            {
                amtToAdd = 4.70m;
            }
            else if (temp == "Sm_Espresso")
            {
                amtToAdd = 3.00m;
            }
            else if (temp == "Sm_Cappuccino")
            {
                amtToAdd = 3.50m;
            }
            else if (temp == "Md_Cappuccino")
            {
                amtToAdd = 4.30m;
            }
            else if (temp == "Lg_Cappuccino")
            {
                amtToAdd = 5.10m;
            }
            else if (temp == "Sm_Coffee")
            {
                amtToAdd = 2.30m;
            }
            else if (temp == "Md_Coffee")
            {
                amtToAdd = 2.60m;
            }
            else if (temp == "Lg_Coffee")
            {
                amtToAdd = 3.00m;
            }
            else if (temp == "Sm_Iced_Coffee")
            {
                amtToAdd = 2.50m;
            }
            else if (temp == "Md_Iced_Coffee")
            {
                amtToAdd = 2.80m;
            }
            else if (temp == "Lg_Iced_Coffee")
            {
                amtToAdd = 3.10m;
            }
            else if (temp == "Sm_Vanilla_Latte")
            {
                amtToAdd = 3.50m;
            }
            else if (temp == "Md_Vanilla_Latte")
            {
                amtToAdd = 4.30m;
            }
            else if (temp == "Lg_Vanilla_Latte")
            {
                amtToAdd = 5.10m;
            }
            else if (temp == "Sm_Tea")
            {
                amtToAdd = 1.50m;
            }
            else if (temp == "Md_Tea")
            {
                amtToAdd = 1.70m;
            }
            else if (temp == "Lg_Tea")
            {
                amtToAdd = 2.00m;
            }
            else if (temp == "Sm_Iced_Tea")
            {
                amtToAdd = 2.50m;
            }
            else if (temp == "Md_Iced_Tea")
            {
                amtToAdd = 2.70m;
            }
            else if (temp == "Lg_Iced_Tea")
            {
                amtToAdd = 3.00m;
            }
            else if (temp == "Sm_Mocha")
            {
                amtToAdd = 3.20m;
            }
            else if (temp == "Md_Mocha")
            {
                amtToAdd = 4.10m;
            }
            else if (temp == "Lg_Mocha")
            {
                amtToAdd = 4.90m;
            }
            else if (temp == "Sm_PSL")
            {
                amtToAdd = 4.40m;
            }
            else if (temp == "Md_PSL")
            {
                amtToAdd = 5.00m;
            }
            else if (temp == "Lg_PSL")
            {
                amtToAdd = 5.30m;
            }
            else if (temp == "Choco_Chip_Cookie")
            {
                amtToAdd = 2.30m;
            }
            else if (temp == "Brownie")
            {
                amtToAdd = 3.00m;
            }
            else if (temp == "Croissant")
            {
                amtToAdd = 2.95m;
            }
            else if (temp == "Scone")
            {
                amtToAdd = 1.90m;
            }
            else if (temp == "Muffin")
            {
                amtToAdd = 3.00m;
            }
            return amtToAdd;
        }

        //Prints the Sorted List that containes the names of the drinks 
        //and their prices. Loop through the sorted list printing the key and
        //the value. Also take the value and add it to a total, the total due.
        //Every time the function is called clean the listbox and the total
        //this provents item and prices from duplicating.
        private void UpdateOrder()
        {
              
            decimal amtToAdd = 0;
            listBox1.Items.Clear();
            total = 0;
            foreach (KeyValuePair<int, string> kvp in recept)
            {
                string temp = kvp.Value;
                amtToAdd = GetPriceFromItem(amtToAdd, temp);

                listBox1.Items.Add(amtToAdd.ToString("c")+"..."+kvp.Value );

              
                total = (total + amtToAdd);
            }
            lblTotal.Text = total.ToString("c");
        }

        //helper function. When a drink button is pressed it calls this function.
        //this function checks the size of the drink and adds it to the recept.
        //this function also checks to see if an item is bing removed and deleats it
        private void AddDrinks(string small, string med, string large)
        {
            if (rdoLarg.Checked == true || rdoMed.Checked == true || rdoSmall.Checked == true)
            {
                try
                {
                    if (rdoSmall.Checked == true)
                    {
                        recept.Add(tranNumber, small);
                    }
                    else if (rdoMed.Checked == true)
                    {    
                        recept.Add(tranNumber, med);   
                    }
                    else
                    {
                        recept.Add(tranNumber, large);
                    }
                    tranNumber++;
                    UpdateOrder();
                }
                catch
                {
                    MessageBox.Show("Error, Item already in list");
                }
            }
            else
            {
                MessageBox.Show("Plese select a size");
            }
        }

        //anouter helper function, but this function only works with food items.
        //becasue their is no size for food items it just adds the item to the 
        //recept. This function also checks to see if an item is bing removed and deleats it
        private void AddFoodItems(string foodItem)
        {        
                try
                {
                    recept.Add(tranNumber, foodItem);
                    tranNumber++;
                    UpdateOrder();
                }
                catch
                {
                    MessageBox.Show("Error, Item already in list");
                }         
        }

        //Go to the OrderScreen
        //Switch button visibality to represent the ordering screen
        private void ToOrder()
        {
            btnBrownie.Visible = true;
            btnCap.Visible = true;
            btnChoCookie.Visible = true;
            btnCoffee.Visible = true;
            btnCroissant.Visible = true;
            btnEspress.Visible = true;
            btnIcedCoff.Visible = true;
            btnIcedTea.Visible = true;
            btnLatte.Visible = true;
            btnMocha.Visible = true;
            btnMuffin.Visible = true;
            btnPSL.Visible = true;
            btnScone.Visible = true;
            btnTea.Visible = true;
            btnVLatte.Visible = true;
            groupBox1.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label3.Visible = true;
            txtNotes.Visible = true;
            btnPay.Visible = true;
            lblTotal.Visible = true;
            label2.Visible = true;

            lblTotalDue.Visible = false;
            lblPrice.Visible = false;
            lblReceved.Visible = false;
            lblAmountReceved.Visible = false;
            lblChange.Visible = false;
            lblChangeDue.Visible = false;
            btnSignOut.Enabled = true;
            

            btnExact.Visible = false;

            btn5.Visible = false;
            btn10.Visible = false;
            btn15.Visible = false;
            btn20.Visible = false;
            label6.Visible = false;
            txtOther.Visible = false;
            btnPayOut.Visible = false;
            btnPayOut.Enabled = false;
            btnBack.Visible = false;
            btnRemoveMode.Enabled = true;
        }

        //creats a documet using the recept number. 
        //print the date and time of the order and each menue item.
        //then print out the amount due, receved, and the change
        //print out a thank you message
        private void sendRecept(decimal amountReceved)
        {
            

            tw = new StreamWriter("C:\\Users\\Peter\\Documents\\VIsualFinal\\Recepts\\recept" + receptNum + ".txt");
            tw.WriteLine("Cyber Cafe");
            tw.WriteLine("Date:" + dt);

            tw.WriteLine();

            foreach (KeyValuePair<int, string> kvp in recept)
            {
                decimal price = 0;
                string temp = kvp.Value;
                price = GetPriceFromItem(price,temp);
                tw.WriteLine(price.ToString("c")+ "..." + kvp.Value );
            }

            tw.WriteLine();

            tw.WriteLine("Due: " + total.ToString("c"));
            tw.WriteLine("Paied: " + amountReceved.ToString("c"));
            tw.WriteLine("Change: " + (total - amountReceved).ToString("c"));

            tw.WriteLine();

            tw.WriteLine("Thank You! Have a Great Day");

            tw.Close();
        }

        //creata a documet that is to be sent to the kitcen
        //include an order number, the items ordered, and notes
        private void sendOrdertoKitchen()
        {

            tw = new StreamWriter("C:\\Users\\Peter\\Documents\\VIsualFinal\\Orders\\Order" + receptNum + ".txt");
            tw.WriteLine("Date:" + dt);
            tw.WriteLine("Order Number: " + receptNum);

            tw.WriteLine();

            foreach (KeyValuePair<int, string> kvp in recept)
            {
                tw.WriteLine(kvp.Value);
            }

            tw.WriteLine();

            tw.WriteLine("Notes: " + txtNotes.Text);

            tw.Close();
        }


        /////////////////// buttons used for payment ///////////////////////////////

        //all of the folowing buttons add the amount listed on them to the amount receved.
        //Then it checks to see if the amout receved is at least equal if not greater then 
        //what is due. If not enoug money was receved then the user cannnot accept payment.
        //If the amoutn receved is equal to or greater then what is due the user is alowed to proceded
        private void btnExact_Click(object sender, EventArgs e)
        {
            receved = total;
            lblAmountReceved.Text = btnExact.Text;
            lblChangeDue.Text = "$0.00";
            lblChangeDue.ForeColor = System.Drawing.Color.Black;
            btnPayOut.Enabled = true;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            receved = 5;
            lblAmountReceved.Text = receved.ToString("c");
            lblChangeDue.Text = (total - receved).ToString("c");
            if ((total - receved) <= 0)
           {
               lblChangeDue.ForeColor = System.Drawing.Color.Black;
               btnPayOut.Enabled = true;
           }
            else if (total - receved >= 0)
           {
               btnPayOut.Enabled = false;
               lblChangeDue.ForeColor=System.Drawing.Color.Red;
           }
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            receved = 10;
            lblAmountReceved.Text = receved.ToString("c");
            lblChangeDue.Text = (total - receved).ToString("c");
            if ((total - receved) <= 0)
            {
                lblChangeDue.ForeColor = System.Drawing.Color.Black;
                btnPayOut.Enabled = true;
            }
            else if (total - receved >= 0)
            {
                btnPayOut.Enabled = false;
                lblChangeDue.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            receved = 15;
            lblAmountReceved.Text = receved.ToString("c");
            lblChangeDue.Text = (total - receved).ToString("c");
            if ((total - receved) <= 0)
            {
                lblChangeDue.ForeColor = System.Drawing.Color.Black;
                btnPayOut.Enabled = true;
            }
            else if (total - receved >= 0)
            {
                btnPayOut.Enabled = false;
                lblChangeDue.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            receved = 20;
            lblAmountReceved.Text = receved.ToString("c");
            lblChangeDue.Text = (total - receved).ToString("c");
            if ((total - receved) <= 0)
            {
                lblChangeDue.ForeColor = System.Drawing.Color.Black;
                btnPayOut.Enabled = true;
            }
            else if (total - receved >= 0)
            {
                btnPayOut.Enabled = false;
                lblChangeDue.ForeColor = System.Drawing.Color.Red;
            }
        }

        //When text is changed in the "Other" text box preform checks
        //to make sure the data is valid. After the data is confermed to be valid data
        //check to make sure it is at leat the correct amount. If it is then 
        //alow the user to proceded to accept payment
        private void txtOther_TextChanged(object sender, EventArgs e)
        {
            decimal moneyReceved;
            try
            {
                string text2 = txtOther.Text;

                //if the text2 sting(input from "Other") is a decimal
                if (decimal.TryParse(text2, out moneyReceved))
                {
                    //if the decimal is more then 0 but less then 10,000
                    if ((moneyReceved > 0 && moneyReceved < 10000))
                    {
                        //change the lables and check the amount
                        lblAmountReceved.Text = moneyReceved.ToString("c");
                        receved = moneyReceved;
                        lblChangeDue.Text = (total - moneyReceved).ToString("c");
                        if ((total - moneyReceved) <= 0)
                        {
                            lblChangeDue.ForeColor = System.Drawing.Color.Black;
                            btnPayOut.Enabled = true;
                        }
                        else if (total - moneyReceved >= 0)
                        {
                            btnPayOut.Enabled = false;
                            lblChangeDue.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    // if the decimal is not in the corect range do not
                    // allow the user to enter it
                    else
                    {                   
                        txtOther.Text = "";
                        btnPayOut.Enabled = false;
                    }
                }
                //if the data is not a valid(not a decimal) do 
                //not allw the user to input it
                else
                {
                    
                    txtOther.Text = "";
                    btnPayOut.Enabled = false;
                }       
            }
            catch
            {    
            }
        }

        //clicking this button casuses a recept to be sent to the printer(here it
        // goes to a folder in documents) and an order to go to the kitchen(here, it
        //goes to a folder in documents). After the recept and order are sent out clear the existing order
        //return to the ordering screen, and incremet the recept number(used to keep track of order num)
        private void btnPayOut_Click(object sender, EventArgs e)
        {         
            try
            {
                sendRecept(receved);
                sendOrdertoKitchen();
                ToOrder();
                recept.Clear();
                UpdateOrder();
                total = 0;
                txtNotes.Clear();
                receptNum++;
                tranNumber = 1;
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Paying-Out. " + ex);
            }
        }

        //sets mode to removemode. Inform the user they are entering remove mode and gice them
        //the option to back out. 
        private void btnRemoveMode_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result =  MessageBox.Show("Entering Remove Mode. \nClick on an item in the order to remove it.","Remove Mode", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK  )
            {
                inRemoveMode = true;
                btnRemoveMode.Enabled = false;
            }
        }

        //remove the selected item. Get the index of the selected item and remove it from the 
        //sorted list. Up date the sorted list. Only remove items if you are in remove mode.
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inRemoveMode == true)
            {
                int curItem = listBox1.SelectedIndex;
                recept.RemoveAt(curItem);
                UpdateOrder();
                inRemoveMode = false;
                btnRemoveMode.Enabled = true;
            } 
        }        
    }
}
