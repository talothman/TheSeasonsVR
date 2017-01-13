using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Vectrosity;

public class Arrows : MonoBehaviour {
    public GameObject earth;
    VectorLine line;
    VectorLine orbitLine;
    public Material lineMaterial;

	// Use this for initialization
	void Start () {
        
        line = VectorLine.SetLine3D(Color.white, transform.position, earth.transform.position);
        VectorLine.SetCamera3D(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>());

        orbitLine = new VectorLine("OrbitLine", new List<Vector3> (150), 1.0f, LineType.Continuous);
        orbitLine.material = lineMaterial;
        orbitLine.MakeEllipse(transform.position + new Vector3(-3, 0, 0), transform.up, 20f, 10f);
        orbitLine.Draw3DAuto();

        StartCoroutine(SpinAroundAxis());
    }
	
	// Update is called once per frame
	void Update () {
        line.points3[0] = transform.position;
        line.points3[1] = earth.transform.position;
        orbitLine.MakeEllipse(transform.position + new Vector3(-3, 0, 0), transform.up, 20f, 10f);
    }

    IEnumerator SpinAroundAxis()
    {
        while (true)
        {
            for (float dist = 1.0f; dist > 0.0; dist += -Time.deltaTime/10)
            {
                earth.transform.position = orbitLine.GetPoint3D01(dist);
                yield return null;
            }
        }
        
    }
}
