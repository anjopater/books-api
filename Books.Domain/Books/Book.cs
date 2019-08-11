namespace Books.Domain.Books
{
    public class Book : Entity
    {

        public Book(string title, string genre, int releaseYear, string autor, string imgUrl)
        {
            Title = title;
            Genre = genre;
            ReleaseYear = releaseYear;
            Autor = autor;
            ImgUrl = imgUrl;
        }

        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Autor { get; set; }
        public string ImgUrl { get; set; }
    }
}
