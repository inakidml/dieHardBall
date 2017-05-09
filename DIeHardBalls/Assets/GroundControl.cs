using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour {
	public float velocidad;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (-moveVertical, 0.0f,- moveHorizontal);
		transform.Rotate (movement);
		/*float rotacionActualX = transform.rotation.x;//valor de la rotación tomada del objeto 
		float rotacionActualZ = transform.rotation.z;
		float movimientoXAhora = Input.acceleration.x;//valor de la rotación por el acelerometro
		float movimientoZAhora = Input.acceleration.y;

		if (movimientoZAhora > 0) {//si la rotación es positiva
			if (movimientoZAhora < movimientoZAnterior) {
				rotacionActualZ -= movimientoZAhora * multiplicadorRotacion; 
			} else {
				rotacionActualZ += movimientoZAhora * multiplicadorRotacion; 
			}

		} else {//si la rotación es negativa
			if (movimientoZAhora < movimientoZAnterior) {
				rotacionActualZ += movimientoZAhora * multiplicadorRotacion; 
			} else {
				rotacionActualZ -= movimientoZAhora * multiplicadorRotacion; 
			}
		}

		if (movimientoXAhora > 0) {//si la rotación es positiva
			if (movimientoXAhora < movimientoXAnterior) {
				rotacionActualX -= movimientoXAhora * multiplicadorRotacion; 
			} else {
				rotacionActualX += movimientoXAhora * multiplicadorRotacion; 
			}

		} else {//si la rotación es negativa
			if (movimientoXAhora < movimientoXAnterior) {
				rotacionActualX += movimientoXAhora * multiplicadorRotacion; 
			} else {
				rotacionActualX -= movimientoXAhora * multiplicadorRotacion; 
			}
		}

		movimientoXAnterior = movimientoXAhora;
		movimientoZAnterior = movimientoZAhora;

		Vector3 movimientoAcelerometro = new Vector3 (-rotacionActualX, 0, -rotacionActualZ);
		transform.Rotate (movimientoAcelerometro);
*/
		Vector3 dir = Vector3.zero;
		dir.x = Input.acceleration.y;
		dir.z = -Input.acceleration.x;
		if (dir.sqrMagnitude > 1) {
			dir.Normalize ();
		}
		dir *= Time.deltaTime;
		transform.Rotate (dir * velocidad);

		transform.Rotate (movement);





	}
}
