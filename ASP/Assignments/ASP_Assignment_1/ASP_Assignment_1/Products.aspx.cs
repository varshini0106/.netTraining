/*Quetion-2:.Create a web application that hosts a series of products (any) as adropdown list.
Have a image control that can display the image of the selected item in the dropdown
have a button control that gets the price of the selected product and displays it in a Label control*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Assignment_1
{
    public partial class Products : System.Web.UI.Page
    {
        Dictionary<string, (string ImageUrl, decimal Price)> products = new Dictionary<string, (string, decimal)>
        {
            {"IPad",("~/Images/IPad.jpg", 9800m) },
            {"HeadPhones",("~/Images/HeadPhones.jpg", 7500m) },
            {"Spects",("~/Images/Spects.jpg", 1000m) },
            {"Watch",("~/Images/Watch.jpg", 1800m) },
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (var product in products.Keys)
                {
                    ddlProducts.Items.Add(product);
                }
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = ddlProducts.SelectedItem.Text;
            if (products.ContainsKey(selectedProduct))
            {
                imgProduct.ImageUrl = products[selectedProduct].ImageUrl;
            }
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            string selectedProduct = ddlProducts.SelectedItem.Text;
            if (products.ContainsKey(selectedProduct))
            {
                lblPrice.Text = "Price:" + products[selectedProduct].Price.ToString();
            }
        }
    }
}
