using Bogus;
using DbTesterApp.Models;

namespace DbTesterApp.Services
{
    public static class OrganizationGenerator
    {
        public static async Task<Organization> GetOrganization(
            string id,
            List<Library> libraries,
            List<Worker> workers,
            int quantity = 1)
        {
            var organization = new Faker<Organization>()
              .RuleFor(p => p.Id, (f, p) => p.Id = id)
              .RuleFor(p => p.OrganizationName, (f, p) => f.Company.CompanyName())
              .RuleFor(p => p.Address, (f, p) => f.Address.FullAddress())
              .RuleFor(p => p.Libraries, (f, p) => p.Libraries = libraries)
              .RuleFor(p => p.Workers, (f, p) => p.Workers = workers)
              .Generate(quantity);

            return organization.First();
        }
    }
}