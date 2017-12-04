using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Category c = new Category();
    List<Category> cl = new List<Category>();
    protected void Page_Load(object sender, EventArgs e)
    {
        cl = c.getCategory();
        foreach (Category cat in cl)
        {
            categoryDDL.Items.Add(cat.Name);
        }
    }

    protected void sendBTN_Click(object sender, EventArgs e)
    {
        string name = nameTB.Text;
        double price = double.Parse(priceTB.Text);
        string category = categoryDDL.SelectedValue;
        string info = infoTA.Value;
    }
}