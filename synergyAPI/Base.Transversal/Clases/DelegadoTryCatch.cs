namespace Base.Transversal.Clases
{
    using System;
    using System.Threading.Tasks;

    public class DelegadoTryCatch<T> : Validaciones<T>
    {
        public delegate Task<Respuesta<T>> Delegado();

        public static async Task<Respuesta<T>> EjecutarTransaccionAsync(Delegado delegado)
        {
            try
            {
                return await delegado();
            }
            catch (Exception error)
            {
                return CrearRespuesta<T>.Fallida(error.ToString());
            }
        }
    }
}