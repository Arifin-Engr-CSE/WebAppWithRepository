using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppWithRepository.Models;
using WebAppWithRepository.Data;
using WebAppWithRepository.Repository;

namespace WebAppWithRepository.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICompanyRepoditory _repo;
        public HomeController(ICompanyRepoditory repo)
        {
            _repo = repo;
        }


        public async Task<IActionResult>  Index()
        {
            return View(_repo.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,ComapnyName,City")]Company company)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(company);

                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }
        public async Task<IActionResult>  Edit(int ? id)
        {
            if (id==null)
            {
               return NotFound();
            }
            var company = _repo.Find(id.GetValueOrDefault());
            if (company==null)
            {
                return NotFound();

            }
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Edit(int id,[Bind("CompanyId,ComapnyName,City")] Company company)
        {
            if (id !=company.CompanyId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _repo.Update(company);

                return RedirectToAction(nameof(Index));
            }


            return View();
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            _repo.Remove(id.GetValueOrDefault());
            return RedirectToAction(nameof(Index));
        }
    }
}
