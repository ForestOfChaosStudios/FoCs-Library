using System;
using ForestOfChaosAdvVar.Base;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameSystemTypeLists] public class ByteListReference: AdvListReference<byte> { }

	[Serializable] public class ByteListVariable: AdvListVariable<byte, ByteListReference> { }
}
