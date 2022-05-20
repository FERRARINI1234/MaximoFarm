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
    public class ContaDebitoQueries : IContaDebitoQueries
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ContaDebito> _repository;
        private bool _disposedValue;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        public ContaDebitoQueries(IMapper mapper, IGenericRepository<ContaDebito> repository)
        {
            _mapper=mapper;
            _repository=repository;
        }
        public async Task<List<ContaDebitoViewModel>> ConsultarContaDebito()
        {
            return _mapper.Map<List<ContaDebitoViewModel>> (await _repository.GetAll());
        }
        public async Task<List<ContaDebitoViewModel>> ConsultarContaDebitoPorCodigo(int codigo)
        {
            return _mapper.Map<List<ContaDebitoViewModel>>( await _repository.GetByCode(codigo));
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
