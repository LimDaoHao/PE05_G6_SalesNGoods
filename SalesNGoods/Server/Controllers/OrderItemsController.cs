using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesNGoods.Server.Data;
using SalesNGoods.Shared.Domain;
using SalesNGoods.Server.IRepository;

namespace SalesNGoods.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public OrderItemsController(ApplicationDbContext context)
        public OrderItemsController(IUnitOfWork unitOfWork)
        {
            //Refactored
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/OrderItems
        [HttpGet]
        //Refactored
        // public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        public async Task<IActionResult> GetOrderItems()
        {
            //Refactored
            //return await _context.OrderItems.ToListAsync();
            var orderitems = await _unitOfWork.OrderItems.GetAll(includes: q => q.Include(x => x.Product).Include(x => x.Order));
            return Ok(orderitems);
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItem(int id)
        {
            //Refactored
            //var orderitem = await _context.OrderItems.FindAsync(id);
            var orderitem = await _unitOfWork.OrderItems.Get(q => q.Id == id);

            if (orderitem == null)
            {
                return NotFound();
            }

            //Refactored
            //return orderitem;
            return Ok(orderitem);
        }

        // PUT: api/OrderItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(int id, OrderItem orderitem)
        {
            if (id != orderitem.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(orderitem).State = EntityState.Modified;
            _unitOfWork.OrderItems.Update(orderitem);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!OrderItemExists(id))
                if (!await OrderItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem orderitem)
        {
            //Refactored
            //_context.OrderItems.Add(orderitem);
            //await _context.SaveChangesAsync();
            await _unitOfWork.OrderItems.Insert(orderitem);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetOrderItem", new { id = orderitem.Id }, orderitem);
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            //Refactored
            //var orderitem = await _context.OrderItems.FindAsync(id);
            var orderitem = await _unitOfWork.OrderItems.Get(q => q.Id == id);
            if (orderitem == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.OrderItems.Remove(orderitem);
            //await _context.SaveChangesAsync();
            await _unitOfWork.OrderItems.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored    
        //private bool OrderItemExists(int id)
        private async Task<bool> OrderItemExists(int id)
        {
            //Refactored
            //return _context.OrderItems.Any(e => e.Id == id);
            var orderitem = await _unitOfWork.OrderItems.Get(q => q.Id == id);
            return orderitem != null;
        }

    }
}
