using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, ~0, QueryTriggerInteraction.Collide))
            {
                if (hit.collider.CompareTag("FillTrigger"))
                {
                    Debug.Log("Clicked on 'fill' trigger ");
                    hit.collider.GetComponentInParent<Glass>().Fill();
                }
                else if (hit.collider.CompareTag("EmptyTrigger"))
                {
                    Debug.Log("Clicked on 'empty' trigger ");
                    hit.collider.GetComponentInParent<Glass>().Empty();
                }
                else if (hit.collider.CompareTag("InterruptFillOrEmpty"))
                {
                    Debug.Log("Clicked on 'empty' trigger ");
                    hit.collider.GetComponentInParent<Glass>().Interrupt();
                }
            }
        }
    }
}
