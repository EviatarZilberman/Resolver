using Resolver;

/*class Program
{
    static void Main(string[] args)
    {*/
        string dllPath = "C:\\Users\\User\\Projects\\Python\\ThePackage\\ThePackage\\bin\\Debug\\net8.0\\ThePackage.dll";
        DllResolver resolverIns = new DllResolver(dllPath);
        DllResolver resolverSt = new DllResolver(dllPath);

        // Load instance class
        string className = "ThePackage.NewMathClass";
        resolverIns.LoadInstanceAble(className);


        Console.WriteLine("Static:");
        Console.WriteLine();
        // Load static class
        string staticClassName = "ThePackage.MathClass";
        resolverSt.LoadStatic(staticClassName);
        Console.WriteLine(resolverSt.UseStaticMethodReturn("Plus", new object[] { 2,3 }));
        resolverSt.UseStaticMethod("SayHi");

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Instance:");
        Console.WriteLine();
        // Use instance method
        resolverIns.UseMethods("SayBye");
        Console.WriteLine(resolverIns.UseMethodsReturn("Plus", new object[] { 3, 7 }));
        resolverIns.UseStaticMethod("SayHi");
        Console.WriteLine(resolverIns.UseStaticMethodReturn("SayHi", new string[] { "Eviatar" }));

        Console.ReadLine();
/*    }
}*/
