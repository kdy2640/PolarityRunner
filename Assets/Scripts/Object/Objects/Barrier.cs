using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] Material BarrierBlue;
    [SerializeField] Material BarrierRed;
    [SerializeField] bool IsRed = true;
    private ObjectPolarity polar;
    private MeshRenderer render;
    private Collider collider;
    private GameManager manager;
    void Start()
    {
        manager = GameManager.GetInstance();
        polar = GetComponent<ObjectPolarity>();
        render = GetComponent<MeshRenderer>();  
        collider = GetComponent<Collider>();
        if(IsRed)
        {
            render.sharedMaterial = BarrierRed;
            polar.SetPolarity(Polarity.Red);
        }
        else
        {
            render.sharedMaterial = BarrierBlue;
            polar.SetPolarity(Polarity.Blue);
        } 
    }

    public void OnPlayerPolarityChanged(Polarity playerPolar)
    {
        if(polar.GetPolarity() != playerPolar)
        {
            collider.isTrigger = false;
        }
        else
        {
            collider.isTrigger = true;
        }
    }
    private void OnDestroy()
    {
        manager.Player.RemovePolarityListener(OnPlayerPolarityChanged);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") && !other.CompareTag("Grabbable")) return;
        ObjectPolarity otherPolar = other.GetComponent<ObjectPolarity>();
        if (otherPolar == null)
            return;

        if (otherPolar.GetPolarity() == polar.GetPolarity())
        {
            Physics.IgnoreCollision(collider, other, true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player") && !other.CompareTag("Grabbable")) return; 
        ObjectPolarity otherPolar = other.GetComponent<ObjectPolarity>();
        if (otherPolar == null)
            return;

        if (otherPolar.GetPolarity() == polar.GetPolarity())
        {
            Physics.IgnoreCollision(collider, other, true);
        }
        else
        { 
            Physics.IgnoreCollision(collider, other, false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Physics.IgnoreCollision(collider, other, false);
    }
}
