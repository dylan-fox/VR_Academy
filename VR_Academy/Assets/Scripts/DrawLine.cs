using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
	public float lineThickness = 0.01f;
	public ColorManager cm;
	//public Color newColor;
	public Material newMat;
	public GameObject parentObject;


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
			go.transform.SetParent (parentObject.transform);
            curLine = go.AddComponent<LineRenderer>();
			curLine.material = newMat;
			curLine.material.color = cm.color;
			curLine.SetWidth(lineThickness, lineThickness);
			curLine.useWorldSpace = false;
            numClicks = 0;

        } else if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            curLine.positionCount = numClicks + 1;
            curLine.SetPosition(numClicks, trackedObj.transform.position);
            numClicks++;
        }

		//DISABLE ANY LINE THAT COLLIDES WITH THE CONTROLLER IF THE APP MENU BUTTON IS HELD
		if (device.GetTouch (SteamVR_Controller.ButtonMask.ApplicationMenu)) {
			//need to add colliders and tags to the lines as they're generated.
		}
	}
}
