using Bogus;
using DbTesterApp.Models.Sql;

namespace DbTesterApp.Services
{
    public static class PointGenerator
    {
        public static async Task<Point> GetPoint(
            string id,
            List<Number> numbers,
            int quantity = 1)
        {
            var point = new Faker<Point>()
              .RuleFor(p => p.Id, (f, p) => p.Id = id)
              .RuleFor(p => p.Name, (f, p) => f.Person.FirstName)
              .RuleFor(p => p.Values, (f, p) => p.Values = numbers)
              .Generate(quantity);

            return point.First();
        }
    }
}