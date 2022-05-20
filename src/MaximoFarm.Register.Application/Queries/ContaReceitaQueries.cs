using AutoMapper;
using MaximoFarm.Register.Application.Queries.Interfaces;
using MaximoFarm.Register.Application.Queries.ViewModels;
using MaximoFarm.Register.Domain.Entities;
using MaximoFarm.Register.Domain.Interfaces;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries
{
    public class ContaReceitaQueries : IContaReceitaQueries
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ContaReceita> _repository;
        private bool _disposedValue;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        public ContaReceitaQueries(IMapper mapper, IGenericRepository<ContaReceita> repository)
        {
            
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<ContaReceitaViewModel>> ConsultarContaReceita()
        {
            return _mapper.Map<List<ContaReceitaViewModel>>(await _repository.GetAll());
        }
        public async Task<List<ContaReceitaViewModel>> ConsultarContaReceitaPorCodigo(int codigo)
        {
            return _mapper.Map<List<ContaReceitaViewModel>>(await _repository.GetByCode(codigo));
        }
        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle.Dispose();
                }
                _disposedValue = true;
            }
        }
    }
}
