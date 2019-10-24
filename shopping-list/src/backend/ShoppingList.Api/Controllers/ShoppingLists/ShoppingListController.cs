namespace ShoppingList.Api.Controllers.ShoppingLists
{
    using System.Threading.Tasks;
    using Domain.ShoppingLists.AddList;
    using Domain.ShoppingLists.AddProductByName;
    using Domain.ShoppingLists.GetAllLists;
    using Domain.ShoppingLists.GetListById;
    using Domain.ShoppingLists.RenameList;
    using Domain.ShoppingLists.SetAsAlreadyBought;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/shopping-lists")]
    public class ShoppingListController : Controller
    {
        private readonly IMediator _mediator;

        public ShoppingListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetAllListsResponse> GetAll() => await _mediator.Send(new GetAllListsQuery());

        [HttpGet]
        [Route("{id}")]
        public async Task<GetListByIdResponse> GetById(int id) => await _mediator.Send(new GetListByIdQuery(id));

        [HttpPost]
        public async Task AddList(AddListCommand command) => await _mediator.Send(command);

        [HttpPut]
        [Route("")]
        public async Task RenameList(RenameListCommand command) => await _mediator.Send(command);

        [HttpPost]
        [Route("product")]
        public async Task AddProductByName(AddProductByNameCommand command) => await _mediator.Send(command);

        [HttpPut]
        [Route("setItemAsAlreadyBought")]
        public async Task SetAsAlreadyBought(SetAsAlreadyBoughtCommand command) => await _mediator.Send(command);
    }
}