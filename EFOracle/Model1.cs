namespace EFOracle
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<DISCIPLINE> DISCIPLINEs { get; set; }
        public virtual DbSet<FAQ> FAQS { get; set; }
        public virtual DbSet<GROUP> GROUPs { get; set; }
        public virtual DbSet<SCHEDULE> SCHEDULEs { get; set; }
        public virtual DbSet<STUDENT> STUDENTs { get; set; }
        public virtual DbSet<STUDENTWORK> STUDENTWORKs { get; set; }
        public virtual DbSet<TASK> TASKs { get; set; }
        public virtual DbSet<TASKTYPE> TASKTYPES { get; set; }
        public virtual DbSet<TEACHER> TEACHERs { get; set; }
        public virtual DbSet<USER> USERs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DISCIPLINE>()
                .Property(e => e.DISCIPLINE_CODE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<DISCIPLINE>()
                .Property(e => e.DISCIPLINE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<DISCIPLINE>()
                .HasMany(e => e.SCHEDULEs)
                .WithRequired(e => e.DISCIPLINE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DISCIPLINE>()
                .HasMany(e => e.TASKs)
                .WithRequired(e => e.DISCIPLINE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FAQ>()
                .Property(e => e.STUDENT_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<FAQ>()
                .Property(e => e.TASK_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<FAQ>()
                .Property(e => e.FAQS_QUESTION)
                .IsUnicode(false);

            modelBuilder.Entity<FAQ>()
                .Property(e => e.TEACHER_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<FAQ>()
                .Property(e => e.FAQS_ANSWER)
                .IsUnicode(false);

            modelBuilder.Entity<GROUP>()
                .Property(e => e.GROUP_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<GROUP>()
                .HasMany(e => e.SCHEDULEs)
                .WithRequired(e => e.GROUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GROUP>()
                .HasMany(e => e.STUDENTs)
                .WithRequired(e => e.GROUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SCHEDULE>()
                .Property(e => e.TEACHER_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SCHEDULE>()
                .Property(e => e.GROUP_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<SCHEDULE>()
                .Property(e => e.DISCIPLINE_CODE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SCHEDULE>()
                .Property(e => e.SCHEDULE_ROOM)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STUDENT>()
                .Property(e => e.STUDENT_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STUDENT>()
                .Property(e => e.GROUP_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENT>()
                .Property(e => e.USER_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENT>()
                .HasMany(e => e.FAQS)
                .WithRequired(e => e.STUDENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STUDENT>()
                .HasMany(e => e.STUDENTWORKs)
                .WithRequired(e => e.STUDENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STUDENTWORK>()
                .Property(e => e.STUDENT_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STUDENTWORK>()
                .Property(e => e.TASK_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STUDENTWORK>()
                .Property(e => e.STUDENT_WORK_TEXT)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENTWORK>()
                .Property(e => e.STUDENT_WORK_MARK)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TASK>()
                .Property(e => e.TASK_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TASK>()
                .Property(e => e.PARENT_TASK_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TASK>()
                .Property(e => e.DISCIPLINE_CODE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TASK>()
                .Property(e => e.TASK_TYPE_CODE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TASK>()
                .Property(e => e.TASK_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TASK>()
                .HasMany(e => e.FAQS)
                .WithRequired(e => e.TASK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TASK>()
                .HasMany(e => e.STUDENTWORKs)
                .WithRequired(e => e.TASK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TASK>()
                .HasMany(e => e.TASK1)
                .WithOptional(e => e.TASK2)
                .HasForeignKey(e => e.PARENT_TASK_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TASKTYPE>()
                .Property(e => e.TASK_TYPE_CODE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TASKTYPE>()
                .Property(e => e.TASK_TYPE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TASKTYPE>()
                .HasMany(e => e.TASKs)
                .WithRequired(e => e.TASKTYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TEACHER>()
                .Property(e => e.TEACHER_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TEACHER>()
                .Property(e => e.USER_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<TEACHER>()
                .HasMany(e => e.SCHEDULEs)
                .WithRequired(e => e.TEACHER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.USER_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.USER_PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.USER_EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.USER_FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.USER_LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.TEACHERs)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);
        }
    }
}
