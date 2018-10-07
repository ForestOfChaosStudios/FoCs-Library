using System;
using ForestOfChaosAdvVar.Base;
using UnityEngine;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameUnityLists] public class ColorListReference: AdvListReference<Color> { }

	[Serializable] public class ColorListVariable: AdvListVariable<Color, ColorListReference> { }
}
