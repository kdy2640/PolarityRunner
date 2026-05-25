using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected static GameManager instance;
    public ObjectPolarity Player;
    public CubeManager cube;
    public static GameManager GetInstance()
    {
        if(instance == null)
        { 
            instance = GameObject.Find("GameManager").GetComponent<GameManager>();
            if(instance == null)
            {
                GameObject go = new GameObject("GameManager");
                instance = go.AddComponent<GameManager>();
            }
        }
        return instance;
    }
    private void Awake()
    {
        cube = GetComponent<CubeManager>();
        if(Player == null)
        {
            Player = GameObject.Find("Player").GetComponent<ObjectPolarity>();
        }
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
