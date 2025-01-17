﻿namespace Business.Models;

public class User
{   public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string County { get; set; } = null!;
}