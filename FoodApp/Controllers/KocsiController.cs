using FoodApp.Data;
using FoodApp.Models;
using FoodApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Controllers
{
    public class KocsiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Kocsi _kocsi;

        public KocsiController(ApplicationDbContext context, Kocsi kocsi)
        {
            _context = context;
            _kocsi = kocsi;
        }
        public RedirectToActionResult UresKocsi()
        {
            return RedirectToAction("Index", new { alert = "alert alert-warning alert-dismissible show" });
        }
        public ViewResult Index(string alert)
        {
            var items = _kocsi.GetKocsiItems();
            _kocsi.KocsiItems = items;
            var kocsiVM = new KocsiViewModel
            {
                kocsi = _kocsi,
                kocsiTotal = _kocsi.GetTotal()
            };
            ViewBag.AlertClass = alert;
            return View(kocsiVM);
        }
        public RedirectToActionResult AddtoKocsi(int id)
        {
            var etel = _context.Etlap.Find(id);
            if (etel != null) 
            {
                _kocsi.AddToCart(etel, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult DeleteFromKocsi(int id)
        {
            var etel = _context.Etlap.Find(id);
            if (etel != null)
            {
                _kocsi.RemoveFromKocsi(etel);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult DeleteAll(int id)
        {
            var etel = _context.Etlap.Find(id);
            if (etel != null)
            {
                _kocsi.RemoveAllFromKocsi(etel);
            }
            return RedirectToAction("Index");
        }
    }
}
