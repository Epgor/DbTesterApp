namespace DbTesterApp.Models.Sql
{
    public class Point : BasePoint
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Number> Values { get; set; }
    }
}
