using System;
using System.Collections.Generic;
using System.Text;

namespace sumplierapp.Model
{
    public class Ticket
    {
        public int id { get; set; }
        public long ticketCode { get; set; }
        public long companyCode { get; set; }
        public long accountCode { get; set; }
        public string accountName { get; set; }
        public long resellerCode { get; set; }
        public long customerCode { get; set; }
        public long userCode { get; set; }
        public DateTime createDateTime { get; set; }
        public DateTime modifiedDateTime { get; set; }
        public decimal total { get; set; }
        public decimal taxTotal { get; set; }
        public decimal discountTotal { get; set; }
        public decimal generalTotal { get; set; }
        public string paymentType { get; set; }
        public string description { get; set; }
        public int status { get; set; }
        public string deviceCode { get; set; }
        public string statusName { get; set; }
        public int paymentStatus { get; set; }
        public bool isDeleted { get; set; }
        public List<TicketOrder> ticketOrders { get; set; } = new List<TicketOrder>();
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
        public bool? isDeleted { get; set; }
        public int rowId { get; set; }
    }
}
