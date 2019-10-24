namespace ShoppingList.Domain.Tests.ShoppingLists.GetListById
{
    using System.Collections.Generic;
    using AutoMapper;
    using Domain.ShoppingLists;
    using Domain.ShoppingLists.GetListById;
    using FluentAssertions;
    using NUnit.Framework;

    public class ShoppingListToGetListByIdResponseMapperTests
    {
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            var configuration = new MapperConfiguration(m => m.AddProfile<ShoppingListMapProfile>());
            _mapper = new Mapper(configuration);
        }

        [Test]
        public void Can_Map_From_ShoppingList_To_GetListByIdResponse()
        {
            // arrange
            var shoppingList = new ShoppingList
            {
                Id = 1,
                Name = "Test list",
                Items = new List<ShoppingListItem>
                {
                    new ShoppingListItem(1, 1)
                    {
                        Id = 1,
                        AlreadyBought = false,
                        Product = new Product
                        {
                            Id = 10,
                            Name = "First product"
                        }
                    },
                    new ShoppingListItem(1, 2)
                    {
                        Id = 2,
                        AlreadyBought = true,
                        Product = new Product
                        {
                            Id = 20,
                            Name = "Second product"
                        }
                    }
                }
            };

            // act
            var result = _mapper.Map<GetListByIdResponse>(shoppingList);

            // assert
            var expectedResult = new GetListByIdResponse
            {
                ShoppingListName = "Test list",
                Items = new List<GetListByIdItem>
                {
                    new GetListByIdItem
                    {
                        ItemId = 1,
                        AlreadyBought = false,
                        ProductName = "First product"
                    },
                    new GetListByIdItem
                    {
                        ItemId = 2,
                        AlreadyBought = true,
                        ProductName = "Second product"
                    }
                }
            };

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}