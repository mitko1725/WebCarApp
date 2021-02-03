using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCarApp.Services.Models.Clients;

namespace WebCarApp.Web.Models.ClientModels
{
    public class AllClientsViewModel
    {

        public IEnumerable<ClientListingServiceModel> Clients { get; set; }
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

        public string SortOrder { get; set; }
    }
}
