using UnityEngine;

public class GlassMouth : MonoBehaviour
{
    public Glass glass;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if (other.CompareTag("FillStream"))
        {
            Debug.Log("Beer stream entered glass mouth!");
            glass.Fill();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FillStream"))
        {
            Debug.Log("Beer stream exited glass mouth!");
            glass.Interrupt();
        }
    }

}
