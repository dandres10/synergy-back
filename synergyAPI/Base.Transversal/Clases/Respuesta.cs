namespace Base.Transversal.Clases
{
    using Base.Transversal.Enumeraciones;

    public class Respuesta<T>
    {
        public T Resultado { get; set; }
        public string Mensaje { get; set; }
        public TipoNotificacionEnum TipoNotificacion { get; set; }
    }
}