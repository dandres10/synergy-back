namespace Base.Transversal.Clases
{
    public class Validaciones<T>
    {
        public static bool ObjIsNull(T Obj)
        {
            return Obj == null ? true : false;
        }
    }
}