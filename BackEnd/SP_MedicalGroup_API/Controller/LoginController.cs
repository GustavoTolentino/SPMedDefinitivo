using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SP_MedicalGroup_API.Domains;
using SP_MedicalGroup_API.Interfaces;
using SP_MedicalGroup_API.Repositories;
using SP_MedicalGroup_API.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SP_MedicalGroup_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuario _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("E-mail ou senha inválidos!");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoDeUsuario.ToString()),

                    new Claim("role", usuarioBuscado.IdTipoDeUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("TolentinoKeyGRANDEOSUFICIENTEAGORA?"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "hroads.webApi",
                    audience: "hroads.webApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        }
    }

