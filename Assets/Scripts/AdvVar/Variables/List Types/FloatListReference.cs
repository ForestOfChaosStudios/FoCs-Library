using System;
using ForestOfChaosLib.AdvVar.Base;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameSystemTypeLists] public class FloatListReference: AdvListReference<float> { }

	[Serializable] public class FloatListVariable: AdvListVariable<float, FloatListReference> { }
}
