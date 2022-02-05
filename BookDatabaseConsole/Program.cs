using BookDatabaseConsole;

const string RootUri = "http://localhost:5231";

using var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri(RootUri);

var testHarness = new BookDatabaseTestHarness(httpClient);

await testHarness.AddBooksAsync();
await testHarness.IncrementBookSaleCountsAsync();
await testHarness.OutputBooksAsync();

Console.WriteLine("Finished!");
Console.ReadLine();