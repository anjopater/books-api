using Books.Domain.Books;
using System.Linq;

namespace Books.Data.Seeds
{
    public static class EnsureBooksData
    {
        public static void Seed(BooksContext context)
        {
            if(context.Books.FirstOrDefault() == null)
            {
                Book newBook1 = new Book(
                    id: new System.Guid(),
                    title: "Cien Anos de Soledad",
                    genre: "Drama",
                    releaseYear: 1990,
                    autor: "Gabriel Gacia Marquez",
                    imgUrl: "https://images-na.ssl-images-amazon.com/images/I/51egIZUl88L._SX336_BO1,204,203,200_.jpg"
                );
                context.Books.Add(newBook1);
                context.SaveChanges();
                
                Book newBook2 = new Book(
                    id: new System.Guid(),
                    title: "El Alquimista: Una Fabula Para Seguir Tus Suenos",
                    genre: "Fabule",
                    releaseYear: 1995,
                    autor: "Paulo Cohelo",
                    imgUrl: "https://images-na.ssl-images-amazon.com/images/I/41LfYrZSQML._SX327_BO1,204,203,200_.jpg"
                );
                
                context.Books.Add(newBook2);
                context.SaveChanges();
                
                Book newBook3 = new Book(
                    id: new System.Guid(),
                    title: "Don Quijote de la Mancha",
                    genre: "Alternate story",
                    releaseYear: 1970,
                    autor: "Miguel de cervantes",
                    imgUrl: "https://images-na.ssl-images-amazon.com/images/I/51bnuGpPpXL._SX321_BO1,204,203,200_.jpg"
                );
                
                context.Books.Add(newBook3);
                context.SaveChanges();

            }
            return;
        }
    }
}
