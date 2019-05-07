using Domain.Interfaces.Command;

namespace Domain.Commands
{
    /// <summary>
    /// Class de Retorno utulizada em todos os controllers,  uma maneira de manter o padrao no retorno da aplicãção
    /// </summary>
    public class CommandResult: ICommandResult
    {
        public CommandResult(bool success, string message, object data)
        {
            this.Success = success;
            this.Message = message;
            this.Data = data; 
        }

        public bool Success { get; }
        public string Message { get; }
        public object Data { get; }
    }
}
