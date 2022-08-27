// ReSharper disable InvertIf
// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System.ComponentModel.DataAnnotations;

[SuppressMessage("Performance", "CA1813:Avoid unsealed attributes", Justification = "OK.")]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class IsoCurrencySymbolAttribute : ValidationAttribute
{
    public IsoCurrencySymbolAttribute()
        : base("The {0} field requires a ISO-Currency-Symbol value.")
    {
        this.Required = false;
        this.IsoCurrencySymbols = Array.Empty<string>();
    }

    public bool Required { get; set; }

    public string[] IsoCurrencySymbols { get; set; }

    public override bool IsValid(
        object? value)
    {
        if (this.Required &&
            value is null)
        {
            this.ErrorMessage = "The {0} field is required.";
            return false;
        }

        if (value is null)
        {
            return true;
        }

        var str = value.ToString();
        if (str!.Length != 3 ||
            !str.Equals(str.ToUpper(GlobalizationConstants.EnglishCultureInfo), StringComparison.Ordinal))
        {
            this.ErrorMessage = "The field {0} is not a valid ISO-Currency-Symbol, it should be in three upper-case letters.";
            return false;
        }

        if (this.IsoCurrencySymbols.Any())
        {
            if (!this.IsoCurrencySymbols.Any(x => str.Equals(x.ToUpper(GlobalizationConstants.EnglishCultureInfo), StringComparison.Ordinal)))
            {
                this.ErrorMessage = $"The field {{0}} do not match any: {string.Join(", ", this.IsoCurrencySymbols)}.";
                return false;
            }
        }
        else
        {
            var systemIsoCurrencySymbols = CultureHelper
                .GetCultures()
                .Select(x => x.IsoCurrencySymbol.ToUpper(GlobalizationConstants.EnglishCultureInfo))
                .OrderBy(x => x)
                .ToList();

            if (!systemIsoCurrencySymbols.Any(x => str.Equals(x, StringComparison.Ordinal)))
            {
                this.ErrorMessage = $"The field {{0}} do not match any: {string.Join(", ", systemIsoCurrencySymbols)}.";
                return false;
            }
        }

        return true;
    }
}