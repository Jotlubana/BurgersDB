using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgersDB.Data;
using BurgersDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurgersDB.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _appDb;
        public ClientsController(ApplicationDbContext dbc)
        {
            _appDb = dbc;
        }
        public IActionResult Clients()
        {
            try
            {
                var clients = _appDb.TClients.ToList();
                return View(clients);
            }
            catch (Exception)
            {

                return View();

            }
        }
        // adds or edits new burger
        public IActionResult AddNew(Client c)
        {
            return View(c);
        }

        // adds or edits burger based on burger id and redirects burgers view
        [HttpPost]
        public async Task<IActionResult> AddClient(Client c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (c.CID == 0)
                    {
                        _appDb.Add(c);
                        await _appDb.SaveChangesAsync();
                    }
                    else
                    {
                        _appDb.Update(c);
                        await _appDb.SaveChangesAsync();
                    }
                    return RedirectToAction("Clients");
                }
                return View(c);
            }
            catch (Exception)
            {

                return RedirectToAction("Clients");
            }
        }

        // deletes a burger and redirects to burgers view
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var c = await _appDb.TClients.FindAsync(id);
                if (c != null)
                {
                    _appDb.TClients.Remove(c);
                    await _appDb.SaveChangesAsync();
                }
                return RedirectToAction("Clients");
            }
            catch (Exception)
            {
                return RedirectToAction("Clients");
            }
        }
    }
}
