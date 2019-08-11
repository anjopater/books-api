
using Books.Domain.Books;
using Books.Services.ViewModels;

namespace Books.Services.Factory
{
    public static class ModelFactory
    {
        public static BookViewModel CreateViewModel(Book bookToView)
        {
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

        public static Book CreateDomainModel(BookViewModel bookToCreate)
        {
            return new Book(
                title: bookToCreate.Title,
                genre: bookToCreate.Genre,
                releaseYear: bookToCreate.ReleaseYear,
                autor: bookToCreate.Autor,
                imgUrl: bookToCreate.ImgUrl
            );
        }
    }
}
