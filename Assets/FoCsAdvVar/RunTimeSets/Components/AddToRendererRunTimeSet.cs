#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AddToRendererRunTimeSet.cs
//    Created: 2020/10/09
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/RunTime/" + "Add Renderer RunTime Ref")]
    public class AddToRendererRunTimeSet: BaseAddToRunTimeSet<Renderer> {
        [SerializeField]
        private Renderer _renderer;

        public Renderer Renderer {
            get => _renderer != null? _renderer : _renderer = GetComponent<Renderer>();
            set => _renderer = value;
        }

        public override Renderer Value => Renderer;
    }
}