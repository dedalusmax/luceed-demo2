namespace LuceedDemo.Shared;

public abstract record LuceedApiResult<T>
{
    public List<T> result { get; set; }
}
