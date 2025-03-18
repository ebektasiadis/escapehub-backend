using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Storage;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
}