using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Application.Curves.Queries.GetCurvePoint;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Curves.Queries.GetAllCurvePoints
{
    public class GetAllCurvePointsQuery : IRequest<IEnumerable<CurvePointModel>>
    {
        public class GetAllCuvePointsQueryHandler : IRequestHandler<GetAllCurvePointsQuery, IEnumerable<CurvePointModel>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetAllCuvePointsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<CurvePointModel>> Handle(GetAllCurvePointsQuery request, CancellationToken cancellationToken)
            {
                var curvePointEntities = await _dbContext.CurvePoint.ToListAsync();

                return _mapper.Map<IEnumerable<CurvePointModel>>(curvePointEntities);
            }
        }
    }
}
