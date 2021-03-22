using System;
using AutoMoqCore;
using FluentAssertions;
using Moq;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Tests.Fakes;
using Xunit;

namespace PaymentContext.Tests.Handlers
{
  public class SubscriptionHandlerTests
  {


    [Fact]
    public void ShouldReturnErrorWhenDocumentExists()
    {

      var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
      var command = new CreateBoletoSubscriptionCommand
      {
        FirstName = "Bruce",
        LastName = "Wayne",
        Document = "99999999999",
        Email = "thomas@henrique.com",
        BarCode = "123456789",
        BoletoNumber = "1234654987",
        PaymentNumber = "123121",
        PaidDate = DateTime.Now,
        ExpireDate = DateTime.Now.AddMonths(1),
        Total = 60,
        TotalPaid = 60,
        Payer = "WAYNE CORP",
        PayerDocument = "12345678911",
        PayerDocumentType = EDocumentType.CPF,
        PayerEmail = "batman@dc.com",
        Street = "asdas",
        Number = "asdd",
        Neighborhood = "asdasd",
        City = "as",
        State = "as",
        Country = "as",
        ZipCode = "12345678"
      };


      var result = handler.Handle(command) as CommandResult;


      Assert.False(handler.Valid);
    }



    [Fact]
    public void ShouldReturnErrorWhenDocumentExistsAutomoq()
    {

      var mocker = new AutoMoqer();
      mocker.Create<SubscriptionHandler>();
      var handler = mocker.Resolve<SubscriptionHandler>();
      var repository = mocker.GetMock<IStudentRepository>();

      repository.Setup(r => r.DocumentExists(It.IsAny<string>())).Returns(true);

      var command = new CreateBoletoSubscriptionCommand
      {
        FirstName = "Bruce",
        LastName = "Wayne",
        Document = "99999999999",
        Email = "thomas@henrique.com",
        BarCode = "123456789",
        BoletoNumber = "1234654987",
        PaymentNumber = "123121",
        PaidDate = DateTime.Now,
        ExpireDate = DateTime.Now.AddMonths(1),
        Total = 60,
        TotalPaid = 60,
        Payer = "WAYNE CORP",
        PayerDocument = "12345678911",
        PayerDocumentType = EDocumentType.CPF,
        PayerEmail = "batman@dc.com",
        Street = "asdas",
        Number = "asdd",
        Neighborhood = "asdasd",
        City = "as",
        State = "as",
        Country = "as",
        ZipCode = "12345678"
      };

      var result = handler.Handle(command) as CommandResult;


      result.Message.Should().Equals("Não foi possível realizar sua assinatura");
      result.Success.Should().BeFalse();
      Assert.False(handler.Valid);
    }



    [Fact]
    public void ShouldReturnErrorWhenEmailExistsAutomoq()
    {

      var mocker = new AutoMoqer();
      mocker.Create<SubscriptionHandler>();
      var handler = mocker.Resolve<SubscriptionHandler>();
      var repository = mocker.GetMock<IStudentRepository>();

      repository.Setup(r => r.EmailExists(It.IsAny<string>())).Returns(true);

      var command = new CreateBoletoSubscriptionCommand
      {
        FirstName = "Bruce",
        LastName = "Wayne",
        Document = "99999999999",
        Email = "thomas@henrique.com",
        BarCode = "123456789",
        BoletoNumber = "1234654987",
        PaymentNumber = "123121",
        PaidDate = DateTime.Now,
        ExpireDate = DateTime.Now.AddMonths(1),
        Total = 60,
        TotalPaid = 60,
        Payer = "WAYNE CORP",
        PayerDocument = "12345678911",
        PayerDocumentType = EDocumentType.CPF,
        PayerEmail = "batman@dc.com",
        Street = "asdas",
        Number = "asdd",
        Neighborhood = "asdasd",
        City = "as",
        State = "as",
        Country = "as",
        ZipCode = "12345678"
      };

      var result = handler.Handle(command) as CommandResult;


      result.Message.Should().Equals("Não foi possível realizar sua assinatura");
      result.Success.Should().BeFalse();
      Assert.False(handler.Valid);
    }

    [Fact]
    public void ShouldSendEmailAutomoq()
    {

      var mocker = new AutoMoqer();
      mocker.Create<SubscriptionHandler>();
      var handler = mocker.Resolve<SubscriptionHandler>();
      var emailService = mocker.GetMock<IEmailService>();

      var command = new CreateBoletoSubscriptionCommand
      {
        FirstName = "Bruce",
        LastName = "Wayne",
        Document = "99999999999",
        Email = "thomas@henrique.com",
        BarCode = "123456789",
        BoletoNumber = "1234654987",
        PaymentNumber = "123121",
        PaidDate = DateTime.Now,
        ExpireDate = DateTime.Now.AddMonths(1),
        Total = 60,
        TotalPaid = 60,
        Payer = "WAYNE CORP",
        PayerDocument = "12345678911",
        PayerDocumentType = EDocumentType.CPF,
        PayerEmail = "batman@dc.com",
        Street = "asdas",
        Number = "asdd",
        Neighborhood = "asdasd",
        City = "as",
        State = "as",
        Country = "as",
        ZipCode = "12345678"
      };

      var result = handler.Handle(command) as CommandResult;

      result.Message.Should().Equals("Assinatura Realizada com sucesso");
      result.Success.Should().BeTrue();

      emailService.Verify(e =>
      e.Send(
          It.IsAny<string>(),
          It.IsAny<string>(),
          It.IsAny<string>(),
          It.IsAny<string>()), Times.Once);

    }

    [Fact]
    public void ShouldCreateSubscriptionAutomoq()
    {

      var mocker = new AutoMoqer();
      mocker.Create<SubscriptionHandler>();
      var handler = mocker.Resolve<SubscriptionHandler>();

      var command = new CreateBoletoSubscriptionCommand
      {
        FirstName = "Bruce",
        LastName = "Wayne",
        Document = "99999999999",
        Email = "thomas@henrique.com",
        BarCode = "123456789",
        BoletoNumber = "1234654987",
        PaymentNumber = "123121",
        PaidDate = DateTime.Now,
        ExpireDate = DateTime.Now.AddMonths(1),
        Total = 60,
        TotalPaid = 60,
        Payer = "WAYNE CORP",
        PayerDocument = "12345678911",
        PayerDocumentType = EDocumentType.CPF,
        PayerEmail = "batman@dc.com",
        Street = "asdas",
        Number = "asdd",
        Neighborhood = "asdasd",
        City = "as",
        State = "as",
        Country = "as",
        ZipCode = "12345678"
      };

      var result = handler.Handle(command) as CommandResult;

      result.Message.Should().Equals("Assinatura Realizada com sucesso");
      result.Success.Should().BeTrue();

    }
  }
}