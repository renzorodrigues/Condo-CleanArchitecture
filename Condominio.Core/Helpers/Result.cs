namespace Condominio.Core.Helpers
{
    public class Result<T> : CustomResult
    {
        public T Data { get; private set; }

        public Result(T data)
        {
            this.Data = data;
        }
    }

    public class Result : CustomResult
    {

    }
}
