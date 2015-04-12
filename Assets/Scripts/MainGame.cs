using UnityEngine;
using System.Collections;
using System.IO;
using YamlDotNet.RepresentationModel;
using SimpleJSON;


public class MainGame : MonoBehaviour {

    private const int LEFTMOST_CARD = -200;
    private const int CARD_SPACING = 200;
    private const int CARD_Y = -90;
    private const int CARD_Z = 1;

    private static MainGame myself;

    public static MainGame me
    {
        get
        {
            if(myself == null)
                myself = new MainGame();
            return myself;
        }
    }

    public WeaponCard itemCardPrefab;
    public Canvas canvas;

	// Use this for initialization
    IEnumerator Start()
    {
        /**
         * loads sample json file
         */
        
        //when we publish online, url needs to point to same domain as game
        string url = "http://google.com"; //TODO update with server URL

        //if you're testing in the editor, load file from directory:
#if UNITY_EDITOR
        Debug.Log("I'm in the editor!");
        url = "file://C:/test/actions.json";
#endif

        //load the sample json file
        WWW file = new WWW(url);
        yield return file;
        if(file.error != null)
            Debug.LogError(file.error);

        resetHand(file.text);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    /**
     * Takes a string, formatted in json, of all of the items that
     * the player has this round.
     */
    void resetHand(string itemsText)
    {
        JSONNode items = JSON.Parse(itemsText);
        for (System.Int32 i = 0; i < items["destructive"]["public"].Count; i++ )
        {
            //Debug.Log(items["destructive"]["public"][i].ToString());
            WeaponCard card = Instantiate<WeaponCard>(itemCardPrefab);
            card.transform.parent = canvas.transform;
            card.initCard(items["destructive"]["public"][i]);
            card.transform.localPosition = new Vector3(LEFTMOST_CARD + i * CARD_SPACING, CARD_Y, CARD_Z);
            card.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
