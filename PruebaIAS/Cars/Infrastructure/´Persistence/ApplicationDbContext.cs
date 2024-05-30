using Application.Data;
using Domain.Cars;
using Domain.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure._Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;

        
        public DbSet<Car> Carss { get ; set ; }

        public ApplicationDbContext(DbContextOptions option,IPublisher publisher): base(option)
        {
            _publisher = publisher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync (CancellationToken cancellationToken= new CancellationToken())
        {
            var domainEvent = ChangeTracker.Entries<AgregateRoot>().Select(e => e.Entity).Where(e => e.GetDomainEvent().any()).SelectMany(e => e.GetDomainEvents());
            var result =  await base.SaveChangesAsync (cancellationToken);
            return result;

        }
    }
}
