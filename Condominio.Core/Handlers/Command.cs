using Condominio.Core.Handlers.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace Condominio.Core.Handlers
{
    public abstract class Command<TResult> : ICommand<TResult>
    {
        [JsonIgnore]
        public Guid RequestId { get; set; }
    }

    public abstract class Command : ICommand
    {
        [JsonIgnore]
        public Guid RequestId { get; set; }
    }
}
