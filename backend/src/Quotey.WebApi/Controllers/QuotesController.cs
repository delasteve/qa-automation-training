using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brickweave.Cqrs;
using Microsoft.AspNetCore.Mvc;
using Quotey.Domain.Quotes.Commands;
using Quotey.Domain.Quotes.Queries;
using Quotey.WebApi.Models;
using Quotey.WebApi.Models.Requests;

namespace Quotey.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public QuotesController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IEnumerable<Quote>> GetAsync()
        {
            var quotes = await _dispatcher.DispatchQueryAsync(new GetAllQuotes());

            return quotes.Select(quote => new Quote(quote.Id, quote.Phrase, quote.Attribution, quote.CreatedAt, quote.UpdatedAt));
        }

        [HttpGet("{id}")]
        public async Task<Quote> Get(int id)
        {
            var quote = await _dispatcher.DispatchQueryAsync(new GetQuoteById(id));

            return new Quote(quote.Id, quote.Phrase, quote.Attribution, quote.CreatedAt, quote.UpdatedAt);
        }

        [HttpPost]
        public async Task<Quote> PostAsync([FromBody] CreateQuoteRequest request)
        {
            var quote = await _dispatcher.DispatchCommandAsync(new CreateQuote(request.Phrase, request.Attribution));

            return new Quote(quote.Id, quote.Phrase, quote.Attribution, quote.CreatedAt, quote.UpdatedAt);
        }

        [HttpPut("{id}")]
        public async Task<Quote> Put(int id, [FromBody] UpdateQuoteRequest request)
        {
            var quote = await _dispatcher.DispatchCommandAsync(new UpdateQuote(id, request.Phrase, request.Attribution));

            return new Quote(quote.Id, quote.Phrase, quote.Attribution, quote.CreatedAt, quote.UpdatedAt);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _dispatcher.DispatchCommandAsync(new DeleteQuote(id));
        }
    }
}
