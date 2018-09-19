using System;
using ForestOfChaosAdvVar.Base;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameSystemTypeLists] public class StringListReference: AdvListReference<string> { }

	[Serializable] public class StringListVariable: AdvListVariable<string, StringListReference> { }
}
