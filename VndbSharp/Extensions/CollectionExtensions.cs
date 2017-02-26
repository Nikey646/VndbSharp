using System.Collections.Generic;

namespace VndbSharp.Extensions
{
	internal static class CollectionExtensions
	{
		internal static void AddRange<T>(this ICollection<T> collection, params T[] items)
		{
			for (var i = 0; i < items.Length; i++)
				collection.Add(items[i]);
		}
	}
}
