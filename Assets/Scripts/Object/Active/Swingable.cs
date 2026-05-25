using UnityEngine;

public class Swingable : Activable
{
    [SerializeField] Material MatOn;
    [SerializeField] Material MatOff;

    [SerializeField] Vector3 localMoveDirection = Vector3.right;
    [SerializeField] float moveDistance = 3f;
    [SerializeField] float transitionSpeed = 2f;
    [SerializeField] bool useLerp = true;

    [SerializeField] GameObject platformGO;

    Rigidbody platformRigid;
    MeshRenderer platformRenderer;

    Vector3 startLocalPosition;
    Vector3 endLocalPosition;

    bool isOn = false;

    private void Awake()
    {
        platformRigid = platformGO.GetComponent<Rigidbody>();
        platformRenderer = platformGO.GetComponent<MeshRenderer>();

        platformRigid.isKinematic = true;

        startLocalPosition = platformGO.transform.localPosition;
        endLocalPosition = startLocalPosition + localMoveDirection.normalized * moveDistance;
    }

    private void Start()
    {
        TurnOff();
        MoveImmediate(startLocalPosition);
    }

    private void FixedUpdate()
    {
        if (!isOn)
            return;

        float t = (Mathf.Sin(Time.time * transitionSpeed) + 1f) * 0.5f;
        Vector3 targetLocalPos = Vector3.Lerp(startLocalPosition, endLocalPosition, t);

        MoveImmediate(targetLocalPos);
    }
    public override void TurnOn()
    {
        isOn = true;

        if (platformRenderer != null) platformRenderer.material = MatOn;
    }

    public override void TurnOff()
    {
        isOn = false;

        if (platformRenderer != null) platformRenderer.material = MatOff;
    }
     

    private void MoveImmediate(Vector3 localPosition)
    {
        platformGO.transform.localPosition = localPosition;
        platformRigid.MovePosition(platformGO.transform.position);
    }
}