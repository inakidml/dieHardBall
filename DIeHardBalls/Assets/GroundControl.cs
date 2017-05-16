using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundControl : MonoBehaviour {
	public float velocidad;
	public Text letreroDebug;
	private Vector3 vectorAnterior;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (-moveVertical, 0.0f,- moveHorizontal);
		transform.Rotate (movement);

		float movimientoXAhora = Input.acceleration.y;//valores del acelerometro
		float movimientoZAhora = Input.acceleration.x;

		if (movimientoZAhora > 0) {//si la rotación es positiva
			if (movimientoZAhora < vectorAnterior.z) {
				movimientoZAhora = -movimientoZAhora; 
			}

		} else {//si la rotación es negativa
			if (movimientoZAhora < vectorAnterior.z) {
				
			} else {
				movimientoZAhora = -movimientoZAhora ; 
			}
		}

		if (movimientoXAhora > 0) {//si la rotación es positiva
			if (movimientoXAhora < vectorAnterior.x) {
				movimientoXAhora = -movimientoXAhora; 
			}

		} else {//si la rotación es negativa
			if (movimientoXAhora < vectorAnterior.x) {

			} else {
				movimientoXAhora = -movimientoXAhora ; 
			}
		}
			

		Vector3 dir = Vector3.zero;
		//dir.x = Input.acceleration.y;
		//dir.z = -Input.acceleration.x;

		dir.x= movimientoXAhora;
		dir.z = movimientoZAhora;

		if (dir.sqrMagnitude > 1) {
			dir.Normalize ();
		}

		vectorAnterior = dir;


		//Debug
		letreroDebug.text= "";
		letreroDebug.text = "x.acel: " + (dir.x).ToString() + "\n";
		letreroDebug.text += "z.acel: " + (dir.z).ToString() + "\n";
		letreroDebug.text += "Rot.x: " + transform.rotation.x.ToString() + "\n";
		letreroDebug.text += "Rot.z: " + transform.rotation.z.ToString() + "\n";

		dir *= Time.deltaTime;
		transform.Rotate (dir * velocidad);






	}
}
