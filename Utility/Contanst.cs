using System;
namespace study.Utility
{
#pragma warning disable CS8601 // Possible null reference assignment.
    public class Contanst
	{
		public Contanst()
		{
		}
	}

    public enum Connect
    {
        Read = 1,
        Write = 2
    }

    public enum Method
    {
        GET = 1,
        POST = 2,
        PUT = 3,
        DELETE = 4,
    }

    public class LogType
    {
        public static string LogInfo = "[Info] ";
        public static string LogError = "[Error] ";
    }
    public class LogKafka
    {

        public static string BrokerList = ConfigurationManager.AppSetting["Serilog:Brokers"];
        public static string Topic1Name = ConfigurationManager.AppSetting["Serilog:Topic1"];
        public static string Topic2Name = ConfigurationManager.AppSetting["Serilog:Topic2"];
        public static string Environment = ConfigurationManager.AppSetting["AppSetting:Environment"];
    }
#pragma warning restore CS8601 // Possible null reference assignment.
}

