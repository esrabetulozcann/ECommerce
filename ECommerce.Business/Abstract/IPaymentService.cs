using ECommerce.Core.Models.Request.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IPaymentService
    {
        Task<List<PaymentRequestModel>> GetAllAsync();
        Task<PaymentRequestModel> GetById(int id);
        Task<PaymentRequestModel> IsOkAsync(bool isOk);
    }
}
