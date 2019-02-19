using System.Threading.Tasks;
using Brickweave.Cqrs;
using Quotey.Domain.Quotes.Models;
using Quotey.Domain.Quotes.Services;

namespace Quotey.Domain.Quotes.Commands
{
    public class UpdateQuoteHandler : ICommandHandler<UpdateQuote, ReadOnlyQuote>
    {
        private readonly IQuotesRepository _quotesRepository;

        public UpdateQuoteHandler(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        public async Task<ReadOnlyQuote> HandleAsync(UpdateQuote command)
        {
            var quote = await _quotesRepository.GetQuote(command.Id);

            var readonlyQuote = new ReadOnlyQuote(quote.Id, command.Phrase, command.Attribution, quote.CreatedAt, quote.UpdatedAt);

            return await _quotesRepository.UpdateQuote(readonlyQuote);
        }
    }
}
