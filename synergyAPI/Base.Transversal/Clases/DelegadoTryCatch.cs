namespace Base.Transversal.Clases
{
    using System;
    using System.Threading.Tasks;

    public class DelegadoTryCatch : Validaciones
    {
        public delegate Task<dynamic> DelegadoET();

        public static async Task<dynamic> EjecutarTransaccionAsync(DelegadoET delegado)
        {
            try
            {
                return await delegado();
            }
            catch (Exception error)
            {
                return CrearRespuesta<dynamic>.Fallida(error.ToString());
            }
        }
    }
}