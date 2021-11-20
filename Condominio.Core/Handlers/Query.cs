using Condominio.Core.Handlers.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace Condominio.Core.Handlers
{
    public abstract class Query<TResult> : IQuery<TResult>
    {
        [JsonIgnore]
        public Guid RequestId { get; set; }
    }
}
