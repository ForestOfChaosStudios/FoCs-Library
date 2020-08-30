#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.AdvVar
//       File: AddToRendererRunTimeSet.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:47 AM
#endregion


using ForestOfChaosLibrary;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/RunTime/" + "Add Renderer RunTime Ref")]
    public class AddToRendererRunTimeSet: BaseAddToRunTimeSet<Renderer, RendererRunTimeList> {
        [SerializeField]
        private Renderer _renderer;

        public Renderer Renderer {
            get => _renderer ?? (_renderer = GetComponent<Renderer>());
            set => _renderer = value;
        }

        public override Renderer Value => Renderer;
    }
}