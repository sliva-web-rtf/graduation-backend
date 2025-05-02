using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.AcademicGroups;
using Graduation.Domain.AcademicPrograms;
using Graduation.Domain.Commissions;
using Graduation.Domain.Documents;
using Graduation.Domain.Events;
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
    : IdentityDbContext<User, AppIdentityRole, Guid, IdentityUserClaim<Guid>, ApplicationUserRole,
            IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>,
        IAppDbContext,
        IDataProtectionKeyContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TopicRequestedRole> TopicRequestedRoles { get; private set; }

    public DbSet<CommissionStudent> CommissionStudents { get; private set; }
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
    public DbSet<AcademicProgram> AcademicPrograms { get; private set; }
    public DbSet<TopicAcademicProgram> TopicAcademicPrograms { get; private set; }
    public DbSet<Topic> Topics { get; private set; }
    public DbSet<UserRoleTopic> UserRoleTopics { get; private set; }
    public DbSet<QualificationWorkRole> QualificationWorkRoles { get; private set; }
    public DbSet<Document> Documents { get; private set; }
    public DbSet<QualificationWork> QualificationWorks { get; private set; }
    public DbSet<Request> Request { get; private set; }
    public DbSet<TopicChangeRequest> TopicChangeRequest { get; private set; }
    public DbSet<Event> Events { get; private set; }
    public DbSet<DataProtectionKey> DataProtectionKeys { get; private set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}