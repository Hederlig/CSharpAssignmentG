using Business.Dtos;
using Business.Factories;
using Business.Models;

namespace Tests.Factories;

public class UserFactory_Test
{

    [Fact]
    public void Create_ShouldReturnUserRegistrationForm()
    {
        // Arrange
        var form = UserFactory.Create();
        // Act
        var result = UserFactory.Create();
        // Assert
        Assert.NotNull(result);
        Assert.IsType<UserRegistrationForm>(result);
    }
    [Fact]
    public void Create_ShouldReturnUser_WhenUserRegistrationFormIsProvided()
    {
        // Arrange
        var userRegistrationForm = new UserRegistrationForm()
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@dead.com",
            PhoneNumber = "12345678",
            Address = "Doe Street",
            ZipCode = "1234",
            County = "Dead mans land"
        };
     
        // Act
        var result = UserFactory.Create(userRegistrationForm);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<User>(result);
        Assert.Equal(userRegistrationForm.FirstName, result.FirstName);
        Assert.Equal(userRegistrationForm.LastName, result.LastName);
        Assert.Equal(userRegistrationForm.Email, result.Email);
        Assert.Equal(userRegistrationForm.PhoneNumber, result.PhoneNumber);
        Assert.Equal(userRegistrationForm.Address, result.Address);
        Assert.Equal(userRegistrationForm.ZipCode, result.ZipCode);
        Assert.Equal(userRegistrationForm.County, result.County);
    }
}
