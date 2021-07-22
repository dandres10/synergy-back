namespace Base.Negocio.BL
{
    using AutoMapper;
    using Base.Datos.Contexto.Entidades;
    using Base.Datos.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.DTO.Consultas;
    using Base.IC.DTO.Entidades;
    using Base.Negocio.BO.Consultas;
    using Base.Negocio.Configuracion;
    using Base.Transversal.Clases;
    using Base.Transversal.Mensajes;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class PersonaBL : AccesoComunBL, IPersonaAccion
    {
        private readonly PersonaDAL personaDAL;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly Context context;

        public PersonaBL(PersonaDAL personaDAL, IMapper mapper, Context context, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.context = context;
            this.personaDAL = personaDAL;
            this.configuration = configuration;
        }

        public async Task<Respuesta<IPersonaLoginTokenDTO>> AutenticarPersona(IPersonaLoginDTO persona)
            => await EjecutarTransaccionAsync(async () =>
            {
                Respuesta<PersonaInfoBO> personaInfoBO =
                        mapper.Map<Respuesta<IPersonaInfoDTO>, Respuesta<PersonaInfoBO>>(await personaDAL.AutenticarPersona(persona));

                if (!personaInfoBO.EsValido)
                    return CrearRespuesta<IPersonaLoginTokenDTO>.Fallida(MensajesBaseEspanol.NoData);

                string TokenGenerado = GenerarTokenJWT(personaInfoBO.Resultado);

                PersonaLoginTokenBO response = new PersonaLoginTokenBO
                {
                    Token = TokenGenerado,
                    Correo = personaInfoBO.Resultado.Correo,
                    Estado = personaInfoBO.Resultado.Estado,
                    Nombre = string.Format("{0} {1}", personaInfoBO.Resultado.Nombres, personaInfoBO.Resultado.Apellidos)
                };

                return CrearRespuesta<IPersonaLoginTokenDTO>.Exitosa(response, null);
            });

        #region Metodos privados

        private string GenerarTokenJWT(PersonaInfoBO personaInfoBO)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, personaInfoBO.Id.ToString()),
                new Claim("nombre", personaInfoBO.Nombres),
                new Claim("apellidos", personaInfoBO.Apellidos),
                new Claim(JwtRegisteredClaimNames.Email, personaInfoBO.Correo),
                new Claim(ClaimTypes.Role, string.Join(",", personaInfoBO.NombreRoles)),
                new Claim("codigoRoles", string.Join(",", personaInfoBO.CodigoRoles))
            };

            var notBefore = DateTime.UtcNow;
            var expiracion = DateTime.UtcNow.AddHours(10);

            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: notBefore,
                    expires: expiracion
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }

        public async Task<Respuesta<List<IPersonaDTO>>> ConsultarListaPersona()
             => await EjecutarTransaccionAsync(async () => await personaDAL.ConsultarListaPersona());

        public async Task<Respuesta<IPersonaDTO>> ConsultarPersona(IPersonaDTO persona)
            => await EjecutarTransaccionAsync(async () => await personaDAL.ConsultarPersona(persona));

        public async Task<Respuesta<IPersonaDTO>> EditarPersona(IPersonaDTO persona)
            => await EjecutarTransaccionAsync(async () =>
            {
                Respuesta<IPersonaDTO> respuestaDAL = await personaDAL.ConsultarPersona(persona);
                if (!respuestaDAL.EsValido) return respuestaDAL;
                return await personaDAL.EditarPersona(persona);
            });

        public async Task<Respuesta<IPersonaDTO>> EliminarPersona(IPersonaDTO persona)
            => await EjecutarTransaccionAsync(async () =>
            {
                Respuesta<IPersonaDTO> respuestaDAL = await personaDAL.ConsultarPersona(persona);
                if (!respuestaDAL.EsValido) return respuestaDAL;
                return await personaDAL.EliminarPersona(persona);
            });

        public async Task<Respuesta<IPersonaDTO>> GuardarPersona(IPersonaDTO persona)
            => await EjecutarTransaccionAsync(async () => await personaDAL.GuardarPersona(persona));

        #endregion Metodos privados
    }
}