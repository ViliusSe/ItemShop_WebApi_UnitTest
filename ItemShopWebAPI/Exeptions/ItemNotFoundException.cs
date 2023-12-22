namespace _20231220_EntityFrameworkCore_ItemShop_WebApi.Exeptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() : base ("Item not found"){}
    }
}
