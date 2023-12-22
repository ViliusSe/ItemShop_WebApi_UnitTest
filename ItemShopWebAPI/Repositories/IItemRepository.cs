//repository is creating for testing reasons

using _20231220_EntityFrameworkCore_ItemShop_WebApi.Models;

namespace _20231220_EntityFrameworkCore_ItemShop_WebApi.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemEntity>> Index();
        Task<ItemEntity?> Index(int id);
        Task<int> Create(ItemEntity item);
        Task<int> Update(ItemEntity item);
        Task Delete(ItemEntity item);
    }
}
