using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    List<CheckBox> cbList = new List<CheckBox>();
    List<Product> cart;
    Label priceLBL = new Label();
    Label visit = new Label();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cart"] == null)
        {
            return;
        }

        visit.Text = "";
        ph.Controls.Add(visit);


        if (Request.Cookies["visitCart"] == null)
        {
            Response.Cookies["visitCart"].Value = "firstTime";
            Response.Cookies["visitCart"].Expires = DateTime.Now.AddSeconds(5);
            visit.Text = "Welcome to cart for the first time";
            
        }

        cart = (List<Product>)Session["cart"];

        Table dTable = new Table();
        ph.Controls.Add(dTable);

        for (int i = 0; i < cart.Count; i += 10)
        {
            TableRow dRow = new TableRow();
            dTable.Controls.Add(dRow);

            for (int j = 0; i + j < cart.Count; j++)
            {

                TableCell dCell = new TableCell();
                dRow.Controls.Add(dCell);

                Image dImg = new Image();
                dImg.ImageUrl = cart[i + j].ImagePath;

                Label dName = new Label();
                dName.Text = "<br/>" + cart[i + j].Title + "<br/>";

                Label dPrice = new Label();
                dPrice.Text = cart[i + j].Price.ToString() + "<br/>";

                Label dInv = new Label();
                dInv.Text = cart[i + j].Inventory.ToString();

                CheckBox dCB = new CheckBox();
                dCB.Checked = true;
                dCB.AutoPostBack = true;
                dCB.CheckedChanged += new EventHandler(calcPrice);
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
        
        calc();

        Button pay = new Button();
        pay.Text = "Pay";
        pay.Click += Pay_Click;
        ph.Controls.Add(pay);
        ph.Controls.Add(priceLBL);
    }

    private void Pay_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payment.aspx");
    }

    private void calc()
    {
        double totalPrice = 0;
        for (int i = 0; i < cbList.Count; i++)
        {
            if (cbList[i].Checked)
            {
                totalPrice += cart[i].Price;
            }
        }
        Session["price"] = totalPrice;
        priceLBL.Text = "The price is: " + totalPrice.ToString();
    }

    private void calcPrice(object sender, EventArgs e)
    {
        calc();
        visit.Text = "Changes saved";
    }


}