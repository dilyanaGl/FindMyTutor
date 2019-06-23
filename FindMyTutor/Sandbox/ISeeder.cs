namespace Sandbox
{
    using System;
    using System.Threading.Tasks;
    using FindMyTutor.Data;

    public interface ISeeder
    {
        Task SeedAsync(FindMyTutorWebContext dbContext, IServiceProvider serviceProvider);
    }
}