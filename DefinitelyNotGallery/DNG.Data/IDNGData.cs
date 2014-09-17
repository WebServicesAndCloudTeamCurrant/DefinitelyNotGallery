using System;
namespace DNG.Data
{
    using DNG.Data.Repositories;
    using DNG.Models;

    public interface IDngData
    {
        IRepository<User> Users { get; }

        IRepository<Category> Categories { get; }

        IRepository<Image> Images { get; }

     //   IRepository<Subscription> Subscriptions { get; }

        int SaveChanges();
    }
}
