﻿using Starbucks.application.datas;
using Starbucks.domain.user;
using Starbucks.infrastructure.components;
using Starbucks.presentation.email;
using Starbucks.presentation.product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starbucks.presentation.basket
{
    public partial class Screen_MyBasket : Form
    {
        int row = 1;
        public static Screen_MyBasket sc_basket;
        public Screen_MyBasket()
        {
            InitializeComponent();
            sc_basket = this;
            my_basket_label.Location = new Point((ClientSize.Width / 2) - (my_basket_label.Width / 2), 10);
            loadItems();
        }

        void loadItems()
        {
            if (row == 0)
            {
                cart_items_panel.Controls.Add(
                    new 
                    Label { 
                        Text = "No Items in the cart",
                        AutoSize = true,
                        Font = new Font("",20),
                    }
                    );
                total_price.Visible = false;
                next_btn.Visible = false;
            }
            else {
                AddCart cart = new AddCart();
                SqlDataReader cartdata = cart.showCart();
                while (cartdata.Read())
                {
                   byte[] photo_aray = (byte[])cartdata["image"];
                    cart_items_panel.Controls.Add(
                        new Product_Tile
                        {

                            Title = cartdata["name"].ToString(),
                            Image = photo_aray,
                            Price = int.Parse( cartdata["price"].ToString()),
                        });
                    data.totalPrice +=int.Parse( cartdata["price"].ToString());
                    total_price.Text = $"Total: {data.totalPrice.ToString()}";
                    total_price.Refresh();
                }
            }
           
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            Screen_email email = new Screen_email();
            email.Show();
            Close();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            Screen_Product product = new Screen_Product(1);
            product.Show();
            Hide();
        }
    }
}
