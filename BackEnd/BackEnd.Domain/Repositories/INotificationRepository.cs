using BackEnd.Domain.Base.Repositories;
using BackEnd.Domain.Entities;

namespace BackEnd.Domain.Repositories;

public interface INotificationRepository : IBaseRepository<Notification, Guid>
{
    
}