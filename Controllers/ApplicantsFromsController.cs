using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicantsFromProject.Models;

namespace NewFormsProject.Controllers
{
    public class ApplicantsFromsController : Controller
    {
        private readonly DBFormsContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public ApplicantsFromsController(DBFormsContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        //// GET: ApplicantsFroms
        //public async Task<IActionResult> Index()
        //{
        //    var dBFormsContext = _context.ApplicantsFroms.Include(a => a.Faculty).Include(a => a.Governorate).Include(a => a.Speciality).Include(a => a.University);
        //    return View(await dBFormsContext.ToListAsync());
        //}

        //// GET: ApplicantsFroms/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.ApplicantsFroms == null)
        //    {
        //        return NotFound();
        //    }

        //    var applicantsFrom = await _context.ApplicantsFroms
        //        .Include(a => a.Faculty)
        //        .Include(a => a.Governorate)
        //        .Include(a => a.Speciality)
        //        .Include(a => a.University)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (applicantsFrom == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(applicantsFrom);
        //}

        // GET: ApplicantsFroms/Create
        public IActionResult Create()
        {
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name");
            ViewData["GovernorateId"] = new SelectList(_context.Governorates, "Id", "Name");
            ViewData["SpecialityId"] = new SelectList(_context.Specialities, "Id", "Name");
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Name");
            return View();
        }

        // POST: ApplicantsFroms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicantsFrom applicantsFrom)
        {
            if (ModelState.IsValid)
            {
                var filePath = await UploadPhotoAsync(applicantsFrom.CVFile);
                if (filePath != null)
                {
                    applicantsFrom.CV = $"Files/CVs/{filePath}";
                    _context.Add(applicantsFrom);
                    await _context.SaveChangesAsync();
                    ViewBag.SuccessMessage = "Your Application submitted successfully.";

                    return View(new ApplicantsFrom());
                        //RedirectToAction(nameof(Create));

                }
                else
                {
                    ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name", applicantsFrom.FacultyId);
                    ViewData["GovernorateId"] = new SelectList(_context.Governorates, "Id", "Name", applicantsFrom.GovernorateId);
                    ViewData["SpecialityId"] = new SelectList(_context.Specialities, "Id", "Name", applicantsFrom.SpecialityId);
                    ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Name", applicantsFrom.UniversityId);
                    return View(applicantsFrom);
                }

            }
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name", applicantsFrom.FacultyId);
            ViewData["GovernorateId"] = new SelectList(_context.Governorates, "Id", "Name", applicantsFrom.GovernorateId);
            ViewData["SpecialityId"] = new SelectList(_context.Specialities, "Id", "Name", applicantsFrom.SpecialityId);
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Name", applicantsFrom.UniversityId);
            return View(applicantsFrom);
        }


        async Task<string?> UploadPhotoAsync(IFormFile CVFile)
        {
            if (CVFile != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Files/CVs");
                string uniqueFileName = Guid.NewGuid() + ".pdf";
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await CVFile.CopyToAsync(fileStream);
                }

                return uniqueFileName;
            }
            return null;
        }


        //// GET: ApplicantsFroms/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.ApplicantsFroms == null)
        //    {
        //        return NotFound();
        //    }

        //    var applicantsFrom = await _context.ApplicantsFroms.FindAsync(id);
        //    if (applicantsFrom == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Id", applicantsFrom.FacultyId);
        //    ViewData["GovernorateId"] = new SelectList(_context.Governorates, "Id", "Id", applicantsFrom.GovernorateId);
        //    ViewData["SpecialityId"] = new SelectList(_context.Specialities, "Id", "Id", applicantsFrom.SpecialityId);
        //    ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Id", applicantsFrom.UniversityId);
        //    return View(applicantsFrom);
        //}

        //// POST: ApplicantsFroms/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,GovernorateId,FacultyId,UniversityId,Name_En,Mobile,Github_Link,LinkedIn_Link,ITI_Graduate,year_Of_Graduation,Graduation_Year,Current_Company,Current_Salary,Expected_Salary,Availability_Date,Interested_Working_In_Cairo,Mobile_Apps_Experience,E_Commerce_Apps_Experience,CV,SpecialityId")] ApplicantsFrom applicantsFrom)
        //{
        //    if (id != applicantsFrom.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(applicantsFrom);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ApplicantsFromExists(applicantsFrom.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Id", applicantsFrom.FacultyId);
        //    ViewData["GovernorateId"] = new SelectList(_context.Governorates, "Id", "Id", applicantsFrom.GovernorateId);
        //    ViewData["SpecialityId"] = new SelectList(_context.Specialities, "Id", "Id", applicantsFrom.SpecialityId);
        //    ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Id", applicantsFrom.UniversityId);
        //    return View(applicantsFrom);
        //}

        //// GET: ApplicantsFroms/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.ApplicantsFroms == null)
        //    {
        //        return NotFound();
        //    }

        //    var applicantsFrom = await _context.ApplicantsFroms
        //        .Include(a => a.Faculty)
        //        .Include(a => a.Governorate)
        //        .Include(a => a.Speciality)
        //        .Include(a => a.University)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (applicantsFrom == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(applicantsFrom);
        //}

        //// POST: ApplicantsFroms/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.ApplicantsFroms == null)
        //    {
        //        return Problem("Entity set 'DBFormsContext.ApplicantsFroms'  is null.");
        //    }
        //    var applicantsFrom = await _context.ApplicantsFroms.FindAsync(id);
        //    if (applicantsFrom != null)
        //    {
        //        _context.ApplicantsFroms.Remove(applicantsFrom);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ApplicantsFromExists(int id)
        //{
        //  return (_context.ApplicantsFroms?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
