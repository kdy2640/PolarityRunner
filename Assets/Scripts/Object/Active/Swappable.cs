using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Swappable : Activable
{
    public Material MatOn;
    public Material MatOff;
    public List<MeshRenderer> MeshRenderers = new List<MeshRenderer>();
    public Collider TriggingCollider;
    public void Start()
    {
        TurnOff();
    }
    public override void TurnOn()
    {  
        for (int i = 0; i < MeshRenderers.Count; i++)
        {
            MeshRenderers[i].material = MatOn;
            MeshRenderers[i].GetComponent<Collider>().isTrigger = false; 
        } 
        if(TriggingCollider !=null) TriggingCollider.enabled = true;
    }

    public override void TurnOff()
    { 
        for (int i = 0; i < MeshRenderers.Count; i++)
        {
            MeshRenderers[i].material = MatOff;
            MeshRenderers[i].GetComponent<Collider>().isTrigger = true;
        }
        if (TriggingCollider != null) TriggingCollider.enabled = false;
    }
}
