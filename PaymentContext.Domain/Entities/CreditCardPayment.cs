using System;

namespace PaymentContext.Domain.Entities
{
  public class CreditCardPayment : Payment
  {
    public CreditCardPayment(string cardHolderName, string cardeNumber, string lastTransactionNumber,
    DateTime paidDate,
      DateTime expireDate,
       decimal total,
        decimal totalPaid,
         string document,
          string payer,
           string address,
            string email) : base(paidDate, expireDate, total, totalPaid, document, payer, address, email)
    {
      CardHolderName = cardHolderName;
      CardeNumber = cardeNumber;
      LastTransactionNumber = lastTransactionNumber;
    }

    public string CardHolderName { get; private set; }
    public string CardeNumber { get; private set; }
    public string LastTransactionNumber { get; private set; }
  }
}