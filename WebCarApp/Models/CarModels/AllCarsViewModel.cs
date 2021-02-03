using System;
using System.Collections.Generic;


using WebCarApp.Services.Models.Car;

namespace WebCarApp.Models.CarModels
{
    public class AllCarsViewModel
    {
        public IEnumerable<CarListingServiceModel> Cars { get; set; }
        public int CurrentPage { get; set; }
        public int Total { get; set; }
        public int PreviousPage => this.CurrentPage - 1;
        public int NextPage => this.CurrentPage + 1;

        public bool PreviousDisabled => this.CurrentPage == 1;

        public int MaxPage => (int)Math.Ceiling((double)this.Total / 20);
        public bool NextDisabled
        {
            get
            {
                var maxPage = Math.Ceiling((double)this.Total / 20);
                return maxPage == this.CurrentPage;
            }
        }

    }
}
