using System;
using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/pessoa")]
    public class PessoaController : ControllerBase
    {
        private readonly DataContext _context;

        //Construtor
        public PessoaController(DataContext context) => _context = context;

        //POST: api/pessoa/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            return Created("", pessoa);
        }

        //GET: api/pessoa/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.Pessoas.ToList());

        //GET: api/pessoa/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //Buscar um pessoa pela chave primária
            Pessoa pessoa = _context.Pessoas.Find(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        //DELETE: api/pessoa/delete/
        [HttpDelete]
        [Route("delete/{name}")]
        public IActionResult Delete([FromRoute] string name)
        {
            //Expressão lambda
            //Buscar um pessoa pelo nome
            Pessoa pessoa = _context.Pessoas.FirstOrDefault
            (
                pessoa => pessoa.Nome == name
            );
            if (pessoa == null)
            {
                return NotFound();
            }
            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
            return Ok(_context.Pessoas.ToList());
        }

        //PUT: api/pessoa/create
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();
            return Ok(pessoa);
        }


    }
}