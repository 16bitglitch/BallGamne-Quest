using UnityEngine;
using System.Collections;


public class controllerInfo : MonoBehaviour
{

    public int triggerDown;
    public int thumbDown;
    public Vector2 thumbPosition;
    public Vector2 oThumbPosition;
    public Vector2 thumbVelocity;
    public float sliderX;
    public float sliderY;

    public Vector3 position;
    public Vector3 velocity;
    public Vector3 angularVelocity;

    public float triggerVal;

    //added
    public int controller_index;


    SteamVR_TrackedObject trackedObj;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        sliderX = 0;
        sliderY = 0;
    }

    void FixedUpdate()
    {


        // if (SteamVR_Controller.GetTouchDown(SteamVR_Controller.Trigger)){
        if (bruteForceManager.Instance.GetTriggerTouchDown(controller_index))
        {
            triggerDown = 1;
        }

        //if (SteamVR_Controller.GetTouchUp(SteamVR_Controller.Trigger)){
        if (bruteForceManager.Instance.GetTriggerTouchUp(controller_index))
        {
            triggerDown = 0;
        }

        position = transform.position;
        //velocity = SteamVR_Controller.velocity;
        velocity = bruteForceManager.Instance.GetVelocity(controller_index);
        // angularVelocity = SteamVR_Controller.angularVelocity;
        angularVelocity = bruteForceManager.Instance.GetAngularVelocity(controller_index);
        oThumbPosition = thumbPosition;
        // thumbPosition = SteamVR_Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);
        thumbPosition =Vector2.zero;


        // if (SteamVR_Controller.GetTouchDown(SteamVR_Controller.Touchpad)){
        if (bruteForceManager.Instance.GetPadTouchDown())
        {
            thumbDown = 1;
        }
        else if (bruteForceManager.Instance.GetPadTouchUp())
        {
            thumbDown = 0;
            //      print( sliderX );
        }

        if (thumbDown == 1)
        {
            thumbVelocity = thumbPosition - oThumbPosition;
            sliderX += thumbVelocity.x;
            sliderY += thumbVelocity.y;
        }
        else
        {
            thumbVelocity = new Vector2(0, 0);
        }


        
        //triggerVal = SteamVR_Controller.GetStateRAxisX(1);
        triggerVal= bruteForceManager.Instance.GetStateRAxisX(controller_index);
        //print( axis.x );

    }


}
