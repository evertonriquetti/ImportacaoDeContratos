using CsvHelper;
using CsvHelper.Configuration;
using ImportacaoDeContratos.Context;
using ImportacaoDeContratos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Threading;

namespace ImportacaoDeContratos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _environment;

        public ContratoController(DataContext dataContext, IWebHostEnvironment environment)
        {
            _dataContext = dataContext;
            _environment = environment;
        }

        [HttpPost]
        public IActionResult Import(IFormFile file)
        {
            try
            {
                var config = new CsvConfiguration(Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    Delimiter = ";"
                };

                var contratos = new List<Contratos>();

                using (var reader = new StreamReader(file.OpenReadStream()))
                using (var csv = new CsvReader(reader, config))
                {
                    while (csv.Read())
                    {
                        var contrato = csv.GetRecord<Contratos>();
                        contratos.Add(contrato);
                    }
                }

                using (var transaction = _dataContext.Database.BeginTransaction())
                {
                    try
                    {
                        _dataContext.Contrato.AddRange(contratos);
                        _dataContext.SaveChanges();
                        transaction.Commit();

                        return Ok("Contratos importados com sucesso.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return StatusCode(500, $"Ocorreu um erro ao salvar os contratos: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
