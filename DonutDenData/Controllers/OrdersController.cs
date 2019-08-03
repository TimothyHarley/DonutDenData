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

        //[HttpPost]
        //public ActionResult CreateOrder(CreateOrderRequest createRequest)
        //{

        //    var newOrder = _ordersRepository.AddOrder(createRequest);
        //    if (newOrder == null)
        //    {
        //        return NotFound();
        //    }
        //    // For each object in the array of objects called OrderLines
        //    // Each object has productId and Quantity
        //    foreach (var orderItem in createRequest.OrderItems)
        //    {
        //        // Gets all the information for a single product since an ID is passed in
        //        var menuItem = _menuItemRepository.GetSingleMenuItem(orderItem.ItemId);
        //        // For the OrdersItem table 
        //        orderItem.OrderId = newOrder.Id;
        //        // Also for the OrderItem table
        //        orderItem.UnitPrice = menuItem.Price;
        //        // Now that the orderItem has all the required fields we're passing it into a method that inserts it into the OrdersLine table
        //        var orderLineItem = _orderItemsRepository.AddOrderItem(orderItem);
        //    }

        //    return Created($"api/orders/{newOrder.Id}", newOrder);
        //}

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