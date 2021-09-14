using UnityEngine;
using System.Collections;
using Valve.VR;

public class EventManager : MonoBehaviour
{

    public delegate void TriggerDown(GameObject t);
    public static event TriggerDown OnTriggerDown;

    public delegate void TriggerUp(GameObject t);
    public static event TriggerUp OnTriggerUp;

    public delegate void TriggerStay(GameObject t);
    public static event TriggerStay StayTrigger;

    public GameObject handL;
    public GameObject handR;

    SteamVR_TrackedObject trackedObjL;
    SteamVR_TrackedObject trackedObjR;

    void Start()
    {

        trackedObjL = handL.GetComponent<SteamVR_TrackedObject>();
        trackedObjR = handR.GetComponent<SteamVR_TrackedObject>();

    }

    void FixedUpdate()
    {

        //TODO FIX THESE EVENTS
       // getTrigger(handL, trackedObjL);
       // getTrigger(handR, trackedObjR);

    }

    
    public void triggerDown()
    {
        OnTriggerDown(gameObject);
    }
   
    public void triggerUp()
    {
        OnTriggerUp(gameObject);
    }

    void getTrigger(GameObject go, SteamVR_TrackedObject tObj)
    {

        if ((int)tObj.index < 0) { return; }
        //      var device = new SteamVR_Controller();

        //if ( device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)){
        if (bruteForceManager.Instance.GetTriggerTouchDown((int)tObj.index))
        {
            if (OnTriggerDown != null) OnTriggerDown(go);
        }

        if (bruteForceManager.Instance.GetTriggerTouchUp((int)tObj.index))
        {
            if (OnTriggerUp != null) OnTriggerUp(go);
        }


        if (bruteForceManager.Instance.GetTriggerTouch((int)tObj.index))
        {
            if (StayTrigger != null) StayTrigger(go);
        }

    }



}