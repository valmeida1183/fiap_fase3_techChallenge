using Core.Entity;

namespace Core.Repository.Interface;
public interface IContactHttpRepository : IHttpRepository<Contact>
{
    Task<IList<Contact>> GetAllByDddAsync(int dddId);
}
