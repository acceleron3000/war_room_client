using UnityEngine;
using System.Collections;
using SimpleJSON;

var getGameDataUrl = "";

void Update() {
    updateGameData();
}

void updateGameData() {
    var www = new WWW(getGameData);
    yield www;
    JSONNode json = JSON.Parse(itemsText);
    var game : GameObject = GameObject.name("GameScript");
    game.rounds.Add(json["round"], json);
}
