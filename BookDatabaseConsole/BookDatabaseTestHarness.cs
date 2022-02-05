using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.Http.Json;

namespace BookDatabaseConsole
{
    internal class BookDatabaseTestHarness
    {
        private readonly HttpClient httpClient;
        private readonly ConcurrentDictionary<Guid, Book> books = new();

        public BookDatabaseTestHarness(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task AddBooksAsync()
        {
            for (var index = 1; index <= 5; index++)
            {
                var bookName = $"Book {index}";
                var book = new Book
                {
                    Name = bookName
                };

                var response = await httpClient.PostAsJsonAsync("Books", book);
                response.EnsureSuccessStatusCode();
                book = await response.Content.ReadFromJsonAsync<Book>();

                if (book is not null)
                {
                    books.TryAdd(book.Id, book);
                    Console.WriteLine($"Added {bookName}");
                }
            }
        }

        public Task IncrementBookSaleCountsAsync()
        {
            Console.WriteLine("Incrementing sale counts...");

            var incrementSaleCountTasks = new List<Task>();

            foreach (var book in books.Values)
            {
                var bookSaleRequest = new BookSaleRequst
                {
                    BookId = book.Id
                };

                for (var count = 0; count < 1000; count++)
                {
                    Console.WriteLine($"Book {book.Name} - Count {count}");
                    var incrementSaleCountTask = IncrementSaleCountAsync(bookSaleRequest);
                    incrementSaleCountTasks.Add(incrementSaleCountTask);
                }
            }

            return Task.WhenAll(incrementSaleCountTasks);
        }

        private async Task IncrementSaleCountAsync(BookSaleRequst bookSaleRequest)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            await httpClient.PostAsJsonAsync("Books/Sale", bookSaleRequest);

            stopwatch.Stop();
            this.books[bookSaleRequest.BookId].AddResponseTime(stopwatch.ElapsedMilliseconds);

            Console.WriteLine($"Received response from {bookSaleRequest.BookId}");
        }

        public async Task OutputBooksAsync()
        {
            foreach (var book in books.Values)
            {
                var bookResponse = await httpClient.GetFromJsonAsync<Book>($"Books/{book.Id}");

                if (bookResponse is not null)
                {
                    Console.WriteLine($"{bookResponse.Name}\t{bookResponse.SalesCount}\t{book.GetAverageResponseTime()}ms");
                }
            }
        }
    }
}
