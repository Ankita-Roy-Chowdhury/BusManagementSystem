using System;
using System.Collections.Generic;
using BusManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BusManagementSystem.Data;

public partial class BusInfoContext : DbContext
{
    public BusInfoContext()
    {
    }

    public BusInfoContext(DbContextOptions<BusInfoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BusInfo> BusInfos { get; set; }

    public virtual DbSet<BusView> BusViews { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-UAOPN03; Initial Catalog=Bus_Info;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BusInfo>(entity =>
        {
            entity.HasKey(e => e.BusId).HasName("PK_BusID");
        });

        modelBuilder.Entity<BusView>(entity =>
        {
            entity.ToView("Bus_View");

            entity.Property(e => e.BusId).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
