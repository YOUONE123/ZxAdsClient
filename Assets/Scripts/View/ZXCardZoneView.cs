using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZXCardZoneView : MonoBehaviour {

	public ZXCardZone cardZone;

    public ZXCardZone viewingCardZone;

    public bool lineUp = false;

    public float lineUpWidth = 0.1f;

    public float lineUpCardThickness = 0.0001f;

    public void SetCardZone(ZXCardZone cardZone)
    {
        this.cardZone = cardZone;
    }

	// Use this for initialization
	void Start ()
    {
        viewingCardZone = new ZXCardZone(cardZone);
        for(int i = 0; i < viewingCardZone.cards.Count; i++)
        {
            var cardView = ViewController.GetInstance().GetCardView(cardZone.cards[i]);
            cardView.gameObject.transform.parent = this.gameObject.transform;
            cardView.gameObject.transform.position = this.GetCardViewPosition(i);
            cardView.gameObject.transform.rotation = this.gameObject.transform.rotation;
        }
    }

    // Update is called once per frame
    void Update () {
        UpdateZone();
    }


    public void UpdateZone()
    {
        if (viewingCardZone.cards.Count != cardZone.cards.Count && this.lineUp)
        {
            for (int i = 0; i < cardZone.cards.Count; i++)
            {
                //描画
                this.UpdateCardView(i);
            }
        }
        else
        {
            for (int i = 0; i < cardZone.cards.Count; i++)
            {
                //描画すべきカードを検知
                if (viewingCardZone.cards.Count <= i || cardZone.cards[i] != viewingCardZone.cards[i])
                {
                    //描画
                    this.UpdateCardView(i);
                }

            }
        }

        viewingCardZone.cards.Clear();
        viewingCardZone.cards.AddRange(this.cardZone.cards);
    }

    public void UpdateCardView(int index)
    {
        //描画
        var cardView = ViewController.GetInstance().GetCardView(cardZone.cards[index]);
        cardView.gameObject.transform.parent = this.gameObject.transform;
        iTween.MoveTo(cardView.gameObject, iTween.Hash("position", this.GetCardViewPosition(index), "time", 0.5f));
        iTween.RotateTo(cardView.gameObject, iTween.Hash("rotation", this.gameObject.transform.eulerAngles, "time", 0.5f));
    }

    Vector3 GetCardViewPosition(int cardIndex)
    {
        Vector3 localPos = Vector3.zero;

        if (this.lineUp)
        {
            //Y
            localPos = new Vector3(localPos.x, localPos.y, localPos.z - (this.lineUpCardThickness * cardIndex));

            float cardWidth = ZXCardView.CARD_WIDTH;
            float boxWidth = this.lineUpWidth;
            int cardNum = this.cardZone.cards.Count;

            if (cardWidth * cardNum < boxWidth)
            {
                //X
                float cardLocalPos = cardWidth * cardIndex;
                float cardListWidth = cardWidth * (cardNum - 1);
                localPos = new Vector3(localPos.x - (cardListWidth / 2) + cardLocalPos, localPos.y, localPos.z);
            }
            else
            {
                //X
                float cardListStartPos = 0 - (boxWidth / 2) + (cardWidth / 2);
                float cardListEndPos = 0 + (boxWidth / 2) - (cardWidth / 2);
                float cardListWidth = cardListEndPos - cardListStartPos;
                float cardDistance = cardListWidth / (cardNum - 1);
                localPos = new Vector3(localPos.x + cardListStartPos + (cardDistance * cardIndex), localPos.y, localPos.z);
            }
        }
        else
        {
            //Y
            localPos = new Vector3(localPos.x, localPos.y, localPos.z - (ZXCardView.CARD_THICKNESS * cardIndex));
        }

        Vector3 pos = this.gameObject.transform.position + this.gameObject.transform.TransformVector(localPos);

        return pos;
    }
}
