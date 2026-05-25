using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrab : MonoBehaviour
{
    [SerializeField] float grabDistance = 2f;
    [SerializeField] float throwPower = 20f;
    [SerializeField] float holdMinDistance = 0.5f;
    [SerializeField] float holdDistance = 3;
    [SerializeField] float holdInterDivisionRatio = 0.8f;
    [SerializeField] GameObject nowHoldObject;
    GameManager manager;
    Camera cam;
    Rigidbody objectRigid;
    CubeHandler cubeHandler;
    int mask;

    private void Start()
    {
        manager = GameManager.GetInstance();
        
        cam = Camera.main;
        mask = LayerMask.GetMask("Grabbable");
        manager.Player.AddPolarityListener(OnPlayerPolarityChanged);
    }
    public void Update()
    {
        if(nowHoldObject != null)
        {
            objectRigid.linearVelocity = Vector3.zero;
            objectRigid.angularVelocity = Vector3.zero;


            int exceptMask = ~LayerMask.GetMask("Player", "Grabbable");
            Vector2 mid = new Vector2(0.5f, 0.5f);
            Ray ray = cam.ViewportPointToRay(mid);
            RaycastHit hit;
            float targetDistance = holdDistance;

            if (Physics.Raycast(ray, out hit, holdDistance, exceptMask))
            {
                targetDistance = hit.distance * holdInterDivisionRatio;
            }

            targetDistance = Mathf.Clamp(targetDistance, holdMinDistance, holdDistance);

            nowHoldObject.transform.position = cam.transform.position + cam.transform.forward * targetDistance;
        }
    }

    public void OnInteract(InputValue val)
    { 
        if(nowHoldObject != null)
        { 
            nowHoldObject = null;
            objectRigid = null;
            cubeHandler = null;
            return;
        }
        Vector2 mid = new Vector2(0.5f, 0.5f);
        Ray ray = cam.ViewportPointToRay(mid); 
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,grabDistance, mask))
        {
            if (hit.collider.gameObject.GetComponent<ObjectPolarity>().GetPolarity() != manager.Player.GetPolarity()) return;
            nowHoldObject = hit.collider.gameObject;
            objectRigid = nowHoldObject.GetComponent<Rigidbody>(); 
            cubeHandler = GetComponent<CubeHandler>();  
        }
    }
    public void OnAttack(InputValue val)
    { 
        if (nowHoldObject == null)
        { 
            return;
        }

        objectRigid.AddForce(throwPower * cam.transform.forward, ForceMode.Impulse);
        nowHoldObject = null;
        objectRigid = null;
        cubeHandler = null;

    }

    public void OnPlayerPolarityChanged(Polarity playerPolar)
    {
        if(nowHoldObject == null)
        {
            return;
        }

        if (nowHoldObject.GetComponent<ObjectPolarity>().GetPolarity() != playerPolar)
        {
            nowHoldObject = null;
            objectRigid = null;
            cubeHandler = null;
        }
    }
} 
