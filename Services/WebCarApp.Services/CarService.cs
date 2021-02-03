using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCarApp.Data;
using WebCarApp.Models;
using WebCarApp.Services.Interfaces;
using WebCarApp.Services.Models.Car;
using WebCarApp.Services.Models.Engine;
using WebCarApp.Services.Models.Make;
using WebCarApp.Services.Models.Model;

namespace WebCarApp.Services
{
    public class CarService : ICarService
    {
        private readonly CarDbContex data;



        public CarService(CarDbContex data)
        {
            this.data = data;
        }





        public void Create(CreateCarServiceModel model)
        {
            if (model.Color == null || model.EngineId == 0 || model.ModelId == 0 || model.VIN == "" || model.Price == 0 || model.ProductionDate.Year < 1991)
            {
                throw new ArgumentException("Invalid Input data");
            }
           
            if (data.Cars.Any(x => x.VIN == model.VIN))
            {
                throw new ArgumentException("Cannot Insert car with Same VIN");
            }
            var car = new Car()
            {

                ProductionDate = model.ProductionDate,
                VIN = model.VIN,
                Price = model.Price,
                Color = model.Color,
                ModelId = model.ModelId,
                EngineId = model.EngineId
            };
            this.data.Add(car);
            this.data.SaveChanges();
        }

        public IEnumerable<CarListingServiceModel> AllAvaiable(int page = 1)
        {

            return this.data.Cars.AsNoTracking()
       .Where(x => x.IsSold == IsSold.No)
       .Skip((page - 1) * 20)
        .Take(20)
       .Select(c => new CarListingServiceModel
       {
           Id = c.Id,
           Model = c.Model.Name,
           Make = c.Model.Make.Name,
           CubicCentimeters = c.Engine.CubicCentimeters,
           HorsePower = c.Engine.HorsePower,
           ModelYear = c.Model.Year,
           IsSold = c.IsSold

       })
       .ToList();



        }
        /// <summary>
        /// Add Make this Car back in list with AJAX!!!
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public IEnumerable<CarListingServiceModel> AllSold(int page = 1)
        {
            //Take??

            return this.data.Cars
                  .Skip((page - 1) * 20)
                 .Select(c => new CarListingServiceModel
                 {
                     Id = c.Id,
                     Model = c.Model.Name,
                     Make = c.Model.Make.Name,
                     CubicCentimeters = c.Engine.CubicCentimeters,
                     HorsePower = c.Engine.HorsePower,
                     ModelYear = c.Model.Year,
                     IsSold = c.IsSold

                 })
                 .Where(x => x.IsSold == IsSold.Yes)
              .AsNoTracking()
                 .ToList();
        }

        public int TotalAvaiable()
        => this.data.Cars.Where(x => x.IsSold == IsSold.No).Count();

        public int TotalSold()
        => this.data.Cars.Where(x => x.IsSold == IsSold.Yes).Count();

        public IEnumerable<ModelsForCarAddSelectServiceModel> ModelsForCarSelect()
        => this.data.Models
            .AsNoTracking()
            .Select(x => new ModelsForCarAddSelectServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                Year = x.Year,
                MakeName = x.Make.Name
            })
            .ToList();

        public IEnumerable<EnginesForCarAddSelectServiceModel> EnginesForCarSelect()
        => this.data.Engines.Select(x => new EnginesForCarAddSelectServiceModel
        {
            Id = x.Id,
            HorsePower = x.HorsePower,
            CubicCentimeters = x.CubicCentimeters,
            Transmisson = x.Transmission,
            FuelType = x.FuelType
        }).AsNoTracking().ToList();

        public FullCarDetailsServiceModel GetById(int id)
        {

            var car = this.data.Cars.Find(id);
            if (car == null)
            {
                throw new ArgumentException("Cannot find car with such Id");
            }
            Model modelForCar = this.data.Models.Where(x => x.Id == car.ModelId).FirstOrDefault();
            Make makeForCar = this.data.Makes.Where(x => x.Id == modelForCar.MakeId).FirstOrDefault();
            Engine engineForCar = this.data.Engines.Where(x => x.Id == car.EngineId).FirstOrDefault();
            var fcsm = new FullCarDetailsServiceModel()
            {
                Model = modelForCar.Name,
                Make = makeForCar.Name,
                VIN = car.VIN,
                Color = car.Color,
                Price = car.Price,
                ProductionDate = car.ProductionDate,
                Kilowatt = engineForCar.Kilowatt,
                Tranmission = engineForCar.Transmission,
                FuelType = engineForCar.FuelType,
                HorsePower = engineForCar.HorsePower,
                CubicCentimeters = engineForCar.CubicCentimeters,
                ModelYear = modelForCar.Year

            };
            return fcsm;
        }

        public IEnumerable<AllCarsByMakeServiceModel> SearchCarByMake(string makeName)
        {


            return this.data.Cars
                .AsNoTracking()

                .Select(c => new AllCarsByMakeServiceModel
                {
                    Id = c.Id,
                    Model = c.Model.Name,
                    Make = c.Model.Make.Name,
                    CubicCentimeters = c.Engine.CubicCentimeters,
                    HorsePower = c.Engine.HorsePower,
                    ModelYear = c.Model.Year

                })
                .Where(x => x.Make.ToLower().Contains(makeName.ToLower().Trim()))
                .ToList();
        }

        public bool IsThereCarMake(string makeName)
        => this.data.Cars.Any(x => x.Model.Make.Name.ToLower().Contains(makeName.ToLower().Trim()));
        /// <summary>
        /// GetCarData is for WebCarApp - API
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModelsForCarGetServiceModel> GetCarData()
       => this.data.Cars
           .AsNoTracking()
           .Select(x => new ModelsForCarGetServiceModel
           {
               Id = x.Id,
               ProductionDate = x.ProductionDate,
               VIN = x.VIN,
               Price = x.Price,
               Color = x.Color,
               ModelId = x.ModelId,
               EngineId = x.EngineId
           })
           .ToList();

        public Dictionary<string,string> FillCarDataForAPI(int id, string carDataId, string carDataPD,
            string carDataVIN, string carDataPrice, string carDataColor, string carDataModelId, string carDataEngineId)
        {
            var car = this.data.Cars.AsNoTracking().FirstOrDefault(x=>x.Id==id);
           
            var dict = new Dictionary<string, string>();
            if (id == 0)
            {
                throw new NullReferenceException("Invalid Id.");
            }
            var filteredData = new ModelsForCarGetServiceModel();
            if (carDataId!=null)
            {
                dict["CarId"] = car.Id.ToString();

            }
            if (carDataPD!=null)
            {
                dict["Production Date"] = car.ProductionDate.ToString();

            }
            if (carDataVIN!=null)
            {
                dict["VIN"] = car.VIN.ToString();

            }
            if (carDataPrice!=null)
            {
                dict["Purchase Price"] = car.Price.ToString();

            }
            if (carDataColor!=null)
            {
                dict["Color"] = car.Color.ToString();

            }
            if (carDataModelId!=null)
            {
                dict["ModelId"] = car.ModelId.ToString();

            }
            if (carDataEngineId != null)
            {
                dict["EngineId"] = car.EngineId.ToString();

            }

            return dict;


        }
      
    }
}

