using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookcase.Models;

namespace Bookcase.Services
{
    public class Service<TypeOfModel> : IService<TypeOfModel> where TypeOfModel : class
    {
        private readonly IRepository<TypeOfModel> _repository;

        public Service(IRepository<TypeOfModel> repository)
        {
            _repository = repository;
        }

        public IQueryable<TypeOfModel> GetItemsAsync()
        {
            return _repository.GetAll().Result;
        }

        public TypeOfModel FindItemAsync(int itemId)
        {
            return _repository.FindById(itemId).Result;
        }

        public void UpdateItemAsync(TypeOfModel updatedItem)
        {
            _repository.Update(updatedItem);
        }

        public void DeleteAsync(int itemId)
        {
            _repository.Remove(itemId);
        }
    }
}
