using UnityEngine;

public class StartPortal : MonoBehaviour
{
    GameManager manager;
    ObjectPolarity player;
    public readonly float MaxDistance = 100f;
    [SerializeField] float RotationSpeed = 3f;
    public void Initialize()
    {
        manager = GameManager.GetInstance();
        player = manager.Player; 
        player.transform.position = transform.position;
        player.transform.rotation = transform.rotation; 
    }
    private void Start()
    {
        Initialize();
    }
    void Update()
    { 
        if(player != null)
        {
            if(Vector3.Distance(transform.position,player.transform.position) > MaxDistance)
            {
                player.transform.position = transform.position;
                Rigidbody rigid = player.GetComponent<Rigidbody>();
                rigid.angularVelocity = Vector3.zero;
                rigid.linearVelocity = Vector3.zero;
            }
        }

        transform.Rotate(new Vector3(0, RotationSpeed, 0));
    }
}
