using Gravirozas.Model;
using Gravirozas.Model.Entity;
using Gravirozas.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gravirozas.Service
{
    public class UgyfelService
    {

        private readonly UgyfelRepository _ugyfelRepository = null;

        public UgyfelService()
        {
            _ugyfelRepository = new UgyfelRepository();
        }

        public ResponseMessage<Ugyfel> Create(Ugyfel entity)
        {
            ResponseMessage<Ugyfel> response = new ResponseMessage<Ugyfel>();

            try
            {
                response.ResponseObject = _ugyfelRepository.Create(entity);
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



        public ResponseMessage<Ugyfel> Update(Ugyfel entity)
        {
            ResponseMessage<Ugyfel> response = new ResponseMessage<Ugyfel>();

            try
            {
                response.ResponseObject = _ugyfelRepository.Update(entity);
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

        public ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            try
            {
                response.IsSuccess = _ugyfelRepository.Delete(id);
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ResponseMessage<Ugyfel> GetByID(int id)
        {
            ResponseMessage<Ugyfel> response = new ResponseMessage<Ugyfel>();

            try
            {
                response.ResponseObject = _ugyfelRepository.GetByID(id);
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

        public ResponseMessage<List<Ugyfel>> GetAll()
        {
            ResponseMessage<List<Ugyfel>> response = new ResponseMessage<List<Ugyfel>>();

            try
            {
                response.ResponseObject = _ugyfelRepository.GetAll();
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
