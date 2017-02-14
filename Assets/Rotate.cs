using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    float RotateSpeedAlongX = 0.0f;
    public float RotateSpeedAlongY = 10.0f;
    float RotateSpeedAlongZ = 0.0f;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * Time.deltaTime * RotateSpeedAlongY);
        transform.Rotate(Vector3.forward * Time.deltaTime * RotateSpeedAlongZ);
        transform.Rotate(Vector3.right * Time.deltaTime * RotateSpeedAlongX);
    }
}
