using System.Reflection;

namespace Resolver
{
    public class DllResolver
    {
        private object? ClassInstance { get; set; } = null;
        private Type? StaticClass { get; set; } = null;
        private string DllPath { get; set; }

        public DllResolver(string dllPath)
        {
            this.DllPath = dllPath;
        }

        public void UseStaticMethod(string methodName, object[]? arguments = null) // For void static methods.
        {
            if (StaticClass == null) throw new InvalidOperationException("Static class not loaded.");

            MethodInfo? method;
            if (arguments == null)
            {
                method = StaticClass.GetMethod(methodName, Type.EmptyTypes);
            }
            else
            {
                Type[] argumentTypes = arguments.Select(arg => arg.GetType()).ToArray();
                method = StaticClass.GetMethod(methodName, argumentTypes);
            }

            if (method == null) throw new InvalidOperationException($"Method '{methodName}' not found in static class.");

            method.Invoke(null, arguments);
        }

        public object UseStaticMethodReturn(string methodName, object[]? arguments = null) // For return static methods.
        {
            if (StaticClass == null) throw new InvalidOperationException("Static class not loaded.");

            MethodInfo? method;
            if (arguments == null)
            {
                method = StaticClass.GetMethod(methodName, Type.EmptyTypes);
            }
            else
            {
                Type[] argumentTypes = arguments.Select(arg => arg.GetType()).ToArray();
                method = StaticClass.GetMethod(methodName, argumentTypes);
            }

            if (method == null) throw new InvalidOperationException($"Method '{methodName}' not found in static class.");

            return method.Invoke(null, arguments);
        }

        public void UseMethods(string methodName, object[]? arguments = null) // For internal void methods.
        {
            if (ClassInstance == null) throw new InvalidOperationException("Class instance not loaded.");
            MethodInfo? method = ClassInstance.GetType().GetMethod(methodName);
            if (method == null) throw new InvalidOperationException($"Method '{methodName}' not found in instance class.");
            method.Invoke(ClassInstance, arguments);
        }

        public object UseMethodsReturn(string methodName, object[]? arguments = null) // Internal methods with return.
        {
            if (ClassInstance == null) throw new InvalidOperationException("Class instance not loaded.");
            MethodInfo? method = ClassInstance.GetType().GetMethod(methodName);
            if (method == null) throw new InvalidOperationException($"Method '{methodName}' not found in instance class.");
            return method.Invoke(ClassInstance, arguments);
        }

        public void LoadInstanceAble(string className, object[]? args = null) // Loads the resolver for Instance of a class.
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentNullException(nameof(className));
            }

            try
            {
                // Load the assembly from the specified DLL path
                Assembly? assembly = Assembly.LoadFrom(DllPath);

                // Get the type of the class from the assembly
                Type? type = assembly.GetType(className);

                if (type == null)
                {
                    throw new TypeLoadException($"Type '{className}' not found in assembly '{DllPath}'.");
                }

                // Create an instance of the class
                this.ClassInstance = Activator.CreateInstance(type, args);
                this.StaticClass = type;
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new InvalidOperationException("Failed to load and create instance of the specified type.", ex);
            }
        }

        public void LoadStatic(string className) // Loads static classes.
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentNullException(nameof(className));
            }

            try
            {
                // Load the assembly from the specified DLL path
                Assembly? assembly = Assembly.LoadFrom(DllPath);

                // Get the type of the class from the assembly
                Type? type = assembly.GetType(className);
                if (type == null)
                {
                    throw new TypeLoadException($"Type '{className}' not found in assembly '{DllPath}'.");
                }

                if (type.IsAbstract)
                {
                    this.StaticClass = type;
                }
                else
                {
                    throw new InvalidOperationException("Type is not static.");
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new InvalidOperationException("Failed to load and create instance of the specified type.", ex);
            }
        }

        public new Type? GetType()
        {
            return this.StaticClass;
        }

        public string? GetNameSpace()
        {
            return this.StaticClass?.Namespace;
        }

        public Type[]? GetInterfaces()
        {
            return this.StaticClass?.GetInterfaces();
        }

        public string? GetInheritenceName()
        {
            return this.StaticClass?.BaseType?.FullName;
        }

        public Type? GetInheritence()
        {
            return this.StaticClass?.BaseType;
        }

        public object[]? GetAttributes(bool flag)
        {
            return this.StaticClass?.GetCustomAttributes(flag);
        }

        public MethodInfo[]? GetMethods()
        {
            return this.StaticClass?.GetMethods();
        }
    }
}
