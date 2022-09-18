using AutoMapper;
using Confitec.Core.Application.Events.Commands.Base;
using Confitec.Core.Application.Events.Contracts.Base;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Application.Services.Intefaces;
using Confitec.Core.Model.Dtos;
using Confitec.Core.Model.Models.Base;
using Confitec.Infra.Utils.Extensions;
using Confitec.Infra.Utils.Utils;
using MediatR;

namespace Confitec.Core.Application.Services
{
    public class Service<TBaseModel> : IService<TBaseModel> where TBaseModel : BaseModel
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private IEventsContract<TBaseModel> _eventsContract; // Determina as ações padrões que serão disparadas pelo objeto

        public Service(IMapper mapper,
            IMediator mediator,
            IEventsContract<TBaseModel> eventsContract)
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
        public virtual async Task<ResponseDTO<TBaseModel>> CreateAsync(RequestDTO<TBaseModel> requestDTO)
        {
            var requestHandler = _mapper.MapDynamic(
                source: requestDTO.Data,
                destinationType: _eventsContract.CreateCommand);

            var response = (Response<TBaseModel>)await _mediator.Send(requestHandler);

            return new ResponseDTO<TBaseModel>
            {
                Data = response.Result, // Result e data são objetos que decem ser equivalentes sendo uma lista ou um objeto,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual async Task<ResponseDTO> DeleteAsync(int id)
        {
            var model = App.Init<TBaseModel>();
            model.Id = id;

            var requestHandler = _mapper.MapDynamic(
               source: model,
               destinationType: _eventsContract.DeleteCommand);

            var response = (Response)await _mediator.Send(requestHandler);

            return new ResponseDTO<TBaseModel> { };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual async Task<ResponseDTO<TBaseModel>> UpdateAsync(RequestDTO<TBaseModel> requestDTO)
        {
             var requestHandler = _mapper.MapDynamic(
                source: requestDTO.Data,
                destinationType: _eventsContract.UpdateCommand);

            var response = (Response<TBaseModel>)await _mediator.Send(requestHandler);

            return new ResponseDTO<TBaseModel>
            {
                Data = response.Result, // Result e data são objetos que decem ser equivalentes sendo uma lista ou um objeto,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<ResponseDTO<IEnumerable<TBaseModel>>> FindAllAsync()
        {
            var requestHandler = App.Init(_eventsContract.GetAllQuery);

            var response = (Response<IEnumerable<TBaseModel>>)await _mediator.Send(requestHandler);

            return new ResponseDTO<IEnumerable<TBaseModel>>
            {
                Data = response.Result, // Result e data são objetos que decem ser equivalentes sendo uma lista ou um objeto,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<ResponseDTO<TBaseModel>> FindByIdAsync(int id)
        {
            var model = App.Init<TBaseModel>();
            model.Id = id;

            var requestHandler = _mapper.MapDynamic(
               source: model,
               destinationType: _eventsContract.GetByIdQuery);

            var response = (Response<TBaseModel>)await _mediator.Send(requestHandler);

            return new ResponseDTO<TBaseModel>
            {
                Data = response.Result, // Result e data são objetos que decem ser equivalentes sendo uma lista ou um objeto,
            };
        }
    }
}
