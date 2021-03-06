using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColmanBookStore.Models;
using ColmanBookStore.Data;

namespace ColmanBookStore.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly BookStoreContext _context;

        public StatisticsController(BookStoreContext context)
        {
            _context = context;
        }

        public ActionResult MostOrderedProduct()
        {
            var amountOfProductsSold = _context.OrderItems
                .Include(order => order.Product)
                .GroupBy(Order => Order.Product)
                .Select(o => new GraphData
                {
                    Name = o.Key.Name,
                    Value = o.Sum(order => order.Quantity)
                })
                .OrderByDescending(o => o.Value)
                .ToList();

            return Json(amountOfProductsSold);
        }

        public ActionResult CategoriesGraph()
        {

            var sellesbyCategories = _context.OrderItems
                .Join(_context.Products,
                order => order.Product.ID,
                product => product.ID,
                (order, product) => new {
                    product = product,
                    order = order
                }).Join(_context.Categories,
                order => order.product.Category.ID,
                category => category.ID,
                (order, category) => new {
                    order = order.order,
                    product = order.product,
                    category = category
                })
                .GroupBy(x => x.category)
                .Select(o => new GraphData
                {
                    Name = o.Key.Name,
                    Value = o.Sum(order => order.order.Quantity)
                })
                .ToList();

            return Json(sellesbyCategories);
        }

        public ActionResult SumOrdersPerMonthGraph()
        {
            var sellesbyCategories = _context.OrderItems
                .Join(_context.Products,
                order => order.Product.ID,
                product => product.ID,
                (orderItem, product) => new {
                    product = product,
                    orderItem = orderItem
                }).Join(_context.Orders,
                orderDetails => orderDetails.orderItem.Order.Id,
                order => order.Id,
                (orderDetails, order) => new {
                    orderItem = orderDetails.orderItem,
                    product = orderDetails.product,
                    order = order
                })
                .GroupBy(x => x.order.OrderDate.ToString("MM-yyyy"))
                .Select(o => new GraphData
                {
                    Name = o.Key.ToString(),
                    Value = o.Sum(order => order.orderItem.Quantity * order.product.Price)
                })
                .ToList();

            return Json(sellesbyCategories);
        }


        public ActionResult OrderStatusGraph()
        {
            var ordersByStatus = _context.Orders
                .Join(_context.OrderStatuses,
                order => order.Status.ID,
                status => status.ID,
                (order, status) => new {
                    order = order,
                    status = status
                })
                .GroupBy(x => x.status)
                .Select(o => new GraphData
                {
                    Name = o.Key.Name,
                    Value = o.Count()
                })
                .ToList();

            return Json(ordersByStatus);
        }
    }
}
