using Gravirozas.Model;
using Gravirozas.Model.Entity;
using Gravirozas.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gravirozas.Service
{
    public class KapcsolatListaService
    {
        private readonly KapcsolatListaRepository _kapcsolatListaRepository = null;

        public KapcsolatListaService()
        {
            _kapcsolatListaRepository = new KapcsolatListaRepository();
        }
        public ResponseMessage<List<KapcsolatLista>> GetAll()
        {
            ResponseMessage<List<KapcsolatLista>> response = new ResponseMessage<List<KapcsolatLista>>();

            try
            {
                response.ResponseObject = _kapcsolatListaRepository.GetAll();
                response.IsSuccess = true;
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}
