using Domain.Commands.PersonCommands;
using Domain.Handlers;
using Domain.Interfaces.Command;
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonHandler _handler;
        private readonly IPersonRespository _personRespository;
        public PersonController(PersonHandler handler,
            IPersonRespository personRepository)
        {
            this._handler = handler;
            _personRespository = personRepository;
        }

        /// <summary>
        /// cria um novo registro
        /// </summary>
        /// <param name="command">objeto com parametros de criação</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Person/Create")]
        public ActionResult<ICommandResult> Post([FromBody]CreatePersonCommand command)
        {
            try
            {
                return Ok(_handler.Handler(command));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Altera dados espeficicos por id
        /// </summary>
        /// <param name="command"> objeto de entrada que contem atributos ediataveis</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Person/Update")]
        public ActionResult<ICommandResult> Post([FromBody]UpdatePersonCommand command)
        {
            try
            {
                return Ok(_handler.Handler(command));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Deleta dados por id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Person/Delete")]
        public ActionResult<ICommandResult> Post([FromBody]DeletePersonCommand command)
        {
            try
            {
                return Ok(_handler.Handler(command));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        ///  busca dados por Id, Retorna uma pessoa especifica
        /// </summary>
        /// <param name="command">Objeto de entrada</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Person/GetById/{id}")]
        public ActionResult<ICommandResult> Get(int id)
        {
            try
            {
                return Ok(_personRespository.GetPersonResult(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("Person/Get")]
        public ActionResult<ICommandResult> Get()
        {
            try
            {
                return Ok(_personRespository.GetPersonResult());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}