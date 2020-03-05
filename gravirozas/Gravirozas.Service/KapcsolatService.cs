using Gravirozas.Model;
using Gravirozas.Model.Entity;
using Gravirozas.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gravirozas.Service
{
    public class KapcsolatService
    {
        private readonly KapcsolatRepository _kapcsolatRepository = null;

        public KapcsolatService()
        {
            _kapcsolatRepository = new KapcsolatRepository();
        }

        public ResponseMessage<Kapcsolat> Create(Kapcsolat entity)
        {
            ResponseMessage<Kapcsolat> response = new ResponseMessage<Kapcsolat>();

            try
            {
                response.ResponseObject = _kapcsolatRepository.Create(entity);
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


        public ResponseMessage<Kapcsolat> GetByID(int id)
        {
            ResponseMessage<Kapcsolat> response = new ResponseMessage<Kapcsolat>();

            try
            {
                response.ResponseObject = _kapcsolatRepository.GetByID(id);
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

        public ResponseMessage<List<Kapcsolat>> GetAll()
        {
            ResponseMessage<List<Kapcsolat>> response = new ResponseMessage<List<Kapcsolat>>();

            try
            {
                response.ResponseObject = _kapcsolatRepository.GetAll();
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
