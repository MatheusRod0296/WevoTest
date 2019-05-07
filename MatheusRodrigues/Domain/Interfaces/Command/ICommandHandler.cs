using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Command
{
    // interface que define  os Handlers
    public interface ICommandHandler<in TEntity> where TEntity : ICommand
    {
        ICommandResult Handler(TEntity command);
    }
}
