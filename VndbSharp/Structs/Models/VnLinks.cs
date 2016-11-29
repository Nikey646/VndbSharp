using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models
{
	public class VnLinks
	{
		[JsonProperty("wikipedia")]
		public string Wikipedia;
		[JsonProperty("encubed")]
		public string Encubed;
		[JsonProperty("renai")]
		public string Renai;
	}
}
