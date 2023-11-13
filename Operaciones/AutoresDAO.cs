using System;
using System.Collections.Generic;
using System.Linq;
using ApiExamen.Operaciones;
using ApiExamen.Models;
using ApiExamen.Context;
using ApiExamen.Controllers;

namespace ApiExamen.Operaciones
{
    public class AutoresDAO
    {
        private readonly LibreriaContext _contexto;

        public AutoresDAO(LibreriaContext contexto)
        {
            _contexto = contexto;
        }

        public List<Author> SeleccionarTodos()
        {
            var autores = _contexto.Authors.ToList();
            return autores;
        }

        public Author Seleccionar(int id)
        {
            var autor = _contexto.Authors.FirstOrDefault(a => a.Id == id);
            return autor;
        }

        public bool Agregar(int id, string name)
        {
            try
            {
                Author autor = new Author
                {
                    Id = id,
                    Name = name
                };

                _contexto.Authors.Add(autor);
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
