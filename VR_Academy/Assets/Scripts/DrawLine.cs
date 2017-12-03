using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    private LineRenderer curLine;
    private int numClicks = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.LogError("Got here.");
            GameObject go = new GameObject();
            curLine = go.AddComponent<LineRenderer>();
            curLine.SetWidth(0.1f, 0.1f);
            numClicks = 0;
        } else if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            curLine.positionCount = numClicks + 1;
            curLine.SetPosition(numClicks, trackedObj.transform.position);
            numClicks++;
        }
	}
}
