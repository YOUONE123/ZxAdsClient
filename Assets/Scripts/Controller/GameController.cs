using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    public ZXCardZoneView deckView;
    public ZXCardZoneView chargeView;
    public ZXCardZoneView trashView;
    public ZXCardZoneView lifeView;
    public ZXCardZoneView handView;
    public ZXCardZoneView resourceView;
    public ZXCardZoneView opDeckView;
    public ZXCardZoneView opChargeView;
    public ZXCardZoneView opTrashView;
    public ZXCardZoneView opLifeView;
    public ZXCardZoneView opHandView;
    public ZXCardZoneView opResourceView;
    
    public ZXCardZone deck;
    public ZXCardZone charge;
    public ZXCardZone trash;
    public ZXCardZone life;
    public ZXCardZone hand;
    public ZXCardZone resource;
    public ZXCardZone opDeck;
    public ZXCardZone opCharge;
    public ZXCardZone opTrash;
    public ZXCardZone opLife;
    public ZXCardZone opHand;
    public ZXCardZone opResource;

    public ZXCardZoneView square1View;
    public ZXCardZoneView square2View;
    public ZXCardZoneView square3View;
    public ZXCardZoneView square4View;
    public ZXCardZoneView square5View;
    public ZXCardZoneView square6View;
    public ZXCardZoneView square7View;
    public ZXCardZoneView square8View;
    public ZXCardZoneView square9View;
    public ZXCardZoneView temporaryView;
    public ZXCardZoneView removeView;


    public ZXCardZone square1;
    public ZXCardZone square2;
    public ZXCardZone square3;
    public ZXCardZone square4;
    public ZXCardZone square5;
    public ZXCardZone square6;
    public ZXCardZone square7;
    public ZXCardZone square8;
    public ZXCardZone square9;
    public ZXCardZone temporary;
    public ZXCardZone remove;

    public Dictionary<int, ZXCard> cards = new Dictionary<int, ZXCard>();
    public Dictionary<ZXCardZone, ZXCardZoneView> zoneViews = new Dictionary<ZXCardZone, ZXCardZoneView>();
    public Dictionary<ZXCard, ZXCardView> cardViews = new Dictionary<ZXCard, ZXCardView>();

    public GameObject cardPrefab;

    static GameController _Instance;

    public static GameController GetInstance()
    {
        return _Instance;
    }

    public GameController()
    {
        _Instance = this;
    }

    public ZXCardView GetCardView(ZXCard card)
    {
        return this.cardViews[card];
    }

    // Use this for initialization
    void Awake () {

        deck = new ZXCardZone();
        charge = new ZXCardZone();
        trash = new ZXCardZone();
        life = new ZXCardZone();
        hand = new ZXCardZone();
        resource = new ZXCardZone();
        opDeck = new ZXCardZone();
        opCharge = new ZXCardZone();
        opTrash = new ZXCardZone();
        opLife = new ZXCardZone();
        opHand = new ZXCardZone();
        opResource = new ZXCardZone();

        deckView.SetCardZone(deck);
        zoneViews.Add(deck,deckView);

        chargeView.SetCardZone(charge);
        zoneViews.Add(charge, chargeView);

        trashView.SetCardZone(trash);
        zoneViews.Add(trash, trashView);

        lifeView.SetCardZone(life);
        zoneViews.Add(life, lifeView);

        handView.SetCardZone(hand);
        zoneViews.Add(hand, handView);

        resourceView.SetCardZone(resource);
        zoneViews.Add(resource, resourceView);

        opDeckView.SetCardZone(opDeck);
        zoneViews.Add(opDeck, opDeckView);

        opChargeView.SetCardZone(opCharge);
        zoneViews.Add(opCharge, opChargeView);

        opTrashView.SetCardZone(opTrash);
        zoneViews.Add(opTrash, opTrashView);

        opLifeView.SetCardZone(opLife);
        zoneViews.Add(opLife, opLifeView);

        opHandView.SetCardZone(opHand);
        zoneViews.Add(opHand, opHandView);

        opResourceView.SetCardZone(opResource);
        zoneViews.Add(opResource, opResourceView);
        
        square1 = new ZXCardZone();
        square2 = new ZXCardZone();
        square3 = new ZXCardZone();
        square4 = new ZXCardZone();
        square5 = new ZXCardZone();
        square6 = new ZXCardZone();
        square7 = new ZXCardZone();
        square8 = new ZXCardZone();
        square9 = new ZXCardZone();
        remove = new ZXCardZone();
        temporary = new ZXCardZone();


        square1View.SetCardZone(square1);
        zoneViews.Add(square1, square1View);
        
        square2View.SetCardZone(square2);
        zoneViews.Add(square2, square2View);

        square3View.SetCardZone(square3);
        zoneViews.Add(square3, square3View);

        square4View.SetCardZone(square4);
        zoneViews.Add(square4, square4View);
        
        square5View.SetCardZone(square5);
        zoneViews.Add(square5, square5View);

        square6View.SetCardZone(square6);
        zoneViews.Add(square6, square6View);

        square7View.SetCardZone(square7);
        zoneViews.Add(square7, square7View);

        square8View.SetCardZone(square8);
        zoneViews.Add(square8, square8View);

        square9View.SetCardZone(square9);
        zoneViews.Add(square9, square9View);

        temporaryView.SetCardZone(temporary);
        zoneViews.Add(temporary, temporaryView);

        removeView.SetCardZone(remove);
        zoneViews.Add(remove, removeView);
        
        SetupCardViews();
    }

    void SetupCardViews()
    {
        for (int i = 0; i < 40; i++)
        {
            var card = new ZXCard();
            card.name = "test_cards_" + i.ToString();
            card.entityId = i;
            card.power = 1000;
            card.sleep = false;
            card.isPrivateInfo = true;
            deck.cards.Add(card);
            card.zone = deck;
            cards.Add(card.entityId, card);
            this.CreateCardView(card);
        }

        for (int i = 0; i < 40; i++)
        {
            var card = new ZXCard();
            card.name = "test_cards_" + (i + 100).ToString();
            card.entityId = i + 100;
            card.power = 1000;
            card.sleep = false;
            opDeck.cards.Add(card);
            card.zone = opDeck;
            cards.Add(card.entityId, card);
            this.CreateCardView(card);
        }
    }



    ZXCardView CreateCardView(ZXCard card)
    {
        // プレハブを取得
        GameObject prefab = GameController.GetInstance().cardPrefab;

        Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        // プレハブからインスタンスを生成
        GameObject obj = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
        // 作成したオブジェクトを子として登録
        obj.transform.parent = this.transform;
        // 座標を補正
        obj.transform.localPosition = prefab.transform.localPosition;
        obj.transform.localRotation = prefab.transform.localRotation;
        obj.transform.localScale = prefab.transform.localScale;
        //設定
        var view = obj.GetComponent<ZXCardView>();
        view.SetZXCard(card);
        //リストに追加
        this.cardViews.Add(card, view);
        return view;
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void TestButton1()
    {
        var card = deck.cards[0];
        card.zone = hand;
        hand.cards.Add(card);
        deck.cards.Remove(card);
    }
    public void TestButton2()
    {
        if(temporary.cards.Count > 0)
        {
            var card = temporary.cards[0];
            card.zone = trash;
            trash.cards.Add(card);
            temporary.cards.Remove(card);
        }
        else
        {
            var card = deck.cards[0];
            card.zone = temporary;
            temporary.cards.Add(card);
            deck.cards.Remove(card);

        }
    }
    public void TestButton3()
    {

        hand.cards[0].isPrivateInfo = !hand.cards[0].isPrivateInfo;
        hand.cards[0].sleep = !hand.cards[0].sleep;

    }
}
