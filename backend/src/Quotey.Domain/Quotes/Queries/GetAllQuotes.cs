using System.Collections.Generic;
using Brickweave.Cqrs;
using Quotey.Domain.Quotes.Models;

namespace Quotey.Domain.Quotes.Queries
{
    public class GetAllQuotes : IQuery<IEnumerable<ReadOnlyQuote>>
    {
    }
}
