using UnityEngine;
using System.Collections;

public class UIFollow : MonoBehaviour {
    public GameObject objectToFollow;
    public GameObject objectToLookAt;

    public Vector3 offset = Vector3.zero;
	
	// Update is called once per frame
	void Update () {

        if (objectToFollow != null)
            transform.position = objectToFollow.transform.position + offset;

        if (objectToLookAt != null)
            transform.LookAt(objectToLookAt.transform);
	}
}
