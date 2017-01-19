using UnityEngine;
using System.Collections;

using Vectrosity;

public class CenterOfEarth : MonoBehaviour {
    VectorLine lineThroughEarth;
    public Transform northPole;
    public Transform southPole;
	
    // Use this for initialization
	void Start () {
	    lineThroughEarth = VectorLine.SetLine3D(Color.white, northPole.position, southPole.position);
        lineThroughEarth.lineWidth = 0.009f;
        VectorLine.SetCamera3D(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>());
    }
	
	// Update is called once per frame
	void Update () {
        
        lineThroughEarth.points3[0] = northPole.position;
        lineThroughEarth.points3[1] = southPole.position;
    }
}
