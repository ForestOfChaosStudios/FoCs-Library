using System;
using ForestOfChaosLib.AdvVar.Base;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameSystemTypeLists] public class ByteListReference: AdvListReference<byte> { }

	[Serializable] public class ByteListVariable: AdvListVariable<byte, ByteListReference> { }
}