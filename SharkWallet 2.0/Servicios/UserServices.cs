using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using CoinGecko.Clients;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SharkWallet_2._0.UOWork;
using SharkWallet_2._0.Autenticacion.response;
using SharkWallet_2._0.Autenticacion.request;
using SharkWallet_2._0.Entidades;
using SharkWallet_2._0.entidades;

namespace SharkWallet_2._0.Servicios
{
    public class UserServices
    {

        private readonly IUOWork _uOW;
        private readonly IConfiguration _configuration;
        public UserServices(IUOWork uow, IConfiguration configuration)
        {
            _uOW = uow;
            _configuration = configuration;
        }

        #region UserResponseRegistrar
        public UserResponse Registrar(UserRequest Email, string Contraseña, LogIn logIn)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            CrearPassHash(Contraseña, out passwordHash, out passwordSalt);
            LogIn logeo = new LogIn();
            logeo.Email = logIn.Email;
            logeo.PasswordHash = passwordHash;
            logeo.PasswordSalt = passwordSalt;
            _uOW.LogInRepo.Insert(logeo);
            _uOW.Save();
            UserResponse response = new UserResponse();
            response.Email = logeo.Email;
            response.UsuarioID = logeo.usuario;

            return response;
        }
        #endregion UserResposeRegistrar


        #region userResponseLogin
        public UserResponse Login(string Email, string password)
        {
            if (_uOW.LogInRepo.ExisteUsuario(Email))
            {
                UserResponse response = new UserResponse();
                //traigo el usuario, por el email
                LogIn login = _uOW.LogInRepo.GetByEmail(Email);
                //verifico si el password ingresado es el mismo del usuario en la DB
                if (!VerificarPassword(password, login.PasswordHash, login.PasswordSalt))
                {
                    return null;
                }
                //aca deberia mappear a un UserResponse
                response.Email = Email;
                response.Contraseña = password;
                //Devuelvo la respuesta si esta todo bien
                return response;
            }
            return null;
        }
        #endregion userResponseLogin


        #region VerficatePassword
        private bool VerificarPassword(string pass, byte[] pHash, byte[] pSalt)
        {
            //hago una encriptacion con la key (psalt)
            var hMac = new HMACSHA512(pSalt);
            var hash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
            //comparo el pass de la DB con el que acabo de encriptar
            for (var i = 0; i < hash.Length; i++)
            {
                if (hash[i] != pHash[i]) return false;
            }

            return true;
        }
        #endregion VerificatePassword


        #region getToken
        public string GetToken(UserResponse usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.NameId, usuario.UsuarioID.ToString()),
                
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddMinutes(30),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials

            };
            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion getToken


        #region CrearPassHash
        private void CrearPassHash(string pass, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //creo una encriptacion
            var hMac = new HMACSHA512();
            //le asigno la llave de la encriptacion al passwordSalt
            passwordSalt = hMac.Key;
            //Encripto el pass y lo guardo en passwordHash
            passwordHash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));

        }
        #endregion CrearPassHash

    }

}

