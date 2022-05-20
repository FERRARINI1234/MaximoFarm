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
    public class CargosQueries : ICargosQueries
    {
        private readonly IGenericRepository<Cargos> _repository;
        private readonly IMapper _mapper;
        private bool _disposedValue;
        private SafeHandle safehandle = new SafeFileHandle(IntPtr.Zero, true);
        public CargosQueries(IGenericRepository<Cargos> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper=mapper;
        }
        public async Task<List<CargosViewModel>> ConsultarCargos()
        {
            return _mapper.Map<List<CargosViewModel>>(await _repository.GetAll());
        }
        public async Task<List<CargosViewModel>> ConsultarCargosPorCodigo(int codigo)
        {
            return _mapper.Map<List<CargosViewModel>>(await _repository.GetByCode(codigo));
        }
        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    GC.SuppressFinalize(this);
                    safehandle.Dispose();
                }
                _disposedValue = true;
            }
        }
    }
}
