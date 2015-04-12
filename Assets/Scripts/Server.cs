using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Server : MonoBehaviour
{

    string getGameDataUrl = "";

    void Update()
    {
        updateGameData();
    }

    IEnumerator updateGameData() {
    var www = new WWW(getGameDataUrl);
    yield return www;
    //JSONNode json = JSON.Parse(itemsText);
    //var game : GameObject = GameObject.name("GameScript");
    //game.rounds.Add(json["round"], json);
}
}
