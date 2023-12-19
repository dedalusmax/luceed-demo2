namespace LuceedDemo.Shared;

public record Article
{
    public int id { get; set; }

    public string naziv { get; set; }
}

public record ResultList
{
    public List<Article> artikli { get; set; }
}

public sealed record ArticlesResult
{
    public List<ResultList> result { get; set; }
}
