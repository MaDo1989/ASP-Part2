using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ShowProducts : System.Web.UI.Page
{
    List<CheckBox> cbList = new List<CheckBox>();
    List<Product> allProducts;
    double discount;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserType"] != null)
        {
            discount = 0.2;
        }
        else
        {
            Response.Cookies["UserType"].Value = "return";
            Response.Cookies["UserType"].Expires = DateTime.Now.AddYears(999);
            discount = 0.5;
        }

        Product import = new Product();
        allProducts = import.getProducts();

        Label sale = new Label();
        ph.Controls.Add(sale);
        sale.Text = allProducts[0].Title + " is on sale - " + (discount * 100).ToString() + "% OFF! (Full price = " + allProducts[0].Price + ")";

        Table dTable = new Table();
        ph.Controls.Add(dTable);

        for (int i = 0; i < allProducts.Count; i += 10)
        {
            TableRow dRow = new TableRow();
            dTable.Controls.Add(dRow);

            for (int j = 0; j < 10; j++)
            {
                TableCell dCell = new TableCell();
                dRow.Controls.Add(dCell);

                Image dImg = new Image();
                dImg.ImageUrl = allProducts[i + j].ImagePath;

                Label dName = new Label();
                dName.Text = "<br/>" + allProducts[i + j].Title + "<br/>";

                Label dPrice = new Label();
                if (i + j == 0)
                {
                    double SalePrice = allProducts[i + j].Price * (1 - discount);
                    dPrice.Text = SalePrice.ToString() + "<br/>";
                }
                else
                {
                    dPrice.Text = allProducts[i + j].Price.ToString() + "<br/>";
                }

                Label dInv = new Label();
                dInv.Text = allProducts[i + j].Inventory.ToString();

                CheckBox dCB = new CheckBox();
                cbList.Add(dCB);
                dCB.ID = (i + j).ToString();

                if (dInv.Text == "0")
                {
                    dCB.Enabled = false;
                }

                dCell.Controls.Add(dImg);
                dCell.Controls.Add(dName);
                dCell.Controls.Add(dCB);
                dCell.Controls.Add(dPrice);

                if (i + j == 50)
                {
                    return;
                }
            }
        }
    }

    protected void Checkout_Click(object sender, EventArgs e)
    {
        List<Product> cart = new List<Product>();
        for (int i = 0; i < cbList.Count; i++)
        {
            if (cbList[i].Checked)
            {
                cart.Add(allProducts[i]);
            }
        }
    }
}