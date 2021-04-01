using FoodApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodApp.Models
{
    public class Kocsi
    {
        private readonly ApplicationDbContext _context;
        private Kocsi(ApplicationDbContext DbContext)
        {
            _context = DbContext;
        }
        public string KocsiId { get; set; }
        public List<KocsiItem> KocsiItems { get; set; }

        //static függvény hogy mindenki csak a saját kocsiját lássa
        public static Kocsi GetKocsi(IServiceProvider services)
        {

            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();
            // ha nincs id kreál egyet
            var cartId = session.GetString("KocsiId") ?? Guid.NewGuid().ToString();

            session.SetString("KocsiId", cartId);
            //visszadjuk a kocsit vagy az ujat vagy a már meglévőt
            return new Kocsi(context) { KocsiId = cartId };
        }
        public void AddToCart(Etlap etel, int db)
        {
            var KocsiItem = _context.KocsiItem.SingleOrDefault(s => s.Etel.ID == etel.ID && s.KocsiId == KocsiId);
            if (KocsiItem == null)
            {
                KocsiItem = new KocsiItem
                {
                    KocsiId = KocsiId,
                    Etel = etel,
                    Darab = 1
                };
                _context.KocsiItem.Add(KocsiItem);
            }
            else
            {
                KocsiItem.Darab++;
            }
            _context.SaveChanges();
        }
        public int RemoveFromKocsi(Etlap etel)
        {
            var KocsiItem = _context.KocsiItem.SingleOrDefault(s => s.Etel.ID == etel.ID && s.KocsiId == KocsiId);
            var localAmount = 0;
            if(KocsiItem != null)
            {
                if (KocsiItem.Darab > 1)
                {
                    KocsiItem.Darab--;
                    localAmount = KocsiItem.Darab;
                }
                else
                {
                    _context.KocsiItem.Remove(KocsiItem);
                }
            }
            _context.SaveChanges();
            return localAmount;
        }
        public List<KocsiItem> GetKocsiItems()
        {
            return KocsiItems ?? (KocsiItems = _context.KocsiItem.Where(c => c.KocsiId == KocsiId).Include(s => s.Etel).ToList());
        }
        public void ClearKocsi()
        {
            var kocsiItems = _context.KocsiItem.Where(cart => cart.KocsiId == KocsiId);
            _context.KocsiItem.RemoveRange(kocsiItems);
            _context.SaveChanges();
        }
        public int GetTotal()
        {
            var total = _context.KocsiItem.Where(c => c.KocsiId == KocsiId).Select(c => c.Etel.Ar * c.Darab).Sum();
            return total;
        }
    }
}
