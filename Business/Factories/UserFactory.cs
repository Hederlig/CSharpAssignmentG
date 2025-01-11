using Business.Helpers;
using Business.Models;
namespace Business.Factories;

public static class UserFactory
{
    public static UserRegistrationForm Create() 
    {
        return new UserRegistrationForm();
    }

    public static UserEntity Create(UserRegistrationForm form)
    {
        return new UserEntity
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.PhoneNumber,
            Address = form.Address,
            ZipCode = form.ZipCode,
            County = form.County,
        };
    }

    public static User Create(UserEntity entity)
    {
        return new User
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            Address = entity.Address,
            ZipCode = entity.ZipCode,
            County = entity.County,
        };
    }
}
