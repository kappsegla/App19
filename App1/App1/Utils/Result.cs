namespace App1.Utils
{
    public class Result<T,E>
    {
        public Result(T data) => Successful = (true, data);
        public Result(E data) => Error      = (true, data);
 
        public (bool, T) Successful { get; }
        public (bool, E) Error      { get; }
    }
}