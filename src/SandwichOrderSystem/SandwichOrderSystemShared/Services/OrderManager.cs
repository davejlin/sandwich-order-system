using SandwichOrderSystemShared.Models;

namespace SandwichOrderSystemShared.Services
{
    public class OrderManager : IOrderManager
    {
        public IOrders Orders { get; set; }
    }
}
