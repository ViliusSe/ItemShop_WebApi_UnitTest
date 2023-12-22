namespace _20231220_EntityFrameworkCore_ItemShop_WebApi.Exeptions
{
    public class CreateItemException : Exception
    {
        public CreateItemException(string e) : base("Can't create new Item. " + e) { }
    }
}
