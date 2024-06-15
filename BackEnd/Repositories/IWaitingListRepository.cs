using Abp.Domain.Repositories;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public interface IWaitingListRepository : IRepository<WaitingList, Guid>
{
    
}