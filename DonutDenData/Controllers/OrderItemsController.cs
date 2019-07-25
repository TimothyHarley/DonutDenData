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
    public class OrderItemsController : ControllerBase
    {
        readonly OrderItemsRepository _orderItemsRepository;
        readonly OrderItemRequestValidator _validator;

        public OrderItemsController()
        {
            _orderItemsRepository = new OrderItemsRepository();
            _validator = new OrderItemRequestValidator();
        }

        [HttpGet("{id}")]
        public ActionResult GetSingleOrderItem(int id)
        {
            return Ok(_orderItemsRepository.GetSingleOrderItem(id));
        }

        [HttpGet("order/{id}")]
        public ActionResult GetByOrderId(int id)
        {
            return Ok(_orderItemsRepository.GetByOrderId(id));
        }

        [HttpPost]
        public ActionResult AddOrderItem(CreateOrderItemRequest createOrderItem)
        {
            if (!_validator.Validate(createOrderItem))
            {
                return BadRequest(new { error = "empty spots on form" });
            }
            var newOrderItem = _orderItemsRepository.AddOrderItem(createOrderItem);

            return Created($"api/orderItems/{newOrderItem.Id}", newOrderItem);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrderItem(int id, OrderItem orderItemToUpdate)
        {
            if (id != orderItemToUpdate.Id)
            {
                return BadRequest(new { error = "There was a mixup in the update" });
            }
            var updatedOrderItem = _orderItemsRepository.UpdateOrderItem(orderItemToUpdate);

            return Ok(updatedOrderItem);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrderItem(int id)
        {
            _orderItemsRepository.DeleteOrderItem(id);

            return NoContent();
        }
    }
}