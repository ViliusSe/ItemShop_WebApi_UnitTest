using _20231220_EntityFrameworkCore_ItemShop_WebApi.Cotext;
using Microsoft.EntityFrameworkCore;
using _20231220_EntityFrameworkCore_ItemShop_WebApi.Models;

namespace _20231220_EntityFrameworkCore_ItemShop_WebApi.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemEntityContext _dataContext;

        public ItemRepository(ItemEntityContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<ItemEntity>> Index()
        {
            return await _dataContext.ItemEntity.ToListAsync();
        }

        public async Task<ItemEntity?> Index(int id)
        {
            return await _dataContext.ItemEntity.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<int> Create(ItemEntity item)
        {
            _dataContext.ItemEntity.Add(item);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<int> Update(ItemEntity item)
        {
            _dataContext.Update(item);
           return await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(ItemEntity item)
        {
            _dataContext.Remove(item);
            await _dataContext.SaveChangesAsync();
        }
    }
}
