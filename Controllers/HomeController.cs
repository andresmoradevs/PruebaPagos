using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pagos;
using Pagos.Models;
using System.Text;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;

    public HomeController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var apiUrl = "http://pbiz.zonavirtual.com/api/Prueba/Consulta";
        var httpClient = _httpClientFactory.CreateClient();

        try
        {
            var objetoRequest = new MyObjetRequest
            {
                Value = 2
            };

            var jsonContent = JsonConvert.SerializeObject(objetoRequest);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var ncontent = await response.Content.ReadAsStringAsync();
                var pagos = JsonConvert.DeserializeObject<List<PagoModel>>(ncontent);
                var dbContextOptions = new DbContextOptionsBuilder<MyContext>()
                    .UseSqlServer(_configuration.GetConnectionString("MiConexionSQLServer"))
                    .Options;
                using (var dbContext = new MyContext(dbContextOptions))
                {
                    foreach (var pago in pagos)
                    {

                        var pagoList = new PagoModel

                        {
                            ComercioCodigo = pago.ComercioCodigo,
                            ComercioNombre = pago.ComercioNombre,
                            ComercioNit = pago.ComercioNit,
                            ComercioDireccion = pago.ComercioDireccion,
                            TransCodigo = pago.TransCodigo,
                            TransMedioPago = pago.TransMedioPago,
                            TransEstado = pago.TransEstado,
                            TransTotal = pago.TransTotal,
                            TransFecha = pago.TransFecha,
                            TransConcepto = pago.TransConcepto,
                            UsuarioIdentificacion = pago.UsuarioIdentificacion,
                            UsuarioNombre = pago.UsuarioNombre,
                            UsuarioEmail = pago.UsuarioEmail
                        };

                        dbContext.Pagos.Add(pagoList);
                    }

                    await dbContext.SaveChangesAsync();
                }

                return View(pagos); 
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}

internal class MyObjetRequest
{
    public int Value { get; set; }
}