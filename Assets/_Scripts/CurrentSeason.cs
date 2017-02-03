using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSeason : MonoBehaviour {
    List<string> seasonList;
    int currentSeason = 0;

	// Use this for initialization
	void Start () {

        seasonList = new List<string>()
        {
            "Fall",
            "Winter",
            "Spring",
            "Summer"
        };

        GetComponent<Text>().text = seasonList[0];
	}
	
	public void IncrementeSeason()
    {
        if (currentSeason < 3)
        {
            currentSeason++;
        }
        else
            currentSeason = 0;
        
        GetComponent<Text>().text = seasonList[currentSeason];
    }
}
