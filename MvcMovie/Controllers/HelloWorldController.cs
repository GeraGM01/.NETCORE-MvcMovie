using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;


//Clase HelloWorld que hereda de Controller esto hace que esta clase actue como Controlador MVC

//Un controlador obtiene los datos de una cadena url especifica ; Los controladores procesan los datos de entrada
// Pueden validar la informacion de formularios, lectura de datos desde URL etc.

// Tambien retornan las vistas con los datos necesarios a mostrar a los usuarios

// Los controladores se encargan de proporcionar los datos necesarios para que una plantilla de vista represente
// una respuesta.
public class HelloWorldController : Controller
{
    //Metodo de accion Index 
    public IActionResult Index()
    {
        return View();  //Llama al metodo View del cntrolador
    }

    public IActionResult Welcome(string name, int numTimes = 1)
    {
        //return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}"); //Encoder es para proteger la cadena de entradas malintencionadas por ejemplo JavaScript 
        //return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        ViewData["Message"] = "Hello " + name;  //Esta informacion que agregamos al viewData se le pasaran a la vista
        ViewData["NumTimes"] = numTimes;
        return View();
    }
}