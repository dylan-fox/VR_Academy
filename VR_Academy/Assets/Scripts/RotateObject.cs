using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {
	//Rotates object as long as the touchpad is held left or right.

	public GameObject rotater;
	public SteamVR_TrackedObject trackedObj;
	public float rotationSpeed = 1f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
		if (device.GetPress (SteamVR_Controller.ButtonMask.Touchpad)) {
			Vector2 touchpad = (device.GetAxis (Valve.VR.EVRButtonId.k_EButton_Axis0));
			rotater.transform.Rotate (0f, touchpad.x  * rotationSpeed, 0f);
		}
	}
}
