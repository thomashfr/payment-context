using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Fakes
{
  public class FakeStudentRepository : IStudentRepository
  {
    public void CreateSubscription(Student student)
    {
      throw new System.NotImplementedException();
    }

    public bool DocumentExists(string document)
    {
      if (document == "99999999999")
      {
        return true;
      }
      return false;


    }

    public bool EmailExists(string email)
    {
      if (email == "thomas@henrique.com")
      {
        return true;
      }
      return false;
    }
  }
}