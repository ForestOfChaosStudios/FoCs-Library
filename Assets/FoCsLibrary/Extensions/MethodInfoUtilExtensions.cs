#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: MethodInfoUtilExtensions.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Reflection;

namespace ForestOfChaos.Unity.Extensions {
    public static class MethodInfoUtil {
        public static bool IsOverride(this MethodInfo methodInfo) => methodInfo.GetBaseDefinition().DeclaringType != methodInfo.DeclaringType;

        public static bool IsMethodFromType<T>(this MethodInfo methodInfo) => methodInfo.GetBaseDefinition().DeclaringType == typeof(T);
    }
}