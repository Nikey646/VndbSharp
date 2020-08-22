using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Models.User
{
	public class UserLabels
	{
		[JsonProperty("uid")]
		public UInt32 UserId { get; private set; }
		public UInt32 Id { get; private set; }
		public String Label { get; private set; }
		[JsonProperty("private")]
		public Boolean IsPrivate { get; private set; }
	}
}
