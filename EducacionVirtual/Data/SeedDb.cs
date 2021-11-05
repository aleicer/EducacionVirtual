using EducacionVitual.Enums;
using EducacionVitual.Helpers;
using EducacionVitual.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducacionVirtual.Data
{
    public class SeedDb
    {

        private readonly EducacionVirtualContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(
            EducacionVirtualContext dataContext,
            IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            var admin = await CheckUserAsync("1010", "Profesor", "Americana", "pamericana@gmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.Admin);
            var driver = await CheckUserAsync("2020", "Profesor", "Americana", "pamericana55@hotmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.Driver);
            var user1 = await CheckUserAsync("3030", "Profesor", "Americana", "Profesor.Americana@globant.com", "350 634 2747", "Calle Luna Calle Sol", UserType.User);
            var user2 = await CheckUserAsync("4040", "Profesor", "Americana", "ProfesorAmericana2480@correo.itm.edu.co", "350 634 2747", "Calle Luna Calle Sol", UserType.User);
        }
        
        private async Task<ApplicationUser> CheckUserAsync(
                                                            string document,
                                                            string firstName,
                                                            string lastName,
                                                            string email,
                                                            string phone,
                                                            string address,
                                                            UserType userType)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return (ApplicationUser)user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Driver.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }
    }
}
