using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    internal interface IBaseRespository<T>
    {
        Task<int> AddAdnReturnIdAsync(T model);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> UpdateAsync(T model);
        Task<T> DeleteByIdAsync(int id);
         
    }
}
