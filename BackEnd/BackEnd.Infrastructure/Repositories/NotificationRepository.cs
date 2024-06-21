using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories;

public class NotificationRepository : BaseRepository<ApplicationDbContext, Notification, Guid>, INotificationRepository
{
    public NotificationRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}