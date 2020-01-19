using AutoMapper;
using MediatR;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Bids.Commands.CreateBidItem
{
    /// <summary>
    /// Request class. Defines the request structure for creating a BidItem.
    /// </summary>
    public class CreateBidItemCommand : IRequest<int>
    {
        public string Account { get; set; }

        public string Type { get; set; }

        public double? BidQuantity { get; set; }

        public double? AskQuantity { get; set; }

        public double? Bid { get; set; }

        public double? Ask { get; set; }

        public string Benchmark { get; set; }

        public DateTime? BidListDate { get; set; }

        public string Commentary { get; set; }

        public string Security { get; set; }

        public string Status { get; set; }

        public string Trader { get; set; }

        public string Book { get; set; }

        public string DealName { get; set; }

        public string DealType { get; set; }

        public string SourceListId { get; set; }

        public string Side { get; set; }

        /// <summary>
        /// Handler for CreateBidItemCommand --> Takes CreateBidItemCommand as input and saves it to the database.
        /// </summary>
        public class CreateBidItemCommandHandler : IRequestHandler<CreateBidItemCommand, int>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public CreateBidItemCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateBidItemCommand request, CancellationToken cancellationToken)
            {
                var bidEntity = _mapper.Map<BidList>(request);

                _dbContext.BidList.Add(bidEntity);

                return await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
