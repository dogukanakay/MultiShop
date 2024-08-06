using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(){

            var userClaim = User.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userClaim.Value);
            return Ok(new
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName,

            });
        }

        [HttpGet("GetAllUsersList")]
        public async Task<IActionResult> GetAllUsersList()
        {
            var users = await _userManager.Users.ToListAsync();
            var userDto = new List<ResultUserDto>();
            foreach (var user in users)
            {
                userDto.Add(new ResultUserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    AccessFailedCount = user.AccessFailedCount,
                    Email = user.Email,
                    UserName = user.UserName,
                    EmailConfirmed = user.EmailConfirmed,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    Surname = user.Surname,
                    TwoFactorEnabled = user.TwoFactorEnabled

                });
            }
            return Ok(userDto);
        }
    }
}
