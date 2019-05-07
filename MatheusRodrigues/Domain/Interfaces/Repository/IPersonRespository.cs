using Domain.Entities.Model;
using Domain.Queries.PersonQueries;
using System.Collections.Generic;

namespace Domain.Interfaces.Repository
{
    /// <summary>
    /// Interace que define PersonRepositorio e seus Metedos, 
    /// atraves da injeção de dependencia , deficne os metodos que poderam ser utilizados 
    ///  pela classe que estiver sendo injetada
    /// </summary>
    public interface IPersonRespository
    {
        int Create(Person person);

        bool Update(Person person);

        Person Get(int Id);

        bool Delete(int Id);

        bool EmailExists(string email);

        bool CpfExists(string Cpf);

        PersonResult GetPersonResult(int Id);

        IEnumerable<PersonResult> GetPersonResult();


    }
}
