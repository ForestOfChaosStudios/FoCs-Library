using System;
using ForestOfChaosAdvVar.Base;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameSystemTypeLists] public class FloatListReference: AdvListReference<float> { }

	[Serializable] public class FloatListVariable: AdvListVariable<float, FloatListReference> { }
}
