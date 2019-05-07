using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Classe Pai de todas as entidades
    /// </summary>
    public class EntityBase : Notifiable
    {
        public int Id { get; set; }

        protected const string IsNullOrEmpty = "Campo Obrigátorio";
        protected const string HasMaxLen = "{0} caracteres é o máximo permitido";
        protected const string HasMinLen = "{0} caracteres é o mínimo permitido";
        protected const string IsEmail = "Campo e-mail está inválido";
        protected const string IsDateNascimento = "Campo DataNascimento está inválido";

    }
}
