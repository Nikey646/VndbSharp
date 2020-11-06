using System;
using System.Text.Json.Serialization;

namespace VndbSharp.Interfaces
{
    public interface IRequestOptions
    {
        Int32? Page { get; init; }

        [JsonPropertyName("results")]
        Int32? Count { get; init; }

        String Sort { get; init; }

        Boolean? Reverse { get; init; }
    }
}
