using System.Text.RegularExpressions;
using ARSoft.Tools.Net.Dns;

namespace Velvet.Mappings
{
	public abstract class Mapping
	{
		protected readonly Regex pattern;

		protected Mapping(string pattern)
		{
			var escaped = Regex.Escape(pattern);
			var regStr = "^" + escaped.Replace("\\*", "([^\\.]*)") + "$";

			this.pattern = new Regex(regStr, RegexOptions.IgnoreCase);
		}

		public abstract DnsRecordBase Answer(DnsQuestion question);
	}
}