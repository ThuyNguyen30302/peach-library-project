using BackEnd.Domain.Base.Uow;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Domain.Ums.Repositories;
using BackEnd.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BackEnd.Infrastructure.Base.Uow;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction _transaction;

    public UnitOfWork(ApplicationDbContext context, IUserRepository userRepository, IMemberRepository memberRepository,
        IBookRepository bookRepository, IAuthorRepository authorRepository, IBookCopyRepository bookCopyRepository,
        IPublisherRepository publisherRepository, ICheckOutRepository checkOutRepository,
        IHoldRepository holdRepository, INotificationRepository notificationRepository,
        IWaitingListRepository waitingListRepository, IMetaCataloRepository metaCataloRepository,
        ICataloRepository cataloRepository, IRoleRepository roleRepository)
    {
        _context = context;
        UserRepository = userRepository;
        MemberRepository = memberRepository;
        BookRepository = bookRepository;
        AuthorRepository = authorRepository;
        BookCopyRepository = bookCopyRepository;
        PublisherRepository = publisherRepository;
        CheckOutRepository = checkOutRepository;
        HoldRepository = holdRepository;
        NotificationRepository = notificationRepository;
        WaitingListRepository = waitingListRepository;
        MetaCataloRepository = metaCataloRepository;
        CataloRepository = cataloRepository;
        RoleRepository = roleRepository;
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
        return _transaction;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
        await _transaction.CommitAsync();
    }

    public async Task RollbackAsync()
    {
        await _transaction.RollbackAsync();
    }

    public IUserRepository UserRepository { get; private set; }
    public IMemberRepository MemberRepository { get; private set; }
    public IBookRepository BookRepository { get; private set; }
    public IAuthorRepository AuthorRepository { get; private set; }
    public IBookCopyRepository BookCopyRepository { get; private set; }
    public IPublisherRepository PublisherRepository { get; private set; }
    public ICheckOutRepository CheckOutRepository { get; private set; }
    public IHoldRepository HoldRepository { get; private set; }
    public INotificationRepository NotificationRepository { get; private set; }
    public IWaitingListRepository WaitingListRepository { get; private set; }
    public IMetaCataloRepository MetaCataloRepository { get; private set; }
    public ICataloRepository CataloRepository { get; private set; }
    public IRoleRepository RoleRepository { get; private set; }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context?.Dispose();
    }
}