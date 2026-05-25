using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRouter : MonoBehaviour
{
    CameraController camera;
    public void Start()
    {
        camera = Camera.main.GetComponent<CameraController>();
    }
    public void OnLook(InputValue val)
    { 
        camera.OnLook(val);
    }
}
