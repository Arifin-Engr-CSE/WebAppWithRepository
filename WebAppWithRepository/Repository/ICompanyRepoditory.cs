using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppWithRepository.Models;

namespace WebAppWithRepository.Repository
{
    public interface ICompanyRepoditory
    {
        
           Company Find(int id);
        List<Company> GetAll();
        Company Add(Company company);
        Company Update(Company company);
        void Remove(int id);

    }
}
