using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Server : MonoBehaviour
{
    private string getGameDataUrl = "localhost:9292/getUpdate";

    void Update()
    {
        updateGameData();
    }

    IEnumerator updateGameData() {
        WWW www = new WWW(getGameDataUrl);
        yield return www;
        JSONNode json = JSON.Parse(itemsText);
        GameObject game = GameObject.Find("GameScript");
        game.rounds.Add(json["round"], json);
    }
}
