using FluentAssertions;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Tests.ValueObjects
{
  public class DocumentTests
  {
    [Fact]
    public void ShoudReturnErrorWhenCNPJIsInvalid()
    {
      //Given
      var doc = new Document("123", EDocumentType.CNPJ);
      //When

      //Then
      doc.Invalid.Should().BeTrue();

      //Assert.True(doc.Invalid);

    }
    [Fact]
    public void ShoudReturnErrorWhenCNPJIsValid()
    {
      //Given

      var doc = new Document("34110468000150", EDocumentType.CNPJ);
      //When

      //Then

      doc.Valid.Should().BeTrue();

      //Assert.True(doc.Valid);

    }
    [Fact]
    public void ShoudReturnErrorWhenCPFIsInvalid()
    {
      //Given
      var doc = new Document("123", EDocumentType.CPF);
      //When

      //Then
      doc.Invalid.Should().BeTrue();

      //Assert.True(doc.Invalid);

    }
    [Fact]
    public void ShoudReturnErrorWhenCPFIsValid()
    {
      //Given

      var doc = new Document("34225545806", EDocumentType.CPF);
      //When

      //Then

      doc.Valid.Should().BeTrue();

      //Assert.True(doc.Valid);

    }
  }
}