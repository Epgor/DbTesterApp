namespace DbTesterApp.Models
{
    public class Library
    {
        public string Id { get; set; }
        public string LibraryName { get; set; }   
        public List<Worker> Workers { get; set; }
        public List<Book> Books { get; set; }
        public string Address { get; set; }
    }
}
