using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Presentation_App.Dialogs;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IFileService>(new FileService("users.json"));
serviceCollection.AddTransient<IUserService, UserService>();
serviceCollection.AddSingleton<MenuDialogs>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var menuDialogs = serviceProvider.GetRequiredService<MenuDialogs>();

menuDialogs.MainMenu();