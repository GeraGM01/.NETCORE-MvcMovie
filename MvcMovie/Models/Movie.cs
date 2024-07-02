//Clase de modelo de datos

//En las clases de modelo de datos solo definen las propiedades de los datos que se almacenan en la base de datos.

using System.ComponentModel.DataAnnotations;
namespace MvcMovie.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


//Clase Movie que tiene los datos referentes a una pelicula

public class Movie
{
    public int Id { get; set; }  //Id que sera la llave primaria
    public string? Title { get; set; }  //Titulo de la pelicula, tiene signo de interrogacion por que puede admitir un valor null
    [Display(Name = "Release Date")] //Agregamos la etiqueta como debe ser y no con el nombre de la variable
    [DataType(DataType.Date)]  //Atributo que que especifica el tipo de datos que sera Date
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
}