namespace Base.Datos.Configuracion
{
    using Base.Datos.Contexto.Entidades;
    using Base.Transversal.Clases;
    using System;
    using System.Threading.Tasks;

    public class AccesoComunDAL : Validaciones
    {
        public delegate Task<dynamic> EjecutarCodigo();

        public static async Task<dynamic> EjecutarTransaccionAsync(EjecutarCodigo ejecutarCodigo, Context context, string nombreMetodo)
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