using FluentAssertions;
using PaymentContext.Domain.Commands;
using Xunit;

namespace PaymentContext.Tests.Commands
{
  public class CreateBoletoSubscriptionCommandTests
  {
    [Fact]
    public void ShouldReturnErrorWhenNameIsInvalid()
    {
      //Given
      var command = new CreateBoletoSubscriptionCommand
      {
        FirstName = "",
        LastName = ""
      };

      //When

      command.Validate();

      //Then

      command.Valid.Should().BeFalse();
      Assert.False(command.Valid);
    }
  }
}