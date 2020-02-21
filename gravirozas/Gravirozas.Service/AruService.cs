using Gravirozas.Model;
using Gravirozas.Model.Entity;
using Gravirozas.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gravirozas.Service
{
    public class AruService
    {
        private readonly AruRepository _aruRepository = null;

        public AruService()
        {
            _aruRepository = new AruRepository();
        }

        public ResponseMessage<Aru> Create(Aru entity)
        {
            ResponseMessage<Aru> response = new ResponseMessage<Aru>();

            try
            {
                response.ResponseObject = _aruRepository.Create(entity);
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


        public ResponseMessage<Aru> Felvitel(string nev, string tipus, int mennyiseg, int ar)
        {
            ResponseMessage<Aru> response = new ResponseMessage<Aru>();

            try
            {
                response.ResponseObject = _aruRepository.Felvitel(nev, tipus, mennyiseg, ar);
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


        public ResponseMessage<Aru> Update(Aru entity)
        {
            ResponseMessage<Aru> response = new ResponseMessage<Aru>();

            try
            {
                response.ResponseObject = _aruRepository.Update(entity);
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

        public ResponseMessage<int> UpdateMennyiseg(int id, int menny)
        {
            ResponseMessage<int> response = new ResponseMessage<int>();

            try
            {
                response.ResponseObject = _aruRepository.UpdateMennyiseg(id, menny);
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
                response.IsSuccess = _aruRepository.Delete(id);
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public int Elerheto(int id)
        {
            int response = 0;

            try
            {
                response = _aruRepository.Elerheto(id);
            }
            catch (Exception ex)
            {
            }

            return response;
        }

        public ResponseMessage<Aru> GetByID(int id)
        {
            ResponseMessage<Aru> response = new ResponseMessage<Aru>();

            try
            {
                response.ResponseObject = _aruRepository.GetByID(id);
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

        public ResponseMessage<List<Aru>> GetAll()
        {
            ResponseMessage<List<Aru>> response = new ResponseMessage<List<Aru>>();

            try
            {
                response.ResponseObject = _aruRepository.GetAll();
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

        public ResponseMessage<Aru> GetByName(string name)
        {
            ResponseMessage<Aru> response = new ResponseMessage<Aru>();

            try
            {
                response.ResponseObject = _aruRepository.GetByName(name);
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
