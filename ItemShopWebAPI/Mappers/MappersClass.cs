using _20231220_EntityFrameworkCore_ItemShop_WebApi.Dtos;
using _20231220_EntityFrameworkCore_ItemShop_WebApi.Models;
using _20231220_EntityFrameworkCore_ItemShop_WebApi.Models.Dtos;
using AutoMapper;

namespace _20231220_EntityFrameworkCore_ItemShop_WebApi.Mappers
{
    public class MappersClass : Profile
    {
        public MappersClass()
        {
            CreateMap<CreateItemDto, ItemEntity>().ReverseMap();
            
            CreateMap<PutItemDto, ItemEntity>().ReverseMap();

        }
    }
}
