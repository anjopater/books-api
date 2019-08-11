using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Domain.Books
{
    //Have all your domain classes extend the entity class.
    //Entity classes are a abstract class that has characteristics that all domain models have or will inherit.
    public class Book : Entity
    {
        //Define your constructor for creating and updating from database
        //Will use it to convert a view model to a domain model in our services to use as a argument to our repository to create new data.
        public Book(string title, string genre, int releaseYear, string autor, string imgUrl)
        {
            Title = title;
            Genre = genre;
            ReleaseYear = releaseYear;
            Autor = autor;
            ImgUrl = imgUrl;
        }
        //Your Books Table will have a column with a id(inherited from the entity class) with a type of integar.
        //THen will have a title, genre, and company column with a type of string.
        //Then have a ReleaseYear column with type of integar. 
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Autor { get; set; }
        public string ImgUrl { get; set; }
    }
}
