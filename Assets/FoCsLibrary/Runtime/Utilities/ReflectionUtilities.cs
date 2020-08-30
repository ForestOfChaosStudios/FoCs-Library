#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: ReflectionUtilities.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System;
using System.Collections.Generic;
using System.Reflection;

namespace ForestOfChaosLibrary.Utilities {
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
            var fields = path.Split('.');

            if (fields.Length == 1)
                return obj;

            var info = obj.GetType().GetField(fields[0], BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            obj = info.GetValue(obj);

            return GetParentObject(string.Join(".", fields, 1, fields.Length - 1), obj);
        }
    }
}