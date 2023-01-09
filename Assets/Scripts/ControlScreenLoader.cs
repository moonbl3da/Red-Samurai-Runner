using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScreenLoader : MonoBehaviour
{   
    public bool isControlScreenActive = false;
    public GameObject controlScreen;
    
    public void setControlScreenOn()
    {
        if(!isControlScreenActive)
        {
            controlScreen.SetActive(true);
            isControlScreenActive = true;
        }
    }

    public void setControlScreenOff()
    {
        if(isControlScreenActive)
        {
            controlScreen.SetActive(false);
            isControlScreenActive = false;
        }
    }
}
