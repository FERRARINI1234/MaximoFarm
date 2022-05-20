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
    public class CentroCustoQueries : ICentroCustoQueries
    {
        private readonly IGenericRepository<CentroCusto> _repository;
        private readonly IMapper _mapper;
        private bool _disposedValue;
        private SafeHandle safehandle = new SafeFileHandle(IntPtr.Zero, true);

        public CentroCustoQueries(IGenericRepository<CentroCusto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<CentroCustoViewModel>> ConsultarCentroCusto()
        {
            return _mapper.Map<List<CentroCustoViewModel>>(await _repository.GetAll());
        }
        public async Task<List<CentroCustoViewModel>> ConsultarCentroCustoPorCodigo(int codigo)
        {
            return _mapper.Map<List<CentroCustoViewModel>>(await _repository.GetByCode(codigo));
        }
        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    safehandle.Dispose();
                }
                _disposedValue = true;
            }
        }

    }
}
