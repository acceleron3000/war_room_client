using UnityEngine;
using System.Collections;
using System.IO;
using SimpleJSON;


public class MainGame : MonoBehaviour {

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

    public int LEFTMOST_CARD = -100;
    public int CARD_SPACING = 100;
    public int CARD_Y = -80;
    public int CARD_Z = 1;
    public float CARD_SCALE = 0.7f;

    public Dictionary<System.Int32, JSONNode> rounds = new Dictionary<System.Int32, JSONNode>();

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
            card.transform.localScale = new Vector3(CARD_SCALE, CARD_SCALE, CARD_SCALE);
        }
    }

    void getCurrentActions() {
        System.Int32 round = rounds.Count;
        if (rounds.TryGetValue(round, out value)) {
            
        }
        /*"{\"actions\":[[108,204,6],[202,208,109],[201,5,106]],\"round\":-1}"*/

    }
}
