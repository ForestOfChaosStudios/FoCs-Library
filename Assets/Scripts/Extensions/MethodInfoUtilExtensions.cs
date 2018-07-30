using System.Reflection;

namespace ForestOfChaosLib.Extensions
{
	public static class MethodInfoUtil
	{
		public static bool IsOverride(this MethodInfo methodInfo)
		{
			return methodInfo.GetBaseDefinition().DeclaringType != methodInfo.DeclaringType;
		}

		public static bool IsMethodFromType<T>(this MethodInfo methodInfo)
		{
			return methodInfo.GetBaseDefinition().DeclaringType == typeof(T);
		}
	}
}
