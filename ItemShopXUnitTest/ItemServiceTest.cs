using _20231220_EntityFrameworkCore_ItemShop_WebApi.Exeptions;
using _20231220_EntityFrameworkCore_ItemShop_WebApi.Mappers;
using _20231220_EntityFrameworkCore_ItemShop_WebApi.Models;
using _20231220_EntityFrameworkCore_ItemShop_WebApi.Repositories;
using _20231220_EntityFrameworkCore_ItemShop_WebApi.Services;
using AutoMapper;
using FluentAssertions;
using Moq;

namespace _20231220_EntityFrameworkCore_ItemShop_WebApi.temShopXUnitTest
{
    public class ItemServiceTest
    {

        private readonly Mock<IItemRepository> _itemRepositoryMock;
        private readonly IMapper _mapper;

        public ItemServiceTest()
        {
            _itemRepositoryMock = new Mock<IItemRepository>();
            _mapper = new Mapper(
                new MapperConfiguration(
                    cfg => cfg.AddProfile<MappersClass>())
                );
        }

        [Fact]
        public async Task IndexById_GivenValidId_ReturnsDto()
        {
            //Arrange
            int id = 1;
            _itemRepositoryMock.Setup(m => m.Index(id)).ReturnsAsync(
                new ItemEntity()
                {
                    Id = id
                });

            var itemService = new ItemService(_itemRepositoryMock.Object, _mapper);

            //Act
            var result = await itemService.Index(id);

            //Assert
            result.Id.Should().Be(id);
        }


        [Fact]
        public async Task IndexById_GivenInvalidId_ThrowsItemNotFoundException()
        {
            // Arrange
            int id = 1;
            _itemRepositoryMock.Setup(m => m.Index(id)).Returns(Task.FromResult<ItemEntity>(null));

            var todoService = new ItemService(_itemRepositoryMock.Object, _mapper);

            // Act Assert
            await Assert.ThrowsAsync<ItemNotFoundException>(async () => await todoService.Index(id));
        }

        [Fact]
        public async Task Index_Correct_ReturnsListItems()
        {
            // Arrange
            var testRepository = new Mock<IItemRepository>();
            testRepository.Setup(m => m.Index()).ReturnsAsync(new List<ItemEntity>());

            var itemService = new ItemService(_itemRepositoryMock.Object, _mapper);

            //Act
            var result = await itemService.Index();

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Index_Incorrect_ThrowsNotFoundException()
        {
            // Arrange
            _itemRepositoryMock.Setup(m => m.Index()).Returns(Task.FromResult<IEnumerable<ItemEntity>>(null));

            var todoService = new ItemService(_itemRepositoryMock.Object, _mapper);

            // Act Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await todoService.Index());
        }

        //[Fact]
        //public async Task Create_Success_ReturnInt()
        //{
        //    int success = 1;
        //    // Arrange
        //    var testRepository = new Mock<IItemRepository>();
        //    testRepository.Setup(m => m.Create()).ReturnsAsync(new List<ItemEntity>());

        //    var itemService = new ItemService(_itemRepositoryMock.Object, _mapper);

        //    //Act
        //    var result = await itemService.Index();

        //    //Assert
        //    result.Should().NotBeNull();
        //}
    }
}