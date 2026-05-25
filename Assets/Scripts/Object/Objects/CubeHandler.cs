using UnityEngine;

public class CubeHandler : MonoBehaviour
{ 
    [SerializeField] Material MatBlue;
    [SerializeField] Material MatRed;
    [SerializeField] bool IsRed = true;
    private ObjectPolarity polar;
    private MeshRenderer render;
    private Collider collider;
    private GameManager manager;
    void Start()
    {
        manager = GameManager.GetInstance();
        polar = GetComponent<ObjectPolarity>(); 
        collider = GetComponent<Collider>();
        for (int i = 0; i < 3; i++)
        {
           Transform child = transform.GetChild(i);
            render = child.GetComponent<MeshRenderer>();
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
