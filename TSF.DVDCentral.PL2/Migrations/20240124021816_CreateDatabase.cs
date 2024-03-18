using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TSF.DVDCentral.PL2.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCustomer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ZIP = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomer_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblDirector",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDirector_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFormat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFormat_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblGenre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGenre_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrder_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblOrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderItem_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRating_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(28)", unicode: false, maxLength: 28, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblMovie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    FormatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMovie_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblMovie_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "tblDirector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblMovie_FormatId",
                        column: x => x.FormatId,
                        principalTable: "tblFormat",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblMovie_RatingId",
                        column: x => x.RatingId,
                        principalTable: "tblRating",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblCart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCart_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMovieGenre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMovieGenre_Id", x => x.Id);
                    table.ForeignKey(
                        name: "tblMovieGenre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "tblGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "tblMovieGenre_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCartItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCartItem_tblCart_CartId",
                        column: x => x.CartId,
                        principalTable: "tblCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCartItem_tblMovie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblCustomer",
                columns: new[] { "Id", "Address", "City", "FirstName", "LastName", "Phone", "State", "UserId", "ZIP" },
                values: new object[,]
                {
                    { new Guid("aedf3410-4d7c-4107-86c2-3304d2d0b8a6"), "159 Johnson Avenue", "Allenton", "Brian", "Foote", "9202623415", "WI", new Guid("7dcf4b54-921e-4cd2-a07d-0082264bf6bf"), "53142" },
                    { new Guid("b0486982-f906-44b1-84c1-62893dccda76"), "453 Oak Street", "Fond du Lac", "Steve", "Marin", "9205879797", "WI", new Guid("d33e147e-8168-401c-b739-d837ba3f94d4"), "54935" },
                    { new Guid("e87eaf88-9ada-43b7-ac57-05d50f3a9f56"), "987 Willow Road", "Slinger", "John", "Doro", "9202623345", "WI", new Guid("5cd9a2c2-a54b-4a67-a206-f080771e6c46"), "56495" }
                });

            migrationBuilder.InsertData(
                table: "tblDirector",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("55dd42ba-32eb-4b47-8a6c-04b43507c6db"), "Rob", "Reiner" },
                    { new Guid("68e368f2-817b-4250-ae7c-295baecf2872"), "Steven", "Spielberg" },
                    { new Guid("9c3c136a-8ca7-45be-89d2-48f435445bfb"), "Clint", "Eastwood" },
                    { new Guid("cccb7073-fae5-4d73-b06b-37ac9eff399d"), "George", "Lucas" },
                    { new Guid("d4d54b8b-de88-4a1e-8ce1-8e6f3811eadd"), "John", "Avildsen" },
                    { new Guid("d9ca0a80-d880-4c35-96d1-a7cfd8977826"), "Other", "Other" }
                });

            migrationBuilder.InsertData(
                table: "tblFormat",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("3f6b69f0-3019-4144-913a-52241ca9620f"), "Blu-Ray" },
                    { new Guid("5e7e8a54-f847-4682-8072-e605abcfbe6a"), "Other" },
                    { new Guid("88af9351-8238-453e-98e9-9011daf02af5"), "VHS" },
                    { new Guid("c42b60e7-2e91-4146-a47b-41ffcc1f2f29"), "DVD" }
                });

            migrationBuilder.InsertData(
                table: "tblGenre",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("212836a7-cd81-434b-84b7-f537a97771d2"), "Sci-Fi" },
                    { new Guid("34589a40-c2af-497e-bc2c-df52ae3e5cd6"), "Action" },
                    { new Guid("47c97388-2979-4577-88f1-7923a27606e8"), "Documentary" },
                    { new Guid("52f5e158-fe8c-43ea-b327-d5b655e46b63"), "Western" },
                    { new Guid("7b5990bc-61b9-47ab-b9f3-e63f2477bd63"), "Romance" },
                    { new Guid("8da7c3bd-38a8-4af1-82c8-34b7f28801b3"), "Horror" },
                    { new Guid("bb2e4e35-f56d-43ee-8dca-ca3371e071f3"), "Mystery" },
                    { new Guid("bbbc2490-e3f5-4589-90a8-34fe4d75298f"), "Other" },
                    { new Guid("c55427bb-6830-490d-a92d-f4a4e005caea"), "Comedy" },
                    { new Guid("cfc67b74-e3d4-4dd7-a2c2-3c56d429bb2c"), "Musical" }
                });

            migrationBuilder.InsertData(
                table: "tblOrder",
                columns: new[] { "Id", "CustomerId", "OrderDate", "ShipDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("069f4810-7c80-4b04-b8cf-6ebd49bf3103"), new Guid("aedf3410-4d7c-4107-86c2-3304d2d0b8a6"), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5cd9a2c2-a54b-4a67-a206-f080771e6c46") },
                    { new Guid("585232c2-522d-4327-8c43-3bc0d98adfdb"), new Guid("aedf3410-4d7c-4107-86c2-3304d2d0b8a6"), new DateTime(2022, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7dcf4b54-921e-4cd2-a07d-0082264bf6bf") },
                    { new Guid("d8c9499c-7112-4322-ad7a-499b6558c31e"), new Guid("e87eaf88-9ada-43b7-ac57-05d50f3a9f56"), new DateTime(2017, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5cd9a2c2-a54b-4a67-a206-f080771e6c46") }
                });

            migrationBuilder.InsertData(
                table: "tblOrderItem",
                columns: new[] { "Id", "Cost", "MovieId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("0847225b-17aa-4beb-980e-15f9a6c2adcf"), 8.9900000000000002, new Guid("7c64848d-3fa5-48d4-87a1-495a57e94a76"), new Guid("d8c9499c-7112-4322-ad7a-499b6558c31e"), 0 },
                    { new Guid("4e08b331-3c4b-462c-9c92-24b522c1c0d9"), 9.9900000000000002, new Guid("97d65ba3-2789-46cc-81e4-64ddbb6a1a05"), new Guid("d8c9499c-7112-4322-ad7a-499b6558c31e"), 0 },
                    { new Guid("f1bf0529-c3b3-46b6-8a5a-19694e220dd5"), 10.99, new Guid("97d65ba3-2789-46cc-81e4-64ddbb6a1a05"), new Guid("069f4810-7c80-4b04-b8cf-6ebd49bf3103"), 0 }
                });

            migrationBuilder.InsertData(
                table: "tblRating",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("03d0de13-4f1b-460d-b4c8-c23e265e05fd"), "R" },
                    { new Guid("519cbe56-4714-4a3d-91ff-5bfac3ed301f"), "PG-13" },
                    { new Guid("83032d4c-fec2-4a90-b9e6-283ab967942f"), "G" },
                    { new Guid("d7a7ef3c-2dda-4963-94a9-a78220700e09"), "PG" },
                    { new Guid("dd8f1343-c4f1-44e2-9066-8ad463f1e80f"), "Other" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("5cd9a2c2-a54b-4a67-a206-f080771e6c46"), "John", "Doro", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "jdoro" },
                    { new Guid("7dcf4b54-921e-4cd2-a07d-0082264bf6bf"), "Brian", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "bfoote" },
                    { new Guid("d33e147e-8168-401c-b739-d837ba3f94d4"), "Steve", "Marin", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "smarin" }
                });

            migrationBuilder.InsertData(
                table: "tblCart",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("32c46caa-b3af-4a58-b28a-686154ec91e6"), new Guid("5cd9a2c2-a54b-4a67-a206-f080771e6c46") },
                    { new Guid("332e13a2-bf6b-41fe-bf60-b5d47e0e89fc"), new Guid("d33e147e-8168-401c-b739-d837ba3f94d4") }
                });

            migrationBuilder.InsertData(
                table: "tblMovie",
                columns: new[] { "Id", "Cost", "Description", "DirectorId", "FormatId", "ImagePath", "Quantity", "RatingId", "Title" },
                values: new object[,]
                {
                    { new Guid("33f653cb-5308-4453-99be-eec4e8798dda"), 7.5, "Star Wars: Episode IV – A New Hope is a 1977 American epic space-opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.", new Guid("68e368f2-817b-4250-ae7c-295baecf2872"), new Guid("c42b60e7-2e91-4146-a47b-41ffcc1f2f29"), "StarWarsNewHope.jpg", 1, new Guid("519cbe56-4714-4a3d-91ff-5bfac3ed301f"), "Star Wars: Episode IV – A New Hope" },
                    { new Guid("7c64848d-3fa5-48d4-87a1-495a57e94a76"), 6.9900000000000002, "Rocky is a 1976 American sports drama film directed by John G. Avildsen, written by and starring Sylvester Stallone.", new Guid("d4d54b8b-de88-4a1e-8ce1-8e6f3811eadd"), new Guid("88af9351-8238-453e-98e9-9011daf02af5"), "Rocky.jpg", 2, new Guid("83032d4c-fec2-4a90-b9e6-283ab967942f"), "Rocky" },
                    { new Guid("89140fae-2f4c-45b9-8b85-490b0b7c1f0b"), 10.5, "Indiana Jones and the Last Crusade is a 1989 American action-adventure film directed by Steven Spielberg, from a story co-written by executive producer George Lucas.", new Guid("cccb7073-fae5-4d73-b06b-37ac9eff399d"), new Guid("3f6b69f0-3019-4144-913a-52241ca9620f"), "IndianaJonesLastCrusade.jpg", 2, new Guid("03d0de13-4f1b-460d-b4c8-c23e265e05fd"), "Indiana Jones and the Last Crusade" },
                    { new Guid("97d65ba3-2789-46cc-81e4-64ddbb6a1a05"), 8.9900000000000002, "Jaws is a 1975 American thriller film directed by Steven Spielberg and based on the Peter Benchley 1974 novel of the same name.", new Guid("68e368f2-817b-4250-ae7c-295baecf2872"), new Guid("c42b60e7-2e91-4146-a47b-41ffcc1f2f29"), "Jaws1.jpg", 1, new Guid("519cbe56-4714-4a3d-91ff-5bfac3ed301f"), "Jaws" },
                    { new Guid("ebc4162c-a971-4e51-92ba-1f0419832ded"), 9.9900000000000002, "Pale Rider is a 1985 American Western film produced and directed by Clint Eastwood, who also stars in the lead role.", new Guid("68e368f2-817b-4250-ae7c-295baecf2872"), new Guid("c42b60e7-2e91-4146-a47b-41ffcc1f2f29"), "PaleRider.jpg", 1, new Guid("519cbe56-4714-4a3d-91ff-5bfac3ed301f"), "Pale Rider" },
                    { new Guid("eeb02716-7d4b-4ca8-a0a6-8da2f6453da8"), 6.9900000000000002, "Other", new Guid("d4d54b8b-de88-4a1e-8ce1-8e6f3811eadd"), new Guid("88af9351-8238-453e-98e9-9011daf02af5"), "Rocky.jpg", 2, new Guid("83032d4c-fec2-4a90-b9e6-283ab967942f"), "Other" },
                    { new Guid("fc09c6c8-7f4f-4b90-89f3-100d67cba9e3"), 12.5, "The Princess Bride is a 1987 American fantasy adventure comedy film directed and co-produced by Rob Reiner, starring Cary Elwes, Robin Wright, Mandy Patinkin, Chris Sarandon, Wallace Shawn, André the Giant, and Christopher Guest.", new Guid("55dd42ba-32eb-4b47-8a6c-04b43507c6db"), new Guid("3f6b69f0-3019-4144-913a-52241ca9620f"), "PrincessBride.jpg", 4, new Guid("d7a7ef3c-2dda-4963-94a9-a78220700e09"), "The Princess Bride" }
                });

            migrationBuilder.InsertData(
                table: "tblCartItem",
                columns: new[] { "Id", "CartId", "MovieId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("0a5e9f29-aacb-4819-9680-55f8d41988dd"), new Guid("332e13a2-bf6b-41fe-bf60-b5d47e0e89fc"), new Guid("97d65ba3-2789-46cc-81e4-64ddbb6a1a05"), 2 },
                    { new Guid("db925cb9-1914-4a8a-860b-70bab18a41ff"), new Guid("332e13a2-bf6b-41fe-bf60-b5d47e0e89fc"), new Guid("7c64848d-3fa5-48d4-87a1-495a57e94a76"), 1 },
                    { new Guid("df56c3bf-f040-4d24-be71-8c441cf621ef"), new Guid("32c46caa-b3af-4a58-b28a-686154ec91e6"), new Guid("97d65ba3-2789-46cc-81e4-64ddbb6a1a05"), 1 }
                });

            migrationBuilder.InsertData(
                table: "tblMovieGenre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("00b91041-1311-4cfa-824c-b96f91888bcc"), new Guid("8da7c3bd-38a8-4af1-82c8-34b7f28801b3"), new Guid("89140fae-2f4c-45b9-8b85-490b0b7c1f0b") },
                    { new Guid("34f8a717-454c-42a4-ad9e-5fe5dac4242d"), new Guid("c55427bb-6830-490d-a92d-f4a4e005caea"), new Guid("fc09c6c8-7f4f-4b90-89f3-100d67cba9e3") },
                    { new Guid("357255a4-af64-48a7-8b1e-ce6fc9d94ae3"), new Guid("47c97388-2979-4577-88f1-7923a27606e8"), new Guid("7c64848d-3fa5-48d4-87a1-495a57e94a76") },
                    { new Guid("3947b167-834b-4711-868d-3c01f4c15479"), new Guid("47c97388-2979-4577-88f1-7923a27606e8"), new Guid("89140fae-2f4c-45b9-8b85-490b0b7c1f0b") },
                    { new Guid("4e72d4df-8ac0-466d-b03f-22569e9e1317"), new Guid("212836a7-cd81-434b-84b7-f537a97771d2"), new Guid("97d65ba3-2789-46cc-81e4-64ddbb6a1a05") },
                    { new Guid("4f95f91f-32c8-4925-9112-ce8c6fa585b4"), new Guid("bb2e4e35-f56d-43ee-8dca-ca3371e071f3"), new Guid("ebc4162c-a971-4e51-92ba-1f0419832ded") },
                    { new Guid("5f6ce3b2-c8b6-421e-bfe6-79f8cc64847c"), new Guid("8da7c3bd-38a8-4af1-82c8-34b7f28801b3"), new Guid("97d65ba3-2789-46cc-81e4-64ddbb6a1a05") },
                    { new Guid("6de1c0ff-673f-4326-b6d4-756b38be0172"), new Guid("8da7c3bd-38a8-4af1-82c8-34b7f28801b3"), new Guid("7c64848d-3fa5-48d4-87a1-495a57e94a76") },
                    { new Guid("753aa70f-54c6-4e00-8267-220c75f9ae75"), new Guid("34589a40-c2af-497e-bc2c-df52ae3e5cd6"), new Guid("fc09c6c8-7f4f-4b90-89f3-100d67cba9e3") },
                    { new Guid("9198f64a-e42f-4a83-bc09-b69a825374ca"), new Guid("cfc67b74-e3d4-4dd7-a2c2-3c56d429bb2c"), new Guid("33f653cb-5308-4453-99be-eec4e8798dda") },
                    { new Guid("968bfa58-7cf8-4864-98cb-adf8b058a755"), new Guid("47c97388-2979-4577-88f1-7923a27606e8"), new Guid("fc09c6c8-7f4f-4b90-89f3-100d67cba9e3") },
                    { new Guid("a0c4c3a5-bb1d-4205-939b-90fbf0abd786"), new Guid("8da7c3bd-38a8-4af1-82c8-34b7f28801b3"), new Guid("33f653cb-5308-4453-99be-eec4e8798dda") },
                    { new Guid("bd59e16b-aaee-4dbb-b114-5b768f8c6490"), new Guid("212836a7-cd81-434b-84b7-f537a97771d2"), new Guid("7c64848d-3fa5-48d4-87a1-495a57e94a76") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCart_UserId",
                table: "tblCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartItem_CartId",
                table: "tblCartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartItem_MovieId",
                table: "tblCartItem",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovie_DirectorId",
                table: "tblMovie",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovie_FormatId",
                table: "tblMovie",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovie_RatingId",
                table: "tblMovie",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovieGenre_GenreId",
                table: "tblMovieGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovieGenre_MovieId",
                table: "tblMovieGenre",
                column: "MovieId");

            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[spGetMovies]
                AS
                    select m.Id, m.RatingId, m.DirectorId, m.FormatId, m.Cost, m.Title, m.Description, m.Quantity,
                    r.Description RatingDescription,
                    f.Description FormatDescription,
                    d.FirstName, d.LastName
                    from tblMovie m
                    inner join tblRating r on m.RatingId = r.Id
                    inner join tblFormat f on m.FormatId = f.Id
                    inner join tblDirector d on m.DirectorId = d.Id
 
                RETURN 0");

            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[spGetMoviesByGenre]
                     @GenreName VARCHAR(20)
                AS
                     select m.Id, m.RatingId, m.DirectorId, m.FormatId, m.Cost, m.Title, m.Description, m.Quantity,
                     r.Description RatingDescription,
                     f.Description FormatDescription,
                     d.FirstName, d.LastName
                     from tblMovie m
                     inner join tblRating r on m.RatingId = r.Id
                     inner join tblFormat f on m.FormatId = f.Id
                     inner join tblDirector d on m.DirectorId = d.Id
                     inner join tblMovieGenre mg on m.Id = mg.MovieId
                     inner join tblGenre g on mg.GenreId = g.Id
                     WHERE g.Description Like '%' + @GenreName + '%'
                RETURN 0
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCartItem");

            migrationBuilder.DropTable(
                name: "tblCustomer");

            migrationBuilder.DropTable(
                name: "tblMovieGenre");

            migrationBuilder.DropTable(
                name: "tblOrder");

            migrationBuilder.DropTable(
                name: "tblOrderItem");

            migrationBuilder.DropTable(
                name: "tblCart");

            migrationBuilder.DropTable(
                name: "tblGenre");

            migrationBuilder.DropTable(
                name: "tblMovie");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblDirector");

            migrationBuilder.DropTable(
                name: "tblFormat");

            migrationBuilder.DropTable(
                name: "tblRating");
        }
    }
}
