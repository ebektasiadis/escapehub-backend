using Microsoft.EntityFrameworkCore;

using Domain.User;

namespace Application.Abstractions.Storage;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
}