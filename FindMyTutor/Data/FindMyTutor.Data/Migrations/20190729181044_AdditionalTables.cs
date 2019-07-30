using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindMyTutor.Data.Migrations
{
    public partial class AdditionalTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CommenterId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_SubjectNames_SubjectId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectNames_Subjects_SubjectId",
                table: "SubjectNames");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.CreateTable(
                name: "ReportedComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rationale = table.Column<string>(nullable: true),
                    ResourceCreatorId = table.Column<string>(nullable: true),
                    ReporterId = table.Column<string>(nullable: true),
                    CommentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportedComment_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportedComment_AspNetUsers_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportedComment_AspNetUsers_ResourceCreatorId",
                        column: x => x.ResourceCreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportedOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rationale = table.Column<string>(nullable: true),
                    ResourceCreatorId = table.Column<string>(nullable: true),
                    ReporterId = table.Column<string>(nullable: true),
                    OfferId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportedOffers_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportedOffers_AspNetUsers_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportedOffers_AspNetUsers_ResourceCreatorId",
                        column: x => x.ResourceCreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportedComment_CommentId",
                table: "ReportedComment",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedComment_ReporterId",
                table: "ReportedComment",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedComment_ResourceCreatorId",
                table: "ReportedComment",
                column: "ResourceCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedOffers_OfferId",
                table: "ReportedOffers",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedOffers_ReporterId",
                table: "ReportedOffers",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedOffers_ResourceCreatorId",
                table: "ReportedOffers",
                column: "ResourceCreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CommenterId",
                table: "Comments",
                column: "CommenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_SubjectNames_SubjectId",
                table: "Offers",
                column: "SubjectId",
                principalTable: "SubjectNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectNames_Subjects_SubjectId",
                table: "SubjectNames",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CommenterId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_SubjectNames_SubjectId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectNames_Subjects_SubjectId",
                table: "SubjectNames");

            migrationBuilder.DropTable(
                name: "ReportedComment");

            migrationBuilder.DropTable(
                name: "ReportedOffers");

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rationale = table.Column<string>(nullable: true),
                    ReporterId = table.Column<string>(nullable: true),
                    ResourceCreatorId = table.Column<string>(nullable: true),
                    ResourceId = table.Column<int>(nullable: false),
                    ResourceType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_AspNetUsers_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_AspNetUsers_ResourceCreatorId",
                        column: x => x.ResourceCreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReporterId",
                table: "Reports",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ResourceCreatorId",
                table: "Reports",
                column: "ResourceCreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CommenterId",
                table: "Comments",
                column: "CommenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_SubjectNames_SubjectId",
                table: "Offers",
                column: "SubjectId",
                principalTable: "SubjectNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectNames_Subjects_SubjectId",
                table: "SubjectNames",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
