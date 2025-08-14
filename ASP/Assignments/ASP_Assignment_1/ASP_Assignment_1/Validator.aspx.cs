/*1.Write the following application. The initial page is called Validator.aspx and it has 7 text boxes representing (Name, Family Name, Address, City, Zip Code, Phone and e-mail address) and a Check button.

User gets the following page after clicking on Check button:The required validation actions are:

· name different from family name,

· address at least 2 letters,

· city at least 2 letters,

· zip-code 5 digits,

· phone according to the format XX-XXXXXXX or XXX-XXXXXXX,

e-mail is a valid email.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace ASP_Assignment_1
{
    public partial class Validator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void City_Validate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "")
            {
                args.IsValid = false;
            }
            else if (args.Value.Length < 5)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void Address_Validate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "")
            {
                args.IsValid = false;
            }
            else if (args.Value.Length < 5)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void ZipCode_Validate(object source, ServerValidateEventArgs args)
        {
            string zipCode = args.Value;
            if (zipCode == "")
            {
                args.IsValid = false;
            }
            else if (Regex.IsMatch(zipCode, @"^\d{5}$"))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void PhoneNo_Validate(object source, ServerValidateEventArgs args)
        {
            string phoneNumber = args.Value;
            if (phoneNumber == "")
            {
                args.IsValid = false;
            }
            else if (Regex.IsMatch(phoneNumber, @"^\d{2}-\d{7}$|^\d{3}-\d{7}$"))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void Email_Validate(object source, ServerValidateEventArgs args)
        {
            string email = args.Value;
            if (email == "")
            {
                args.IsValid = false;
            }
            else if (Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void FamilyName_Validate(object source, ServerValidateEventArgs args)
        {
            string name = Txtname.Text.Trim();
            string familyName = args.Value.Trim();
            if (name != "" && familyName != "" && name.ToLower() != familyName.ToLower())
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void OnCheckButtonClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                txtmsg.Text = "Validation Success";
                txtmsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                txtmsg.Text = "Validation failed. Please check your input.";
                txtmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}