namespace Base.Transversal.Clases
{
    using System;
    using System.Threading.Tasks;

    public class Delegados : Validaciones
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
                return CrearRespuesta<dynamic>.Fallida(error.ToString());
            }
        }
    }
}