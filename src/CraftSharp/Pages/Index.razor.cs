using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using CraftSharp.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CraftSharp.Services;

namespace CraftSharp.Pages
{
    public partial class Index
    {
        [Inject]
        public IStringLocalizer<Index> Localizer { get; set; }

        [Inject]
        public ILogger<Index> Logger { get; set; }

        private void CreateLogs()
        {
            var logLevels = Enum.GetValues(typeof(LogLevel)).Cast<LogLevel>();

            foreach (var logLevel in logLevels.Where(l => l != LogLevel.None))
            {
                Logger.Log(logLevel, $"Log message for the level: {logLevel}");
            }
        }

    }
}
