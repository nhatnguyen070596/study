using System;
namespace study.Models
{
	public class RedisInput
	{
        public RedisInput(string Key, string Value)
		{
            this.Key = Key;
			this.Value = Value;
		}
		public string? Key { get; set; }
		public string? Value { get; set; }
		
	}

    public class RedisOutput
    {
        public RedisOutput(string Key, string Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
}

