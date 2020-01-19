using AutoMapper;
using MediatR;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Ratings.Commands.CreateRatingItem
{
    public class CreateRatingItemCommand : IRequest<int>
    {
        public string MoodysRating { get; set; }

        public string SandPrating { get; set; }

        public string FitchRating { get; set; }

        public byte? OrderNumber { get; set; }

        public class CreateRatingItemCommandHandler : IRequestHandler<CreateRatingItemCommand, int>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public CreateRatingItemCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public Task<int> Handle(CreateRatingItemCommand request, CancellationToken cancellationToken)
            {
                var ratingEntity = _mapper.Map<Rating>(request);

                _dbContext.Rating.Add(ratingEntity);

                return _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
