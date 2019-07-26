using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        [Route("api/all")]
        public IDictionary<string, string> GetAll()
        {
            var config = new Dictionary<string, string>();

            foreach (var appSetting in ConfigurationManager.AppSettings.AllKeys)
                config[$"AS_{appSetting}"] = ConfigurationManager.AppSettings[appSetting];

            foreach (ConnectionStringSettings connStr in ConfigurationManager.ConnectionStrings)
                config[$"CS_{connStr.Name}"] = connStr.ConnectionString;

            return config;
        }

        [Route("api/appsettings")]
        public IDictionary<string, string> GetAppSettings()
        {
            var config = new Dictionary<string, string>();

            foreach (var appSetting in ConfigurationManager.AppSettings.AllKeys)
                config[appSetting] = ConfigurationManager.AppSettings[appSetting];

            return config;
        }

        [Route("api/connectionstrings")]
        public IDictionary<string, string> GetConnectionStrings()
        {
            var config = new Dictionary<string, string>();

            foreach (ConnectionStringSettings connStr in ConfigurationManager.ConnectionStrings)
                config[connStr.Name] = connStr.ConnectionString;

            return config;
        }
    }
}
