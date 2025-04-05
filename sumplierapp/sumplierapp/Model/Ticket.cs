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
        public int productCode { get; set; }
        public string barcode { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int discountPrice { get; set; }
        public int totalPrice { get; set; }
        public int status { get; set; }
        public bool isChange { get; set; }
        public int newQuantity { get; set; }
        public int newPrice { get; set; }
        public int newTotalPrice { get; set; }
        public int companyCode { get; set; }
        public string deviceCode { get; set; }
        public bool isDeleted { get; set; }
    }
}
