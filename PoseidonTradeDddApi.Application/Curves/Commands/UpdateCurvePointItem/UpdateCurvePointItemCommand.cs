using AutoMapper;
using MediatR;
using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Curves.Commands.UpdateCurvePointItem
{
    public class UpdateCurvePointItemCommand : IRequest
    {
        public int Id { get; set; }

        public byte? CurveId { get; set; }

        public DateTime? AsOfDate { get; set; }

        public double? Term { get; set; }

        public double? Value { get; set; }

        public class UpdateCurvePointItemCommandHandler : IRequestHandler<UpdateCurvePointItemCommand>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public UpdateCurvePointItemCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateCurvePointItemCommand request, CancellationToken cancellationToken)
            {
                var curvePointEntity = await _dbContext.CurvePoint
                    .FindAsync(request.Id);

                if (curvePointEntity == null)
                {
                    throw new NotFoundException(nameof(CurvePoint), request.Id);
                }

                _mapper.Map(request, curvePointEntity);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
