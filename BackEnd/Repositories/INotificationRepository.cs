using Abp.Domain.Repositories;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public interface INotificationRepository : IRepository<Notification, Guid>
{
    
}