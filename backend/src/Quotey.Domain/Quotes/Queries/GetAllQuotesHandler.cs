using System.Collections.Generic;
using System.Threading.Tasks;
using Brickweave.Cqrs;
using Quotey.Domain.Quotes.Models;
using Quotey.Domain.Quotes.Services;

namespace Quotey.Domain.Quotes.Queries
{
    public class GetAllQuotesHandler : IQueryHandler<GetAllQuotes, IEnumerable<ReadOnlyQuote>>
    {
        private readonly IQuotesRepository _quotesRepository;

        public GetAllQuotesHandler(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        public async Task<IEnumerable<ReadOnlyQuote>> HandleAsync(GetAllQuotes query)
        {
            return await _quotesRepository.GetAllQuotes();
        }
    }
}
