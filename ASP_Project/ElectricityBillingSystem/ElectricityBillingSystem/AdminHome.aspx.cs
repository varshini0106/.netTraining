using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ElectricityBillingSystem
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlAdd.Visible = true;
                pnlRetrieve.Visible = false;
            }
        }
        protected void btnShowAdd_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = true;
            pnlRetrieve.Visible = false;
            lblAddErr.Text = lblAddOut.Text = "";
        }

        protected void btnShowRetrieve_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = false;
            pnlRetrieve.Visible = true;
            lblRetErr.Text = "";
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            lblAddErr.Text = lblAddOut.Text = "";
            try
            {
                // Validate units using BillValidator (as per spec)
                var validator = new BillValidator();
                int units;
                if (!int.TryParse(txtUnitsConsumed.Text, out units))
                {
                    lblAddErr.Text = "Please enter a valid number for Units Consumed.";
                    return;
                }
                var msg = validator.ValidateUnitsConsumed(units);
                if (!string.IsNullOrEmpty(msg))
                {
                    lblAddErr.Text = msg; // "Given units is invalid"
                    return;
                }

                var ebill = new ElectricityBill
                {
                    ConsumerNumber = txtConsumerNumber.Text,   // this setter validates EB pattern (or throws)
                    ConsumerName = txtConsumerName.Text,
                    UnitsConsumed = units
                };

                ElectricityBoard.CalculateBill(ebill);
                ElectricityBoard.AddBill(ebill);

                // Show output, then clear inputs (single form for N entries)
                lblAddOut.Text = $"{ebill.ConsumerNumber} {ebill.ConsumerName} {ebill.UnitsConsumed} Bill Amount : {ebill.BillAmount}";
                txtConsumerNumber.Text = "";
                txtConsumerName.Text = "";
                txtUnitsConsumed.Text = "";
                txtConsumerNumber.Focus();
            }
            catch (FormatException fx)
            {
                // Must show "Invalid Consumer Number"
                lblAddErr.Text = fx.Message;
            }


            catch (SqlException sqlEx)
            {
                if (sqlEx.Message.Contains("PRIMARY KEY constraint"))
                {
                    lblAddErr.Text = "A bill with this Consumer Number already exists. Please use a unique Consumer Number.";
                }
                else
                {
                    lblAddErr.Text = "A database error occurred: " + sqlEx.Message;
                }
            }
            catch (Exception ex)
            {
                lblAddErr.Text = "An unexpected error occurred: " + ex.Message;
            }
        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            lblRetErr.Text = ""; // Clear previous error
            int n;

            if (!int.TryParse(txtN.Text.Trim(), out n) || n < 1)
            {
                lblRetErr.Text = "Please enter a valid positive number for N.";
                gvBills.DataSource = null;
                gvBills.DataBind();
                return;
            }

            List<ElectricityBill> allBills = ElectricityBoard.Generate_N_BillDetails(n); // Get all records

            if (n > allBills.Count)
            {
                lblRetErr.Text = $"Requested {n} records, but only {allBills.Count} are available.";
                gvBills.DataSource = null;
                gvBills.DataBind();
                return;
            }

            List<ElectricityBill> lastBills = allBills.Skip(allBills.Count - n).ToList();
            gvBills.DataSource = lastBills;
            gvBills.DataBind();
        }
    }
}