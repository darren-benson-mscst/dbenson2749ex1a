using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dbenson2749ex1a_ef.Model;

namespace dbenson2749ex1a
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.loadVendors();
                this.loadShipMethods();
                this.loadEmployees();
                this.loadPurchaseOrderHeaders();
            }

        }

        private void loadVendors()
        {

            List<Vendor> vendorList = new List<Vendor>();
            try
            {
                vendorList = Company.getVendors();
            }
            catch (Exception ex)
            {
                messageLabel.Text = ex.Message;
                messageLabel.CssClass = "control-label text-danger";
            }

            this.vendorDropDownList.DataSource = vendorList;
            this.vendorDropDownList.DataTextField = "ShortString";
            this.vendorDropDownList.DataValueField = "BusinessEntityID";
            this.vendorDropDownList.DataBind();
            this.vendorDropDownList.SelectedValue = "1496";
        }

        private void loadShipMethods()
        {

            List<ShipMethod> shipMethodList = new List<ShipMethod>();
            try
            {
                shipMethodList = Company.getShipMethods();
            }
            catch (Exception ex)
            {
                messageLabel.Text = ex.Message;
                messageLabel.CssClass = "control-label text-danger";
            }

            this.shippingDropDownList.DataSource = shipMethodList;
            this.shippingDropDownList.DataTextField = "Name";
            this.shippingDropDownList.DataValueField = "ShipMethodID";
            this.shippingDropDownList.DataBind();
           
        }

        private void loadEmployees()
        {

            List<Employee> employeeList = new List<Employee>();
            try
            {
                employeeList = Company.getEmployees();
            }
            catch (Exception ex)
            {
                messageLabel.Text = ex.Message;
                messageLabel.CssClass = "control-label text-danger";
            }

            this.employeeDropDownList.DataSource = employeeList;
            this.employeeDropDownList.DataTextField = "LastFirstName";
            this.employeeDropDownList.DataValueField = "BusinessEntityID";
            this.employeeDropDownList.DataBind();

        }

        private void loadPurchaseOrderHeaders()
        {
            this.clearPurchaseOrderControls();

            List<PurchaseOrderHeader> purchaseOrderList = new List<PurchaseOrderHeader>();
            int vendorID = Int32.Parse(vendorDropDownList.SelectedValue);
            try
            {              
                purchaseOrderList = Company.getPurchaseOrderHeaders(vendorID);
            }
            catch (Exception ex)
            {
                messageLabel.Text = ex.Message;
                messageLabel.CssClass = "control-label text-danger";
            }

            
            this.purchaseOrderHeaderDropDownList.DataSource = purchaseOrderList;
            this.purchaseOrderHeaderDropDownList.DataTextField = "ShortString";
            this.purchaseOrderHeaderDropDownList.DataValueField = "PurchaseOrderID";
            this.purchaseOrderHeaderDropDownList.DataBind();

            if (purchaseOrderList.Count > 0)
            {
                this.purchaseOrderHeaderDropDownList.SelectedIndex = 0;
                this.fillPurchaseOrderControls(purchaseOrderList.First());
            }

        }

        protected void vendorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            messageLabel.Text = string.Empty;
            messageLabel.CssClass = "control-label";

            try
            {
                this.loadPurchaseOrderHeaders();
            }
            catch (Exception ex)
            {
                messageLabel.Text = ex.Message;
                messageLabel.CssClass = "control-label text-danger";
            }
        }

        protected void purchaseOrderHeaderDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            messageLabel.Text = string.Empty;
            messageLabel.CssClass = "control-label";

            try
            {
                this.loadPurchaseOrderHeader();
            }
            catch (Exception ex)
            {
                messageLabel.Text = ex.Message;
                messageLabel.CssClass = "control-label text-danger";
            }
        }

        protected void clearPurchaseOrderControls()
        {

            messageLabel.Text = string.Empty;
            messageLabel.CssClass = "control-label";

            revisionNumberTextBox.Text = string.Empty;
            statusTextBox.Text = string.Empty;
            employeeDropDownList.SelectedIndex = -1;
            orderDateCalendar.SelectedDates.Clear();
            orderDateCalendar.VisibleDate = DateTime.Now;
            shipDateCalendar.SelectedDates.Clear();
            shipDateCalendar.VisibleDate = DateTime.Now;
            shippingDropDownList.SelectedIndex = -1;
            subTotalLabel.Text = string.Empty;
            taxLabel.Text = string.Empty;
            freightTextBox.Text = string.Empty;
            totalLabel.Text = string.Empty;
        }

        protected void fillPurchaseOrderControls(PurchaseOrderHeader purchaseOrderHeader)
        {
            revisionNumberTextBox.Text = purchaseOrderHeader.RevisionNumber.ToString();
            statusTextBox.Text = purchaseOrderHeader.Status.ToString();
            employeeDropDownList.SelectedValue = purchaseOrderHeader.EmployeeID.ToString();
            orderDateCalendar.SelectedDate = purchaseOrderHeader.OrderDate;
            orderDateCalendar.VisibleDate = purchaseOrderHeader.OrderDate;    
            if (purchaseOrderHeader.ShipDate != null)
            {
                shipDateCalendar.SelectedDates.Clear();
                shipDateCalendar.VisibleDate = DateTime.Now;
            }
            shippingDropDownList.SelectedValue = purchaseOrderHeader.ShipMethodID.ToString();
            subTotalLabel.Text = purchaseOrderHeader.SubTotal.ToString("N2");
            taxLabel.Text = purchaseOrderHeader.TaxAmt.ToString("N2");
            freightTextBox.Text = purchaseOrderHeader.Freight.ToString("N2");
            totalLabel.Text = (purchaseOrderHeader.SubTotal + purchaseOrderHeader.TaxAmt + purchaseOrderHeader.Freight).ToString("N2");
        }

        protected void loadPurchaseOrderHeader()
        {
            this.clearPurchaseOrderControls();

            PurchaseOrderHeader purchaseOrderHeader = new PurchaseOrderHeader();
            int purchOrdID = Int32.Parse(purchaseOrderHeaderDropDownList.SelectedValue);
            try
            {
                purchaseOrderHeader = Company.getPurchaseOrderHeader(purchOrdID);
            }
            catch (Exception ex)
            {
                messageLabel.Text = ex.Message;
                messageLabel.CssClass = "control-label text-danger";
            }

            if (purchaseOrderHeader != null)
            {
                this.fillPurchaseOrderControls(purchaseOrderHeader);
            }

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = string.Empty;
            messageLabel.CssClass = "control-label";
           
            int purchaseOrderID = Int32.Parse(purchaseOrderHeaderDropDownList.SelectedValue);
            
            try
            {
                PurchaseOrderHeader poHeader = Company.getPurchaseOrderHeader(purchaseOrderID);

                poHeader.RevisionNumber = Byte.Parse(this.revisionNumberTextBox.Text);
                poHeader.Status = Byte.Parse(this.statusTextBox.Text);
                poHeader.EmployeeID = Int32.Parse(this.employeeDropDownList.SelectedValue);
                poHeader.OrderDate = this.orderDateCalendar.SelectedDate;
                if (shipDateCalendar.SelectedDates.Count > 0)
                {
                    poHeader.ShipDate = this.shipDateCalendar.SelectedDate;
                }                
                poHeader.ShipMethodID = Int32.Parse(this.shippingDropDownList.SelectedValue);
                poHeader.SubTotal = Decimal.Parse(this.subTotalLabel.Text);
                poHeader.TaxAmt = Decimal.Parse(this.taxLabel.Text);
                poHeader.Freight = Decimal.Parse(this.freightTextBox.Text);
                totalLabel.Text = (poHeader.SubTotal + poHeader.TaxAmt + poHeader.Freight).ToString("N2");

                int countChanges = Company.saveChanges();

                if (countChanges > 0)
                {
                    messageLabel.Text = "Update Successful";
                    messageLabel.CssClass = "control-label text-success";
                }
               
            }
            catch (Exception ex)
            {
                messageLabel.Text = ex.Message;
                messageLabel.CssClass = "control-label text-danger";
            }
                        
        }

        protected void newButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = string.Empty;
            messageLabel.CssClass = "control-label";

            clearPurchaseOrderControls();
            PurchaseOrderHeader newPOHeader = null;

            int vendID = Int32.Parse(vendorDropDownList.SelectedValue);

            try
            {
                 newPOHeader = Company.newPurchaseOrderHeader(vendID);             
            }
            catch (Exception ex)
            {
                messageLabel.Text = ex.Message + "<br />" + ex.InnerException.InnerException.Message;
                messageLabel.CssClass = "control-label text-danger";
            }

            if (newPOHeader != null)
            {
                fillPurchaseOrderControls(newPOHeader);
                purchaseOrderHeaderDropDownList.Items.Add(new ListItem(newPOHeader.ShortString, newPOHeader.PurchaseOrderID.ToString()));
                purchaseOrderHeaderDropDownList.SelectedValue = newPOHeader.PurchaseOrderID.ToString();

                messageLabel.Text = "New Purchase Order";
                messageLabel.CssClass = "control-label text-success";
            }
                
        }

        protected void removeButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = string.Empty;
            messageLabel.CssClass = "control-label";

            clearPurchaseOrderControls();
            
            int poID = Int32.Parse(purchaseOrderHeaderDropDownList.SelectedValue);
            PurchaseOrderHeader currentPurchaseOrderHeader = null;

            try
            {
                currentPurchaseOrderHeader = Company.getPurchaseOrderHeader(poID);
                int countChanges = Company.removePurchaseOrderHeader(currentPurchaseOrderHeader);

                if (countChanges > 0)
                {
                    purchaseOrderHeaderDropDownList.Items.Remove(purchaseOrderHeaderDropDownList.SelectedItem);
                    purchaseOrderHeaderDropDownList.SelectedIndex = purchaseOrderHeaderDropDownList.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {
                messageLabel.Text = ex.Message + "<br />" + ex.InnerException.InnerException.Message;
                messageLabel.CssClass = "control-label text-danger";
            }

            

            loadPurchaseOrderHeader();

            messageLabel.Text = "Purchase Order Removed";
            messageLabel.CssClass = "control-label text-success";

        }
    }
}