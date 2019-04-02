namespace WCFLayer
{
    public sealed class Service : IContract
    {
        public string GetData()
        {
            return "Hello World!";
        }
    }
}
