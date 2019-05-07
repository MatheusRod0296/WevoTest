using Domain.Interfaces.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Domain.Commands.PersonCommands
{
    /// <summary>
    /// classe  com os parametros de deleção para a entidade Person, 
    /// utilizada   como parametos em Controllers e Handlers
    /// </summary>
    public class DeletePersonCommand : ICommand
    {
        public int Id { get; set; }

       
    }
}
