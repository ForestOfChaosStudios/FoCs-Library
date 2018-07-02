using System;
using ForestOfChaosLib.AdvVar.Base;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameSystemTypeLists] public class IntListReference: AdvListReference<int> { }

	[Serializable] public class IntListVariable: AdvListVariable<int, IntListReference> { }
}