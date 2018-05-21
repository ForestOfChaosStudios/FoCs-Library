using System;
using System.Collections.Generic;

namespace ForestOfChaosLib.Utilities
{
	public static class ReflectionUtilities
	{
		public static List<Type> GetTypesWith<TAttribute>(bool inherit)
			where TAttribute: Attribute
		{
			var assembliesList = AppDomain.CurrentDomain.GetAssemblies();
			var list = new List<Type>();

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

		public static List<Type> GetTypesWith<TAttribute, TInherit>(bool inherit)
			where TAttribute: Attribute
		{
			var assembliesList = AppDomain.CurrentDomain.GetAssemblies();

			var list = new List<Type>();

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

		public static List<Type> GetInheritedClasses<TInherit>()
			where TInherit: class
		{
			var assembliesList = AppDomain.CurrentDomain.GetAssemblies();

			var list = new List<Type>();

			foreach(var assembly in assembliesList)
			{
				foreach(var t in assembly.GetTypes())
				{
					if(t.IsSubclassOf(typeof(TInherit)))
					{
						if(!list.Contains(t))
							list.Add(t);
					}
				}
			}
			return list;
		}
	}
}