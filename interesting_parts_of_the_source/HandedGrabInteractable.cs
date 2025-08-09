using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace vr_beer_prop.scripts
{
    public class HandedGrabInteractable : XRGrabInteractable
    {
        public Transform leftHandedAttachTransform;
        public Transform rightHandedAttachTransform;

        protected override void OnSelectEntering(SelectEnterEventArgs args)
        {
           

            if (args.interactorObject.handedness == InteractorHandedness.Left)
            {
                Debug.Log("left handed grab");
                attachTransform = leftHandedAttachTransform;
            }
            else if (args.interactorObject.handedness == InteractorHandedness.Right)
            {
                Debug.Log("right handed grab");
                attachTransform = rightHandedAttachTransform;
            }
            
            // if you don't call this _after_ setting the attach transform, you get fairly
            // non deterministic behavior.  The transform might be only appropriately set
            // if you pick up and put down the object with the same hand.
            base.OnSelectEntering(args);
        }
    }
}
