using AutoMapper;
using MediatR;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Curves.Queries.GetCurvePoint
{
    public class GetCurvePointQuery : IRequest<CurvePointModel>
    {
        public int Id { get; set; }

        public class GetCurvePointQueryHandler : IRequestHandler<GetCurvePointQuery, CurvePointModel>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetCurvePointQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<CurvePointModel> Handle(GetCurvePointQuery request, CancellationToken cancellationToken)
            {
                var curvePointEntity = await _dbContext.CurvePoint
                    .FindAsync(request.Id);

                return _mapper.Map<CurvePointModel>(curvePointEntity);
            }
        }
    }
}
