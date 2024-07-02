using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext _context;

        //Este constructor usa la inyeccion de dependencias para insertar el contexto de la BD en el controlador 
        public MoviesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: Movies/Details/5
        // Le pasaos el id de la pelicula mediante el URL al seleccionarlo desde el navegador
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) //Verificamos que no sea nulo el ID
            {
                return NotFound();
            }

            var movie = await _context.Movie //Seleccionamos las entidades que coincidan con los valores de consulta de la cadena
                .FirstOrDefaultAsync(m => m.Id == id); //Todo lo que coincida con el id
            if (movie == null) //Si es nulo el id
            {
                return NotFound();
            }

            //caso contrario, si se encuentra una pelicula pasamos una instancia del modelo movie a la vista de detalles
            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

// GET: Movies/Edit/5
/*
 * toma el parámetro ID de la película, busca la película con el método FindAsync de Entity Framework y 
 * devuelve la película seleccionada a la vista de edición. Si no se encuentra una película, se devuelve 
 * NotFound (HTTP 404).
 */

public async Task<IActionResult> Edit(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var movie = await _context.Movie.FindAsync(id);
    if (movie == null)
    {
        return NotFound();
    }
    return View(movie);
}

// POST: Movies/Edit/5
// To protect from overposting attacks, enable the specific properties you want to bind to.

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
{
    if (id != movie.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)  //comprueba que los datos enviados en el formulario pueden usarse para modificar
            {
        try
        {
            _context.Update(movie);  //Si los datos son validos actualizamos
            await _context.SaveChangesAsync();  //Guardamos los cambios en el contexto 
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MovieExists(movie.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));  //una vez que se guardaron los datos redirigimos al Index
    }
    return View(movie);
}

// GET: Movies/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var movie = await _context.Movie
        .FirstOrDefaultAsync(m => m.Id == id);
    if (movie == null)
    {
        return NotFound();
    }

    return View(movie);
}

// POST: Movies/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var movie = await _context.Movie.FindAsync(id);
    if (movie != null)
    {
        _context.Movie.Remove(movie);
    }

    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

private bool MovieExists(int id)
{
    return _context.Movie.Any(e => e.Id == id);
}
}
}
