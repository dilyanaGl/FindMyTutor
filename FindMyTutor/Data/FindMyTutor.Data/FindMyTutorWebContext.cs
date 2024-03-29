﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindMyTutor.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FindMyTutor.Data
{
    public class FindMyTutorWebContext : IdentityDbContext<FindMyTutorUser>
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<SubjectName> SubjectNames { get; set; }
        public DbSet<ReportedOffer> ReportedOffers { get; set; }
        public DbSet<ReportedComment> ReportedComment { get; set; }

        public DbSet<Log> Log { get; set; }
      
        public DbSet<Notification> Notifications { get; set; }
               

        public FindMyTutorWebContext(DbContextOptions<FindMyTutorWebContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Comment>()
                .HasOne(p => p.Offer)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.OfferId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comment>()
                 .HasOne(p => p.Commenter)
                 .WithMany(p => p.Comments)
                 .HasForeignKey(p => p.CommenterId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Message>()
                .HasOne(p => p.Sender)
                .WithMany(p => p.SentMessages)
                .HasForeignKey(p => p.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Message>()
                .HasOne(p => p.Receiver)
                .WithMany(p => p.ReveivedMessages)
                .HasForeignKey(p => p.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Recommendation>()
                .HasOne(p => p.Recommender)
                .WithMany(p => p.GivenRecommendations)
                .HasForeignKey(p => p.RecommenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Recommendation>()
            .HasOne(p => p.Recommendee)
            .WithMany(p => p.ReceivedRecommendations)
            .HasForeignKey(p => p.RecommendeeId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Recommendation>()
            .HasOne(p => p.RecommendTo)
            .WithMany(p => p.RecommendationsByFriends)
            .HasForeignKey(p => p.RecommendToId)
            .OnDelete(DeleteBehavior.ClientSetNull);


            builder.Entity<Review>()
                .HasOne(p => p.Reviewer)
                .WithMany(p => p.GivenReviews)
                .HasForeignKey(p => p.ReviewerId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            builder.Entity<Review>()
                .HasOne(p => p.Reviewee)
                .WithMany(p => p.ReceivedReviews)
                .HasForeignKey(p => p.RevieweeId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            builder.Entity<Offer>()
                .HasOne(p => p.Tutor)
                .WithMany(p => p.MadeOffers)
                .HasForeignKey(p => p.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Offer>()
                .HasOne(p => p.Subject)
                .WithMany(p => p.Offers)
                .HasForeignKey(p => p.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);  

            builder.Entity<SubjectName>()
                .HasOne(p => p.Subject)
                .WithMany(p => p.SubCategories)
                .HasForeignKey(p => p.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ReportedOffer>()
                .HasOne(p => p.ResourceCreator)
                .WithMany(p => p.ReportedOffersReceived)
                .HasForeignKey(p => p.ResourceCreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<ReportedOffer>()
               .HasOne(p => p.Reporter)
               .WithMany(p => p.ReportedOffersMade)
               .HasForeignKey(p => p.ReporterId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<ReportedOffer>()
                .HasOne(p => p.Offer)
                .WithMany(p => p.Reports)
                .HasForeignKey(p => p.OfferId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ReportedComment>()
              .HasOne(p => p.ResourceCreator)
              .WithMany(p => p.ReportedCommentsReceived)
              .HasForeignKey(p => p.ResourceCreatorId)
              .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<ReportedComment>()
               .HasOne(p => p.Reporter)
               .WithMany(p => p.ReportedCommentsMade)
               .HasForeignKey(p => p.ReporterId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<ReportedComment>()
                .HasOne(p => p.Comment)
                .WithMany(p => p.Reports)
                .HasForeignKey(p => p.CommentId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Notification>()
                .HasOne(p => p.NotificationRecipient)
                .WithMany(p => p.Notifications)
                .HasForeignKey(p => p.NotificationRecipientId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Log>()
                .HasOne(p => p.User)
                .WithMany(p => p.Logs)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        



            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
