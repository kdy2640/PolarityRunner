using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSwitch : MonoBehaviour
{
    public List<Activable> ActiveList = new List<Activable>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SwitchOn()
    {
        for (int i = 0; i < ActiveList.Count; i++)
        {
            ActiveList[i].TurnOn();
        }
    }

    public void SwitchOff()
    { 
        for (int i = 0; i < ActiveList.Count; i++)
        {
            ActiveList[i].TurnOff();
        }
    }
}
