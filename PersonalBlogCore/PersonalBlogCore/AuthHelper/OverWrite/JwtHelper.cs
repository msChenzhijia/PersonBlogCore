using Blog.Core.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlogCore.AuthHelper.OverWrite
{
    /// <summary>
    /// 
    /// </summary>
    public class JwtHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static string secretKey { set; get; } = "sdfsdfsrty45634kkhllghtdgdfss345t678fs";
        /// <summary>
        /// 颁发JWT字符串
        /// </summary>
        /// <param name="tokenModelJWT"></param>
        /// <returns></returns>
        public static string IssueJWT(TokenModelJWT tokenModelJWT)
        {
            var datetime = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,tokenModelJWT.Id.ToString()),
                new Claim("Role",tokenModelJWT.Role),
                new Claim(JwtRegisteredClaimNames.Iat,datetime.ToString(),ClaimValueTypes.Integer64)
            };
            //密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtHelper.secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                  issuer: "Blog.Core",
                  claims: claims,
                  expires: datetime.AddHours(2),
                  signingCredentials: creds
                );
            var jwtHander = new JwtSecurityTokenHandler();
            var encodedJwt = jwtHander.WriteToken(jwt);
            return encodedJwt;
        }
        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="jwtStr"></param>
        /// <returns></returns>
        public static TokenModelJWT SerializeJWT(string jwtStr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);
            object role = new object();
            try
            {
                jwtToken.Payload.TryGetValue("Role", out role);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            var tm = new TokenModelJWT
            {
                Id = (jwtToken.Id).ObjToInt(),
                Role = role != null ? role.ObjToString() : ""
            };
            return tm;
        }

    }
}
