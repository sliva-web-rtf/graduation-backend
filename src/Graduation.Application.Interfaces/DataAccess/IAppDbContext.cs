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
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Interfaces.DataAccess;

public interface IAppDbContext : IDbContextWithSets, IDisposable
{
    DbSet<SupervisorLimit> SupervisorLimits { get; }
    DbSet<Year> Years { get; }
    DbSet<Skill> Skills { get; }
    DbSet<UserSkill> UserSkills { get; }
    DbSet<ScientificInterest> ScientificInterests { get; }
    DbSet<Commission> Commissions { get; }
    DbSet<CommissionExpert> CommissionExperts { get; }
    DbSet<CommissionStudent> CommissionStudents { get; }
    DbSet<Student> Students { get; }
    DbSet<QualificationWorkStage> QualificationWorkStages { get; }
    DbSet<Stage> Stages { get; }
    DbSet<AcademicGroup> AcademicGroups { get; }
    DbSet<AcademicProgram> AcademicPrograms { get; }
    DbSet<TopicAcademicProgram> TopicAcademicPrograms { get; }
    DbSet<Topic> Topics { get; }
    DbSet<UserRoleTopic> UserRoleTopics { get; }
    DbSet<QualificationWorkRole> QualificationWorkRoles { get; }
    DbSet<Document> Documents { get; }
    DbSet<QualificationWork> QualificationWorks { get; }
    DbSet<Request> Request { get; }
    DbSet<TopicChangeRequest> TopicChangeRequest { get; }
    DbSet<ApplicationUserRole> UserRoles { get; }
    DbSet<AppIdentityRole> Roles { get; }
    DbSet<User> Users { get; }
    DbSet<Event> Events { get; }
}