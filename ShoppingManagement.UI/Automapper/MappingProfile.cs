using AutoMapper;
using ShoppingManagement.Domain;
using ShoppingManagement.UI.DTO;

namespace ShoppingManagement.UI.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Inventory, InventoryDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
        }
    }
}
