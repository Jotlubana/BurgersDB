using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgersDB.Data;
using BurgersDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurgersDB.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext adbc;
        public OrdersController(ApplicationDbContext db)
        {
            adbc = db;
        }
        //get list of all the orfers and retun to view
        public IActionResult Orders()
        {
            try
            {
                var orders = adbc.TOrders.ToList();
                return View(orders);
            }catch(Exception)
            {
                return View();
            }
        }
        // add new order
        public IActionResult AddNew(Order o)
        {
            return View(o);
        }
        // http post add new order
        [HttpPost]
        public async Task<IActionResult> AddOrder(Order o)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (o.OId == 0)
                    {
                        adbc.Add(o);
                        await adbc.SaveChangesAsync();
                    }
                    else
                    {
                        adbc.Update(o);
                        await adbc.SaveChangesAsync();
                    }
                    return RedirectToAction("Orders");
                }
                return View(o);
            }
            catch (Exception)
            {
                return RedirectToAction("Orders");
            }
        }
        // delete an order by using id
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var o = await adbc.TOrders.FindAsync(id);
                if (o != null)
                {
                    adbc.Remove(o);
                    await adbc.SaveChangesAsync();
                }
                return RedirectToAction("Orders");
            }
            catch (Exception)
            {
                return RedirectToAction("Orders");
            }
        }
    }
}
