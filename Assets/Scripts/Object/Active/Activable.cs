using UnityEngine;

public abstract class Activable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public abstract void TurnOn();
    public abstract void TurnOff(); 
}
