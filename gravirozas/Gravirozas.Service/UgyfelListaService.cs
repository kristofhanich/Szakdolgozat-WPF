using Gravirozas.Model;
using Gravirozas.Model.Entity;
using Gravirozas.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gravirozas.Service
{
    public class UgyfelListaService
    {
        private readonly UgyfelListaRepository _ugyfelListaRepository = null;

        public UgyfelListaService()
        {
            _ugyfelListaRepository = new UgyfelListaRepository();
        }
        public ResponseMessage<List<Ugyfel>> GetAll()
        {
            ResponseMessage<List<Ugyfel>> response = new ResponseMessage<List<Ugyfel>>();

            try
            {
                response.ResponseObject = _ugyfelListaRepository.GetAll();
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
