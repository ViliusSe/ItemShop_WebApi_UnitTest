namespace _20231220_EntityFrameworkCore_ItemShop_WebApi.Exeptions
{
    public class CanNotCreateItemExeptio : Exception
    {
        public CanNotCreateItemExeptio() : base("Can't create Item") { }
    }
}
