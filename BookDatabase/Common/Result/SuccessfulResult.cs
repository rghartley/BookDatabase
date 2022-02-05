namespace BookDatabase.Common.Result
{
    internal class SuccessfulResult<T> : Result<T>
    {
        public SuccessfulResult(T value)
        {
            this.Value = value;
        }

        public T Value { get; }
    }
}
