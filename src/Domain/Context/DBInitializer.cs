using Microsoft.EntityFrameworkCore;
using pressAgency.Domain.Entites;

namespace pressAgency.Domain.Context
{
    public class DBInitializer
    {
        private readonly ModelBuilder modelBuilder;
        private static readonly DateTime SeedDate = new DateTime(2026, 1, 18, 0, 0, 0, DateTimeKind.Utc);

        public DBInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Authors>().HasData(
                new Authors
                {
                    AuthorId = 1,
                    Email = "john.doe@netpress.com",
                    Name = "John Doe"
                },
                new Authors
                {
                    AuthorId = 2,
                    Email = "redaction@netpress.com",
                    Name = "Redaction Team"
                }
            );

            modelBuilder.Entity<Posts>().HasData(
                new Posts { PostId = 1, Title = "Introduction to PostgreSQL", Content = "PostgreSQL is a powerful open-source relational database known for reliability, extensibility, and strong SQL compliance.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 1 },
                new Posts { PostId = 2, Title = "Understanding Indexes", Content = "Indexes help databases retrieve data faster by reducing the number of scanned rows during query execution.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 2 },
                new Posts { PostId = 3, Title = "ACID Properties Explained", Content = "ACID stands for Atomicity, Consistency, Isolation, and Durability, which guarantee reliable database transactions.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 1 },
                new Posts { PostId = 4, Title = "Database Normalization Basics", Content = "Normalization reduces data redundancy and improves data integrity by organizing tables and relationships.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 2 },
                new Posts { PostId = 5, Title = "What Is MVCC", Content = "Multi-Version Concurrency Control allows PostgreSQL to handle concurrent reads and writes efficiently.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 1 },
                new Posts { PostId = 6, Title = "Transactions in Practice", Content = "Transactions group multiple operations into a single unit of work that either fully succeeds or fails.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 2 },
                new Posts { PostId = 7, Title = "Using Foreign Keys", Content = "Foreign keys enforce referential integrity between related tables and prevent invalid data relationships.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 1 },
                new Posts { PostId = 8, Title = "Soft Deletes vs Hard Deletes", Content = "Soft deletes keep data for auditing while hard deletes permanently remove records from the database.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 2 },
                new Posts { PostId = 9, Title = "REST API Fundamentals", Content = "REST APIs use standard HTTP methods to enable communication between clients and servers.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 1 },
                new Posts { PostId = 10, Title = "HTTP Status Codes Overview", Content = "Status codes indicate the result of an HTTP request and help clients understand server responses.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 2 },
                new Posts { PostId = 11, Title = "JWT Authentication", Content = "JSON Web Tokens are commonly used for stateless authentication between clients and APIs.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 1 },
                new Posts { PostId = 12, Title = "Session Management Strategies", Content = "Sessions can be managed using cookies, server-side storage, or token-based approaches.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 2 },
                new Posts { PostId = 13, Title = "Database Migrations", Content = "Migrations help evolve database schemas in a controlled and versioned manner.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 1 },
                new Posts { PostId = 14, Title = "Optimizing SQL Queries", Content = "Query optimization involves proper indexing, query rewriting, and understanding execution plans.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 2 },
                new Posts { PostId = 15, Title = "Pagination Techniques", Content = "Pagination limits result sets to improve performance and user experience in data-heavy applications.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 1 },
                new Posts { PostId = 16, Title = "Handling Large Tables", Content = "Partitioning and indexing strategies help maintain performance when working with large datasets.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 2 },
                new Posts { PostId = 17, Title = "Error Handling Best Practices", Content = "Consistent error handling improves debuggability and resilience of backend services.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 1 },
                new Posts { PostId = 18, Title = "Logging and Monitoring", Content = "Effective logging and monitoring provide insight into system health and production issues.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 2 },
                new Posts { PostId = 19, Title = "Concurrency Issues", Content = "Race conditions and deadlocks can occur when multiple processes access shared resources.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 1 },
                new Posts { PostId = 20, Title = "Database Backups", Content = "Regular backups protect against data loss and enable disaster recovery.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 2 },
                new Posts { PostId = 21, Title = "Using EXPLAIN ANALYZE", Content = "EXPLAIN ANALYZE shows how PostgreSQL executes a query and where performance bottlenecks exist.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 1 },
                new Posts { PostId = 22, Title = "Connection Pooling", Content = "Connection pooling improves performance by reusing database connections instead of creating new ones.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 2 },
                new Posts { PostId = 23, Title = "Caching Strategies", Content = "Caching frequently accessed data reduces database load and improves response times.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 1 },
                new Posts { PostId = 24, Title = "Schema Design Principles", Content = "Good schema design balances normalization, performance, and future scalability.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 2 },
                new Posts { PostId = 25, Title = "Security Best Practices", Content = "Principle of least privilege, encryption, and validation help secure applications and data.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 1 },
                new Posts { PostId = 26, Title = "Preparing for Production", Content = "Production readiness includes monitoring, backups, performance testing, and security reviews.", CreatedAt = SeedDate, UpdatedAt = SeedDate, AuthorId = 2 }
            );
        }
    }
}
