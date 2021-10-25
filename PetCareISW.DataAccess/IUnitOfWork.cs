using System.Threading.Tasks;

namespace PetCareISW.DataAccess

{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
