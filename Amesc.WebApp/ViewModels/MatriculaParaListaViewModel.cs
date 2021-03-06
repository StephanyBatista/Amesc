﻿using System;
using Amesc.Dominio.Matriculas;

namespace Amesc.WebApp.ViewModels
{
    public class MatriculaParaListaViewModel
    {
        public int Id { get; set; }
        public string Aluno { get; set; }
        public string Cpf { get; set; }
        public string Curso { get; set; }
        public DateTime DataDoCurso { get; set; }
        public string EstaPago { get; set; }
        public string Cancelada { get; set; }

        public MatriculaParaListaViewModel() { }

        public MatriculaParaListaViewModel(Matricula entidade)
        {
            Id = entidade.Id;
            Curso = entidade.CursoAberto.Curso.Nome;
            DataDoCurso = entidade.CursoAberto.InicioDoCurso;
            Aluno = entidade.Pessoa.Nome;
            Cpf = entidade.Pessoa.Cpf;
            EstaPago = entidade.EstaPago ? "Sim" : "Não";
            Cancelada = entidade.Cancelada ? "Sim": "Não";
        }
    }
}
