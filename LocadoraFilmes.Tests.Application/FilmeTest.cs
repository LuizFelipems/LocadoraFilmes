namespace LocadoraFilmes.Tests.Application
{
    public class FilmeTest
    {
        private List<Book> Books;
        private Book Book1, Book2, Book3, Book4;

        public BooksOrdererServiceTest()
        {
            Books = DomainFactory.GetBooks;

            Book1 = Books[0];
            Book2 = Books[1];
            Book3 = Books[2];
            Book4 = Books[3];
        }

        private BooksOrdererService InitializeService() => new();

        /// <summary>
        /// Método de teste do primeiro UseCase, com o Título ascendente
        /// </summary>
        [Fact]
        public void WhenTitleAsc()
        {
            #region Arrange


            var service = InitializeService();
            #endregion

            #region Act
            var result = service.Orderer(Books);
            #endregion

            #region Assert
            Assert.Equal(result[0].Title, Book3.Title);
            Assert.Equal(result[1].Title, Book4.Title);
            Assert.Equal(result[2].Title, Book1.Title);
            Assert.Equal(result[3].Title, Book2.Title);
            #endregion
        }
    }
}