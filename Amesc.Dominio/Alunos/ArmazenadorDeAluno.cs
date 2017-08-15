﻿using System;
using Amesc.Dominio.Cursos;

namespace Amesc.Dominio.Alunos
{
    public class ArmazenadorDeAluno
    {
        private readonly IRepositorio<Aluno> _alunoRepositorio;

        public ArmazenadorDeAluno(IRepositorio<Aluno> alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public void Armazenar(
            int id, 
            string nome, 
            string cpf, 
            string orgaoEmissorDoRg,
            string rg,
            string dataDeNascimentoEmString,
            string registroProfissional,
            string telefone, 
            string numero, 
            string logradouro, 
            string bairro, 
            string complemento, 
            string cidade, 
            string estado, 
            string publicoAlvo,
            string midiaSocial)
        {
            DateTime.TryParse(dataDeNascimentoEmString, out DateTime dataDeNascimento);

            if (id == 0)
            {
                var endereço = new Endereco(numero, logradouro, bairro, complemento, cidade, estado);
                var aluno = new Aluno(nome, cpf, orgaoEmissorDoRg, rg, dataDeNascimento, registroProfissional, telefone, endereço, publicoAlvo, midiaSocial);
                _alunoRepositorio.Adicionar(aluno);
            }
            else
            {
                var endereço = new Endereco(numero, logradouro, bairro, complemento, cidade, estado);
                var aluno = _alunoRepositorio.ObterPorId(id);
                aluno.Editar(nome, cpf, orgaoEmissorDoRg, rg, dataDeNascimento, registroProfissional, telefone, endereço, publicoAlvo, midiaSocial);
            }
        }
    }
}