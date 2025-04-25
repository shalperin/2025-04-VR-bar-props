using System.Collections;
using System.Data;
using DefaultNamespace;
using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.InputSystem;

public class Glass : MonoBehaviour
{
    public GameObject LiquidScaleOrigin;
   
    private float drainSpeed = 1f;  // speed for the fill/empty animation
    private float minYScale = 0f; // lower bound for empty scale factor
    private float maxYScale = 1f; // upper bound for fill scale factor
    private bool didTipDown = false;

    private Coroutine emptyOrFillAnimation;
    
    // Update is called once per frame
    void Update()
    {
        EmptyFluidOnInvert();
    }

    public void Fill()
    {
        if (emptyOrFillAnimation != null) {StopCoroutine(emptyOrFillAnimation);}
        emptyOrFillAnimation = StartCoroutine(Q.AnimateYScaleTo(LiquidScaleOrigin, maxYScale, drainSpeed));
    }

    public void Empty()
    {
        if (emptyOrFillAnimation != null) {StopCoroutine(emptyOrFillAnimation);}
        emptyOrFillAnimation = StartCoroutine(Q.AnimateYScaleTo(LiquidScaleOrigin, minYScale, drainSpeed));
    }

    public void Interrupt()
    {
        if (emptyOrFillAnimation != null) {StopCoroutine(emptyOrFillAnimation);}
    }
    
    
    private void EmptyFluidOnInvert()
    {
        if (Q.IsTiltedPastHorizontal(this.gameObject))
        {
            didTipDown = true;
            Empty();
        }
        else
        {
            if (didTipDown)
            {
                Interrupt();
            }
            didTipDown = false;
        }
    }
}