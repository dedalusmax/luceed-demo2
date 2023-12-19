namespace LuceedDemo.Shared;

public record CalculationByPaymentType
{
    public string vrste_placanja_uid { get; set; }

    public string naziv { get; set; }

    public double iznos { get; set; }

    public string? nadgrupa_placanja_uid { get; set; }

    public string? nadgrupa_placanja_naziv { get; set; }
}

public record CalculationByPaymentTypeList
{
    public List<CalculationByPaymentType> obracun_placanja { get; set; }
}

public sealed record CalculationByPaymentTypeResult: LuceedApiResult<CalculationByPaymentTypeList> { }

