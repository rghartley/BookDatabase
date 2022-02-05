namespace BookDatabaseConsole
{
    internal class Book
    {
        private long totalResponseTime;
        private int numberOfResponses;

        public Guid Id { get; init; }

        public string Name { get; init; } = string.Empty;

        public int SalesCount { get; init; }

        public void AddResponseTime(long responseTime)
        {
            Interlocked.Increment(ref numberOfResponses);
            Interlocked.Add(ref totalResponseTime, responseTime);
        }

        public double GetAverageResponseTime()
        {
            return totalResponseTime / (double)this.numberOfResponses;
        }
    }
}
