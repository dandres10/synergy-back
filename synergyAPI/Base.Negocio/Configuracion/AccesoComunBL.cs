namespace Base.Negocio.Configuracion
{
    using Base.Datos.Contexto.Entidades;
    using Base.Transversal.Clases;
    using System;
    using System.Threading.Tasks;

    public class AccesoComunBL : Validaciones
    {
        public delegate Task<dynamic> EjecutarCodigo();

        public static async Task<dynamic> EjecutarTransaccionAsync(EjecutarCodigo ejecutarCodigo)
        {
            try
            {
                return await ejecutarCodigo();
            }
            catch (Exception error)
            {
                return CrearRespuesta<dynamic>.Fallida(error.Message.ToString());
            }
        }

        public static async Task<dynamic> EjecutarTransaccionAsync(EjecutarCodigo ejecutarCodigo, Context context, string NombreMetodo)
        {
            try
            {
                return await ejecutarCodigo();
            }
            catch (Exception error)
            {
                return CrearRespuesta<dynamic>.Fallida(error.Message.ToString());
            }
        }
    }
}