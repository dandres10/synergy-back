namespace Base.Transversal.Clases
{
    using Base.Transversal.Enumeraciones;
    using System.Collections.Generic;

    public static class CrearRespuesta<T>
    {
        public static Respuesta<T> Exitosa(T resultado)
            => new Respuesta<T> { Resultado = resultado, TipoNotificacion = TipoNotificacionEnum.Exitoso };

        public static Respuesta<T> Advertencia(T resultado, string mensaje)
            => new Respuesta<T> { Mensaje = mensaje, Resultado = resultado, TipoNotificacion = TipoNotificacionEnum.Advertencia };

        public static Respuesta<T> Fallida(string mensaje)
            => new Respuesta<T> { Mensaje = mensaje, TipoNotificacion = TipoNotificacionEnum.Fallida };

        public static Respuesta<List<T>> ExitosaLista(List<T> resultado)
            => new Respuesta<List<T>> { Resultado = resultado, TipoNotificacion = TipoNotificacionEnum.Exitoso };

        public static Respuesta<List<T>> AdvertenciaLista(List<T> resultado, string mensaje)
            => new Respuesta<List<T>> { Mensaje = mensaje, Resultado = resultado, TipoNotificacion = TipoNotificacionEnum.Advertencia };

        public static Respuesta<List<T>> FallidaLista(string mensaje)
            => new Respuesta<List<T>> { Mensaje = mensaje, TipoNotificacion = TipoNotificacionEnum.Fallida };
    }
}