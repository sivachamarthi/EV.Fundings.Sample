using System;
using EV.Fundings.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EV.Fundings.Api.Data
{
    public partial class EVDbContext : DbContext
    {
        public EVDbContext()
        {
        }

        public EVDbContext(DbContextOptions<EVDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Funding> Funding { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funding>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.InvestmentAmount).HasColumnType("money");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            #region Data Seeding
            modelBuilder.Entity<Funding>().HasData(
                    new Funding()
                    {
                        Id = 1,
                        Name = "Tegel Complex",
                        Description = "New Complex in Tegel area.",
                        IsInvested = false,
                        InvestmentAmount = null,
                        CreateDate = DateTime.Now.AddDays(-4),
                        CreatedBy = "System"
                    },
                     new Funding()
                     {
                         Id = 2,
                         Name = "Mitte Complex",
                         Description = "New Complex in Mitte area.",
                         IsInvested = false,
                         InvestmentAmount = null,
                         CreateDate = DateTime.Now.AddDays(-2),
                         CreatedBy = "System"
                     },
                      new Funding()
                      {
                          Id = 3,
                          Name = "Schoneberg Complex",
                          Description = "New Complex in Schoneberg area.",
                          IsInvested = false,
                          InvestmentAmount = null,
                          CreateDate = DateTime.Now.AddDays(-3),
                          CreatedBy = "System"
                      },
                       new Funding()
                       {
                           Id = 4,
                           Name = "Berlin Complex",
                           Description = "New Complex in Central Berlin area.",
                           IsInvested = false,
                           InvestmentAmount = null,
                           CreateDate = DateTime.Now.AddDays(-1),
                           CreatedBy = "System"
                       },
                        new Funding()
                        {
                            Id = 5,
                            Name = "Tegel Complex",
                            Description = "New Complex in Tegel area.",
                            IsInvested = false,
                            InvestmentAmount = null,
                            CreateDate = DateTime.Now.AddDays(-4),
                            CreatedBy = "System"
                        }
                );

            #endregion

        }
    }
}
