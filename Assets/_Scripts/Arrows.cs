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

    public bool centerToCenterLineShow = false;
    public bool orbitLineShow = true;
    public bool earthRevolves = true;

    public float revolveAroundSunSpeed = 100000.0f;
    public float currentSeasonFloat = 1.0f;

	// Use this for initialization
	void Start () {

        if (centerToCenterLineShow)
        {
            line = VectorLine.SetLine3D(Color.white, transform.position, earth.transform.position);
            // closeup for earth size
            //line.SetWidth(0.015f);
            VectorLine.SetCamera3D(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>());
        }

        if (orbitLineShow)
        {
            orbitLine = new VectorLine("OrbitLine", new List<Vector3>(365), 1f, LineType.Continuous);
            // closeup for earth size
            //orbitLine = new VectorLine("OrbitLine", new List<Vector3> (365), 0.05f, LineType.Continuous);
            orbitLine.material = lineMaterial;
            orbitLine.MakeEllipse(transform.position + new Vector3(0, 0, 0), transform.up, 20f, 10f);
            orbitLine.Draw3DAuto();
        }
        
        if(earthRevolves)
            StartCoroutine(StartSpinAroundAxis(currentSeasonFloat));
    }
	
	// Update is called once per frame
	void Update () {
        if (centerToCenterLineShow)
        {
            line.points3[0] = transform.position;
            line.points3[1] = earth.transform.position;
        }
        
        if(orbitLineShow)
            orbitLine.MakeEllipse(transform.position + new Vector3(0, 0, 0), transform.up, 200f, 200f);
    }

    public IEnumerator StartSpinAroundAxis(float beginSpot)
    {
        //earth.transform.DOMove(orbitLine.GetPoint3D01(beginSpot), 0.02f, false);

        while (true)
        {
            for (float dist = beginSpot; dist > 0.0; dist += -Time.deltaTime/revolveAroundSunSpeed)
            {
                earth.transform.DOMove(orbitLine.GetPoint3D01(dist), 0.02f, false);
                yield return null;
            }
        }
        
    }
}
