using UnityEngine;
using System.Collections;

public class ZXCardView : MonoBehaviour {


    public const float CARD_WIDTH = 0.063f;
    public const float CARD_HEIGHT = 0.063f;
    public const float CARD_THICKNESS = 0.0008f;

	public MeshRenderer frontImageRenderer;
	
	public MeshRenderer backImageRenderer;

    public GameObject model;

	public ZXCard card;
	
	public ZXCard viewingCard;

    public void SetZXCard(ZXCard card)
	{
		this.card = card;
		this.viewingCard = new ZXCard (card);
    }

	// Use this for initialization
	void Start ()
    {
        this.model.gameObject.transform.localEulerAngles = this.GetCardModelAngle();
    }

    bool isAnimation = false;

    // Update is called once per frame
    void Update()
    {
        if (this.card == null)
            return;

        if (isAnimation) return;


        if (this.viewingCard == null)
        {
            this.viewingCard = new ZXCard(card);
        }


        if (this.card.sleep != this.viewingCard.sleep || this.card.isPrivateInfo != this.viewingCard.isPrivateInfo)
        {
            
            iTween.RotateTo(model, iTween.Hash("rotation", this.GetCardModelAngle(), "islocal", true));
            this.viewingCard = new ZXCard(this.card);

        }
    }


    Vector3 GetCardModelAngle()
    {
        Vector3 localAngle = Vector3.zero;

        if (this.card.sleep)
        {
            localAngle = new Vector3(localAngle.x, localAngle.y, 90);
        }
        else
        {
            localAngle = new Vector3(localAngle.x, localAngle.y, 0);
        }

        if (this.card.isPrivateInfo)
        {
            localAngle = new Vector3(localAngle.x, 180, localAngle.z);
        }
        else
        {
            localAngle = new Vector3(localAngle.x, 0, localAngle.z);
        }

            
        return localAngle;
    }
}
