using System;

namespace VndbSharp.Attributes
{
	/// <summary>
	/// Description Attribute
	/// </summary>
	public class DescriptionAttribute : Attribute
	{
		/// <summary>
		/// Default constructor for Description Attribute
		/// </summary>
		/// <param name="description"></param>
		public DescriptionAttribute(String description)
		{
			this.Description = description;
		}

		/// <summary>
		/// Description
		/// </summary>
		public String Description { get; }
	}
}