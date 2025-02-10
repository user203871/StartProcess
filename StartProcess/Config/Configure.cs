using StartProcess.Extensions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace StartProcess.Config
{
    public static class Configure
    {
        public static Configuration Json() 
        {
            try 
            {
                var configurationFile =
                    AppDomain.CurrentDomain.BaseDirectory +
                    @"Config\config.json";

                if (!File.Exists(
                    configurationFile)) 
                {
                    Console.WriteLine(
                        "Error: config file not found...".Timestamp());

                    throw new FileNotFoundException();
                }

                return JsonConvert.DeserializeObject<Configuration>(
                    JObject.Parse(
                        File.ReadAllText(
                            configurationFile)).
                            ToString())!;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(
                    ex.ToString());

                throw;
            }   
        }
    }
}