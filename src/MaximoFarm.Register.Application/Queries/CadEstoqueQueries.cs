using AutoMapper;
using MaximoFarm.Register.Application.Queries.Interfaces;
using MaximoFarm.Register.Application.Queries.ViewModels;
using MaximoFarm.Register.Data.Cache;
using MaximoFarm.Register.Domain.Entities;
using MaximoFarm.Register.Domain.Interfaces;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries
{
    public class CadEstoqueQueries : ICadEstoqueQueries
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<CadEstoque> _repository;
        private bool _disposedValue;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);
        
        public CadEstoqueQueries(IMapper mapper, IGenericRepository<CadEstoque> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<CadEstoqueViewModel>> ConsultarCadastroEstoque()
        {
            return _mapper.Map<List<CadEstoqueViewModel>>(await _repository.GetAll());
        }
        public async Task<List<CadEstoqueViewModel>> ConsultarCadastroEstoquePorCodigo(int codigo)
        {
            return _mapper.Map<List<CadEstoqueViewModel>>(await _repository.GetByCode(codigo));
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
