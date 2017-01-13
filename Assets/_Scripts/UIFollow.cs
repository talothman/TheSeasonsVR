using UnityEngine;
using System.Collections;

public class UIFollow : MonoBehaviour {
    public GameObject objectToFollow;
    public GameObject objectToLookAt;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = objectToFollow.transform.position;
        //transform.LookAt(objectToLookAt.transform);
	}
}
