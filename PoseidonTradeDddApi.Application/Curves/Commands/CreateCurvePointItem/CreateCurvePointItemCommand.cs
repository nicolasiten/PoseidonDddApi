using AutoMapper;
using MediatR;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Curves.Commands.CreateCurvePointItem
{
    public class CreateCurvePointItemCommand : IRequest<int>
    {
        public byte? CurveId { get; set; }

        public DateTime? AsOfDate { get; set; }

        public double? Term { get; set; }

        public double? Value { get; set; }

        public class CreateCurvePointItemCommandHandler : IRequestHandler<CreateCurvePointItemCommand, int>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public CreateCurvePointItemCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateCurvePointItemCommand request, CancellationToken cancellationToken)
            {
                var curvePointEntity = _mapper.Map<CurvePoint>(request);
                curvePointEntity.CreationDate = DateTime.Now;

                _dbContext.CurvePoint.Add(curvePointEntity);

                return await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
