using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeEmpleo.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    IdApplicant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.IdApplicant);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    IdCompany = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.IdCompany);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    IdSkill = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.IdSkill);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    IdEducation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCompletionStudies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdApplicant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.IdEducation);
                    table.ForeignKey(
                        name: "FK_Education_Applicants_IdApplicant",
                        column: x => x.IdApplicant,
                        principalTable: "Applicants",
                        principalColumn: "IdApplicant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    IdOffer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferTittle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCompany = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.IdOffer);
                    table.ForeignKey(
                        name: "FK_Offers_Companies_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "Companies",
                        principalColumn: "IdCompany",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantsSkills",
                columns: table => new
                {
                    IdApplicantSkills = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdApplicant = table.Column<int>(type: "int", nullable: false),
                    IdSkill = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantsSkills", x => x.IdApplicantSkills);
                    table.ForeignKey(
                        name: "FK_ApplicantsSkills_Applicants_IdApplicant",
                        column: x => x.IdApplicant,
                        principalTable: "Applicants",
                        principalColumn: "IdApplicant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantsSkills_Skill_IdSkill",
                        column: x => x.IdSkill,
                        principalTable: "Skill",
                        principalColumn: "IdSkill",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferApplicants",
                columns: table => new
                {
                    IdOfferApplicants = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOffer = table.Column<int>(type: "int", nullable: false),
                    IdApplicant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferApplicants", x => x.IdOfferApplicants);
                    table.ForeignKey(
                        name: "FK_OfferApplicants_Applicants_IdApplicant",
                        column: x => x.IdApplicant,
                        principalTable: "Applicants",
                        principalColumn: "IdApplicant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferApplicants_Offers_IdOffer",
                        column: x => x.IdOffer,
                        principalTable: "Offers",
                        principalColumn: "IdOffer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferSkills",
                columns: table => new
                {
                    IdOfferSkills = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOffer = table.Column<int>(type: "int", nullable: false),
                    IdSkill = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferSkills", x => x.IdOfferSkills);
                    table.ForeignKey(
                        name: "FK_OfferSkills_Offers_IdOffer",
                        column: x => x.IdOffer,
                        principalTable: "Offers",
                        principalColumn: "IdOffer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferSkills_Skill_IdSkill",
                        column: x => x.IdSkill,
                        principalTable: "Skill",
                        principalColumn: "IdSkill",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsSkills_IdApplicant",
                table: "ApplicantsSkills",
                column: "IdApplicant");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsSkills_IdSkill",
                table: "ApplicantsSkills",
                column: "IdSkill");

            migrationBuilder.CreateIndex(
                name: "IX_Education_IdApplicant",
                table: "Education",
                column: "IdApplicant");

            migrationBuilder.CreateIndex(
                name: "IX_OfferApplicants_IdApplicant",
                table: "OfferApplicants",
                column: "IdApplicant");

            migrationBuilder.CreateIndex(
                name: "IX_OfferApplicants_IdOffer",
                table: "OfferApplicants",
                column: "IdOffer");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_IdCompany",
                table: "Offers",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_OfferSkills_IdOffer",
                table: "OfferSkills",
                column: "IdOffer");

            migrationBuilder.CreateIndex(
                name: "IX_OfferSkills_IdSkill",
                table: "OfferSkills",
                column: "IdSkill");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantsSkills");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "OfferApplicants");

            migrationBuilder.DropTable(
                name: "OfferSkills");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
