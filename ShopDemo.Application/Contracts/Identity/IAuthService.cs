﻿using ShopDemo.Application.Models.Identity;

namespace ShopDemo.Application.Contracts.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    
    Task<RegistrationResponse> Register(RegistrationRequest request);
}