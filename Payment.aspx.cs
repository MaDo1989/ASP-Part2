using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (visaCB.Checked)
        {
            paymentsDDL.Visible = true;
            visaTB.Visible = true;
            idTB.Visible = true;
            typeDDL.Visible = true;
            phoneTBVLD.Visible = false;
            phoneTBVLDR.Visible = false;
            phoneCB.Enabled = false;
        }
        else
        {
            paymentsDDL.Visible = false;
            visaTB.Visible = false;
            idTB.Visible = false;
            typeDDL.Visible = false;
        }
        if (phoneCB.Checked)
        {
            phoneTB.Visible = true;
            visaTBVLD.Visible = false;
            idTBVLD.Visible = false;
            visaCB.Enabled = false;
        }
        else
        {
            phoneTB.Visible = false;
        }
    }

    protected void idTBVLD2_ServerValidate(object source, ServerValidateEventArgs args)
    {

        if (idTB.Text.Length != 9)
        {
            args.IsValid = false;
            return;
        }

        try
        {
            int input = int.Parse(idTB.Text);
            int sum = 0;
            int first = input % 10;

            for (int i = 0; i < 9; i++)
            {
                sum += (input % 10);
                input /= 10;
            }

            if (sum % 7 == first)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        catch (Exception)
        {
            args.IsValid = false;
        }

    }

    protected void dateCal_SelectionChanged(object sender, EventArgs e)
    {
        dateTB.Text = dateCal.SelectedDate.ToString();

        if (dateCal.SelectedDate > DateTime.Now.AddDays(30) || dateCal.SelectedDate < DateTime.Now)
        {
            dateTB.Text = "";
        }
    }

    protected void payBTN_Click(object sender, EventArgs e)
    {
        string name = signFU.FileName;
        string path = Server.MapPath("."); 
        signFU.SaveAs(path + "/images/" + name); 
    }
}