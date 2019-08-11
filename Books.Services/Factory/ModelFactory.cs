using System;
using System.Collections.Generic;
using System.Text;
//import your domain models and your view models
using Books.Domain.Books;
using Books.Services.ViewModels;

namespace Books.Services.Factory
{
    //Make your class static since all the method would be static, and will be only responsible for creating domain models for insertion in the future,
    //view models for making the data recieved viewable to the user.
    public static class ModelFactory
    {
        //Now create a method that will responsible for creating view models therefore making your domain model viewable to the user.
        public static BookViewModel CreateViewModel(Book bookToView)
        {
            //Have it return a new BookViewModel instance with it's property assign to the bookTOView properties.
            return new BookViewModel()
            {
                Id = bookToView.Id,
                Title = bookToView.Title,
                Genre = bookToView.Genre,
                ReleaseYear = bookToView.ReleaseYear,
                Autor = bookToView.Autor,
                ImgUrl = bookToView.ImgUrl
            };
        }
        
        //Now create a method that will be responsible for creating domain therefore making your viewmodel suitable to create data.
        public static Book CreateDomainModel(BookViewModel bookToCreate)
        {
            //Now return a new Book domain model
            return new Book(
                title: bookToCreate.Title,
                genre: bookToCreate.Genre,
                releaseYear: bookToCreate.ReleaseYear,
                autor:bookToCreate.Autor,
                imgUrl: bookToCreate.ImgUrl
            );
        }
    }
}
