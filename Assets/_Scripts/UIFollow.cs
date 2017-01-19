using UnityEngine;
using System.Collections;

public class UIFollow : MonoBehaviour {
    public GameObject objectToFollow;
    public GameObject objectToLookAt;

    public Vector3 offset = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = objectToFollow.transform.position + offset;

        if (objectToLookAt != null)
            transform.LookAt(objectToLookAt.transform);
	}
}
