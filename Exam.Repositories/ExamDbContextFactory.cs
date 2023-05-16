using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Exam.Repositories;

public class ExamDbContextFactory : IDesignTimeDbContextFactory<ExamDbContext>
{
    public ExamDbContext CreateDbContext(string[] args)
    {
        var cs = "Server=(localdb)\\mssqllocaldb;Database=Exam;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";
        var options = new DbContextOptionsBuilder<ExamDbContext>();
        options.UseSqlServer(cs);
        options.EnableSensitiveDataLogging();
        return new ExamDbContext(options.Options);
    }
}