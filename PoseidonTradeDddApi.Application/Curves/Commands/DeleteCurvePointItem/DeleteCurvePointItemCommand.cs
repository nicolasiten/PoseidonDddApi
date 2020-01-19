using MediatR;
using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Curves.Commands.DeleteCurvePointItem
{
    public class DeleteCurvePointItemCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteCurvePointItemCommandHandler : IRequestHandler<DeleteCurvePointItemCommand>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteCurvePointItemCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(DeleteCurvePointItemCommand request, CancellationToken cancellationToken)
            {
                var curvePointEntity = await _dbContext.CurvePoint
                    .FindAsync(request.Id);

                if (curvePointEntity == null)
                {
                    throw new NotFoundException(nameof(CurvePoint), request.Id);
                }

                _dbContext.CurvePoint.Remove(curvePointEntity);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
