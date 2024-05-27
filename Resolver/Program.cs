/*using Resolver;
using System.Reflection;

*//*class Program
{
    static void Main(string[] args)
    {*//*
string dllPath = "C:\\Users\\User\\Projects\\Python\\ThePackage\\ThePackage\\bin\\Debug\\net8.0\\ThePackage.dll";
DllResolver resolverIns = new DllResolver(dllPath);
DllResolver resolverSt = new DllResolver(dllPath);
string className = "ThePackage.NewMathClass";

resolverIns.LoadInstanceAble(className);
//Console.WriteLine(resolverIns.GetType());
//MemberInfo[]? arr = resolverIns.GetAllMembers();
*//*for (int i = 0; i < arr.Length; i++)
{
    Console.WriteLine(arr[i].ToString());
}*//*
Console.WriteLine(resolverIns.HasMember("Name"));
Console.ReadLine();

*//*        // Load instance class
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
*//*    }*//*
}*/
