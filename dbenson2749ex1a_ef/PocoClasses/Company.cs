using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbenson2749ex1a_ef.Model
{
    public class Company
    {
        private static AdventureWorksEFEntities dbContext = new AdventureWorksEFEntities();

        public static List<Vendor> getVendors()
        {
            List<Vendor> vendorList = new List<Vendor>();
            
            try
            {
                vendorList =
                    (from vendor in dbContext.Vendors
                     orderby vendor.Name
                     select vendor).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vendorList;
        }

        public static List<ShipMethod> getShipMethods()
        {
            List<ShipMethod> shipMethodList = new List<ShipMethod>();

            try
            {
                shipMethodList =
                    (from ship in dbContext.ShipMethods
                     orderby ship.Name
                     select ship).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return shipMethodList;
        }

        public static List<Employee> getEmployees()
        {
            List<Employee> employeeList = new List<Employee>();

            try
            {
                employeeList =
                    (from emp in dbContext.Employees.Include("Person")
                     orderby emp.Person.LastName, emp.Person.FirstName
                     select emp).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return employeeList;
        }

        public static List<PurchaseOrderHeader> getPurchaseOrderHeaders(int vendorID)
        {
            List<PurchaseOrderHeader> purchaseOrderHeaderList = new List<PurchaseOrderHeader>();

            try
            {
                purchaseOrderHeaderList =
                    (from po in dbContext.PurchaseOrderHeaders
                     orderby po.PurchaseOrderID
                     where po.VendorID == vendorID
                     select po).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return purchaseOrderHeaderList;
        }

        public static PurchaseOrderHeader getPurchaseOrderHeader (int purchaseOrderID)
        {
            PurchaseOrderHeader purchaseOrderHeader = new PurchaseOrderHeader();

            try
            {
                purchaseOrderHeader =
                    (from po in dbContext.PurchaseOrderHeaders
                     orderby po.PurchaseOrderID
                     where po.PurchaseOrderID == purchaseOrderID
                     select po).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return purchaseOrderHeader;
        }

        public static int saveChanges ()
        {
            int countChanges = 0;
            try
            {
                countChanges = dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return countChanges;

        }

        public static PurchaseOrderHeader newPurchaseOrderHeader (int vendorID)
        {
            PurchaseOrderHeader newPOHeader = dbContext.PurchaseOrderHeaders.Create();

            //Set default properties
            newPOHeader.RevisionNumber = (byte)0;
            newPOHeader.Status = (byte)1;
            newPOHeader.EmployeeID = 258; // First item in drop down list (Bad Idea)
            newPOHeader.OrderDate = DateTime.Now;
            newPOHeader.VendorID = vendorID;
            newPOHeader.ShipMethodID = 5;
            newPOHeader.SubTotal = 0m;
            newPOHeader.TaxAmt = 0m;
            newPOHeader.Freight = 0m;
            newPOHeader.ModifiedDate = DateTime.Now;

            dbContext.PurchaseOrderHeaders.Add(newPOHeader);

            try
            {
                int countChanges = Company.saveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return newPOHeader;
        }

        public static int removePurchaseOrderHeader (PurchaseOrderHeader purchaseOrderHeader)
        {
            dbContext.PurchaseOrderHeaders.Remove(purchaseOrderHeader);

            int countChanges = -1;
            try
            {              
                countChanges = Company.saveChanges();
            }
            catch (Exception ex)
            {

            }
            return countChanges;
        }
    }
}
