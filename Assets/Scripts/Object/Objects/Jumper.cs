using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] float JumpPower = 30f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Grabbable"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.AddForce(transform.parent.transform.up * JumpPower,ForceMode.Impulse);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Grabbable"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.AddForce(transform.parent.transform.up * JumpPower, ForceMode.Impulse);
        }
    }
}
