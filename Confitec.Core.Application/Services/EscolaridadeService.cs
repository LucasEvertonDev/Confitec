using AutoMapper;
using Confitec.Core.Application.Services.Intefaces;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using Confitec.Core.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Core.Application.Services
{
    public class EscolaridadeService : IEscolaridadeService
    {
        private IRepository<Escolaridade> _escolaridadeRepository;
        private readonly IMapper _mapper;

        public EscolaridadeService(IRepository<Escolaridade> escolaridadeRepository,
            IMapper mapper)
        {
            _escolaridadeRepository = escolaridadeRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<EscolaridadeModel>> FindAllAsync()
        {
            return _mapper.Map<List<EscolaridadeModel>>(
                await _escolaridadeRepository.Table.OrderBy(a => a.Id).ToListAsync());
        }
    }
}
