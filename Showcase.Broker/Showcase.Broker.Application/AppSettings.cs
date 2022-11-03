using Microsoft.Extensions.Configuration;

namespace Showcase.Broker.Application
{
    public class AppSettings
    {
        public Apis Apis { get; set; } = new Apis();
        public string SystemSource { get; set; } = string.Empty;

        public AppSettings(IConfiguration configuration)
        {
            SetRootProperties(configuration);
            SetApisProperties(configuration);
        }

        private void SetApisProperties(IConfiguration configuration)
        {
            const string root = "Apis";
            this.Apis.Authenticate = configuration.ReadConfig<string>(root, nameof(this.Apis.Authenticate)) ?? string.Empty;
        }

        private void SetRootProperties(IConfiguration configuration)
        {
            const string program = "Program";
            this.SystemSource = configuration.ReadConfig<string>(program, nameof(this.SystemSource)) ?? string.Empty;
        }
    }

    public class Apis
    {
        public string Authenticate { get; set; } = string.Empty;
    }
}
