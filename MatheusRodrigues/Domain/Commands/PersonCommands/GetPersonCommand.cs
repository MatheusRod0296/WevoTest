using Domain.Interfaces.Command;

namespace Domain.Commands.PersonCommands
{
    /// <summary>
    /// classe  com os parametros para buscar  a entidade Person, 
    /// utilizada   como parametos em Controllers e Handlers
    /// </summary>
    public class GetPersonCommand : ICommand
    {
        public int Id { get; set; }
      
    }
}
