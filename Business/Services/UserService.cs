
using System.Text.Json;
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class UserService(IFileService fileService) : IUserService
{
    public readonly IFileService _fileService = fileService;
    public List<User> _users = [];
    public IEnumerable<User> GetAll()
    {
        var content = _fileService.GetContentFromFile();
        try
        {
            _users = JsonSerializer.Deserialize<List<User>>(content)!;
        }
        catch 
        { 
            _users = [];
        }
        return _users;
    }
    public bool Save(UserRegistrationForm form)
    {
        var user = UserFactory.Create(form);
        _users.Add(user);

        var json = JsonSerializer.Serialize(_users);
        var result = _fileService.SaveContentToFile(json);
        return result; 

    }

}

