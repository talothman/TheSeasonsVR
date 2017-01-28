using UnityEngine;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using VRTK;

public class GameController : MonoBehaviour {

    public GameObject earthUI;
    public GameObject farEarthUI;
    public GameObject farSunUI;
    public GameObject axisUI;
    public GameObject moonUI;
    public GameObject explinationUI;

    public GameObject earth;
    public GameObject axis;
    public GameObject moon;
    public GameObject sun;

    public GameObject progressionControllerObject;
    public GameObject cameraRig;

    public bool beginGame = false;
    bool hasBegun = false;
    public float textDisplayDelay = 5f;

    List<string> touchedObjectNames;

    // Use this for initialization
    void Start () {
        touchedObjectNames = new List<string>();
        
        // black out headset
        SteamVR_Fade.Start(Color.black, 0, true);

        earth.GetComponent<VRTK_InteractableObject>().InteractableObjectTouched += TurnEarthUIOn;
        earth.GetComponent<VRTK_InteractableObject>().InteractableObjectUntouched += TurnEarthUIOff;

        moon.GetComponent<VRTK_InteractableObject>().InteractableObjectTouched += TurnMoonUIOn;
        moon.GetComponent<VRTK_InteractableObject>().InteractableObjectUntouched += TurnMoonUIOff;

        axis.GetComponent<VRTK_InteractableObject>().InteractableObjectTouched += TurnAxisUIOn;
        axis.GetComponent<VRTK_InteractableObject>().InteractableObjectUntouched += TurnAxisUIOff;

        //progressionControllerObject.GetComponentInChildren<VRTK_InteractableObject>().InteractableObjectTouched += ZoomOut;
        progressionControllerObject.transform.Find("ForwardButton").GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += NextSeasion;
        progressionControllerObject.transform.Find("BackwardButton").GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += PreviousSeasion;
    }
	
    void TurnEarthUIOn(object sender, InteractableObjectEventArgs e)
    {
        StopCoroutine("DelayedDeactivate");
        earthUI.gameObject.SetActive(true);
        
        if (!touchedObjectNames.Contains(e.interactingObject.name))
        {
            touchedObjectNames.Add(e.interactingObject.name);
        }
        
        if(touchedObjectNames.Count == 3)
        {
            StartCoroutine(ShowProgButtons());
        }

        touchedObjectNames.Add(e.interactingObject.name);
        //print(e.interactingObject.name);
    }

    void TurnEarthUIOff(object sender, InteractableObjectEventArgs e)
    {
        StartCoroutine(DelayedDeactivate(earthUI, textDisplayDelay));
    }

    void TurnMoonUIOn(object sender, InteractableObjectEventArgs e)
    {
        moonUI.gameObject.SetActive(true);
    }

    void TurnMoonUIOff(object sender, InteractableObjectEventArgs e)
    {
        StartCoroutine(DelayedDeactivate(moonUI, textDisplayDelay));
    }

    void TurnAxisUIOn(object sender, InteractableObjectEventArgs e)
    {
        axisUI.gameObject.SetActive(true);
    }

    void TurnAxisUIOff(object sender, InteractableObjectEventArgs e)
    {
        StartCoroutine(DelayedDeactivate(axisUI, textDisplayDelay));
    }

    IEnumerator DelayedDeactivate(GameObject go, float delay)
    {
        yield return new WaitForSeconds(delay);
        go.gameObject.SetActive(false);
    }

    void ZoomOut(object sender, InteractableObjectEventArgs e)
    {
        cameraRig.GetComponent<UIFollow>().enabled = false;
        cameraRig.transform.DOMove(new Vector3(0, 45, -154), 5, false);

        farEarthUI.SetActive(true);
        farSunUI.SetActive(true);
        progressionControllerObject.SetActive(false);
        
        //VRTK_SDK_Bridge.GetControllerRightHand(true).GetComponent<VRTK_ControllerActions>().ToggleHighlightTouchpad(true, Color.white, 5f);
        // show huge earth UI
        // show time and scale control uis
    }

    void NextSeasion(object sender, InteractableObjectEventArgs e)
    {
        sun.GetComponent<Arrows>().StopAllCoroutines();
        sun.GetComponent<Arrows>().currentSeasonFloat -= 0.25f;

        if (sun.GetComponent<Arrows>().currentSeasonFloat > 0.0f)
        {
            sun.GetComponent<Arrows>().StartCoroutine(sun.GetComponent<Arrows>().StartSpinAroundAxis(sun.GetComponent<Arrows>().currentSeasonFloat)); 
        }
        else
        {
            //progressionControllerObject.transform.Find("BackwardButton").gameObject.SetActive(true);
            sun.GetComponent<Arrows>().currentSeasonFloat = 1.25f;
        }
    }

    void PreviousSeasion(object sender, InteractableObjectEventArgs e)
    {
        sun.GetComponent<Arrows>().StopAllCoroutines();
        sun.GetComponent<Arrows>().currentSeasonFloat += 0.25f;

        if (sun.GetComponent<Arrows>().currentSeasonFloat < 1.0f)
        {
            sun.GetComponent<Arrows>().StartCoroutine(sun.GetComponent<Arrows>().StartSpinAroundAxis(sun.GetComponent<Arrows>().currentSeasonFloat));
        }
        else
        {
            sun.GetComponent<Arrows>().currentSeasonFloat = -0.25f;
        }
    }

    IEnumerator ShowProgButtons()
    {
        progressionControllerObject.SetActive(true);
        yield return null;
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.S) && !hasBegun)
        {
            SteamVR_Fade.Start(Color.clear, 10, true);
            hasBegun = true;
        }
    }
}
