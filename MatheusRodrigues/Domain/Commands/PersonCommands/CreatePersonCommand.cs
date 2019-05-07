using Domain.Interfaces.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Domain.Commands.PersonCommands
{   
    /// <summary>
    /// classe  com os parametros de criação para a entidade Person, 
    /// utilizada   como parametos em Controllers e Handlers
    /// </summary>
    public class CreatePersonCommand : ICommand
    {
        public string Name { get;  set; }

        public string CPF { get;  set; }

        public string Email { get;  set; }

        public string PhoneNumber { get;  set; }

        public char Gender { get;  set; }
        public DateTime BirthDate { get;  set; }
    }
}
