namespace Base.Transversal.Clases
{
    using Base.Transversal.Enumeraciones;

    public static class CrearRespuesta<T>
    {
        public static Respuesta<T> Exitosa(T resultado)
            => new Respuesta<T> { Resultado = resultado, TipoNotificacion = TipoNotificacionEnum.Exitoso };

        public static Respuesta<T> Advertencia(T resultado, string mensaje)
            => new Respuesta<T> { Mensaje = mensaje, Resultado = resultado, TipoNotificacion = TipoNotificacionEnum.Advertencia };

        public static Respuesta<T> Fallida(string mensaje)
            => new Respuesta<T> { Mensaje = mensaje, TipoNotificacion = TipoNotificacionEnum.Fallida };

        
    }
}