namespace DbTesterApp.Models
{
    public class Organization : BaseOrganization
    {
        public string Id { get; set; }
        public string OrganizationName { get; set; }
        public List<Library> Libraries { get; set; }
        public List<Worker> Workers { get; set; }
    }
}
