using System;
using ForestOfChaosLib.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameUnityLists] public class ColorListReference: AdvListReference<Color> { }

	[Serializable] public class ColorListVariable: AdvListVariable<Color, ColorListReference> { }
}
