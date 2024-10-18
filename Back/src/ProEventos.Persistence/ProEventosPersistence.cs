using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventosContext _context;

        public ProEventosPersistence (ProEventosContext context)
        {
            _context = context;
            
        }
        //GERAL
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void DeleteRanger<T>(T[] entity) where T : class
        {
            throw new NotImplementedException();
        }

         public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        //EVENTOS
        public Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            throw new NotImplementedException();
        }
        public Task<Evento[]> GetAllEventosAsync(bool includePalestrantes)
        {
            throw new NotImplementedException();
        }
        public Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes)
        {
            throw new NotImplementedException();
        }

        //PALESTRANTES
         public Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool includeEventos)
        {
            throw new NotImplementedException();
        }
         public Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos)
        {
            throw new NotImplementedException();
        }
        public Task<Palestrante> GetPalestranteByIdAsync(int Palestrante, bool includeEventos)
        {
            throw new NotImplementedException();
        }
    }
       
}