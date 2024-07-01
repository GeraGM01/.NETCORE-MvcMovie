using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;


//Clase HelloWorld que hereda de Controller esto hace que esta clase actue como Controlador MVC
public class HelloWorldController : Controller
{
    //Metodo de accion Index 
    public IActionResult Index()
    {
        return View();  //Llama al metodo View del cntrolador
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    public string Welcome(string name, int ID = 1)
    {
        //return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}"); //Encoder es para proteger la cadena de entradas malintencionadas por ejemplo JavaScript 
        return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
    }
}