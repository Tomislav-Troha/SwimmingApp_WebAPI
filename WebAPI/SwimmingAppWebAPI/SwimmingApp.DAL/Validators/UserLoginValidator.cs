using FluentValidation;
using SwimmingApp.Abstract.DTO;
using SwimmingApp.DAL.Repositories.UserService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.DAL.Validators
{
    public class UserLoginValidator : AbstractValidator<UserLoginDTO>
    {
        private readonly IUserService _userService;

        public UserLoginValidator(IUserService userService)
        {
            _userService = userService; 

            RuleFor(x => x.Username).NotEmpty().NotNull().WithMessage("Username is required");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Password is required");
            RuleFor(e => e).MustAsync(VerifyLogin).WithMessage("Email or password are incorect");
        }

        private async Task<bool> VerifyLogin(UserLoginDTO loginDTO, CancellationToken token)
        {
            var user = await _userService.GetUserLoginData(loginDTO.Email);

            if(user != null) 
            {
                var sha256 = SHA256.Create();

                byte[] password = sha256.ComputeHash(Encoding.UTF8.GetBytes((loginDTO.Password) + user.Salt));
                bool passwordIsTrue = StructuralComparisons.StructuralEqualityComparer.Equals(password, user.Password);
                if (passwordIsTrue) { return true; }
            }
            else return false;

            return false;
        }

    }
}
