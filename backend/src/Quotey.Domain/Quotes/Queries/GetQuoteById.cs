using Brickweave.Cqrs;
using Quotey.Domain.Quotes.Models;

namespace Quotey.Domain.Quotes.Queries
{
    public class GetQuoteById : IQuery<ReadOnlyQuote>
    {
        public GetQuoteById(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
