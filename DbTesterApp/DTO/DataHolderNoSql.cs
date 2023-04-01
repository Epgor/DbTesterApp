using DbTesterApp.Models.NoSql;

namespace DbTesterApp.DTO
{
    public class DataHolderNoSql
    {
        public List<BookNoSql> Books { get; set; }
        public List<WorkerNoSql> Workers { get; set; }
        public List<LibraryNoSql> Libraries { get; set; }
        public List<OrganizationNoSql> Organisations { get; set; }
        public List<NumberNoSql> Numbers { get; set; }
        public List<PointNoSql> Points { get; set; }
        public List<VectorNoSql> Vectors { get; set; }
    }
}
