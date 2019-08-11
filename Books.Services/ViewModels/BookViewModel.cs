using System;

namespace Books.Services.ViewModels
{
    public class BookViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Autor { get; set; }
        public string ImgUrl { get; set; }
    }
}
