using UnityEngine;

public class EndPortal : MonoBehaviour
{
    private GameManager manager;

    [SerializeField] float RotationSpeed = 3f;
    private void Start()
    {
        manager = GameManager.GetInstance(); 
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            manager.cube.NextStage();
        } 
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, RotationSpeed, 0));

    }
}
