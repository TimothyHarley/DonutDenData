using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DonutDenData.Data;
using DonutDenData.Models;
using DonutDenData.Validators;

namespace DonutDenData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly OrdersRepository _ordersRepository;
        readonly MenuItemRepository _menuItemRepository;
        readonly OrderItemsRepository _orderItemsRepository;
        readonly OrdersRequestValidator _validator;

        public OrdersController()
        {
            _ordersRepository = new OrdersRepository();
            _menuItemRepository = new MenuItemRepository();
            _orderItemsRepository = new OrderItemsRepository();
            _validator = new OrdersRequestValidator();
        }

        [HttpGet("order-date/{date}")]
        public ActionResult GetOrdersByDate(DateTime date)
        {
            return Ok(_ordersRepository.GetOrdersByDate(date));
        }

        [HttpGet("order-sum/{date}")]
        public ActionResult GetOrdersSum(DateTime date)
        {
            return Ok(_ordersRepository.GetOrdersSum(date));
        }

        [HttpGet("{id}")]
        public ActionResult GetSingleOrder(int id)
        {
            return Ok(_ordersRepository.GetSingleOrder(id));
        }

        [HttpPost]
        public ActionResult AddOrder(CreateOrderRequest createRequest)
        {
            if (!_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "Please fill the whole form" });
            }
            var newOrder = _ordersRepository.AddOrder(createRequest);

            return Created($"api/orders/{newOrder.Id}", newOrder);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, Orders orderToUpdate)
        {
            if (id != orderToUpdate.Id)
            {
                return BadRequest(new { error = "There was an id mixup with your update" });
            }
            var updatedOrder = _ordersRepository.UpdateOrder(orderToUpdate);

            return Ok(updatedOrder);
        }

        [HttpPut("delete-order/{id}")]
        public ActionResult DeleteOrder(int id)
        {
            _ordersRepository.DeleteOrder(id);

            return Ok("Deleted Order");
        }
    }
}