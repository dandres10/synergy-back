namespace Base.Transversal.Clases
{
    using Base.Transversal.Enumeraciones;
    using System.Collections.Generic;

    public static class CrearRespuesta<T>
    {
        public static Respuesta<T> Exitosa(T resultado, string mensaje, TipoMensaje tipoMensaje)
            => new Respuesta<T> { Mensaje = mensaje, Resultado = resultado, TipoNotificacion = TipoNotificacionEnum.Exitoso, EsValido = true, TipoMensaje = tipoMensaje };

        public static Respuesta<T> Advertencia(T resultado, string mensaje, TipoMensaje tipoMensaje)
            => new Respuesta<T> { Mensaje = mensaje, Resultado = resultado, TipoNotificacion = TipoNotificacionEnum.Advertencia, EsValido = false, TipoMensaje = tipoMensaje };

        public static Respuesta<T> Fallida(string mensaje, TipoMensaje tipoMensaje)
            => new Respuesta<T> { Mensaje = mensaje, TipoNotificacion = TipoNotificacionEnum.Fallida, EsValido = false, TipoMensaje = tipoMensaje };

        public static Respuesta<List<T>> ExitosaLista(List<T> resultado, TipoMensaje tipoMensaje)
            => new Respuesta<List<T>> { Resultado = resultado, TipoNotificacion = TipoNotificacionEnum.Exitoso, EsValido = true, TipoMensaje = tipoMensaje };

        public static Respuesta<List<T>> AdvertenciaLista(List<T> resultado, string mensaje, TipoMensaje tipoMensaje)
            => new Respuesta<List<T>> { Mensaje = mensaje, Resultado = resultado, TipoNotificacion = TipoNotificacionEnum.Advertencia, EsValido = false, TipoMensaje = tipoMensaje };

        public static Respuesta<List<T>> FallidaLista(string mensaje, TipoMensaje tipoMensaje)
            => new Respuesta<List<T>> { Mensaje = mensaje, TipoNotificacion = TipoNotificacionEnum.Fallida, EsValido = false, TipoMensaje = tipoMensaje };

        public static Respuesta<T> Exitosa(T resultado, string mensaje)
            => new Respuesta<T> { Mensaje = mensaje, Resultado = resultado, TipoNotificacion = TipoNotificacionEnum.Exitoso, EsValido = true, TipoMensaje = TipoMensaje.Ninguno };

        public static Respuesta<T> Advertencia(T resultado, string mensaje)
            => new Respuesta<T> { Mensaje = mensaje, Resultado = resultado, TipoNotificacion = TipoNotificacionEnum.Advertencia, EsValido = false, TipoMensaje = TipoMensaje.Ninguno };

        public static Respuesta<T> Fallida(string mensaje)
            => new Respuesta<T> { Mensaje = mensaje, TipoNotificacion = TipoNotificacionEnum.Fallida, EsValido = false, TipoMensaje = TipoMensaje.Ninguno };

        public static Respuesta<List<T>> ExitosaLista(List<T> resultado)
            => new Respuesta<List<T>> { Resultado = resultado, TipoNotificacion = TipoNotificacionEnum.Exitoso, EsValido = true, TipoMensaje = TipoMensaje.Ninguno };

        public static Respuesta<List<T>> AdvertenciaLista(List<T> resultado, string mensaje)
            => new Respuesta<List<T>> { Mensaje = mensaje, Resultado = resultado, TipoNotificacion = TipoNotificacionEnum.Advertencia, EsValido = false, TipoMensaje = TipoMensaje.Ninguno };

        public static Respuesta<List<T>> FallidaLista(string mensaje)
            => new Respuesta<List<T>> { Mensaje = mensaje, TipoNotificacion = TipoNotificacionEnum.Fallida, EsValido = false, TipoMensaje = TipoMensaje.Ninguno };
    }
}