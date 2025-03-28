using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.AcademicGroups;
using Graduation.Domain.Commissions;
using Graduation.Domain.Documents;
using Graduation.Domain.QualificationWorkRoles;
using Graduation.Domain.QualificationWorks;
using Graduation.Domain.Requests;
using Graduation.Domain.ScientificInterest;
using Graduation.Domain.Skills;
using Graduation.Domain.Stages;
using Graduation.Domain.Students;
using Graduation.Domain.Topics;
using Graduation.Domain.Users;
using Graduation.Domain.Years;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Infrastructure.Persistence;

public class AppDbContext
    : IdentityDbContext<User, AppIdentityRole, Guid, IdentityUserClaim<Guid>, ApplicationUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>,
        IAppDbContext,
        IDataProtectionKeyContext
{
    public DbSet<SupervisorLimit> SupervisorLimits { get; private set; }
    public DbSet<Year> Years { get; private set; }
    public DbSet<Skill> Skills { get; private set; }
    public DbSet<UserSkill> UserSkills { get; private set; }
    public DbSet<ScientificInterest> ScientificInterests { get; private set; }
    public DbSet<Commission> Commissions { get; private set; }
    public DbSet<CommissionExpert> CommissionExperts { get; private set; }
    public DbSet<Student> Students { get; private set; }
    public DbSet<QualificationWorkStage> QualificationWorkStages { get; private set; }
    public DbSet<Stage> Stages { get; private set; }
    public DbSet<AcademicGroup> AcademicGroups { get; private set; }
    public DbSet<Topic> Topics { get; private set; }
    public DbSet<UserRoleTopic> UserRoleTopics { get; private set; }
    public DbSet<QualificationWorkRole> QualificationWorkRoles { get; private set; }
    public DbSet<Document> Documents { get; private set; }
    public DbSet<QualificationWork> QualificationWork { get; private set; }
    public DbSet<Request> Request { get; private set; }
    public DbSet<TopicChangeRequest> TopicChangeRequest { get; private set; }
    public DbSet<DataProtectionKey> DataProtectionKeys { get; private set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}