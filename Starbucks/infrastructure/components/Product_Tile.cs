﻿using Starbucks.application.datas;
using Starbucks.presentation.basket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starbucks.infrastructure.components
{
    public partial class Product_Tile : UserControl
    {
        int prod_count = 1;
        ImageConverter imageConverter = new ImageConverter();
        public Product_Tile()
        {
            InitializeComponent();
        }

        #region properties
        private byte[] _image;
        private String _title;
        private int _price;
        private string _size;
        private string _flavour;
        private int _count;

        public byte[] Image
        {
            get { return _image; }
            set { _image = value;
                Image img = (Image)imageConverter.ConvertFrom(value);
                cart_prod_img.Image = img; }
        }

        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public String Title
        {
            get { return _title; }
            set { _title = value; cart_prod_label.Text = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; price_label.Text = $"Price: {value}"; }
        }

        public string ProdSize
        {
            get { return _size; }
            set { _size = value; size_txt.Text = value; }
        }

        public string Flavour
        {
            get { return _flavour; }
            set { _flavour = value; flavour_txt.Text = value; }
        }

        public int Count
        {
            get { return _count; }
            set { _count = value; prod_count = value; }
        }

        #endregion

        private void label2_Click(object sender, EventArgs e)

        {
            decreaseAmount();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            increaseAmount();
        }

        void decreaseAmount()
        {
            if (prod_count <= 1)
            {
                prod_amount.Text = "1";
                price_label.Text = $"Price: {_price * prod_count}";
            }
            else
            {
                prod_count--;
                prod_amount.Text = prod_count.ToString();
                price_label.Text = $"Price: {_price * prod_count}";
                data.totalPrice -= _price;
                Screen_MyBasket.sc_basket.total_price.Text = $"Total: {data.totalPrice}";
                Screen_MyBasket.sc_basket.total_price.Refresh();
            }
        }

        void increaseAmount()
        {
            prod_count++;
            prod_amount.Text = prod_count.ToString();
            price_label.Text = $"Price: {_price * prod_count}";
            data.totalPrice += _price;
            Screen_MyBasket.sc_basket.total_price.Text = $"Total: {data.totalPrice}";
            Screen_MyBasket.sc_basket.total_price.Refresh();
        }

        private void guna2Panel4_Click(object sender, EventArgs e)
        {
            increaseAmount();
        }

        private void guna2Panel3_Click(object sender, EventArgs e)
        {
            decreaseAmount();
        }
    }
}
