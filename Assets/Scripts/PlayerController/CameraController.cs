using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject Player;
    GameObject CameraRig;

    [SerializeField] float VerticalMouseSenesitive = 1f;
    [SerializeField] float HorizontalMouseSenesitive = 1f;

    [SerializeField] float rotationLerpPower = 0.3f;
    [SerializeField] float positionLerpPower = 0.3f;
    [SerializeField] float LimitY = 75f;

    float diffX = 0f;
    float diffY = 0f;

    float targetDegreeX = 0f;
    float targetDegreeY = 0f;

    float currentDegreeX = 0f;
    float currentDegreeY = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = -1;

        targetDegreeX = Player.transform.localEulerAngles.y;
        currentDegreeX = targetDegreeX;

        targetDegreeY = 0f;
        currentDegreeY = 0f;
        CameraRig = Player.transform.GetComponentInChildren<CameraRouter>().gameObject;
    }

    public void LateUpdate()
    {
        targetDegreeX += diffX;
        targetDegreeY = Mathf.Clamp(targetDegreeY - diffY, -LimitY, LimitY);

        float t = Mathf.Clamp01(rotationLerpPower);
         
        currentDegreeX = Mathf.LerpAngle(currentDegreeX, targetDegreeX, t);
        currentDegreeY = Mathf.Lerp(currentDegreeY, targetDegreeY, t);
         
        transform.localRotation = Quaternion.Euler(currentDegreeY, currentDegreeX, 0f);
        transform.position = Vector3.Lerp(transform.position,CameraRig.transform.position, positionLerpPower);
    }

    public void OnLook(InputValue val)
    {
        Vector2 vec = val.Get<Vector2>();

        diffX = vec.x * HorizontalMouseSenesitive;
        diffY = vec.y * VerticalMouseSenesitive;
    }
     
}
