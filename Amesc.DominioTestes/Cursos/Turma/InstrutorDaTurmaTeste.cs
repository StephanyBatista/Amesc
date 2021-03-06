﻿using Amesc.Dominio.Cursos.Turma;
using Amesc.Dominio.Pessoas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Cursos.Turma
{
    [TestClass]
    public class InstrutorDaTurmaTeste
    {
        [TestMethod]
        public void DeveCriar()
        {
            var instrutor = FluentBuilder<Pessoa>.New().Build();
            var cargo = CargoNaTurma.Coordenador;

            var instrutorDaTurma = new InstrutorDaTurma(instrutor, cargo);

            Assert.AreEqual(instrutor, instrutorDaTurma.Instrutor);
            Assert.AreEqual(cargo, instrutorDaTurma.Cargo);
        }
    }
}
