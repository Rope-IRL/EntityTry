using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityPlLinq.models;

public partial class RealestaterentalContext : DbContext
{
    public RealestaterentalContext()
    {
    }

    public RealestaterentalContext(DbContextOptions<RealestaterentalContext> options)
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
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=realestaterental;User ID=user;Password=password;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flat>(entity =>
        {
            entity.HasKey(e => e.Fid).HasName("PK__Flats__C1D1314A31F953AE");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.City).HasMaxLength(20);
            entity.Property(e => e.CostPerDay).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Header).HasMaxLength(100);
            entity.Property(e => e.Llid).HasColumnName("LLid");

            entity.HasOne(d => d.Ll).WithMany(p => p.Flats)
                .HasForeignKey(d => d.Llid)
                .HasConstraintName("FK__Flats__LLid__5D4BCC77");
        });

        modelBuilder.Entity<FlatsContract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FlatsCon__3214EC07880813D4");

            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Llid).HasColumnName("LLid");

            entity.HasOne(d => d.FidNavigation).WithMany(p => p.FlatsContracts)
                .HasForeignKey(d => d.Fid)
                .HasConstraintName("FK__FlatsContra__Fid__62108194");

            entity.HasOne(d => d.LidNavigation).WithMany(p => p.FlatsContracts)
                .HasForeignKey(d => d.Lid)
                .HasConstraintName("FK__FlatsContra__Lid__60283922");

            entity.HasOne(d => d.Ll).WithMany(p => p.FlatsContracts)
                .HasForeignKey(d => d.Llid)
                .HasConstraintName("FK__FlatsContr__LLid__611C5D5B");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Hid).HasName("PK__Hotels__C750193FEA3DB20E");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.City).HasMaxLength(20);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Header).HasMaxLength(100);
            entity.Property(e => e.Llid).HasColumnName("LLid");

            entity.HasOne(d => d.Ll).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.Llid)
                .HasConstraintName("FK__Hotels__LLid__64ECEE3F");
        });

        modelBuilder.Entity<HotelsRoom>(entity =>
        {
            entity.HasKey(e => e.Rid).HasName("PK__HotelsRo__CAF055CA79C03C39");

            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.CostPerDay).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Header).HasMaxLength(100);

            entity.HasOne(d => d.HidNavigation).WithMany(p => p.HotelsRooms)
                .HasForeignKey(d => d.Hid)
                .HasConstraintName("FK__HotelsRooms__Hid__67C95AEA");
        });

        modelBuilder.Entity<House>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__Houses__C5705938D2B5993E");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.City).HasMaxLength(20);
            entity.Property(e => e.CostPerDay).HasColumnType("money");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Header).HasMaxLength(100);
            entity.Property(e => e.Llid).HasColumnName("LLid");

            entity.HasOne(d => d.Ll).WithMany(p => p.Houses)
                .HasForeignKey(d => d.Llid)
                .HasConstraintName("FK__Houses__LLid__55AAAAAF");
        });

        modelBuilder.Entity<HousesContract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HousesCo__3214EC07A06D6272");

            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Llid).HasColumnName("LLid");

            entity.HasOne(d => d.LidNavigation).WithMany(p => p.HousesContracts)
                .HasForeignKey(d => d.Lid)
                .HasConstraintName("FK__HousesContr__Lid__5887175A");

            entity.HasOne(d => d.Ll).WithMany(p => p.HousesContracts)
                .HasForeignKey(d => d.Llid)
                .HasConstraintName("FK__HousesCont__LLid__597B3B93");

            entity.HasOne(d => d.PidNavigation).WithMany(p => p.HousesContracts)
                .HasForeignKey(d => d.Pid)
                .HasConstraintName("FK__HousesContr__Pid__5A6F5FCC");
        });

        modelBuilder.Entity<LandLord>(entity =>
        {
            entity.HasKey(e => e.Llid).HasName("PK__LandLord__77BE170E0C0599C8");

            entity.Property(e => e.Llid).HasColumnName("LLid");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<LandLordsAdditionalInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LandLord__3214EC077AB66E4F");

            entity.ToTable("LandLordsAdditionalInfo");

            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.Llid).HasColumnName("LLid");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.PassportId).HasMaxLength(70);
            entity.Property(e => e.Surname).HasMaxLength(30);
            entity.Property(e => e.Telephone).HasMaxLength(20);

            entity.HasOne(d => d.Ll).WithMany(p => p.LandLordsAdditionalInfos)
                .HasForeignKey(d => d.Llid)
                .HasConstraintName("FK__LandLordsA__LLid__52CE3E04");
        });

        modelBuilder.Entity<Lessee>(entity =>
        {
            entity.HasKey(e => e.Lid).HasName("PK__Lessees__C6505B39E7568D3A");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<LesseesAdditionalInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LesseesA__3214EC07C120FE73");

            entity.ToTable("LesseesAdditionalInfo");

            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.PassportId).HasMaxLength(70);
            entity.Property(e => e.Surname).HasMaxLength(30);
            entity.Property(e => e.Telephone).HasMaxLength(20);

            entity.HasOne(d => d.LidNavigation).WithMany(p => p.LesseesAdditionalInfos)
                .HasForeignKey(d => d.Lid)
                .HasConstraintName("FK__LesseesAddi__Lid__4E0988E7");
        });

        modelBuilder.Entity<RoomsContract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomsCon__3214EC0752B68D45");

            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Llid).HasColumnName("LLid");

            entity.HasOne(d => d.LidNavigation).WithMany(p => p.RoomsContracts)
                .HasForeignKey(d => d.Lid)
                .HasConstraintName("FK__RoomsContra__Lid__6AA5C795");

            entity.HasOne(d => d.Ll).WithMany(p => p.RoomsContracts)
                .HasForeignKey(d => d.Llid)
                .HasConstraintName("FK__RoomsContr__LLid__6B99EBCE");

            entity.HasOne(d => d.RidNavigation).WithMany(p => p.RoomsContracts)
                .HasForeignKey(d => d.Rid)
                .HasConstraintName("FK__RoomsContra__Rid__6C8E1007");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
