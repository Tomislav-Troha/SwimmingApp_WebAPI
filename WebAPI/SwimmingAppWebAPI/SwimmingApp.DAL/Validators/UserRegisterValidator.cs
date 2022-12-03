using SwimmingApp.DAL.Repositories.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using System.Security.Cryptography.X509Certificates;
using SwimmingApp.Abstract.DTO;

namespace SwimmingApp.DAL.Validators
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterDTO>
    {
        private readonly IUserService _userService;

        public UserRegisterValidator(IUserService userService)
        {
            _userService = userService; 

            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage("Username is required");
        }
    }
}
