using Dapper;
using Domain.Entities.Model;
using Domain.Interfaces.Repository;
using Domain.Queries.PersonQueries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Infra.Repositories
{
    /// <summary>
    /// Classe concreta  que implenta o IPersonRespository
    /// com seus metodos obrigatorios, que executa  as querys no bd
    /// </summary>
    public class PersonRepository : IPersonRespository
    {
        private readonly SqlConnection _connection;
        public PersonRepository(Context context)
        {
            _connection = context.Connection;
        }

       

        public int Create(Person person)
        {
            var sqlCommand = @"INSERT INTO [dbo].[Person]
                                   ([Name]
                                   ,[CPF]
                                   ,[Email]
                                   ,[PhoneNumber]
                                   ,[Gender]
                                   ,[BirthDate])
                             VALUES
                                   (@Name
                                   ,@CPF
                                   ,@Email
                                   ,@PhoneNumber
                                   ,@Gender
                                   ,@BirthDate) 
                                   SELECT SCOPE_IDENTITY()";

           return _connection.QueryFirst<int>(sqlCommand, person);

        }
        public bool Update(Person person)
        {
            var sqlCommand = @"UPDATE [dbo].[Person]
                           SET [Name] = @Name
                              ,[CPF] = @CPF
                              ,[Email] = @Email
                              ,[PhoneNumber] = @PhoneNumber
                              ,[Gender] = @Gender
                              ,[BirthDate] = @BirthDate
                         WHERE Id = @Id";

            var result = _connection.Execute(sqlCommand, person);
            return result > 0;
        }

        
        public Person Get(int id)
        {
            var sqlCommand = @"Select Id as Id
                               ,[Name] as Name
                              ,[CPF] as CPF
                              ,[Email] as Email
                              ,[PhoneNumber] as PhoneNumber
                              ,[Gender] as Gender
                              ,[BirthDate] as BirthDate 
                                from Person where Id = @id";
                                        

            return _connection.QueryFirstOrDefault<Person>(sqlCommand, new { id });
        }

        public PersonResult GetPersonResult(int id)
        {
            var sqlCommand = @"Select * from Person where Id = @id";

            return _connection.QueryFirstOrDefault<PersonResult>(sqlCommand, new { id });
        }


        public IEnumerable<PersonResult> GetPersonResult()
        {
            var sqlCommand = @"Select * from Person ";

            return _connection.Query<PersonResult>(sqlCommand);
        }

        public bool Delete(int id)
        {           
            var result = _connection.Execute(@"Delete Person where Id = @Id", new { id }) ;
            return result > 0;
        }

        public bool EmailExists(string email)
        {
            var sqlCommand = @"Select Count(Id) from Person where Email = @email";
            var result = _connection.QueryFirst<int>(sqlCommand, new { email } );
            return result > 0;

        }

        public bool CpfExists(string Cpf)
        {
            var sqlCommand = "Select Count(Id) from Person where CPF = @Cpf";
            var result = _connection.QueryFirst<int>(sqlCommand, new { Cpf });
            return result > 0;
        }

       
    }
}
