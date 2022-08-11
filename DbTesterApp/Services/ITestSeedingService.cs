namespace DbTesterApp.Services
{
    public interface ITestSeedingService
    {
        void SeedNoSql();
        void SeedSql();
    }
}