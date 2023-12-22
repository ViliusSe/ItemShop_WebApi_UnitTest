using _20231220_EntityFrameworkCore_ItemShop_WebApi.Dtos;
using _20231220_EntityFrameworkCore_ItemShop_WebApi.Exeptions;
using _20231220_EntityFrameworkCore_ItemShop_WebApi.Models;
using _20231220_EntityFrameworkCore_ItemShop_WebApi.Models.Dtos;
using _20231220_EntityFrameworkCore_ItemShop_WebApi.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace _20231220_EntityFrameworkCore_ItemShop_WebApi.Services
{
    public class ItemService
    {

        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemEntity>> Index()
        {
            var result = await _itemRepository.Index();

            if (result == null)
                throw new NotFoundException();

            return result;
        }

        public async Task<ItemEntity> Index(int id)
        {
            var result = await _itemRepository.Index(id);

            if (result == null)
                throw new ItemNotFoundException();
            return result;
        }

        public async Task Create(CreateItemDto item)
        {
            ItemEntity itemEntity = _mapper.Map<ItemEntity>(item);

           var result =  await _itemRepository.Create(itemEntity);
            
            if (result == 0)
                throw new CanNotCreateItemExeptio();            
        }

        public async Task Update(PutItemDto item)
        {
            ItemEntity itemEntity = _mapper.Map<ItemEntity>(item);

            var result = await _itemRepository.Update(itemEntity);
            if (result == 0)
            {
                throw new ItemNotFoundException();
            }
        }

        public async Task Delete(DeleteItemeDto item)
        {
            var itemEntity = new ItemEntity
            {
                Id = item.Id
            };

            if (itemEntity == null)
                throw new Exception("No Item found to be deleted");

            try
            {
                await _itemRepository.Delete(itemEntity);
            }
            catch
            {
                throw new Exception("Can't delete Item with such Id");
            }
        }

        public async Task<double> Buy(int amount, int id)
        {
            ItemEntity? item = await _itemRepository.Index(id);

            if (amount > 20)
            {
                item.Price = item.Price * 0.8;
            }
            else if (amount > 10)
            {
                item.Price = item.Price * 0.9;
            }
            return amount * item.Price;
        }
    }
}
