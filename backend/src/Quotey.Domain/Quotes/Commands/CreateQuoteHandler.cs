using System.Threading.Tasks;
using Brickweave.Cqrs;
using Quotey.Domain.Quotes.Models;
using Quotey.Domain.Quotes.Services;

namespace Quotey.Domain.Quotes.Commands
{
    public class CreateQuoteHandler : ICommandHandler<CreateQuote, ReadOnlyQuote>
    {
        private readonly IQuotesRepository _quotesRepository;

        public CreateQuoteHandler(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        public async Task<ReadOnlyQuote> HandleAsync(CreateQuote command)
        {
            return await _quotesRepository.CreateQuote(command.Phrase, command.Attribution);
        }
    }
}
