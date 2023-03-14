namespace DbTesterApp.Models.Sql
{
    public class Vector : BaseVector
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Point> Values { get; set; }
    }
}
