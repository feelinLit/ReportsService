using System;
using System.Linq;
using Reports.Domain.Models.Employees;
using Reports.Domain.Models.Problems;
using Reports.Domain.Tools.Exceptions;
using Xunit;

namespace Reports.Tests.UnitTests;

public class EmployeeTests
{
    [Fact]
    public void AddProblem_ProblemAdded()
    {
        var employee = new Employee("funny-username", null);
        const string problemDescription1 = "some-description_1";
        const string problemDescription2 = "some-description_2";
        var problem1 = new Problem(problemDescription1);

        employee.AddProblem(problem1);
        employee.AddProblem(problemDescription2);

        Assert.Collection(employee.Problems,
            p1 => Assert.Equal(problemDescription1, p1.Description),
            p2 => Assert.Equal(problemDescription2, p2.Description));
    }

    [Fact]
    public void AddDuplicateProblem_ProblemNotAdded()
    {
        var employee = new Employee("funny-username", null);
        const string problemDescription = "some-description";
        employee.AddProblem(problemDescription);
        Action addDuplicateProblem = () => employee.AddProblem(problemDescription);

        var exception = Record.Exception(addDuplicateProblem);
        
        Assert.NotNull(exception);
        Assert.IsType<DomainException>(exception);
    }
    
    
}