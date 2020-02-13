﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAutosClasses
{
    public class ClsOrder
    {
        private int pOrderID;
        private int pCustomerID;
        private String pCardID;
        private int pPaymentID;
        private DateTime pDateOfOrder;
        private String pServiceID;
        private double pOrderPrice;
        private String pOrderStatus;
        private Boolean pCompleted;
        public int OrderID 
        {
            get 
            {
                return pOrderID;
            }
            set
            {
                pOrderID = value;
            }
        }
        public int CustomerID 
        { 
            get 
            {
                return pCustomerID;
            } 
            set 
            {
                pCustomerID = value;
            } 
        }
        public String CarID 
        { 
            get 
            {
                return pCardID;
            }
            set
            {
                pCardID = value;
            } 
        }
        public DateTime DateOfOrder 
        {
            get 
            {
                return pDateOfOrder;          
            } 
            set 
            {
                pDateOfOrder = value;   
            } 
        }
        public String ServiceID 
        {
            get 
            {
                return pServiceID;
            } 
            set 
            {
                pServiceID = value;       
            } 
        }
        public double OrderPrice 
        {
            get 
            {
                return pOrderPrice;
            } 
            set 
            {
                pOrderPrice = value;
            } 
        }
        public String OrderStatus 
        {
            get 
            {
                return pOrderStatus;
            }
            set 
            {
                pOrderStatus = value;
            } 
        }
        public int PaymentID 
        {
            get 
            {
                return pPaymentID;
            } 
            set 
            {
                pPaymentID = value;
            } 
        }
        public bool Completed 
        {
            get 
            {
                return pCompleted;
            } 
            set 
            {
                pCompleted = value;   
            } 
        }

        public bool Find(int OrderID)
        {
            //pOrderID = 1;
            //pCustomerID = 1;
            //pCardID = "MP04XTT";
            //pPaymentID = 1;
            //pDateOfOrder = DateTime.Now.Date;
            //pServiceID = "MOT";
            //pOrderPrice = 20.5;
            //pOrderStatus = "Completed";
            //pCompleted = true;
            //return true;
            // Create a new database connection instance.
            clsDataConnection DB = new clsDataConnection();
            // Add the parameter for the Order ID to search for.
            DB.AddParameter("@OrderID", OrderID);
            // Execute the stored procedure
            DB.Execute("dbo.tblOrders_FilterByOrderID");
            // If one record is found (there should be either one or zero)
            if (DB.Count == 1)
            {
                pOrderID = Convert.ToInt32(DB.DataTable.Rows[0]["OrderID"]);
                pCustomerID = Convert.ToInt32(DB.DataTable.Rows[0]["CustomerID"]);
                pCardID = Convert.ToString(DB.DataTable.Rows[0]["NumberPlate"]);
                pPaymentID = Convert.ToInt32(DB.DataTable.Rows[0]["PaymentID"]);
                DateOfOrder = Convert.ToDateTime(DB.DataTable.Rows[0]["DateOfOrder"]);
                pServiceID = Convert.ToString(DB.DataTable.Rows[0]["ServiceID"]);
                pOrderPrice = Convert.ToDouble(DB.DataTable.Rows[0]["OrderPrice"]);
                pOrderStatus = Convert.ToString(DB.DataTable.Rows[0]["OrderStatus"]);
                pCompleted = Convert.ToBoolean(DB.DataTable.Rows[0]["Completed"]);
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}