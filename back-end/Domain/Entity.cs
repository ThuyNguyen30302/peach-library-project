﻿namespace PLP.Domain;

public abstract class Entity<T> : IEntity<T>
{
    public virtual T Id { get; set; }
}