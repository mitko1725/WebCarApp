using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCarApp.Services.Models.Clients;

namespace WebCarApp.Services.Interfaces
{
  public  interface IClientService
    {
        public  IEnumerable<ClientListingServiceModel> AllClients(int page = 1,string sortOrder="");
        public int Total();
        void Create(CreateClientServiceModel model);
        void Edit(EditClientServiceModel model);
        public ClientDetailsServiceModel FindByEGN(string EGN);
        public IEnumerable<ClientOrdersServiceModel> FindAllOrders(int Id);
        public ClientDetailsServiceModel FindById(int id);
        public bool IsThereClient(string egn);
        public IEnumerable<ModelsForClientSelectServiceModel> GetClientData();
    }
}
