using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Command
{
    /// <summary>
    /// Interface define Comandos de resultado
    /// </summary>
    public interface ICommandResult
    {
        bool Success { get; }

        string Message { get; }

        object Data { get; }
    }
}

