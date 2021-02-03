using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCarApp.Data;
using WebCarApp.Models;
using WebCarApp.Services.Interfaces;
using WebCarApp.Services.Models.Clients;

namespace WebCarApp.Services
{
    public class ClientService : IClientService
    {
        private readonly CarDbContex data;



        public ClientService(CarDbContex data)
        {
            this.data = data;
        }

        public IEnumerable<ClientListingServiceModel> AllClients(int page = 1, string sortOrder = "")
        {
            IQueryable<ClientListingServiceModel> result = null;
            result = MakeSorting(sortOrder);

            return result
                .Skip((page - 1) * 20)
                .Take(20)
                .ToList();
        }

        private IQueryable<ClientListingServiceModel> MakeSorting(string sortOrder)
        {
            IQueryable<ClientListingServiceModel> result;
            switch (sortOrder)
            {
                case "IdSortParmDesc":
                    result = this.data.Clients
                .AsNoTracking()
                .Select(c => new ClientListingServiceModel
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    EGN = c.EGN,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber
                }).OrderByDescending(x => x.Id);
                    break;
                case "IdSortParmAsc":
                    result = this.data.Clients
               .AsNoTracking()
               .Select(c => new ClientListingServiceModel
               {
                   Id = c.Id,
                   FirstName = c.FirstName,
                   LastName = c.LastName,
                   EGN = c.EGN,
                   Email = c.Email,
                   PhoneNumber = c.PhoneNumber
               }).OrderBy(x => x.Id);
                    break;
                case "NameAsc":
                    result = this.data.Clients
               .AsNoTracking()
               .Select(c => new ClientListingServiceModel
               {
                   Id = c.Id,
                   FirstName = c.FirstName,
                   LastName = c.LastName,
                   EGN = c.EGN,
                   Email = c.Email,
                   PhoneNumber = c.PhoneNumber
               }).OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
                    break;
                case "NameDesc":
                    result = this.data.Clients
               .AsNoTracking()
               .Select(c => new ClientListingServiceModel
               {
                   Id = c.Id,
                   FirstName = c.FirstName,
                   LastName = c.LastName,
                   EGN = c.EGN,
                   Email = c.Email,
                   PhoneNumber = c.PhoneNumber
               }).OrderByDescending(x => x.FirstName).ThenBy(x => x.LastName);
                    break;
                case "EgnAsc":
                    result = this.data.Clients
               .AsNoTracking()
               .Select(c => new ClientListingServiceModel
               {
                   Id = c.Id,
                   FirstName = c.FirstName,
                   LastName = c.LastName,
                   EGN = c.EGN,
                   Email = c.Email,
                   PhoneNumber = c.PhoneNumber
               }).OrderBy(x => x.EGN);
                    break;
                case "EgnDesc":
                    result = this.data.Clients
              .AsNoTracking()
              .Select(c => new ClientListingServiceModel
              {
                  Id = c.Id,
                  FirstName = c.FirstName,
                  LastName = c.LastName,
                  EGN = c.EGN,
                  Email = c.Email,
                  PhoneNumber = c.PhoneNumber
              }).OrderByDescending(x => x.EGN);
                    break;

                default:
                    result = this.data.Clients
              .AsNoTracking()
              .Select(c => new ClientListingServiceModel
              {
                  Id = c.Id,
                  FirstName = c.FirstName,
                  LastName = c.LastName,
                  EGN = c.EGN,
                  Email = c.Email,
                  PhoneNumber = c.PhoneNumber
              });
                    break;
            }

            return result;
        }

        public void Create(CreateClientServiceModel model)
        {
            if (string.IsNullOrEmpty(model.EGN) ||
                string.IsNullOrEmpty(model.Email) ||
                string.IsNullOrEmpty(model.FirstName) ||
                string.IsNullOrEmpty(model.LastName) ||
                string.IsNullOrEmpty(model.PhoneNumber))
            {
                throw new ArgumentException("Invalid Input data");
            }
            if (data.Clients.Any(x => x.EGN == model.EGN))
            {
                throw new ArgumentException("Cannot Insert car with Same VIN");
            }
            var client = new Client()
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                EGN = model.EGN,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email

            };
            this.data.Add(client);
            this.data.SaveChanges();
        }

        public void Edit(EditClientServiceModel model)
        {

            var client = data.Clients.Find(model.Id);
            if (string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.Email) ||
                string.IsNullOrEmpty(model.LastName) || string.IsNullOrEmpty(model.PhoneNumber)
                || string.IsNullOrEmpty(model.EGN))
            {
                throw new Exception("Must add a value");
            }

            var allClients = data.Clients.AsNoTracking().ToList();
            // check if there is client with same EGN, Email or Phone Number
            for (int i = 0; i < data.Clients.Count(); i++)
            {

                if (allClients[i].EGN == model.EGN && model.Id != allClients[i].Id)
                {
                    throw new ArgumentException("This EGN is already used by another client");
                }
                else if (allClients[i].PhoneNumber == model.PhoneNumber && model.Id != allClients[i].Id)
                {
                    throw new ArgumentException("This Phone number is already used by another client");
                }
                else if (allClients[i].Email == model.Email && model.Id != allClients[i].Id)
                {
                    throw new ArgumentException("This Email is already used by another client");
                }



            }

            client.FirstName = model.FirstName;
            client.LastName = model.LastName;

            client.EGN = model.EGN;

            client.Email = model.Email;
            client.PhoneNumber = model.PhoneNumber;
            this.data.SaveChanges();

        }

        public IEnumerable<ClientOrdersServiceModel> FindAllOrders(int Id)
        {
            var client = this.data.Clients.Where(x => x.Id == Id).AsNoTracking().FirstOrDefault();


            var clientOrdersData = this.data.Orders
                .Where(x => x.ClientId == Id)
                .Select(x => new ClientOrdersServiceModel
                {

                    OrderNumber = x.OrderNumber.ToString(),
                    CarMake = x.Car.Model.Make.Name,
                    CarModel = x.Car.Model.Name,
                    PurchaseDate = x.PurchaseDate,
                    OrderStatus = x.OrderStatus,


                })
                .AsNoTracking().ToList();
            return clientOrdersData;
        }

        public ClientDetailsServiceModel FindByEGN(string egn)
        {
            var findClient = this.data.Clients.Where(x => x.EGN.StartsWith(egn)).FirstOrDefault();
            if (findClient == null)
            {

                throw new ArgumentException("There is no such client with that EGN");
            }
            var currClient = new ClientDetailsServiceModel
            {
                Id = findClient.Id,
                FirstName = findClient.FirstName,
                LastName = findClient.LastName,
                Email = findClient.Email,
                EGN = findClient.EGN,
                PhoneNumber = findClient.PhoneNumber


            };
            return currClient;
        }

        public ClientDetailsServiceModel FindById(int id)
        {
            var findClient = this.data.Clients.Find(id);
            if (findClient == null)
            {
                throw new ArgumentException("There is no such client with that Id");
            }
            var currClient = new ClientDetailsServiceModel
            {
                Id = findClient.Id,
                FirstName = findClient.FirstName,
                LastName = findClient.LastName,
                Email = findClient.Email,
                EGN = findClient.EGN,
                PhoneNumber = findClient.PhoneNumber


            };
            return currClient;
        }

        public int Total()
           => this.data.Clients.Count();
        public bool IsThereClient(string egn)
            => this.data.Clients.Any(x => x.EGN.ToLower().StartsWith(egn.ToLower().Trim()));

        public IEnumerable<ModelsForClientSelectServiceModel> GetClientData()
        => this.data.Clients
            .AsNoTracking()
            .Select(x => new ModelsForClientSelectServiceModel
        {
            ID = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            EGN = x.EGN,
            PhoneNumber = x.PhoneNumber,
            Email = x.Email
        })
            .ToList();
    }
}
