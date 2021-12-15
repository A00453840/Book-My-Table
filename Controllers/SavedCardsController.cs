using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Book_My_Table.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Book_My_Table.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace Book_My_Table.Controllers
{
    [Authorize]
    public class SavedCardsController : Controller
    {
        private UserManager<Book_My_TableUser> _userManager;
        private readonly CustomerReg _context;
        //private int bookingId;

        public SavedCardsController(CustomerReg context, UserManager<Book_My_TableUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: SavedCards
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            string userId = user.Id;
            var cards = from s in _context.SavedCard
                        select s;
            if (!String.IsNullOrEmpty(userId))
            {
                cards = cards.Where(s => s.CustomerId.Contains(userId));
            }
            return View(await cards.AsNoTracking().ToListAsync());
            //return View(await _context.SavedCard.ToListAsync());
        }

        // GET: SavedCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedCard = await _context.SavedCard
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (savedCard == null)
            {
                return NotFound();
            }

            return View(savedCard);
        }

        // GET: SavedCards/Create
        public IActionResult Create()
        {
            return View();
        }

        public class CardValidateAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value,
                ValidationContext validationContext)
            {
                var savCard = (SavedCard)validationContext.ObjectInstance;
                String cardTyp = savCard.CardType;
                var cardNumber = value.ToString();

                string GetErrorMessage() => $"Enter a valid {cardTyp} card number";

                if (cardTyp.Equals("Amex"))
                {
                    if ((cardNumber.Substring(0, 2).Equals("34")|| cardNumber.Substring(0, 2).Equals("37"))&& cardNumber.Length == 15)
                    { return ValidationResult.Success; }
                    else return new ValidationResult(GetErrorMessage());
                }
                else if (cardTyp.Equals("Visa"))
                {
                    if (cardNumber.Substring(0, 1).Equals("4") && cardNumber.Length == 16)
                    { return ValidationResult.Success; }
                    else return new ValidationResult(GetErrorMessage());
                }
                else
                {
                    if ((cardNumber.Substring(0, 2).Equals("51")|| cardNumber.Substring(0, 2).Equals("52")|| cardNumber.Substring(0, 2).Equals("53"))|| cardNumber.Substring(0, 2).Equals("54")|| cardNumber.Substring(0, 2).Equals("55") && cardNumber.Length == 15)
                    { return ValidationResult.Success; }
                    else return new ValidationResult(GetErrorMessage());
                }

            }
        }

        public class DateValidateAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime d = Convert.ToDateTime(value);
                if ((d.Year < 2016) || (d.Year > 2031) || (d.Month > 12) || (d.Month < 1))
                    return false;
                return d >= DateTime.Now;

            }
        }

        // POST: SavedCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int Bid,[Bind("CardNumber,ExpiryDate,CVV,CardType,NameOnCard")] SavedCard savedCard)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = Bid;
                var user = await _userManager.GetUserAsync(User);
                savedCard.CustomerId = user.Id;

                _context.Add(savedCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(savedCard);
        }

        // GET: SavedCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedCard = await _context.SavedCard.FindAsync(id);
            if (savedCard == null)
            {
                return NotFound();
            }
            return View(savedCard);
        }

        // POST: SavedCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardId,CardNumber,ExpiryDate,CVV,CustomerId")] SavedCard savedCard)
        {
            if (id != savedCard.CardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(savedCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SavedCardExists(savedCard.CardId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(savedCard);
        }

        // GET: SavedCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedCard = await _context.SavedCard
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (savedCard == null)
            {
                return NotFound();
            }

            return View(savedCard);
        }

        // POST: SavedCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var savedCard = await _context.SavedCard.FindAsync(id);
            _context.SavedCard.Remove(savedCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SavedCardExists(int id)
        {
            return _context.SavedCard.Any(e => e.CardId == id);
        }
    }
}
