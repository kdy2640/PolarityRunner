using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    public enum CubeObject
    {
        StartPortal,
        EndPortal
    }
    Dictionary<CubeObject, GameObject> ObjectMaps = new Dictionary<CubeObject, GameObject>();

    public GameObject GetObject(CubeObject obj)
    {
        if (ObjectMaps.ContainsKey(obj)) return ObjectMaps[obj];
        Transform child = null;
        if (obj == CubeObject.StartPortal)
        {
            child = transform.GetComponentInChildren<StartPortal>().transform;
        }
        else if (obj == CubeObject.EndPortal)
        {
            child = transform.GetComponentInChildren<EndPortal>().transform; 
        } 

        if (child == null)
        {
            Debug.Log($"찾지 못함");
            return null;
        }

        GameObject go = child.gameObject;
        ObjectMaps[obj] = go;
        return go;
    } 
    void Awake()
    {
        GetObject(CubeObject.StartPortal);
        GetObject(CubeObject.EndPortal);
    }
    public void Initialize()
    { 
    } 
}
