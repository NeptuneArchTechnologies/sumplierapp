using sumplierapp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace sumplierapp.BasketManager
{
    public class BasketOrderManagers
    {
        private static BasketOrderManagers _instance;
        public static BasketOrderManagers Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BasketOrderManagers();
                return _instance;
            }
        }
        public ObservableCollection<TicketOrder> BasketOrders { get; private set; }
        public BasketOrderManagers()
        {
            BasketOrders = new ObservableCollection<TicketOrder>();
        }
        public void AddTicketOrder(TicketOrder order)
        {
            BasketOrders.Add(order);
        }
        public void UpdateTicketOrder(TicketOrder updatedOrder)
        {
            var existing = BasketOrders.FirstOrDefault(x => x.id == updatedOrder.id);
            if (existing != null)
            {
                existing.id = updatedOrder.id;
                existing.productCode = updatedOrder.productCode;
                existing.barcode = updatedOrder.barcode;
                existing.productName = updatedOrder.productName;
                existing.quantity = updatedOrder.quantity;
                existing.price = updatedOrder.price;
                existing.discountPrice = updatedOrder.discountPrice;
                existing.totalPrice = updatedOrder.totalPrice;
                existing.status = updatedOrder.status;
                existing.isChange = updatedOrder.isChange;
                existing.newQuantity = updatedOrder.newQuantity;
                existing.newPrice = updatedOrder.newPrice;
                existing.newTotalPrice = updatedOrder.newTotalPrice;
                existing.companyCode = updatedOrder.companyCode;
                existing.deviceCode = updatedOrder.deviceCode;
                existing.isDeleted = updatedOrder.isDeleted;
            }
        }
        public void DeleteTicketOrderRowId(int rowId)
        {
            var existing = BasketOrders.FirstOrDefault(x => x.rowId == rowId);
            if (existing != null)
            {
                BasketOrders.Remove(existing);
            }
        }
        public void ClearAll()
        {
            BasketOrders.Clear();
        }
        public List<TicketOrder> GetTicketOrder()
        {
            return BasketOrders.ToList();
        }
    }
}
