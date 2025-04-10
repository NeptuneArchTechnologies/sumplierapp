using System;
using System.Collections.Generic;
using System.Text;

namespace sumplierapp.Model
{
    public class Ticket
    {
        public int id { get; set; }
        public int ticketCode { get; set; }
        public int companyCode { get; set; }
        public int accountCode { get; set; }
        public string accountName { get; set; }
        public int resellerCode { get; set; }
        public int customerCode { get; set; }
        public int userCode { get; set; }
        public DateTime createDateTime { get; set; }
        public DateTime modifiedDateTime { get; set; }
        public int total { get; set; }
        public int taxTotal { get; set; }
        public int discountTotal { get; set; }
        public int generalTotal { get; set; }
        public string paymentType { get; set; }
        public string description { get; set; }
        public int status { get; set; }
        public string deviceCode { get; set; }
        public string statusName { get; set; }
        public int paymentStatus { get; set; }
        public bool isDeleted { get; set; }
        public List<TicketOrder> ticketOrders { get; set; }
    }

    public class TicketOrder
    {
        public int id { get; set; }
        public int ticketId { get; set; }
        public long productCode { get; set; }
        public string barcode { get; set; }
        public string productName { get; set; }
        public decimal quantity { get; set; }
        public decimal price { get; set; }
        public decimal discountPrice { get; set; }
        public decimal totalPrice { get; set; }
        public int status { get; set; }
        public bool isChange { get; set; }
        public decimal newQuantity { get; set; }
        public decimal newPrice { get; set; }
        public decimal newTotalPrice { get; set; }
        public long companyCode { get; set; }
        public string deviceCode { get; set; }
        public bool isDeleted { get; set; }
    }
}
