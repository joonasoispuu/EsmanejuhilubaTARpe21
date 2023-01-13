using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EsmaneJuhilubaTARpe21JÕ.Data;
using EsmaneJuhilubaTARpe21JÕ.Models;
using Microsoft.AspNetCore.Authorization;

namespace EsmaneJuhilubaTARpe21JÕ.Controllers
{
    public class Driving_ExamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Driving_ExamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Driving_Exam/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Driving_Exam/Register
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Firstname,Lastname,Age")] Driving_Exam Driving_Exam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Driving_Exam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Driving_School));
            }
            return View(Driving_Exam);
        }

        // POST: Driving_Exam/Ratings
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rating([Bind("Id,Rating,Driving_Test_Driving_Hours,Driving_Test_Date")] Driving_Exam tulemus)
        {

            var driving_Exam = await _context.Driving_Exam.FindAsync(tulemus.Id);
            if (driving_Exam == null)
            {
                return NotFound();
            }

            driving_Exam.Driving_Test_Driving_Hours = tulemus.Driving_Test_Driving_Hours;
            driving_Exam.Rating = tulemus.Rating;
            driving_Exam.Driving_Test_Date = tulemus.Driving_Test_Date;

            if (driving_Exam.Rating >= 5)
            {
                driving_Exam.Driving_Test = 3;
            }
            else if (driving_Exam.Rating <= 5)
            {
                driving_Exam.Driving_Test = 2;

            }

            try
                {
                _context.Update(driving_Exam);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EksamExists(driving_Exam.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Driving_Test));
        }

        // GET: Driving_Exam/Driving_School
        public async Task<IActionResult> Driving_School()
        {
            var model = _context.Driving_Exam
                .Where(e => e.Driving_School == -1);
            return View(await model.ToListAsync());
        }

        // GET: Driving_Exam/Theory_Exam
        public async Task<IActionResult> Theory_Exam()
        {
            var model = _context.Driving_Exam
                .Where(e => e.Driving_School >= 3 && e.Theory_Exam == -1);
            return View(await model.ToListAsync());
        }

        // GET: Driving_Exam/Driving_Test
        public async Task<IActionResult> Driving_Test()
        {
            var model = _context.Driving_Exam
                .Where(e => e.Theory_Exam >= 3 && e.Rating == null);
            return View(await model.ToListAsync());
        }

        public async Task<IActionResult> IssuancePermit(int id)
        {
            var Driving_Exam = await _context.Driving_Exam.FindAsync(id);
            if (Driving_Exam == null)
            {
                return NotFound();
            }

            if (Driving_Exam.Rating >= 5 & Driving_Exam.License == -1)
            {
                Driving_Exam.License = 1;
            }

            try
            {
                _context.Update(Driving_Exam);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EksamExists(Driving_Exam.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(License));
        }

        // GET: Driving_Exam/PassFail/Id
        public async Task<IActionResult> PassFail(int Id, string Partial, int Tulemus)
        {
            var Driving_Exam = await _context.Driving_Exam.FindAsync(Id);
            if (Driving_Exam == null)
            {
                return NotFound();
            }
            switch (Partial)
            {
				case nameof(Driving_Exam.Driving_School):
					{
						Driving_Exam.Driving_School = Tulemus;
						break;
					}
				case nameof(Driving_Exam.Theory_Exam):
                    {
                        Driving_Exam.Theory_Exam = Tulemus;
                        break;
                    }
                case nameof(Driving_Exam.Driving_Test):
                    {
                        Driving_Exam.Driving_Test = Tulemus;
                        break;
                    }
                default:
                    {
                        return NotFound();
                    }
            }
            try
            {
                _context.Update(Driving_Exam);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EksamExists(Driving_Exam.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(Partial);
        }

        public async Task<IActionResult> driving_test_results()
        {
            return View(await _context.Driving_Exam.ToListAsync());
        }

        // GET: Driving_Exam/License
        public async Task<IActionResult> License()
        {
            var model = _context.Driving_Exam.Select(e =>
            new Driving_LicenseViewModel()
            {
                Id = e.Id,
                Firstname = e.Firstname,
                Lastname = e.Lastname,
                Driving_School = e.Driving_School == -1 ? "." : e.Driving_School == 2 ? "Põrus" : "Õnnestus",
				Theory_Exam = e.Theory_Exam == -1 ? "." : e.Theory_Exam == 2 ? "Põrus" : "Õnnestus",
                Driving_Test = e.Driving_Test == -1 ? "." : e.Driving_Test == 2 ? "Põrus" : "Õnnestus",
                License = e.License == -1 ? "Väljasta" : e.Driving_Test == 1 ? "ERROR" : "Väljastatud",
            });

            return View(await model.ToListAsync());
        }


        // GET: Driving_Exam
        public async Task<IActionResult> Index()
        {
            return View(await _context.Driving_Exam.ToListAsync());
        }

        [Authorize]
        // GET: Driving_Exam/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Driving_Exam = await _context.Driving_Exam
                            .FirstOrDefaultAsync(m => m.Id == id);
            if (Driving_Exam == null)
            {
                return NotFound();
            }

            return View(Driving_Exam);
        }

        [Authorize]
        // GET: Driving_Exam/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Driving_Exam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstname,Lastname,Driving_School,Theory_Exam,Driving_Test,License")] Driving_Exam Driving_Exam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Driving_Exam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(License));
            }
            return View(Driving_Exam);
        }

        [Authorize]
        // GET: Driving_Exam/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Driving_Exam = await _context.Driving_Exam.FindAsync(id);
            if (Driving_Exam == null)
            {
                return NotFound();
            }
            return View(Driving_Exam);
        }

        // POST: Driving_Exam/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstname,Lastname,Driving_School,Theory_Exam,Driving_Test,License")] Driving_Exam Driving_Exam)
        {
            if (id != Driving_Exam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Driving_Exam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EksamExists(Driving_Exam.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(License));
            }
            return View(Driving_Exam);
        }

        [Authorize]
        // GET: Driving_Exam/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Driving_Exam = await _context.Driving_Exam
                            .FirstOrDefaultAsync(m => m.Id == id);
            if (Driving_Exam == null)
            {
                return NotFound();
            }

            return View(Driving_Exam);
        }

        // POST: Driving_Exam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Driving_Exam = await _context.Driving_Exam.FindAsync(id);
            _context.Driving_Exam.Remove(Driving_Exam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(License));
        }

        private bool EksamExists(int id)
        {
            return _context.Driving_Exam.Any(e => e.Id == id);
        }
    }
}

