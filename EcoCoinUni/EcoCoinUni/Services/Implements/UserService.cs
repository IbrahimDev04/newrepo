using AutoMapper;
using EcoCoinUni.Dtos.UserDtos;
using EcoCoinUni.Entities;
using EcoCoinUni.Exceptions.UserExceptions;
using EcoCoinUni.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EcoCoinUni.Services.Implements;

public class UserService : IUserService
{
    readonly UserManager<AppUser> _userManager;
    readonly IMapper _mapper;

    public UserService(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task RegisterAsync(RegisterDto dto)
    {
        var user = _mapper.Map<AppUser>(dto);
        if (await _userManager.Users.AnyAsync(u => dto.Username == u.UserName || dto.Email == u.Email))
            throw new UserExistsException();
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in result.Errors)
            {
                sb.Append(item.Description + " ");
            }
            throw new RegisterFailedException(sb.ToString().TrimEnd());
        }
    }
}
