using _20231220_EntityFrameworkCore_ItemShop_WebApi.Dtos;
using _20231220_EntityFrameworkCore_ItemShop_WebApi.Models.Dtos;
using _20231220_EntityFrameworkCore_ItemShop_WebApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace _20231220_EntityFrameworkCore_ItemShop_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;
        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _itemService.Index());
        }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id) 
        {
            return Ok(await _itemService.Index(id));
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateItemDto item)
        {
            await _itemService.Create(item);
            return Created();
        }


        [HttpPut]
        public async Task<IActionResult> Update(PutItemDto item)
        {
            await _itemService.Update(item);
            return Created();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeleteItemeDto item)
        {
            await _itemService.Delete(item);
            return NoContent();
        }


        [HttpGet("{id}/{amount}/Buy")]
        public async Task<IActionResult> Buy(int id, int amount)
        {
           
            return Ok( await _itemService.Buy(amount, id));
        }
    }
}
