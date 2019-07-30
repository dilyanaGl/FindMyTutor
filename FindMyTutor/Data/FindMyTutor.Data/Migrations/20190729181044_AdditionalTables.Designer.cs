﻿// <auto-generated />
using System;
using FindMyTutor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FindMyTutor.Data.Migrations
{
    [DbContext(typeof(FindMyTutorWebContext))]
    [Migration("20190729181044_AdditionalTables")]
    partial class AdditionalTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FindMyTutor.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommenterId");

                    b.Property<string>("Content");

                    b.Property<int>("OfferId");

                    b.Property<DateTime>("PublicationDate");

                    b.Property<int>("Rating");

                    b.HasKey("Id");

                    b.HasIndex("CommenterId");

                    b.HasIndex("OfferId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.FindMyTutorUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("RatingsCount");

                    b.Property<int>("Role");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("TotalRating");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("LogType");

                    b.Property<int>("ResourceId");

                    b.Property<int>("ResourceType");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<bool>("IsRead");

                    b.Property<int?>("OfferId");

                    b.Property<string>("ReceiverId");

                    b.Property<DateTime>("SendDate");

                    b.Property<string>("SenderId");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsSeen");

                    b.Property<int>("MessageType");

                    b.Property<string>("NotificationRecipientId");

                    b.Property<int?>("ResourceId");

                    b.HasKey("Id");

                    b.HasIndex("NotificationRecipientId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<string>("ImageUrl");

                    b.Property<double?>("Price");

                    b.Property<DateTime>("PublishDate");

                    b.Property<int>("RatingsCount");

                    b.Property<int>("SubjectId");

                    b.Property<string>("Title");

                    b.Property<int>("TotalRating");

                    b.Property<string>("TutorId");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TutorId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.Recommendation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("PublicationTime");

                    b.Property<bool>("RecommendToAFriend");

                    b.Property<string>("RecommendToId");

                    b.Property<string>("RecommendeeId");

                    b.Property<string>("RecommenderId");

                    b.HasKey("Id");

                    b.HasIndex("RecommendToId");

                    b.HasIndex("RecommendeeId");

                    b.HasIndex("RecommenderId");

                    b.ToTable("Recommendations");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.ReportedComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommentId");

                    b.Property<string>("Rationale");

                    b.Property<string>("ReporterId");

                    b.Property<string>("ResourceCreatorId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("ReporterId");

                    b.HasIndex("ResourceCreatorId");

                    b.ToTable("ReportedComment");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.ReportedOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OfferId");

                    b.Property<string>("Rationale");

                    b.Property<string>("ReporterId");

                    b.Property<string>("ResourceCreatorId");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.HasIndex("ReporterId");

                    b.HasIndex("ResourceCreatorId");

                    b.ToTable("ReportedOffers");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<bool>("IsBannedByAdministrator");

                    b.Property<DateTime>("PublicationDate");

                    b.Property<double?>("Rating");

                    b.Property<string>("RevieweeId");

                    b.Property<string>("ReviewerId");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.HasIndex("RevieweeId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.SubjectName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Level");

                    b.Property<string>("LevelEnglish");

                    b.Property<string>("Name");

                    b.Property<int>("SubjectId");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("SubjectNames");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.Comment", b =>
                {
                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser", "Commenter")
                        .WithMany("Comments")
                        .HasForeignKey("CommenterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FindMyTutor.Data.Models.Offer", "Offer")
                        .WithMany("Comments")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.Log", b =>
                {
                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser", "User")
                        .WithMany("Logs")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.Message", b =>
                {
                    b.HasOne("FindMyTutor.Data.Models.Offer", "Offer")
                        .WithMany("Messages")
                        .HasForeignKey("OfferId");

                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser", "Receiver")
                        .WithMany("ReveivedMessages")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser", "Sender")
                        .WithMany("SentMessages")
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.Notification", b =>
                {
                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser", "NotificationRecipient")
                        .WithMany("Notifications")
                        .HasForeignKey("NotificationRecipientId");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.Offer", b =>
                {
                    b.HasOne("FindMyTutor.Data.Models.SubjectName", "Subject")
                        .WithMany("Offers")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser", "Tutor")
                        .WithMany("MadeOffers")
                        .HasForeignKey("TutorId");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.Recommendation", b =>
                {
                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser", "RecommendTo")
                        .WithMany("RecommendationsByFriends")
                        .HasForeignKey("RecommendToId");

                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser", "Recommendee")
                        .WithMany("ReceivedRecommendations")
                        .HasForeignKey("RecommendeeId");

                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser", "Recommender")
                        .WithMany("GivenRecommendations")
                        .HasForeignKey("RecommenderId");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.ReportedComment", b =>
                {
                    b.HasOne("FindMyTutor.Data.Models.Comment", "Comment")
                        .WithMany("Reports")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser", "Reporter")
                        .WithMany("ReportedCommentsMade")
                        .HasForeignKey("ReporterId");

                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser", "ResourceCreator")
                        .WithMany("ReportedCommentsReceived")
                        .HasForeignKey("ResourceCreatorId");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.ReportedOffer", b =>
                {
                    b.HasOne("FindMyTutor.Data.Models.Offer", "Offer")
                        .WithMany("Reports")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser", "Reporter")
                        .WithMany("ReportedOffersMade")
                        .HasForeignKey("ReporterId");

                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser", "ResourceCreator")
                        .WithMany("ReportedOffersReceived")
                        .HasForeignKey("ResourceCreatorId");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.Review", b =>
                {
                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser", "Reviewee")
                        .WithMany("ReceivedReviews")
                        .HasForeignKey("RevieweeId");

                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser", "Reviewer")
                        .WithMany("GivenReviews")
                        .HasForeignKey("ReviewerId");
                });

            modelBuilder.Entity("FindMyTutor.Data.Models.SubjectName", b =>
                {
                    b.HasOne("FindMyTutor.Data.Models.Subject", "Subject")
                        .WithMany("SubCategories")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FindMyTutor.Data.Models.FindMyTutorUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
