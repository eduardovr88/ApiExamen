// LibrosDAO.cs
using System;
using System.Collections.Generic;
using System.Linq;
using ApiExamen.Context;
using ApiExamen.Models;

namespace Examen.Operaciones
{
    public class LibrosDAO
    {
        private readonly LibreriaContext _contexto;

        public LibrosDAO(LibreriaContext contexto)
        {
            _contexto = contexto;
        }

        public List<Book> SeleccionarTodos()
        {
            var libros = _contexto.Books.ToList();
            return libros;
        }

        public Book Seleccionar(int id)
        {
            var libro = _contexto.Books.FirstOrDefault(l => l.Id == id);
            return libro;
        }

        public bool Agregar(int id, string title, int chapters, int pages, decimal price, int authorId)
        {
            try
            {
                Book libro = new Book
                {
                    Id = id,
                    Title = title,
                    Chapters = chapters,
                    Pages = pages,
                    Price = price,
                    AuthorId = authorId
                };

                _contexto.Books.Add(libro);
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Manejo de errores, logging, etc.
                return false;
            }
        }

        public bool Actualizar(int id, string title, int chapters, int pages, decimal price, int authorId)
        {
            try
            {
                var libro = _contexto.Books.FirstOrDefault(l => l.Id == id);

                if (libro == null)
                {
                    // El libro no existe
                    return false;
                }

                libro.Title = title;
                libro.Chapters = chapters;
                libro.Pages = pages;
                libro.Price = price;
                libro.AuthorId = authorId;

                _contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Manejo de errores, logging, etc.
                return false;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                var libro = _contexto.Books.FirstOrDefault(l => l.Id == id);

                if (libro == null)
                {
                    // El libro no existe
                    return false;
                }

                _contexto.Books.Remove(libro);
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Manejo de errores, logging, etc.
                return false;
            }
        }
    }
}
