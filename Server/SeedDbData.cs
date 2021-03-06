using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreSpa.Server.Entities;
using AspNetCoreSpa_master.Server.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Core;
using OpenIddict.Models;

namespace AspNetCoreSpa.Server
{
    public class SeedDbData
    {
        readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnv;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public SeedDbData(IWebHost host, ApplicationDbContext context)
        {
            var services = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));
            var serviceScope = services.CreateScope();
            _hostingEnv = serviceScope.ServiceProvider.GetService<IHostingEnvironment>();
            _roleManager = serviceScope.ServiceProvider.GetService<RoleManager<ApplicationRole>>();
            _userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
            _context = context;
            CreateRoles(); // Add roles
            CreateUsers(); // Add users
            CreateBooks(); // Add books
            CreatePosts(); // Add posts
            CreateUserOffers();
            CreateUserDemands();
            CreateBookContracts();
            CreateBookToUsers();
            CreateContracts();
            CreateExternalResources();
            CreateFavoriteYoutubeItems();
            AddLocalisedData();
            AddOpenIdConnectOptions(serviceScope, CancellationToken.None).GetAwaiter().GetResult();
        }

        private void CreateContracts()
        {
            if (!_context.Contracts.Any())
            {
                _context.Contracts.Add(new Contract());

                _context.SaveChanges();
            }
        }

        private void CreateBookToUsers()
        {
            if (!_context.BookToUsers.Any())
            {
                _context.BookToUsers.Add(new BookToUser());

                _context.SaveChanges();
            }
        }

        private void CreateBookContracts()
        {
            if (!_context.BookContracts.Any())
            {
                _context.BookContracts.Add(new BookContract());

                _context.SaveChanges();
            }
        }

        private void CreateUserDemands()
        {
            if (!_context.UserDemands.Any())
            {
                _context.UserDemands.Add(new UserDemand());

                _context.SaveChanges();
            }
        }

        private void CreateUserOffers()
        {
            if (!_context.UserOffers.Any())
            {
                _context.UserOffers.Add(new UserOffer());

                _context.SaveChanges();
            }
        }

        private void CreateExternalResources()
        {
            if (!_context.ExternalResources.Any())
            {
                _context.ExternalResources.Add(new ExternalResource());

                _context.SaveChanges();
            }
        }

        private void CreateFavoriteYoutubeItems()
        {
            if (!_context.YoutubeFavorites.Any())
            {
                _context.YoutubeFavorites.Add(new YoutubeFavorite());

                _context.SaveChanges();
            }
        }

        private void CreateRoles()
        {
            var rolesToAdd = new List<ApplicationRole>(){
                new ApplicationRole { Name= "Admin", Description = "Full rights role"},
                new ApplicationRole { Name= "User", Description = "Limited rights role"}
            };
            foreach (var role in rolesToAdd)
            {
                if (!_roleManager.RoleExistsAsync(role.Name).Result)
                {
                    _roleManager.CreateAsync(role).Result.ToString();
                }
            }
        }
        private void CreateUsers()
        {
            if (!_context.ApplicationUsers.Any())
            {

                _userManager.CreateAsync(new ApplicationUser { UserName = "admin@admin.com", FirstName = "Admin first", LastName = "Admin last", Email = "admin@admin.com", EmailConfirmed = true, CreatedDate = DateTime.Now, IsEnabled = true }, "P@ssw0rd!").Result.ToString();
                _userManager.AddToRoleAsync(_userManager.FindByNameAsync("admin@admin.com").GetAwaiter().GetResult(), "Admin").Result.ToString();

                _userManager.CreateAsync(new ApplicationUser { UserName = "user@user.com", FirstName = "First", LastName = "Last", Email = "user@user.com", EmailConfirmed = true, CreatedDate = DateTime.Now, IsEnabled = true }, "P@ssw0rd!").Result.ToString();
                _userManager.AddToRoleAsync(_userManager.FindByNameAsync("user@user.com").GetAwaiter().GetResult(), "User").Result.ToString();
            }
        }

        private void CreateBooks()
        {
            if (!_context.Books.Any())
            {
                _context.Books.Add(new Book() {
                    Title = "Спустошення",
                    Author = "Любко Дереш",
                    Country = "Україна",
                    Language = "Українська",
                    Genre = "Роман",
                    Publisher = "Просвіта",
                    Published = DateTime.Now,
                });
                _context.Books.Add(new Book() {
                    Title = "Інтернат",
                    Author = "Сергій Жадан",
                    Country = "Україна",
                    Language = "Українська",
                    Genre = "Роман",
                    Publisher = "Просвіта",
                    Published = DateTime.Now,
                });
                _context.Books.Add(new Book() {
                    Title = "Довгі часи",
                    Author = "Володимир Рафєєнко",
                    Country = "Україна",
                    Language = "Українська",
                    Genre = "Роман",
                    Publisher = "Старий Лев",
                    Published = DateTime.Now,
                });
                _context.Books.Add(new Book() {
                    Title = "Троща",
                    Author = "Василь Шкляр",
                    Country = "Україна",
                    Language = "Українська",
                    Genre = "Роман",
                    Publisher = "Абабагамага",
                    Published = DateTime.Now,
                });
                _context.Books.Add(new Book() {
                    Title = "Охайні прописи ерцгерцога Вільгельма",
                    Author = "Наталка Сняданко",
                    Country = "Україна",
                    Language = "Українська",
                    Genre = "Роман",
                    Publisher = "Старий Лев",
                    Published = DateTime.Now,
                });
                _context.Books.Add(new Book() {
                    Title = "Лютеція",
                    Author = "Юрій Винничук",
                    Country = "Україна",
                    Language = "Українська",
                    Genre = "Роман",
                    Publisher = "Просвіта",
                    Published = DateTime.Now,
                });
                _context.Books.Add(new Book() {
                    Title = "Харків 1938",
                    Author = "Олександр Ірванець",
                    Country = "Україна",
                    Language = "Українська",
                    Genre = "Роман",
                    Publisher = "Просвіта",
                    Published = DateTime.Now,
                });

                _context.SaveChanges();
            }
        }
        private void CreatePosts()
        {
            if (!_context.Posts.Any())
            {
                _context.Posts.Add(new Post() {
                    Title = "NewTitle",
                    Published = false,
                });

                _context.SaveChanges();
            }
        }

        private void AddLocalisedData()
        {
            if (!_context.Cultures.Any())
            {
                _context.Cultures.AddRange(
                    new Culture
                    {
                        Name = "en-US",
                        Resources = new List<Resource>() {
                            new Resource { Key = "app_title", Value = "BookPortal" },
                            new Resource { Key = "app_description", Value = "Single page application using aspnet core and angular" },
                            new Resource { Key = "app_nav_home", Value = "Home" },
                            new Resource { Key = "app_nav_chat", Value = "Chat" },
                            new Resource { Key = "app_nav_examples", Value = "Examples" },
                            new Resource { Key = "app_nav_register", Value = "Register" },
                            new Resource { Key = "app_nav_login", Value = "Login" },
                            new Resource { Key = "app_nav_logout", Value = "Logout" },
                        }
                    },
                    new Culture
                    {
                        Name = "ua-UA",
                        Resources = new List<Resource>() {
                            new Resource { Key = "app_title", Value = "BookPortal" },
                            new Resource { Key = "app_description", Value = "Single page application using aspnet core and angular" },
                            new Resource { Key = "app_nav_home", Value = "Домівка" },
                            new Resource { Key = "app_nav_chat", Value = "Чат" },
                            new Resource { Key = "app_nav_examples", Value = "Приклади" },
                            new Resource { Key = "app_nav_register", Value = "Реєстрація" },
                            new Resource { Key = "app_nav_login", Value = "Ввійти" },
                            new Resource { Key = "app_nav_logout", Value = "Вийти" },
                        }
                    }
                    );

                _context.SaveChanges();
            }

        }

        private async Task AddOpenIdConnectOptions(IServiceScope services, CancellationToken cancellationToken)
        {
            var manager = services.ServiceProvider.GetService<OpenIddictApplicationManager<OpenIddictApplication>>();

            if (await manager.FindByClientIdAsync("aspnetcorespa", cancellationToken) == null)
            {
                var host = Startup.Configuration["HostUrl"].ToString();

                var descriptor = new OpenIddictApplicationDescriptor
                {
                    ClientId = "aspnetcorespa",
                    DisplayName = "AspnetCoreSpa",
                    PostLogoutRedirectUris = { new Uri($"{host}signout-oidc") },
                    RedirectUris = { new Uri(host) },
                    Permissions =
                    {
                        OpenIddictConstants.Permissions.Endpoints.Authorization,
                        OpenIddictConstants.Permissions.Endpoints.Token,
                        OpenIddictConstants.Permissions.GrantTypes.Implicit,
                        OpenIddictConstants.Permissions.GrantTypes.Password,
                        OpenIddictConstants.Permissions.GrantTypes.RefreshToken
                    }
                };

                await manager.CreateAsync(descriptor, cancellationToken);
            }

            // if (await manager.FindByClientIdAsync("resource-server-1", cancellationToken) == null)
            // {
            //     var descriptor = new OpenIddictApplicationDescriptor
            //     {
            //         ClientId = "resource-server-1",
            //         ClientSecret = "846B62D0-DEF9-4215-A99D-86E6B8DAB342"
            //     };

            //     await manager.CreateAsync(descriptor, cancellationToken);
            // }

            // if (await manager.FindByClientIdAsync("resource-server-2", cancellationToken) == null)
            // {
            //     var descriptor = new OpenIddictApplicationDescriptor
            //     {
            //         ClientId = "resource-server-2",
            //         ClientSecret = "C744604A-CD05-4092-9CF8-ECB7DC3499A2"
            //     };

            //     await manager.CreateAsync(descriptor, cancellationToken);
            // }
        }
    }
}
