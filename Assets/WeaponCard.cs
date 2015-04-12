using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;

public class WeaponCard : MonoBehaviour {

    public void initCard(JSONNode info)
    {
        Debug.Log(info.ToString());
        Text[] texts = GetComponentsInChildren<Text>();
        texts[0].text = info["name"];
        texts[1].text = info["description"];
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
