using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Wallee.Boc.Vote.AppraisementResults;
using Wallee.Boc.Vote.Appraisements;
using Wallee.Boc.Vote.CandidateOrgUnits;
using Wallee.Boc.Vote.EvaluationContents;

namespace Wallee.Boc.Vote.EntityFrameworkCore
{
    public static class VoteDbContextModelCreationExtensions
    {
        public static void ConfigureVote(this ModelBuilder builder)
        {
            /* Configure your own tables/entities inside here */

            builder.Entity<EvaluationContent>(it =>
            {
                it.ToTable(VoteConsts.DbTablePrefix + "EvaluationContents", VoteConsts.DbSchema);
                it.ConfigureByConvention();
                it.HasIndex(it => it.Name).IsUnique();
                it.Property(it => it.Name).HasMaxLength(50).IsRequired();
                it.Property(it => it.Description).HasMaxLength(512).IsRequired();
            });

            builder.Entity<Appraisement>(it =>
            {
                it.ToTable(VoteConsts.DbTablePrefix + "Appraisements", VoteConsts.DbSchema);
                it.ConfigureByConvention();
                it.Property(it => it.Name).HasMaxLength(50).IsRequired();
                it.Property(it => it.Description).HasMaxLength(256).IsRequired();
                it.Property(it => it.Start).IsRequired();
                it.Property(it => it.End).IsRequired();
                it.Property(it => it.Category).IsRequired();
            });

            builder.Entity<AppraisementResult>(it =>
            {
                it.ToTable(VoteConsts.DbTablePrefix + "AppraisementResults", VoteConsts.DbSchema);
                it.ConfigureByConvention();
                it.Property(it => it.Score).HasColumnType("decimal(18,2)").IsRequired();
                it.Property(it => it.ClientIpAddress).IsRequired();
                it.HasMany(it => it.Details).WithOne().HasForeignKey(it => it.AppraisementResultId);
            });

            builder.Entity<AppraisementResultScoreDetail>(it =>
            {
                it.ToTable(VoteConsts.DbTablePrefix + "AppraisementResultScoreDetails", VoteConsts.DbSchema);
                it.HasKey(it => new { it.AppraisementResultId, it.EvaluationContentId });
                it.ConfigureByConvention();

                it.Property(it => it.Content).HasMaxLength(50).IsRequired();
                it.Property(it => it.Score).HasColumnType("decimal(18,2)").IsRequired();
                it.HasOne<AppraisementResult>().WithMany(it => it.Details).HasForeignKey(it => it.AppraisementResultId);
            });

            builder.Entity<CandidateOrgUnit>(it =>
            {
                it.ToTable(VoteConsts.DbTablePrefix + "CandidateOrgUnits", VoteConsts.DbSchema);
                it.ConfigureByConvention();
                it.Property(it => it.OrganName).HasMaxLength(100).IsRequired();
                it.Property(it => it.OrganCode).HasMaxLength(20).IsRequired();
                it.Property(it => it.SuperiorName).HasMaxLength(50).IsRequired();
            });
        }
    }
}
