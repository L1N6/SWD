using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SWD392_Project.Models;

public partial class Swd392Project1Context : DbContext
{
    public Swd392Project1Context()
    {
    }

    public Swd392Project1Context(DbContextOptions<Swd392Project1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Connection> Connections { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventDetail> EventDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sponsor> Sponsors { get; set; }

    public virtual DbSet<State> States { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("SWD_392_Project"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Accounts__46A222CDD5DA9BBA");

            entity.HasIndex(e => e.UserName, "UQ__Accounts__7C9273C4570C7D25").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Accounts__AB6E6164298C8DCA").IsUnique();

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Avatar)
                .HasMaxLength(50)
                .HasColumnName("avatar");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(250)
                .HasColumnName("full_name");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(250)
                .HasColumnName("user_name");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Accounts__role_i__2F10007B");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__D54EE9B4106F4FA6");

            entity.HasIndex(e => e.Name, "UQ__Categori__72E12F1B5123133B").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comments__E7957687810C9501");

            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Content)
                .HasMaxLength(250)
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DeleteOrUpdate).HasColumnName("delete_or_update");
            entity.Property(e => e.EventId).HasColumnName("event_id");

            entity.HasOne(d => d.Account).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__accoun__3C69FB99");

            entity.HasOne(d => d.Event).WithMany(p => p.Comments)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__event___3D5E1FD2");
        });

        modelBuilder.Entity<Connection>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.JoinOrCare).HasColumnName("join_or_care");

            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Connectio__accou__35BCFE0A");

            entity.HasOne(d => d.Event).WithMany()
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Connectio__event__36B12243");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__2370F7273F7A6CC5");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.Location)
                .HasMaxLength(250)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
            entity.Property(e => e.StateId).HasColumnName("state_id");

            entity.HasOne(d => d.Account).WithMany(p => p.Events)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Events__account___32E0915F");

            entity.HasOne(d => d.Category).WithMany(p => p.Events)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Events__category__31EC6D26");

            entity.HasOne(d => d.State).WithMany(p => p.Events)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__Events__state_id__33D4B598");
        });

        modelBuilder.Entity<EventDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK__EventDet__38E9A2248E07E16E");

            entity.Property(e => e.DetailId).HasColumnName("detail_id");
            entity.Property(e => e.Agenda)
                .HasMaxLength(250)
                .HasColumnName("agenda");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.Image)
                .HasMaxLength(250)
                .HasColumnName("image");

            entity.HasOne(d => d.Event).WithMany(p => p.EventDetails)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventDeta__event__398D8EEE");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__760965CC212A8C6A");

            entity.HasIndex(e => e.Name, "UQ__Roles__72E12F1BAA67E450").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Sponsor>(entity =>
        {
            entity.HasKey(e => e.SponsorId).HasName("PK__Sponsors__BE37D4547A610D78");

            entity.Property(e => e.SponsorId).HasColumnName("sponsor_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.InforSponsor)
                .HasMaxLength(250)
                .HasColumnName("infor_sponsor");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
            entity.Property(e => e.UnitSponsor)
                .HasMaxLength(250)
                .HasColumnName("unit_sponsor");

            entity.HasOne(d => d.Event).WithMany(p => p.Sponsors)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sponsors__event___403A8C7D");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__States__81A474174E4A7683");

            entity.HasIndex(e => e.Name, "UQ__States__72E12F1BBF6B8DF6").IsUnique();

            entity.Property(e => e.StateId).HasColumnName("state_id");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
