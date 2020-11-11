namespace App1.Utils
{
    public class Result<T,E>
    {
        public Result(T data) => Successful = (true, data);
        public Result(E data) => Error      = (true, data);
 
        public (bool success, T Value) Successful { get; }
        public (bool error, E Msg) Error      { get; }
    }
}