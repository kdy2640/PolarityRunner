using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public int nowCubeStage = 1;
    Cube nowCubePrefab;
    Cube nowCubeGO;
    void Start()
    {
        Initialized();
    }
    private void Initialized()
    { 
        nowCubeStage = 1;
        SetCube();
    } 
    public void Restart()
    { 
        SetCube();
    }
    public void NextStage()
    {
        nowCubeStage++;
        SetCube();
    }
    private void SetCube()
    { 
        if(nowCubeGO != null)
        {
            Destroy(nowCubeGO.gameObject);
            nowCubeGO  = null;
        }
        nowCubePrefab = Resources.Load<GameObject>($"Prefabs/Cubes/Cube{nowCubeStage}").GetComponent<Cube>();
        nowCubeGO = GameObject.Instantiate(nowCubePrefab);
        nowCubeGO.Initialize();
    }

    void Update()
    {
        
    }
}
