using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.Payment;
using ECommerce.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<List<PaymentRequestModel>> GetAllAsync()
        {
            var result = await _paymentRepository.GetAllAsync();
            List<PaymentRequestModel> paymentRequestModels = new List<PaymentRequestModel>();
            paymentRequestModels = result.Select(p => new PaymentRequestModel
            {
                Id = p.Id,
                ApproveCode = p.ApproveCode,
                Isok = p.Isok,
                PaymentTotal = p.PaymentTotal,
                Date = p.Date,
                OrderId = p.OrderId,
                PaymentTypeId = p.PaymentTypeId,
            }).ToList();

            return paymentRequestModels;
        }

        public async Task<PaymentRequestModel> GetById(int id)
        {
            var result = await _paymentRepository.GetByIdAsync(id);
            if(result == null)
            {
                return new PaymentRequestModel();
            }
            else
            {
                PaymentRequestModel model = new PaymentRequestModel
                {
                    Id = result.Id,
                    Date = result.Date,
                    Isok = result.Isok,
                    OrderId = result.OrderId,
                    ApproveCode = result.ApproveCode,
                    PaymentTotal = result.PaymentTotal,
                    PaymentTypeId = result.PaymentTypeId,
                };

                return model;
            }
        }

        public async Task<PaymentRequestModel> IsOkAsync(bool isOk)
        {
            var result = await _paymentRepository.IsOkAsync(isOk);
            if(result == null)
            {
                return new PaymentRequestModel();
            }
            else
            {
                PaymentRequestModel paymentRequestModel = new PaymentRequestModel
                {
                    Id = result.Id,
                    Date = result.Date,
                    Isok = result.Isok,
                    OrderId = result.OrderId,
                    ApproveCode= result.ApproveCode,    
                    PaymentTotal = result.PaymentTotal,
                    PaymentTypeId = result.PaymentTypeId,
                };
                return paymentRequestModel;
            }
        }
    }
}
