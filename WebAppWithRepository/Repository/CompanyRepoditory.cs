using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppWithRepository.Data;
using WebAppWithRepository.Models;

namespace WebAppWithRepository.Repository
{
    public class CompanyRepoditory : ICompanyRepoditory
    {
        private readonly ApplicationDb _db;
        public CompanyRepoditory(ApplicationDb db)
        {
            _db = db;
        }
        public Company Add(Company company)
        {
            _db.companies.Add(company);
            _db.SaveChanges();
            return (company);
        }

        public Company Find(int id)
        {
            return _db.companies.FirstOrDefault(u => u.CompanyId == id);
        }

        public List<Company> GetAll()
        {
            return _db.companies.ToList();
        }

        public void Remove(int id)
        {
            Company company = _db.companies.FirstOrDefault(u => u.CompanyId == id);
            _db.companies.Remove(company);
            _db.SaveChanges();
            return;
        }

        public Company Update(Company company)
        {
            _db.companies.Update(company);
            _db.SaveChanges();
            return (company);
        }
    }
}
