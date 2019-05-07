using Domain.Interfaces.Command;


namespace Domain.Commands.PersonCommands
{
    /// <summary>
    /// classe  com os parametros de Update para a entidade Person, 
    /// utilizada   como parametos em Controllers e Handlers
    /// </summary>
    public class UpdatePersonCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get;  set; }  

        public string Phonenumber { get;  set; }

        public char Gender { get;  set; }
   
    }
}
