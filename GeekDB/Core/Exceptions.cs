namespace GeekDB.Core
{
    public class NotFindKeyException : Exception
    {
        public NotFindKeyException(string message) : base(message)
        {
        }
    }
}