using System.Reflection;
namespace Bindings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Reflection Implementation\n---------------------------------");

            Assembly currAssembly = Assembly.GetExecutingAssembly();

            GetAssemblyTypes(currAssembly);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Type currAssemblyType = currAssembly.GetType();
            Console.WriteLine($"\nCurrent Assembly Type: {currAssemblyType}");

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Loading External Assembly...\n");
            Assembly loadedAssembly = Assembly.LoadFrom("ConsoleMusicPlayer");

            Console.WriteLine($"External Assembly name is : {loadedAssembly}");

            Type[] loadedAssemblyTypes = loadedAssembly.GetTypes();

            foreach (Type type in loadedAssemblyTypes)
                Console.WriteLine($"Type Name: {type.Name}");

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            Console.WriteLine("Getting Methods, Property and Field Info.\n\nEnter a Type Name to Explore: ");
            var enteredType = Console.ReadLine();

            Type t = Type.GetType(enteredType);

            //Type t = currAssemblyType.GetType();

            GetMethodInfo(t);

            GetFieldInfo(t);

            GetPropertyInfo(t);
        }


        static void GetAssemblyTypes(Assembly currAssembly)
        {
            Type[] currAssemblyTypes = currAssembly.GetTypes();
            foreach (var type in currAssemblyTypes)
                Console.WriteLine($"Type Name: {type.Name}");
        }


        static void GetMethodInfo(Type t)
        {
            MethodInfo[] methods = t.GetMethods();
            foreach (MethodInfo method in methods) { Console.WriteLine($"Method Name: {method.Name} \n------------------------------------------\n"); }
        }


        static void GetFieldInfo(Type t)
        {
            FieldInfo[] fields = t.GetFields();
            foreach (FieldInfo field in fields) { Console.WriteLine($"Field Name: {field.Name} \n--------------------------------------------\n"); }
        }


        static void GetPropertyInfo(Type t)
        {
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo property in properties) { Console.WriteLine($"Property Name: {property.Name} \n------------------------------------------\n"); }
        }
    }
}