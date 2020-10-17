using Microsoft.EntityFrameworkCore;
using PDMora.DAL;
using PDMora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PDMora.BLL
{
    public class PrestamosBLL
    {
        public static bool Guardar(Prestamos prestamo)
        {
            if (!Existe(prestamo.PrestamoId))
                return Insertar(prestamo);
            else
                return Modificar(prestamo);
        }

        private static bool Existe(int id)
        {
            bool Existencia = false;
            Contexto contexto = new Contexto();

            try
            {
                Existencia = contexto.Prestamos.Any(x => x.PrestamoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Existencia;
        }

        private static bool Insertar(Prestamos prestamo)
        {
            bool Insertado = false;
            Contexto contexto = new Contexto();

            try
            {
                Personas persona = new Personas();
                persona = PersonasBLL.Buscar(prestamo.PersonaId);
                prestamo.Balance += prestamo.Monto;
                persona.Balance = prestamo.Balance;
                PersonasBLL.Guardar(persona);

                contexto.Prestamos.Add(prestamo);
                Insertado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Insertado;
        }

        private static bool Modificar(Prestamos prestamo)
        {
            bool Modificado = false;
            Contexto contexto = new Contexto();

            try
            {
                Personas persona = new Personas();
                persona = PersonasBLL.Buscar(prestamo.PersonaId);
                prestamo.Balance += prestamo.Monto;
                persona.Balance = prestamo.Balance;
                PersonasBLL.Guardar(persona);
                contexto.Entry(prestamo).State = EntityState.Modified;
                Modificado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Modificado;
        }

        public static bool Eliminar(int id)
        {
            bool Eliminado = false;
            Contexto contexto = new Contexto();

            try
            {
                var prestamo = contexto.Prestamos.Find(id);
                Personas persona = new Personas();
                persona = PersonasBLL.Buscar(prestamo.PersonaId);
                persona.Balance -= prestamo.Balance;
                PersonasBLL.Guardar(persona);

                contexto.Entry(prestamo).State = EntityState.Deleted;
                Eliminado = (contexto.SaveChanges() > 0);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Eliminado;
        }

        public static Prestamos Buscar(int id)
        {
            Prestamos prestamo = new Prestamos();
            Contexto contexto = new Contexto();

            try
            {
                prestamo = contexto.Prestamos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return prestamo;
        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> prestamo)
        {
            List<Prestamos> Lista = new List<Prestamos>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Prestamos.Where(prestamo).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
    }
}