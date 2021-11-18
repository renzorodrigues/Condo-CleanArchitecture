using Condominio.Core.Handlers.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace Condominio.Core.Handlers
{
    public class Query<TResponse> : IQuery<TResponse>
    {
        [JsonIgnore]
        public Guid RequestId { get; set; }
    }
}
