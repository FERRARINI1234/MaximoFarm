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
    public class CicloQueries : ICicloQueries
    {
        private readonly IGenericRepository<Ciclo> _repository;
        private readonly IMapper _mapper;
        private bool _disposedValue;
        private SafeHandle _safehandle = new SafeFileHandle(IntPtr.Zero, true);
        public CicloQueries(IGenericRepository<Ciclo> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<CicloViewModel>> ConsultarCiclos()
        {
            return _mapper.Map<List<CicloViewModel>>(await _repository.GetAll());
        }
        public async Task<List<CicloViewModel>> ConsultarCiclosPorCodigo(int codigo)
        {
            return _mapper.Map<List<CicloViewModel>>(await _repository.GetByCode(codigo)); ;
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
