using AutoMapper;
using Confitec.Core.Application.DTOs;
using Confitec.Core.Application.Events.Contracts.Base;
using MediatR;

namespace Confitec.Core.Application.Services
{
    public class Service<TDto> : IService<TDto> where TDto : IDtoBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private IEventsContract<TDto> _eventsContract;

        public Service(IMapper mapper,
            IMediator mediator,
            IEventsContract<TDto> eventsContract)
        {
            _mapper = mapper;
            _mediator = mediator;
            _eventsContract = eventsContract;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual async Task<TDto?> Create(TDto dto)
        {
            return (TDto?)await _mediator.Send(_mapper.Map(dto, typeof(TDto), _eventsContract.CreateCommand.GetType()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual async Task Delete(int id)
        {
            await _mediator.Send(_mapper.Map(id, typeof(TDto), _eventsContract.DeleteCommand.GetType()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual async Task<TDto?> Update(TDto dto)
        {
            return (TDto?)await _mediator.Send(_mapper.Map(dto, typeof(TDto), _eventsContract.UpdateCommand.GetType()));
        }
    }
}
