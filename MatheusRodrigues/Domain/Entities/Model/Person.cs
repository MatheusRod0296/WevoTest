using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Entities.Model
{
    /// <summary>
    /// Classe que simboliza a entidade Person, que esta sendo refletida no banco de dados
    /// </summary>
    public class Person : EntityBase
    {
        /// <summary>
        /// Construtor  com os paramtros Obrigatorios, sendo tambem um contrato para a criação de novos registros
        /// </summary>
       public Person(string name, string cPF, string email, string phoneNumber, char gender, DateTime birthDate)
        {
            Name = name;
            CPF = cPF;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
            BirthDate = birthDate;

            Validation();

        }

        /// <summary>
        ///contrutor Utilizado pelo Dapper para recuperação de dados, pois o mesmo nao consegue  implementrar  um contrutor Complexo
        /// </summary>
        protected Person()
        {
            
        }

        /// <summary>
        ///  metodo de validsação dos campos  com a utilização do FluentValidator
        /// </summary>
        public void Validation()
        {
            AddNotifications(
               new ValidationContract()
                   .Requires()
                   .IsNotNullOrEmpty(this.Name, "Nome", IsNullOrEmpty)
                   .HasMaxLen(this.Name, 100, "FirstName", string.Format(HasMaxLen, 100))
                   .IsNotNullOrEmpty(this.Email, "Email", IsNullOrEmpty)
                   .IsEmail(this.Email, "Email", IsEmail)
                   .HasMaxLen(this.Email, 100, "Email", string.Format(HasMaxLen, 100))
                   .HasMaxLen(this.PhoneNumber, 11, "Telefone", string.Format(HasMaxLen, 11))
                   .HasMaxLen(this.CPF, 11, "CPF", string.Format(HasMaxLen, 11))
                   .IsNotNullOrEmpty(this.Gender.ToString(), "Sexo", IsNullOrEmpty)
                   .IsNotNullOrEmpty(this.BirthDate.ToString(), "DataNascimento", IsNullOrEmpty)
                   .IsBetween(this.BirthDate, new DateTime(), DateTime.Now, "DataNascimento", IsDateNascimento)
               );

            Regex rxCPF = new Regex(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})");
            if (!rxCPF.IsMatch(this.CPF))
            {
                AddNotification(this.CPF, "CPF invalido");
            }

            Regex rxTel = new Regex(@"^1\d\d(\d\d)?$|^0800 ?\d{3} ?\d{4}$|^(\(0?([1-9a-zA-Z][0-9a-zA-Z])?[1-9]\d\) ?|0?([1-9a-zA-Z][0-9a-zA-Z])?[1-9]\d[ .-]?)?(9|9[ .-])?[2-9]\d{3}[ .-]?\d{4}$");
            if (!rxTel.IsMatch(this.PhoneNumber))
            {
                AddNotification(this.PhoneNumber, "Telefone invalido");
            }

            if (this.Gender != 'M' && this.Gender != 'F')
            {
                AddNotification(this.Gender.ToString(), "Sexo Invalido");
            }
        }

        /// <summary>
        /// Realizao a Alteração do Id de Person,
        /// simples porem mantem o Patnner  de Responsabilidade unica
        /// </summary>
        /// <param name="id"></param>
        public void SetId(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// utilizado para  a alteraçao  do objeto
        /// após a alteração ,faz uma nova validação dos campos
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNuhmber"></param>
        /// <param name="gender"></param>
        public void AlterPerson(string name, string phoneNuhmber, char gender)
        {
            this.Name = name;
            this.PhoneNumber = phoneNuhmber;
            this.Gender = gender;
            Validation();

        }       

        public string Name { get; private set; }

        public string CPF { get; private set; }

        public string Email { get; private set; }

        public string  PhoneNumber { get; private set; }

        public char Gender { get; private set; }

        public DateTime BirthDate { get; private set; }
     
    }
}
