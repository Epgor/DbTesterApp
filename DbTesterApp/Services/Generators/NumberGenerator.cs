using Bogus;
using DbTesterApp.Models;

namespace DbTesterApp.Services
{
    public static class NumberGenerator
    {
        public static async Task<Number> GetNumber(string id, int quantity = 1)
        {
            var number = new Faker<Number>()
              .RuleFor(p => p.Id, (f, p) => p.Id = id)
              .RuleFor(p => p.Name, (f, p) => f.Person.FirstName)
              .RuleFor(p => p.Value, (f, p) => f.Random.Number(0,10000))
              .Generate(quantity);

            return number.First();
        }
    }
}