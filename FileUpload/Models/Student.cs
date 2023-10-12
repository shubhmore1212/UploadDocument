namespace FileUpload.Models
{
    public class Student
    {
        public string Number;
        public List<Book> BookList;
    }

    public class Book
    {
        public string Number;
        public List<Page> PageList;
    }

    public class Page
    {
        public string Number;
        public IFormFile File;
    }
}
