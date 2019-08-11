using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Services.ViewModels
{
    //Define the class that you want to display to the user whenever we are retrieving data.
    public class BookViewModel
    {
        //We would not want the user to see the data.
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Autor { get; set; }
        public string ImgUrl{ get; set; }
    }
}
