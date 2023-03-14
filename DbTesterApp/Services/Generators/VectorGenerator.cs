using Bogus;
using DbTesterApp.Models.Sql;

namespace DbTesterApp.Services
{
    public static class VectorGenerator
    {
        public static async Task<Vector> GetVector(
            string id,
            List<Point> points,
            int quantity = 1)
        {
            var vector = new Faker<Vector>()
              .RuleFor(p => p.Id, (f, p) => p.Id = id)
              .RuleFor(p => p.Name, (f, p) => f.Person.FirstName)
              .RuleFor(p => p.Values, (f, p) => p.Values = points)
              .Generate(quantity);

            return vector.First();
        }
    }
}