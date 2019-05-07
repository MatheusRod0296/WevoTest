using Domain.Commands;
using Domain.Commands.PersonCommands;
using Domain.Entities.Model;
using Domain.Interfaces.Command;
using Domain.Interfaces.Repository;
using FluentValidator;

namespace Domain.Handlers

{
    public class PersonHandler : Notifiable,
        ICommandHandler<CreatePersonCommand>
        , ICommandHandler<UpdatePersonCommand>
        , ICommandHandler<DeletePersonCommand>
        , ICommandHandler<GetPersonCommand>
    {

        private readonly IPersonRespository _personRepository;
        public PersonHandler(IPersonRespository person)
        {
            _personRepository = person;
        }

        /// <summary>
        /// Recebe  obejeto de criação, cria a entidde,  salva no banco , retorna status
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Handler(CreatePersonCommand command)
        {
            var person = new Person(command.Name, command.CPF, command.Email, command.PhoneNumber, command.Gender, command.BirthDate);
            AddNotifications(person.Notifications);

            if (Valid)
            {
                if (_personRepository.EmailExists(command.Email))
                {
                    AddNotification("Email", "Esse E-mail já Existe em nosso sistema");
                }

                if (_personRepository.CpfExists(command.CPF))
                {
                    AddNotification("CPF", "Esse CPF já existe em nosso sistema!");
                }
            }


            if (Invalid)
            {
                return new CommandResult(false, "Erro ao cadastrar", Notifications);
            }


            person.SetId(_personRepository.Create(person));

            return new CommandResult(true, "Cadastro Realizado com Sucesso", new
            {
                person.Id,
                person.Name,
                person.Email

            });
        }

        // <summary>
        /// Recebe  obejeto de Update,busca a  entidade no banco,  altera a entidde,  salva no banco , retorna status
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Handler(UpdatePersonCommand command)
        {
            var person = _personRepository.Get(command.Id);
            if (person != null)
            {
                person.AlterPerson(command.Name, command.Phonenumber, command.Gender);
                AddNotifications(person.Notifications);

                if (Invalid)
                {
                    return new CommandResult(false, "Erro ao cadastrar", Notifications);
                }

                _personRepository.Update(person);
                return new CommandResult(true, "Atualizado com sucesso", new
                {
                    person.Id,
                    person.Name,
                    person.Email
                });
            }

            AddNotification("Person", $"Usuário - {command.Id} - não existe no banco");

            return new CommandResult(false, "Erro ao atualizar", new
            {
                Notifications

            });

        }

        // <summary>
        /// Recebe  obejeto de Delete, exclui no banco, retorna status
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Handler(DeletePersonCommand command)
        {
            var result = _personRepository.Delete(command.Id);

            if (result)
                return new CommandResult(result, "Sucesso ao Deletar", new { });
            else
                return new CommandResult(result, "Erro ao Deletar", new { });



        }

        // <summary>
        /// Recebe  obejeto de Get, busca no banco ,  retorna objeto de vizualização
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Handler(GetPersonCommand command)
        {
            var person = _personRepository.GetPersonResult(command.Id);
           
             return new CommandResult(true, "Sucesso ao Carregar Dados", person);
           
        }
    }
}
