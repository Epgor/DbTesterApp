using Bogus;
using DbTesterApp.Models;

namespace DbTesterApp.Services
{
    public static class WorkerGenerator
    {
        public static async Task<Worker> GetWorker(string id, int quantity = 1)
        {
            var worker = new Faker<Worker>()
              .RuleFor(p => p.Id, (f, p) => p.Id = id)
              .RuleFor(p => p.WorkerName, (f, p) => f.Person.FullName)
              .RuleFor(p => p.Salary, (f, p) => f.Finance.Amount(3000,20000,2).ToString())
              .RuleFor(p => p.Category, (f, p) => f.Music.Genre())
              .RuleFor(p => p.Address, (f, p) => f.Address.FullAddress())
              .Generate(quantity);

            return worker.First();
        }
    }
}