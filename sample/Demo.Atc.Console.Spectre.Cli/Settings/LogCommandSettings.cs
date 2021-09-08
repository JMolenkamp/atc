using Atc;
using Microsoft.Extensions.Logging;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Demo.Atc.Console.Spectre.Cli.Settings
{
    public class LogCommandSettings : CommandSettings
    {
        [CommandArgument(0, "[Message]")]
        public string Message { get; set; } = string.Empty;

        [CommandOption("-l|--logLevel")]
        public string LogLevel { get; set; } = "Information";

        public override ValidationResult Validate()
        {
            var validationResult = base.Validate();
            if (!validationResult.Successful)
            {
                return validationResult;
            }

            if (!Enum<LogLevel>.TryParse(LogLevel, out _))
            {
                ValidationResult.Error($"Not supported logLevel: '{LogLevel}'");
            }

            return ValidationResult.Success();
        }
    }
}