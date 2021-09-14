using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bruteForceManager : MonoBehaviour
{

    private static bruteForceManager _instance;
    public Vector3[] playerAreavertices;

    public static bruteForceManager Instance { get { return _instance; } }

    public bool triggerDown0;
    public bool triggerDown1;
    public bool triggerUp0;
    public bool triggerUp1;
    public bool trigger0;
    public bool trigger1;
    public bool touch0;
    public bool touch1;

    public float RAxisX;

    private void Start()
    {
        float[] rates;
        Unity.XR.Oculus.Performance.TryGetAvailableDisplayRefreshRates(out rates);
        Unity.XR.Oculus.Performance.TrySetDisplayRefreshRate(90);
        float rate;
        Unity.XR.Oculus.Performance.TryGetDisplayRefreshRate(out rate);
    
    }

    private void Awake()
    {
       
            _instance = this;
        
    }

    internal bool GetTriggerTouchDown(int index)
    {
       if(index==1)
       return     OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.RTouch);
        else
        {
            return OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.LTouch);
        }
    }

    internal bool GetTriggerTouchUp(int index)
    {
        if (index == 1)
            return OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        else
        {
            return OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.LTouch);
        }
    }

    internal bool GetTriggerTouch(int index)
    {
        if (index == 1)
            return OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        else
        {
            return OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.LTouch);
        }
    }

  
    internal Vector3 GetVelocity(int controller_index)
    {
        if (controller_index == 1)
            return OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
        else
        {
            return OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
        }
    }

    internal Vector3 GetAngularVelocity(int controller_index)
    {
        if (controller_index == 1)
            return OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);
        else
        {
            return OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.LTouch);
        }

    }
    internal float GetAxis(int controller_index, int v)
    {
        if (controller_index == 1)
          return  OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        else
        {
          return  OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.LTouch);
        }
        
    }

    internal bool GetPadTouchDown()
    {
        return false;
    }

    internal bool GetPadTouchUp()
    {
        return false;
    }

    internal float GetStateRAxisX(int v)
    {
        if (v == 1)
            return OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        else
        {
            return OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.LTouch);
        }

    }
}

public class SteamVR_TrackedObject :MonoBehaviour
{

    public int index;


}

