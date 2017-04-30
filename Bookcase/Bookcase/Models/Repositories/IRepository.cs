using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Models
{
    public interface IRepository<TypeOfModel> where TypeOfModel : class
    {
        Task<IQueryable<TypeOfModel>> GetAll();
        Task<TypeOfModel> FindById(int id);
        Task Update(TypeOfModel updatedModel);
        Task Remove(int id);
        Task Save();
    }
}
