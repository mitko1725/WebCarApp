using System;
using System.Collections.Generic;
using System.Text;

using WebCarApp.Services.Models.Orders;

namespace WebCarApp.Services.Interfaces
{
   public interface IOrderService
    {
        public IEnumerable<OrderListingServiceModel> AllOrders(int page = 1,string sortOrder="");

        public int Total();
        public IEnumerable<CarsForOrderListingServiceModel> CarsForOrderSelect();
        public IEnumerable<ClientsForOrderListingServiceModel> ClientsForOrderSelect();
        public void Create(CreateOrderServiceModel model);
        public FullOrderDetailsServiceModel GetByOrderNumber(string orderNumber);
        public OrderPurchasePriceAndDate GetInfoForOrderDetails(string id);
        public bool IsThereOrderNumber(string orderNumber);

        public  IEnumerable<ModelsForOrderServiceModel> GetOrderData();
        public Dictionary<string,string> OrderDataForAPI(string orderNumber,bool carId, bool clinetId,bool purchaseDate,bool orderStatus,bool orderNumberCheck,bool purchasePrice);

    }
}
