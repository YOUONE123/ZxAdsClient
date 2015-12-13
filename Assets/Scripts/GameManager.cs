using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public ViewController viewController;

    public UIViewController uiViewController;

    public UIViewController roomSelectViewController;

    public UIViewController testViewController;

    public Queue<JSONNode> eventQueue;

	// Use this for initialization
	void Start () {
        eventQueue = new Queue<JSONNode>();
        uiViewController.SetUI(roomSelectViewController);

    }
	
	// Update is called once per frame
	void Update () {
	
	}


    public void TestButton3()
    {
        //InputJson("{\"state\":0,\"type\":1,\"data\":[{\"type\":1,\"unique-card-id\":1,\"to-zone-id\":1},{\"type\":2,\"effect\":{\"unique-card-id\":1}},{\"type\":3,\"choose-type\":1,\"messages\":[\"YES\",\"NO\"]},{\"type\":3,\"choose-type\":2,\"card-ids\":[1,2]},{\"type\":3,\"choose-type\":4,\"effects\":[{\"unique-card-id\":1},{\"unique-card-id\":2}]},{\"type\":3,\"choose-type\":5,\"squares\":[1,2,3]},{\"type\":4,\"card\":{\"power\":5000}}]}");


        uiViewController.SetUI(testViewController);
    }

    public void InputJson(string jsonStr)
    {
        var json = JSONNode.Parse(jsonStr);
        ZxConst type = (ZxConst)json["type"].AsInt;
        switch (type)
        {
            case ZxConst.JSON_TYPE_EVENT:
                var nodes = json["data"].AsArray;
                foreach (JSONNode node in nodes)
                {
                    eventQueue.Enqueue(node);
                }
                break;
            default:
                break;
        }
    }

}
