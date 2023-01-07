namespace DbTesterApp.Models
{
    public class Organization
    {
        public string Id { get; set; }
        public string OrganisationName { get; set; }
        public string Address { get; set; }
        public List<Library> Libraries { get; set; }
        public List<Worker> Workers { get; set; }
    }
}
