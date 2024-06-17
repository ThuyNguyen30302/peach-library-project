﻿using BackEnd.Base.Audit;

namespace BackEnd.Entities;

public class Member : FullAudited<Guid>
{
    public string CardNumber { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Status { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }

    public ICollection<CheckOut> CheckOuts { get; set; }
    public ICollection<Hold> Holds { get; set; }
    public ICollection<Notification> Notifications { get; set; }
    public ICollection<WaitingList> WaitingLists { get; set; }
}
