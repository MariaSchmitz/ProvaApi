using System;

namespace API.Models
{
    public class Pessoa
    {
        //Construtor
        public Pessoa() => CadastradoEm = DateTime.Now;

        //Atributos ou propriedades
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Naturalidade { get; set; }
        public int Idade { get; set; }
        public DateTime CadastradoEm { get; set; }

        //ToString
        public override string ToString() =>
            $"Nome: {Nome} | Email: {Email} | Naturalidade : {Naturalidade}  | Idade : {Idade} CadastradoEm: {CadastradoEm}";
    }
}