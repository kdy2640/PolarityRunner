using UnityEngine;

public class Receiver : MonoBehaviour
{
    [SerializeField] Material MatBlue;
    [SerializeField] Material MatRed; 
    [SerializeField] bool IsRed = true;
    private ObjectPolarity polar;
    private MeshRenderer render; 
    private GameManager manager;
    private ActiveSwitch active;
    void Start()
    {
        manager = GameManager.GetInstance();
        polar = GetComponent<ObjectPolarity>();
        render = transform.Find("HighLight").GetComponent<MeshRenderer>(); 
        active = GetComponent<ActiveSwitch>();
        if (IsRed)
        {
            render.sharedMaterial = MatRed;
            polar.SetPolarity(Polarity.Red);
        }
        else
        {
            render.sharedMaterial = MatBlue;
            polar.SetPolarity(Polarity.Blue);
        } 
    }

    public void SensorActive()
    {
        active.SwitchOn();
    }
     
}
