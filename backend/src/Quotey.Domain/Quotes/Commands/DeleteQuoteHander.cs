using System.Threading.Tasks;
using Brickweave.Cqrs;
using Quotey.Domain.Quotes.Services;

namespace Quotey.Domain.Quotes.Commands
{
    public class DeleteQuoteHandler : ICommandHandler<DeleteQuote>
    {
        private readonly IQuotesRepository _quotesRepository;

        public DeleteQuoteHandler(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        public async Task HandleAsync(DeleteQuote command)
        {
            await _quotesRepository.DeleteQuote(command.Id);
        }
    }
}
