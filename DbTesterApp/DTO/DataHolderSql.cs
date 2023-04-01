using DbTesterApp.Models.Sql;

namespace DbTesterApp.DTO
{
    public class DataHolderSql
    {
        public List<Book> Books { get; set; }
        public List<Worker> Workers { get; set; }
        public List<Library> Libraries { get; set; }
        public List<Organization> Organisations { get; set; }
        public List<Number> Numbers { get; set; }
        public List<Point> Points { get; set; }
        public List<Vector> Vectors { get; set; }
    }
}