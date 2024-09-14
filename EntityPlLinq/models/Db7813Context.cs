using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityPlLinq.models;

public partial class Db7813Context : DbContext
{
    public Db7813Context()
    {
    }

    public Db7813Context(DbContextOptions<Db7813Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Flat> Flats { get; set; }

    public virtual DbSet<FlatsContract> FlatsContracts { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelsRoom> HotelsRooms { get; set; }

    public virtual DbSet<House> Houses { get; set; }

    public virtual DbSet<HousesContract> HousesContracts { get; set; }

    public virtual DbSet<LandLord> LandLords { get; set; }

    public virtual DbSet<LandLordsAdditionalInfo> LandLordsAdditionalInfos { get; set; }

    public virtual DbSet<Lessee> Lessees { get; set; }

    public virtual DbSet<LesseesAdditionalInfo> LesseesAdditionalInfos { get; set; }

    public virtual DbSet<RoomsContract> RoomsContracts { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=server.public.databaseasp.net, 1433;User ID=server;Password=password;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flat>(entity =>
        {
            entity.HasKey(e => e.Fid).HasName("PK__Flats__C1D1314A9EAA097E");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.City).HasMaxLength(20);
            entity.Property(e => e.CostPerDay).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Header).HasMaxLength(100);
            entity.Property(e => e.Llid).HasColumnName("LLid");

            entity.HasOne(d => d.Ll).WithMany(p => p.Flats)
                .HasForeignKey(d => d.Llid)
                .HasConstraintName("FK__Flats__LLid__6EF57B66");
        });

        modelBuilder.Entity<FlatsContract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FlatsCon__3214EC074C1F6AC8");

            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Llid).HasColumnName("LLid");

            entity.HasOne(d => d.FidNavigation).WithMany(p => p.FlatsContracts)
                .HasForeignKey(d => d.Fid)
                .HasConstraintName("FK__FlatsContra__Fid__73BA3083");

            entity.HasOne(d => d.LidNavigation).WithMany(p => p.FlatsContracts)
                .HasForeignKey(d => d.Lid)
                .HasConstraintName("FK__FlatsContra__Lid__71D1E811");

            entity.HasOne(d => d.Ll).WithMany(p => p.FlatsContracts)
                .HasForeignKey(d => d.Llid)
                .HasConstraintName("FK__FlatsContr__LLid__72C60C4A");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Hid).HasName("PK__Hotels__C750193FC98F2381");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.City).HasMaxLength(20);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Header).HasMaxLength(100);
            entity.Property(e => e.Llid).HasColumnName("LLid");

            entity.HasOne(d => d.Ll).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.Llid)
                .HasConstraintName("FK__Hotels__LLid__76969D2E");
        });

        modelBuilder.Entity<HotelsRoom>(entity =>
        {
            entity.HasKey(e => e.Rid).HasName("PK__HotelsRo__CAF055CACE0F2EA5");

            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.CostPerDay).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Header).HasMaxLength(100);

            entity.HasOne(d => d.HidNavigation).WithMany(p => p.HotelsRooms)
                .HasForeignKey(d => d.Hid)
                .HasConstraintName("FK__HotelsRooms__Hid__797309D9");
        });

        modelBuilder.Entity<House>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__Houses__C570593898A1D42E");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.City).HasMaxLength(20);
            entity.Property(e => e.CostPerDay).HasColumnType("money");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Header).HasMaxLength(100);
            entity.Property(e => e.Llid).HasColumnName("LLid");

            entity.HasOne(d => d.Ll).WithMany(p => p.Houses)
                .HasForeignKey(d => d.Llid)
                .HasConstraintName("FK__Houses__LLid__6754599E");
        });

        modelBuilder.Entity<HousesContract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HousesCo__3214EC07DA615D26");

            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Llid).HasColumnName("LLid");

            entity.HasOne(d => d.LidNavigation).WithMany(p => p.HousesContracts)
                .HasForeignKey(d => d.Lid)
                .HasConstraintName("FK__HousesContr__Lid__6A30C649");

            entity.HasOne(d => d.Ll).WithMany(p => p.HousesContracts)
                .HasForeignKey(d => d.Llid)
                .HasConstraintName("FK__HousesCont__LLid__6B24EA82");

            entity.HasOne(d => d.PidNavigation).WithMany(p => p.HousesContracts)
                .HasForeignKey(d => d.Pid)
                .HasConstraintName("FK__HousesContr__Pid__6C190EBB");
        });

        modelBuilder.Entity<LandLord>(entity =>
        {
            entity.HasKey(e => e.Llid).HasName("PK__LandLord__77BE170E8DCD28FF");

            entity.Property(e => e.Llid).HasColumnName("LLid");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<LandLordsAdditionalInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LandLord__3214EC073947A45A");

            entity.ToTable("LandLordsAdditionalInfo");

            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.Llid).HasColumnName("LLid");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.PassportId).HasMaxLength(70);
            entity.Property(e => e.Surname).HasMaxLength(30);
            entity.Property(e => e.Telephone).HasMaxLength(20);

            entity.HasOne(d => d.Ll).WithMany(p => p.LandLordsAdditionalInfos)
                .HasForeignKey(d => d.Llid)
                .HasConstraintName("FK__LandLordsA__LLid__6477ECF3");
        });

        modelBuilder.Entity<Lessee>(entity =>
        {
            entity.HasKey(e => e.Lid).HasName("PK__Lessees__C6505B39EB7AAFDB");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<LesseesAdditionalInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LesseesA__3214EC07377F8DBA");

            entity.ToTable("LesseesAdditionalInfo");

            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.PassportId).HasMaxLength(70);
            entity.Property(e => e.Surname).HasMaxLength(30);
            entity.Property(e => e.Telephone).HasMaxLength(20);

            entity.HasOne(d => d.LidNavigation).WithMany(p => p.LesseesAdditionalInfos)
                .HasForeignKey(d => d.Lid)
                .HasConstraintName("FK__LesseesAddi__Lid__5FB337D6");
        });

        modelBuilder.Entity<RoomsContract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomsCon__3214EC077D087D9F");

            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Llid).HasColumnName("LLid");

            entity.HasOne(d => d.LidNavigation).WithMany(p => p.RoomsContracts)
                .HasForeignKey(d => d.Lid)
                .HasConstraintName("FK__RoomsContra__Lid__7C4F7684");

            entity.HasOne(d => d.Ll).WithMany(p => p.RoomsContracts)
                .HasForeignKey(d => d.Llid)
                .HasConstraintName("FK__RoomsContr__LLid__7D439ABD");

            entity.HasOne(d => d.RidNavigation).WithMany(p => p.RoomsContracts)
                .HasForeignKey(d => d.Rid)
                .HasConstraintName("FK__RoomsContra__Rid__7E37BEF6");
        });



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
