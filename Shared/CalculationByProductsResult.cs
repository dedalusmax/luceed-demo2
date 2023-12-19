namespace LuceedDemo.Shared;

public record CalculationByProducts
{
    public string artikl_uid { get; set; }

    public string naziv_artikla { get; set; }

    public double kolicina { get; set; }

    public double iznos { get; set; }

    public string usluga { get; set; }
}

public record CalculationByProductsList
{
    public List<CalculationByProducts> obracun_artikli { get; set; }
}

public sealed record CalculationByProductsResult : LuceedApiResult<CalculationByProductsList> { }
