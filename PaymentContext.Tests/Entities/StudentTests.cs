using System;
using FluentAssertions;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Tests.Entities
{
  public class StudentTests
  {
    private readonly Student _student;
    private readonly Name _name;
    private readonly Document _document;
    private readonly Address _address;
    private readonly Email _email;

    public StudentTests()
    {
      _name = new Name("Bruce", "Wayne");
      _document = new Document("35111507795", EDocumentType.CPF);
      _email = new Email("bruce@dc.com");
      _address = new Address("Rua 01", "1234", "Centro", "Gotam", "MG", "BR", "13400000");
      _student = new Student(_name, _document, _email);


    }

    [Fact]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
      //Given
      var subscription = new Subscription(null);
      var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _document, "Wayne Corp", _address, _email);
      subscription.AddPayment(payment);
      //When

      _student.AddSubscription(subscription);
      _student.AddSubscription(subscription);

      //Then

      _student.Invalid.Should().BeTrue();
      // Assert.True(student.Invalid);


    }
    [Fact]
    public void ShouldReturnSuccessWhenAddSubscription()
    {

      //Given

      var subscription = new Subscription(null);
      var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _document, "Wayne Corp", _address, _email);
      subscription.AddPayment(payment);
      //When

      _student.AddSubscription(subscription);

      //Then

      _student.Valid.Should().BeTrue();
      // Assert.True(student.Valid);

    }
    [Fact]
    public void ShouldReturnErrorWhenHadSubscriptionHasNoPayment()
    {
      //Given

      var subscription = new Subscription(null);
      //When


      _student.AddSubscription(subscription);

      //Then

      _student.Invalid.Should().BeTrue();
      // Assert.True(student.Invalid);
    }

  }
}