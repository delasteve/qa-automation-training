using System.Threading.Tasks;
using Brickweave.Cqrs;
using Quotey.Domain.Quotes.Models;
using Quotey.Domain.Quotes.Services;

namespace Quotey.Domain.Quotes.Queries
{
    public class GetQuoteByIdHandler : IQueryHandler<GetQuoteById, ReadOnlyQuote>
    {
        private readonly IQuotesRepository _quotesRepository;

        public GetQuoteByIdHandler(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        public async Task<ReadOnlyQuote> HandleAsync(GetQuoteById query)
        {
            return await _quotesRepository.GetQuote(query.Id);
        }
    }
}
