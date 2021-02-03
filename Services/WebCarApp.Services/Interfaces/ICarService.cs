using System.Collections.Generic;
using WebCarApp.Services.Models.Car;
using WebCarApp.Services.Models.Model;
using WebCarApp.Services.Models.Engine;
namespace WebCarApp.Services.Interfaces
{
   public interface ICarService
    {
     public  IEnumerable<CarListingServiceModel> AllAvaiable(int page=1);
     public  IEnumerable<CarListingServiceModel> AllSold(int page=1);
        public int TotalAvaiable();
        public int TotalSold();
       

        void Create(CreateCarServiceModel model);
        public IEnumerable<ModelsForCarAddSelectServiceModel> ModelsForCarSelect();
        public IEnumerable<EnginesForCarAddSelectServiceModel> EnginesForCarSelect();
        public FullCarDetailsServiceModel GetById(int id);

        public IEnumerable<AllCarsByMakeServiceModel> SearchCarByMake(string makeName);
        public bool IsThereCarMake(string makeName);
        public IEnumerable<ModelsForCarGetServiceModel> GetCarData();

        public Dictionary<string,string> FillCarDataForAPI(int id, string carDataId, string carDataPD,
            string carDataVIN, string carDataPrice, string carDataColor, string carDataModelId, string carDataEngineId);

    }
}
