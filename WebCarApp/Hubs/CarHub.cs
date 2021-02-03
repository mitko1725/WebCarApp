using Microsoft.AspNetCore.SignalR;
using WebCarApp.Services.Interfaces;

namespace WebCarApp.Web.Hubs
{
    public class CarHub : Hub
    {
        private readonly ICarService _car;
        public CarHub(ICarService car)
        {
            _car = car;
        }
    }
}
