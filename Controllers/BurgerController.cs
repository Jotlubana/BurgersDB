using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgersDB.Data;
using BurgersDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurgersDB.Controllers
{
    // burger controller class 
    public class BurgerController : Controller
    {
        private readonly ApplicationDbContext _Db;
        public BurgerController(ApplicationDbContext Db)
        {
            _Db = Db;
        }
        // action shows all burgers on burgers page
        public IActionResult Burgers()
        {
            try
            {
                var burgers = _Db.burgers.ToList();
                return View(burgers);
            }
            catch (Exception)
            {
                 return View();
            }
        }
        // adds or edits new burger
        public IActionResult AddNew(Burger burger)
        {
            return View(burger);
        }
        // adds or edits burger based on burger id and redirects burgers view
        [HttpPost]
        public async Task<IActionResult> AddBurger(Burger burger)
        {
            try
            {
               if(ModelState.IsValid)
                {
                    if(burger.BurgerId==0)
                    {
                        _Db.Add(burger);
                        await _Db.SaveChangesAsync();
                    }else
                    {
                        _Db.Update(burger);
                        await _Db.SaveChangesAsync();
                    }
                    return RedirectToAction("Burgers");
                }
                return View(burger);
            }
            catch (Exception)
            {

                return RedirectToAction("Burgers");
            }
        }
        // deletes a burger and redirects to burgers view
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var burger = await _Db.burgers.FindAsync(id);
                if(burger!=null)
                {
                    _Db.burgers.Remove(burger);
                    await _Db.SaveChangesAsync();
                }
                return RedirectToAction("Burgers");
            }
            catch (Exception)
            {
                return RedirectToAction("Burgers");
            }
        }
    }
}
