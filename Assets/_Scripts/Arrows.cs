using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Vectrosity;

public class Arrows : MonoBehaviour {
    public GameObject earth;
    VectorLine line;
    VectorLine orbitLine;
    public Material lineMaterial;

	// Use this for initialization
	void Start () {
        
        line = VectorLine.SetLine3D(Color.white, transform.position, earth.transform.position);
        // closeup for earth size
        //line.SetWidth(0.015f);
        VectorLine.SetCamera3D(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>());

        orbitLine = new VectorLine("OrbitLine", new List<Vector3>(365), 1f, LineType.Continuous);
        // closeup for earth size
        //orbitLine = new VectorLine("OrbitLine", new List<Vector3> (365), 0.05f, LineType.Continuous);
        orbitLine.material = lineMaterial;
        orbitLine.MakeEllipse(transform.position + new Vector3(0, 0, 0), transform.up, 20f, 10f);
        orbitLine.Draw3DAuto();

        StartCoroutine(SpinAroundAxis());
    }
	
	// Update is called once per frame
	void Update () {
        line.points3[0] = transform.position;
        line.points3[1] = earth.transform.position;
        orbitLine.MakeEllipse(transform.position + new Vector3(0, 0, 0), transform.up, 118f, 118f);
    }

    IEnumerator SpinAroundAxis()
    {
        while (true)
        {
            for (float dist = 1.0f; dist > 0.0; dist += -Time.deltaTime/100000)
            {
                earth.transform.DOMove(orbitLine.GetPoint3D01(dist), 0.02f, false);
                yield return null;
            }
        }
        
    }
}
