﻿using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IFileService>(new FileService("users.json"));
serviceCollection.AddTransient<IUserService, UserService>();

var servuceProvider = serviceCollection.BuildServiceProvider();
var menuDialogs = servuceProvider.GetRequiredService<MenuDialogs>();