using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundControlV2 : MonoBehaviour {

	public Text letreroDebug;
	private Quaternion vectorRotacion;


	//https://forum.unity3d.com/threads/sharing-gyroscope-camera-script-ios-tested.241825/

	void Start()
	{
		Application.targetFrameRate = 60;

	}

	void Update()
	{
		ApplyGyroRotation();

		//Debug
		letreroDebug.text= "";
		//letreroDebug.text = "x.acel: " + (dir.x).ToString() + "\n";
		//letreroDebug.text += "z.acel: " + (dir.z).ToString() + "\n";
		letreroDebug.text += "Rot.x: " + transform.rotation.x.ToString() + "\n";
		letreroDebug.text += "Rot.z: " + transform.rotation.z.ToString() + "\n";

	}




	void ApplyGyroRotation()
	{
		Quaternion vectorPosicion = Input.gyro.attitude;
		vectorRotacion.x = vectorPosicion.x;
		vectorRotacion.z = vectorPosicion.z;

		transform.rotation = Input.gyro.attitude;
		//transform.Rotate( 0f, 0f, 180f, Space.Self ); // Swap "handedness" of quaternion from gyro.
		//transform.Rotate( 90f, 180f, 0f, Space.World ); // Rotate to make sense as a camera pointing out the back of your device.

	}


}
