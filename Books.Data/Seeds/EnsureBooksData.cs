using System;
using System.Collections.Generic;
using System.Text;
//import your Entity/Domain classes for creating data.
using Books.Domain.Books;
//import Linq since you will be performing context operations.
using System.Linq;

namespace Books.Data.Seeds
{
    //Have the class that will implement sample data be a static class. 
    //Since it will contain only one method and that method would be static
    public static class EnsureBooksData
    {
        //Now have your Seed method be static, and it will be responsible for creating sample data for your database.
        //upon the start of your server.
        //THe seed method will take our context class as a argument, therefore enabling use to create data and save data to our context.
        public static void Seed(BooksContext context)
        {
            //We will only seed data if our table doesn't have data.
            //If the first value of the database that contains a id is null
            if(context.Books.FirstOrDefault() == null)
            {
                //We will assign a new Book 
                Book newBook1 = new Book(
                    title: "Cien anos de aoledad",
                    genre: "Drama",
                    releaseYear: 1990,
                    autor: "Gabriel Gacia Marquez",
                    imgUrl: "https://images-na.ssl-images-amazon.com/images/I/51egIZUl88L._SX336_BO1,204,203,200_.jpg"
                );
                //Now add all your Book and save it to your database.
                context.Books.Add(newBook1);
                context.SaveChanges();
                //We will assign a new book 
                Book newBook2 = new Book(
                    title: "El Alquimista: Una Fabula Para Seguir Tus Suenos",
                    genre: "Fabule",
                    releaseYear: 1995,
                    autor: "Paulo Cohelo",
                    imgUrl: "https://images-na.ssl-images-amazon.com/images/I/41LfYrZSQML._SX327_BO1,204,203,200_.jpg"
                );
                //Now add all your book and save it to your database.
                context.Books.Add(newBook2);
                context.SaveChanges();
                //We will assign a new book 
                Book newBook3 = new Book(
                    title: "Don Quijote de la Mancha",
                    genre: "Alternate story",
                    releaseYear: 1970,
                    autor: "Miguel de cervantes",
                    imgUrl: "https://images-na.ssl-images-amazon.com/images/I/51bnuGpPpXL._SX321_BO1,204,203,200_.jpg"
                );
                //Now add all your book and save it to your database.
                context.Books.Add(newBook3);
                context.SaveChanges();

            }
            //Then have a empty return.
            return;
        }
    }
}
