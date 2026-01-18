using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace pressAgency.Domain.Migrations
{
    /// <inheritdoc />
    public partial class seederAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "john.doe@netpress.com", "John Doe" },
                    { 2, "redaction@netpress.com", "Redaction Team" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, "PostgreSQL is a powerful open-source relational database known for reliability, extensibility, and strong SQL compliance.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Introduction to PostgreSQL", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 2, "Indexes help databases retrieve data faster by reducing the number of scanned rows during query execution.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Understanding Indexes", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 1, "ACID stands for Atomicity, Consistency, Isolation, and Durability, which guarantee reliable database transactions.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "ACID Properties Explained", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, 2, "Normalization reduces data redundancy and improves data integrity by organizing tables and relationships.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Database Normalization Basics", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, 1, "Multi-Version Concurrency Control allows PostgreSQL to handle concurrent reads and writes efficiently.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "What Is MVCC", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, 2, "Transactions group multiple operations into a single unit of work that either fully succeeds or fails.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Transactions in Practice", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, 1, "Foreign keys enforce referential integrity between related tables and prevent invalid data relationships.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Using Foreign Keys", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, 2, "Soft deletes keep data for auditing while hard deletes permanently remove records from the database.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Soft Deletes vs Hard Deletes", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, 1, "REST APIs use standard HTTP methods to enable communication between clients and servers.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "REST API Fundamentals", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, 2, "Status codes indicate the result of an HTTP request and help clients understand server responses.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "HTTP Status Codes Overview", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, 1, "JSON Web Tokens are commonly used for stateless authentication between clients and APIs.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "JWT Authentication", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, 2, "Sessions can be managed using cookies, server-side storage, or token-based approaches.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Session Management Strategies", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, 1, "Migrations help evolve database schemas in a controlled and versioned manner.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Database Migrations", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, 2, "Query optimization involves proper indexing, query rewriting, and understanding execution plans.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Optimizing SQL Queries", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 15, 1, "Pagination limits result sets to improve performance and user experience in data-heavy applications.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Pagination Techniques", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 16, 2, "Partitioning and indexing strategies help maintain performance when working with large datasets.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Handling Large Tables", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 17, 1, "Consistent error handling improves debuggability and resilience of backend services.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Error Handling Best Practices", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 18, 2, "Effective logging and monitoring provide insight into system health and production issues.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Logging and Monitoring", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 19, 1, "Race conditions and deadlocks can occur when multiple processes access shared resources.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Concurrency Issues", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 20, 2, "Regular backups protect against data loss and enable disaster recovery.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Database Backups", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 21, 1, "EXPLAIN ANALYZE shows how PostgreSQL executes a query and where performance bottlenecks exist.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Using EXPLAIN ANALYZE", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 22, 2, "Connection pooling improves performance by reusing database connections instead of creating new ones.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Connection Pooling", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 23, 1, "Caching frequently accessed data reduces database load and improves response times.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Caching Strategies", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 24, 2, "Good schema design balances normalization, performance, and future scalability.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Schema Design Principles", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 25, 1, "Principle of least privilege, encryption, and validation help secure applications and data.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Security Best Practices", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 26, 2, "Production readiness includes monitoring, backups, performance testing, and security reviews.", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Preparing for Production", new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);
        }
    }
}
