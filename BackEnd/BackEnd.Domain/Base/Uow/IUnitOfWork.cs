using BackEnd.Domain.Entity.Repositories;
using BackEnd.Domain.Ums.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace BackEnd.Domain.Base.Uow;

public interface IUnitOfWork: IDisposable
{
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();

    IUserRepository UserRepository { get; }
    IMemberRepository MemberRepository { get; }
    IRoleRepository RoleRepository { get; }
    IBookRepository BookRepository { get; }
    IAuthorRepository AuthorRepository { get; }
    IPublisherRepository PublisherRepository { get; }
    ICheckOutRepository CheckOutRepository { get; }
    IHoldRepository HoldRepository { get; }
    INotificationRepository NotificationRepository { get; }
    IMetaCataloRepository MetaCataloRepository { get; }
    ICataloRepository CataloRepository { get; }
    IWaitingListRepository WaitingListRepository { get; }
    IBookCopyRepository BookCopyRepository { get; }
}