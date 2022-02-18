#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: ReflectionUtilities.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ForestOfChaos.Unity.Utilities {
    public static class ReflectionUtilities {
        public static List<Type> GetTypesWith<TAttribute>(bool inherit) where TAttribute: Attribute {
            var assembliesList = AppDomain.CurrentDomain.GetAssemblies();
            var list           = new List<Type>();

            foreach (var assembly in assembliesList) {
                foreach (var t in assembly.GetTypes()) {
                    if (t.IsDefined(typeof(TAttribute), inherit)) {
                        if (!list.Contains(t))
                            list.Add(t);
                    }
                }
            }

            return list;
        }

        public static List<Type> GetTypesWith<TAttribute, TInherit>(bool inherit) where TAttribute: Attribute {
            var assembliesList = AppDomain.CurrentDomain.GetAssemblies();
            var list           = new List<Type>();

            foreach (var assembly in assembliesList) {
                foreach (var t in assembly.GetTypes()) {
                    if (t.IsDefined(typeof(TAttribute), inherit) && t.IsSubclassOf(typeof(TInherit))) {
                        if (!list.Contains(t))
                            list.Add(t);
                    }
                }
            }

            return list;
        }

        public static List<Type> GetInheritedClasses<TInherit>() => GetInheritedClasses(typeof(TInherit));

        public static List<Type> GetInheritedClasses(Type TInherit) {
            var assembliesList = AppDomain.CurrentDomain.GetAssemblies();
            var list           = new List<Type>();

            foreach (var assembly in assembliesList) {
                foreach (var t in assembly.GetTypes()) {
                    if (!t.IsSubclassOf(TInherit))
                        continue;

                    if (!list.Contains(t))
                        list.Add(t);
                }
            }

            return list;
        }

        public static object GetParentObject(string path, object obj) {
            /*
            var fields = path.Split('.');

            if (fields.Length == 1)
                return obj;

            var info = obj.GetType().GetField(fields[0], BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            obj = info.GetValue(obj);

            return GetParentObject(string.Join(".", fields, 1, fields.Length - 1), obj);
             */
            //Replaced recursive call with loop
            while (true) {
                var fields = path.Split('.');

                if (fields.Length == 1)
                    return obj;

                var info = obj.GetType().GetField(fields[0], BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                obj = info.GetValue(obj);

                path = string.Join(".", fields, 1, fields.Length - 1);
            }
        }

        public static string ToGenericTypeString(this Type type, bool fullName = false) {
            if (!type.IsGenericType)
                return fullName? type.FullName : type.Name;

            var retType = new StringBuilder();

            var parentType = fullName? type.FullName.Split('`') : type.Name.Split('`');
            // We will build the type here.
            var arguments = type.GetGenericArguments();

            var argList = new StringBuilder();

            foreach (var t in arguments) {
                // Let's make sure we get the argument list.
                var arg = t.ToGenericTypeString(fullName);

                if (argList.Length > 0)
                    argList.AppendFormat(", {0}", arg);
                else
                    argList.Append(arg);
            }

            if (argList.Length > 0)
                retType.AppendFormat("{0}<{1}>", parentType[0], argList);

            return retType.ToString();
        }
    }
}