using System.Linq;

namespace Bookcase.Services
{
    public interface IService<TypeOfModel> where TypeOfModel : class
    {
        IQueryable<TypeOfModel> GetItemsAsync();
        TypeOfModel FindItemAsync(int itemId);
        void UpdateItemAsync(TypeOfModel updatedItem);
        void DeleteAsync(int itemId);
    }
}
