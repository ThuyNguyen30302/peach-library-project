using Abp.EntityFrameworkCore;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public class NotificationRepository : Repository<Notification, Guid>, INotificationRepository
{
    public NotificationRepository(IDbContextProvider<MigrationDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}