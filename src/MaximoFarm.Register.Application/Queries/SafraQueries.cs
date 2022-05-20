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
    public class SafraQueries : ISafraQueries
    {
        private readonly IGenericRepository<Safra> _repository;
        private readonly IMapper _mapper;
        private bool _disposedValue;
        private SafeHandle _safehandle = new SafeFileHandle(IntPtr.Zero, true);
        public SafraQueries(IGenericRepository<Safra> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<SafraViewModel>> ConsultarSafras()
        {
           return _mapper.Map<List<SafraViewModel>>(await _repository.GetAll()); 
        }
        public async Task<List<SafraViewModel>> ConsultarSafrasPorCodigo(int codigo)
        {
            return _mapper.Map<List<SafraViewModel>>( await _repository.GetByCode(codigo));
        }
    }
}
