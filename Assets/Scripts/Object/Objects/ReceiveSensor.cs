using UnityEngine;

public class ReceiveSensor : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotateSpeed = 90f;
    [SerializeField] float snapDistance = 0.02f;

    Rigidbody grabbedRigid;

    ObjectPolarity parent;
    Receiver receiver;
    GameObject nowGrab;
    public void Start()
    {
        receiver = transform.GetComponentInParent<Receiver>();
        parent = receiver.GetComponent<ObjectPolarity>(); 
    }
    private void Update()
    {
        if (nowGrab == null)
            return;

        Vector3 targetPos = transform.position;

        nowGrab.transform.position = Vector3.Lerp(nowGrab.transform.position, targetPos, moveSpeed * Time.deltaTime);

        nowGrab.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(nowGrab.transform.position, targetPos) < snapDistance)
        {
            nowGrab.transform.position = targetPos;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabbable"))
        {
            if (other.GetComponent<ObjectPolarity>().GetPolarity() != parent.GetPolarity()) return;

            receiver.SensorActive();

            nowGrab = other.gameObject;
            nowGrab.layer = 0;

            grabbedRigid = nowGrab.GetComponent<Rigidbody>();
            if (grabbedRigid != null)
            {
                grabbedRigid.linearVelocity = Vector3.zero;
                grabbedRigid.angularVelocity = Vector3.zero;
                grabbedRigid.isKinematic = true;
            }
        }
    }

}
