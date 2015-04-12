using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;

public class WeaponCard : MonoBehaviour {

    public CountryCard attacking;

    public void initCard(JSONNode info)
    {
        Debug.Log(info.ToString());
        Text[] texts = GetComponentsInChildren<Text>();
        string title = info["name"];
        title = title.Replace(" ", "   ");
        texts[0].text = title;
        string desc = info["description"] + "\n<color=#cc0000><size=15>Power: " + info["power"] + "</size></color>\n<color=#111111>Targets: " + info["target"] + "</color>";
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
