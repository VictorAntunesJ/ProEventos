using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;

        }

        /// <summary>
        /// Adiciona um novo evento no banco de dados.
        /// </summary>
        /// <param name="model">Objeto do tipo Evento que contém as informações do evento a ser adicionado.</param>
        /// <returns>O evento adicionado com seu ID atualizado se a operação for bem-sucedida; caso contrário, retorna null.</returns>
        /// <exception cref="Exception">Lança uma exceção se ocorrer um erro durante o processo de adição ou salvamento.</exception>
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                // Chama o método de persistência genérica para adicionar o evento ao contexto
                _geralPersist.Add<Evento>(model);

                // Salva as alterações no banco de dados de forma assíncrona
                if (await _geralPersist.SaveChangesAsync())
                {
                    // Se o salvamento for bem-sucedido, retorna o evento recém-adicionado buscando-o pelo ID
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }

                // Se o salvamento falhar, retorna null
                return null;
            }
            catch (Exception ex)
            {
                // Em caso de erro, lança uma exceção com a mensagem original do erro
                throw new Exception(ex.Message);
            }
        }





        /// <summary>
        /// Atualiza um evento existente no banco de dados.
        /// </summary>
        /// <param name="eventoId">ID do evento que será atualizado.</param>
        /// <param name="model">Objeto do tipo Evento contendo os novos dados a serem atualizados.</param>
        /// <returns>O evento atualizado se a operação for bem-sucedida; caso contrário, retorna null.</returns>
        /// <exception cref="Exception">Lança uma exceção se ocorrer um erro de conexão ou outro problema durante a atualização.</exception>
        public async Task<Evento> UpDateEvento(int eventoId, Evento model)
        {
            try
            {
                // Obtém o evento pelo ID. Se não for encontrado, retorna null.
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                if (evento == null) return null;

                // Atribui o ID do evento existente ao modelo que será atualizado
                model.Id = evento.Id;

                // Atualiza o evento no contexto de persistência
                _geralPersist.Update(model);

                // Salva as alterações no banco de dados de forma assíncrona
                if (await _geralPersist.SaveChangesAsync())
                {
                    // Se a atualização for bem-sucedida, retorna o evento atualizado
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }

                // Se o salvamento falhar, retorna null
                return null;
            }
            catch (Exception ex)
            {
                // Em caso de erro, lança uma exceção com uma mensagem personalizada
                throw new Exception("Falha na conexão: " + ex.Message);
            }
        }







        /// <summary>
        /// Deleta um evento do banco de dados com base no ID fornecido.
        /// </summary>
        /// <param name="eventoId">ID do evento que será deletado.</param>
        /// <returns>Retorna true se o evento for deletado com sucesso; caso contrário, lança uma exceção.</returns>
        /// <exception cref="Exception">Lança uma exceção se o evento não for encontrado ou se ocorrer um erro de conexão durante o processo de exclusão.</exception>
        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                // Busca o evento pelo ID. Se não for encontrado, lança uma exceção
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("Evento para deletar não encontrado");

                // Marca o evento para ser deletado no contexto de persistência
                _geralPersist.Delete<Evento>(evento);

                // Salva as alterações no banco de dados de forma assíncrona e retorna true se for bem-sucedido
                if (await _geralPersist.SaveChangesAsync())
                {
                    Console.WriteLine("Evento deletado com sucesso!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Falha ao deletar o evento.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro, lança uma exceção com uma mensagem personalizada
                throw new Exception("Falha na conexão: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtém todos os eventos de forma assíncrona.
        /// </summary>
        /// <param name="includePalestrantes">Um valor booleano que indica se os palestrantes associados aos eventos devem ser incluídos na consulta.</param>
        /// <returns>Um array de objetos <see cref="Evento"/> contendo todos os eventos. Se nenhum evento for encontrado, retorna null.</returns>
        /// <exception cref="Exception">Lança uma exceção se ocorrer um erro durante a recuperação dos eventos.</exception>
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }








        /// <summary>
        /// Obtém todos os eventos que correspondem ao tema especificado de forma assíncrona.
        /// </summary>
        /// <param name="tema">O tema pelo qual os eventos devem ser filtrados.</param>
        /// <param name="includePalestrantes">Um valor booleano que indica se os palestrantes associados aos eventos devem ser incluídos na consulta.</param>
        /// <returns>Um array de objetos <see cref="Evento"/> contendo os eventos que correspondem ao tema especificado. Se nenhum evento for encontrado, retorna null.</returns>
        /// <exception cref="Exception">Lança uma exceção se ocorrer um erro durante a recuperação dos eventos.</exception>
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }







        /// <summary>
        /// Obtém um evento específico pelo seu ID de forma assíncrona.
        /// </summary>
        /// <param name="eventoId">O ID do evento a ser recuperado.</param>
        /// <param name="includePalestrantes">Um valor booleano que indica se os palestrantes associados ao evento devem ser incluídos na consulta.</param>
        /// <returns>Um objeto <see cref="Evento"/> representando o evento correspondente ao ID especificado. Se o evento não for encontrado, retorna null.</returns>
        /// <exception cref="Exception">Lança uma exceção se ocorrer um erro durante a recuperação do evento.</exception>
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);
                if (eventos == null) return null;
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}