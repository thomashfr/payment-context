using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Tests.Queries
{
  public class StudentsQueriesTests
  {
    private IList<Student> _students;

    public StudentsQueriesTests()
    {
      _students = new List<Student>();
      for (var i = 0; i <= 10; i++)
      {
        _students.Add(new Student(
            new Name("Aluno", i.ToString()),
            new Document("1111111111" + i.ToString(), EDocumentType.CPF),
            new Email(i.ToString() + "@balta.io")
        ));
      }
    }

    [Fact]
    public void ShouldReturnNullWhenDocumentNotExists()
    {
      //Given
      var exp = StudentQueries.GetStudentInfo("12345678911");

      //When

      var student = _students.AsQueryable().Where(exp)
      .FirstOrDefault();

      student.Should().BeNull();
      //Then
    }
    [Fact]
    public void ShouldReturnStudentWhenDocumentExists()
    {
      var exp = StudentQueries.GetStudentInfo("11111111111");
      var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

      studn.Should().NotBeNull();
    }


  }
}