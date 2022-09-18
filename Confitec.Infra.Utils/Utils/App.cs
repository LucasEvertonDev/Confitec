namespace Confitec.Infra.Utils.Utils
{
    public static class App
    {
        // Perfumaria
        public static T Init<T>()
        {
            return Activator.CreateInstance<T>();
        }

        // Perfumaria
        public static dynamic Init(Type t)
        {
            return Activator.CreateInstance(t);
        }
    }
}
