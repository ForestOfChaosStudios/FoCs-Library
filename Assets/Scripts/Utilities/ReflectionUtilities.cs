using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ForestOfChaosLib.Utilities
{
	public static class ReflectionUtilities
	{
		public static List<Type> GetTypesWith<TAttribute>(bool inherit) where TAttribute: Attribute
		{
			var assembliesList = AppDomain.CurrentDomain.GetAssemblies();
			var list           = new List<Type>();

			foreach(var assembly in assembliesList)
			{
				foreach(var t in assembly.GetTypes())
				{
					if(t.IsDefined(typeof(TAttribute), inherit))
					{
						if(!list.Contains(t))
							list.Add(t);
					}
				}
			}

			return list;
		}

		public static List<Type> GetTypesWith<TAttribute, TInherit>(bool inherit) where TAttribute: Attribute
		{
			var assembliesList = AppDomain.CurrentDomain.GetAssemblies();
			var list           = new List<Type>();

			foreach(var assembly in assembliesList)
			{
				foreach(var t in assembly.GetTypes())
				{
					if(t.IsDefined(typeof(TAttribute), inherit) && t.IsSubclassOf(typeof(TInherit)))
					{
						if(!list.Contains(t))
							list.Add(t);
					}
				}
			}

			return list;
		}

		public static List<Type> GetInheritedClasses<TInherit>() => GetInheritedClasses(typeof(TInherit));

		public static List<Type> GetInheritedClasses(Type TInherit)
		{
			var assembliesList = AppDomain.CurrentDomain.GetAssemblies();
			var list           = new List<Type>();

			foreach(var assembly in assembliesList)
			{
				foreach(var t in assembly.GetTypes())
				{
					if(!t.IsSubclassOf(TInherit))
						continue;

					if(!list.Contains(t))
						list.Add(t);
				}
			}

			return list;
		}

		public static object GetParentObject(string path, object obj)
		{
			var fields = path.Split('.');

			if(fields.Length == 1)
				return obj;

			var info = obj.GetType().GetField(fields[0], BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			obj = info.GetValue(obj);

			return GetParentObject(string.Join(".", fields, 1, fields.Length - 1), obj);
		}
	}
}