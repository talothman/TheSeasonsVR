using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class GameController : MonoBehaviour {
    public GameObject earthUI;
    public GameObject moonUI;
    public GameObject explinationUI;

    public GameObject earth;
    public GameObject moon;
    public GameObject sun;

    private string[] explanationArrayTexts = { "Notice that Earth is a bit tilted.", "You can tell by observing the line through it's axis. It's not straight.", "This is what it would look like if it wasn't tilted.",
                                                "Let's return the earth to it's original axis tilt, 22.5 degrees.", "Look this way!"};
	// Use this for initialization
	void Start () {
        StartCoroutine(pauseEarthUI());
        StartCoroutine(pauseMoonUI());
    }
	
    IEnumerator pauseEarthUI()
    {
        yield return new WaitForSeconds(5);
        earthUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        earthUI.gameObject.SetActive(false);
    }

    IEnumerator pauseMoonUI()
    {
        yield return new WaitForSeconds(10);
        moonUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        moonUI.gameObject.SetActive(false);

        explinationUI.GetComponentInChildren<Text>().text = explanationArrayTexts[0];
        explinationUI.GetComponentInChildren<Text>().resizeTextForBestFit = true;
        explinationUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        explinationUI.GetComponentInChildren<Text>().text = explanationArrayTexts[1];
        yield return new WaitForSeconds(5);

        explinationUI.GetComponentInChildren<Text>().text = explanationArrayTexts[2];
        earth.transform.DORotate(Vector3.zero, 5f, RotateMode.Fast);
        yield return new WaitForSeconds(10);
        explinationUI.GetComponentInChildren<Text>().text = explanationArrayTexts[3];
        earth.transform.DORotate(new Vector3(0,0,22.5f), 5f, RotateMode.Fast);

        yield return new WaitForSeconds(5);
        explinationUI.GetComponentInChildren<Text>().text = explanationArrayTexts[4];
        explinationUI.transform.Find("Image").gameObject.SetActive(true);
        yield return new WaitForSeconds(5);

    }

    // Update is called once per frame
    void Update () {
	
	}
}
