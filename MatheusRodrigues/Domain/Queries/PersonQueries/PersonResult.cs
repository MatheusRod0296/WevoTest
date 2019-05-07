using System;

namespace Domain.Queries.PersonQueries
{
    /// <summary>
    /// Objeto de vizualização , 
    /// utilizado no retornos dos dados da API
    /// </summary>
    public class PersonResult
    {
        public int Id { get; set; }
        public string Name { get; private set; }

        public string CPF { get; private set; }

        public string Email { get; private set; }

        public string PhoneNumer { get; private set; }

        public char Gender { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
