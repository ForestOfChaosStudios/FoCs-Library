#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: MethodInfoUtilExtensions.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System.Reflection;

namespace ForestOfChaosLibrary.Extensions {
    public static class MethodInfoUtil {
        public static bool IsOverride(this MethodInfo methodInfo) => methodInfo.GetBaseDefinition().DeclaringType != methodInfo.DeclaringType;

        public static bool IsMethodFromType<T>(this MethodInfo methodInfo) => methodInfo.GetBaseDefinition().DeclaringType == typeof(T);
    }
}