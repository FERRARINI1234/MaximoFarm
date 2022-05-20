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
    public class CidadeQueries : ICidadeQueries
    {

        private readonly IGenericRepository<Cidades> _repository;
        private readonly IMapper _mapper;
        private bool _disposedValue;
        private SafeHandle _safehandle = new SafeFileHandle(IntPtr.Zero, true);
        public CidadeQueries(IGenericRepository<Cidades> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<CidadeViewModel>> ConsultarCidades()
        {
            return _mapper.Map<List<CidadeViewModel>>(await _repository.GetAll());
        }
        public async Task<List<CidadeViewModel>> ConsultarCidadesPorCodigo(int codigo)
        {
            return _mapper.Map<List<CidadeViewModel>>(await _repository.GetByCode(codigo));
        }
        public void Dispose() => Dispose(true);
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safehandle.Dispose();
                }
                _disposedValue = true;
            }
        }
    }
}
