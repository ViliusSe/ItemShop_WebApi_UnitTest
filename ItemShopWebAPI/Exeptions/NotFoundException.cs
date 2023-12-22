namespace _20231220_EntityFrameworkCore_ItemShop_WebApi.Exeptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base ("No Items found"){ }
    }
}
