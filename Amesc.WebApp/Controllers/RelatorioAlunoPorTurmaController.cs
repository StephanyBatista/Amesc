using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amesc.Dominio.Cursos;
using Amesc.Dominio.Matriculas;
using Amesc.WebApp.Views;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NPOI.XSSF.UserModel;

namespace Amesc.WebApp.Controllers
{
    public class RelatorioAlunoPorTurmaController : Controller
    {
        private readonly ICursoAbertoRepositorio _cursoAbertoRepositorio;
        private readonly IMatriculaRepositorio _matriculaRepositorio;
        private readonly IHostingEnvironment _hostingEnvironment;

        public RelatorioAlunoPorTurmaController(
            ICursoAbertoRepositorio cursoAbertoRepositorio, 
            IMatriculaRepositorio matriculaRepositorio, 
            IHostingEnvironment hostingEnvironment)
        {
            _cursoAbertoRepositorio = cursoAbertoRepositorio;
            _matriculaRepositorio = matriculaRepositorio;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index(int? turmaId, int? ano, bool? gerarEmExcel)
        {
            ViewBag.TurmaSelecionada = turmaId;

            var cursoAbertos = _cursoAbertoRepositorio.Consultar();
            ViewBag.Turmas = cursoAbertos.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Curso.Nome} - {c.InicioDoCurso:dd/MM/yyyy}",
                Selected = c.Id == turmaId
            }).ToList();

            ViewBag.Anos = new List<int> { 2017, 2018, 2019, 2020 }.Select(c => new SelectListItem
            {
                Value = c.ToString(),
                Text = c.ToString(),
                Selected = ano == c
            }).ToList();

            var alunos = BuscarRelatorio(turmaId, ano);

            if (gerarEmExcel.HasValue && gerarEmExcel.Value)
                return await GerarExcel(alunos);

            return View(alunos);
        }

        public async Task<IActionResult> GerarExcel(IEnumerable<RelatorioDeDadosDoAlunoPorTurmaViewModel> alunos)
        {
            var sWebRootFolder = _hostingEnvironment.WebRootPath;
            var sFileName = $"dados_por_turma_{DateTime.Now:dd_MM_YYYY_ss}.xlsx";
            var memory = new MemoryStream();

            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {

                var workbook = new XSSFWorkbook();
                var excelSheet = workbook.CreateSheet("Dados");
                var row = excelSheet.CreateRow(0);

                row.CreateCell(0).SetCellValue("Nome");
                row.CreateCell(1).SetCellValue("CPF");
                row.CreateCell(2).SetCellValue("Endereço");
                row.CreateCell(3).SetCellValue("Tipo de publico");
                row.CreateCell(4).SetCellValue("Telefone");
                row.CreateCell(5).SetCellValue("Orgão emissor");
                row.CreateCell(6).SetCellValue("RG");
                row.CreateCell(7).SetCellValue("Data de nascimento");
                row.CreateCell(8).SetCellValue("Registro profissional");
                row.CreateCell(9).SetCellValue("Especialidade");

                var index = 1;
                foreach (var item in alunos)
                {
                    row = excelSheet.CreateRow(index);
                    row.CreateCell(0).SetCellValue(item.Nome);
                    row.CreateCell(1).SetCellValue(item.Cpf);
                    row.CreateCell(2).SetCellValue(item.Endereco);
                    row.CreateCell(3).SetCellValue(item.TipoDePublico);
                    row.CreateCell(4).SetCellValue(item.Telefone);
                    row.CreateCell(5).SetCellValue(item.OrgaoEmissor);
                    row.CreateCell(6).SetCellValue(item.RG);
                    row.CreateCell(7).SetCellValue(item.DataDeNascimento);
                    row.CreateCell(8).SetCellValue(item.RegistroProfissional);
                    row.CreateCell(9).SetCellValue(item.Especialidade);

                    index++;
                }
                workbook.Write(fs);
            }

            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }

        private List<RelatorioDeDadosDoAlunoPorTurmaViewModel> BuscarRelatorio(int? turmaId, int? ano)
        {
            var alunos = new List<RelatorioDeDadosDoAlunoPorTurmaViewModel>();

            if (turmaId.HasValue)
            {
                var matriculas = _matriculaRepositorio.ConsultarTodosAlunosPor(turmaId.Value, ano.Value);
                alunos = matriculas.Select(m => new RelatorioDeDadosDoAlunoPorTurmaViewModel(m.Pessoa)).ToList();
            }

            return alunos;
        }
    }
}