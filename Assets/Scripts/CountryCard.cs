using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;

public class CountryCard : MonoBehaviour {

    public void initCard(JSONNode info)
    {
        Debug.Log(info.ToString());
        Text[] texts = GetComponentsInChildren<Text>();
        string title = info["name"];
        title = title.Replace(" ", "   ");
        texts[0].text = title;
        string desc = "Population: " + info["population"] + "\nCash: " + info["money"];
        //desc = desc.Replace(" ", "   ");
        texts[1].text = desc;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
