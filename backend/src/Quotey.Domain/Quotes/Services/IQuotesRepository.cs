using System.Collections.Generic;
using System.Threading.Tasks;
using Quotey.Domain.Quotes.Models;

namespace Quotey.Domain.Quotes.Services
{
    public interface IQuotesRepository
    {
        Task<IEnumerable<ReadOnlyQuote>> GetAllQuotes();
        Task<ReadOnlyQuote> GetQuote(int id);
        Task<ReadOnlyQuote> CreateQuote(string phrase, string attribution);
        Task<ReadOnlyQuote> UpdateQuote(ReadOnlyQuote quote);
        Task DeleteQuote(int id);
    }
}
