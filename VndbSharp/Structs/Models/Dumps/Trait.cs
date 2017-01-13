using System;

namespace VndbSharp.Structs.Models.Dumps
{
	public class Trait
	{
		public UInt32 Id;
		public String Name;
		public String Description;
		public UInt32 Characters;
		public String[] Aliases;
		public UInt32[] Parents;
		public Boolean IsMeta;
	}
}
