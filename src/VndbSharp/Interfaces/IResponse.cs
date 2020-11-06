using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VndbSharp.Interfaces
{
    public interface IResponse<TType> : IEnumerable<TType>
    {
        IReadOnlyCollection<TType> Items { get; init; }

        [JsonPropertyName("more")]
        public Boolean HasMore { get; init; }

        [JsonPropertyName("num")]
        public Int32 Count { get; set; }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        IEnumerator<TType> IEnumerable<TType>.GetEnumerator()
        {
            using var iterator = this.Items.GetEnumerator();
            while (iterator.MoveNext())
                yield return iterator.Current;
        }
    }
}
