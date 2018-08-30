using System;
using ForestOfChaosLib.AdvVar.Base;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameSystemTypeLists] public class StringListReference: AdvListReference<string> { }

	[Serializable] public class StringListVariable: AdvListVariable<string, StringListReference> { }
}
