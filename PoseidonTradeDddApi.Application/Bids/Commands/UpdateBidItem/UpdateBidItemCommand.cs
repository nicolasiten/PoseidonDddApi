using AutoMapper;
using MediatR;
using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Bids.Commands.UpdateBidItem
{
    public class UpdateBidItemCommand : IRequest
    {
        public int BidListId { get; set; }

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

        public class UpdateBidItemCommandHandler : IRequestHandler<UpdateBidItemCommand>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public UpdateBidItemCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateBidItemCommand request, CancellationToken cancellationToken)
            {
                var bidEntity = await _dbContext.BidList
                    .FindAsync(request.BidListId);

                if (bidEntity == null)
                {
                    throw new NotFoundException(nameof(BidList), request.BidListId);
                }

                _mapper.Map(request, bidEntity);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
