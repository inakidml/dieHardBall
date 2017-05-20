using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundControlV2 : MonoBehaviour
{

	public Text letreroDebug;
	private Quaternion vectorRotacion;

	private Gyroscope gyro;

	private Quaternion initialRotation;
	private Quaternion gyroInitialRotation;



	//https://forum.unity3d.com/threads/sharing-gyroscope-camera-script-ios-tested.241825/

	void Start ()
	{
		//Application.targetFrameRate = 60;
		//para que funcione en el Unity remote
		if (SystemInfo.supportsGyroscope) {
			gyro = Input.gyro;
			gyro.enabled = true;
		}

		initialRotation = transform.rotation; 
		gyroInitialRotation = Quaternion.Inverse (Input.gyro.attitude);

	

	}

	void Update ()
	{
		ApplyGyroRotation ();

		//Debug
		letreroDebug.text = "";
		//letreroDebug.text = "x.acel: " + (dir.x).ToString() + "\n";
		//letreroDebug.text += "z.acel: " + (dir.z).ToString() + "\n";
		letreroDebug.text += "Rot.x: " + transform.rotation.x.ToString () + "\n";
		letreroDebug.text += "Rot.z: " + transform.rotation.z.ToString () + "\n";

	}




	void ApplyGyroRotation ()
	{
		//http://answers.unity3d.com/questions/289184/gyro-quaternion-offset.html
		Quaternion offsetRotation = gyroInitialRotation * Input.gyro.attitude;
	
		transform.rotation = initialRotation * GyroToUnity (offsetRotation);
	}

	//https://docs.unity3d.com/ScriptReference/Gyroscope.html
	// The Gyroscope is right-handed.  Unity is left handed.
	// Make the necessary change to the camera.
	Quaternion GyroToUnity (Quaternion q)
	{
		
		//Quaternion iosQuat = new Quaternion (q.x, q.y, -q.z, -q.w);
		Quaternion iosQuat = new Quaternion (q.x, 0, q.y, -q.w);//Anulo rotación horizontal
																//según el objeto, 0 y q.y se intercambian 
		return iosQuat;

	}

}
