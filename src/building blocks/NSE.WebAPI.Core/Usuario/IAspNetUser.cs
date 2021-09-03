﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace NSE.WebAPI.Core.Usuario
{
    public interface IAspNetUser
    {
        string Name { get; }

        Guid ObterUserdId();

        string ObterUserEmail();

        string ObterUserToken();
        string ObterUserRefreshToken();

        bool EstaAutenticado();

        bool PossuiRole(string role);

        IEnumerable<Claim> ObterClaims();

        HttpContext ObterHttpContext();
    }
}
