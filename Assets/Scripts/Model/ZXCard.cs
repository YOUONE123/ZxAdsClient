using UnityEngine;
using System.Collections;

public class ZXCard {

	public int cardId;
	
	public int entityId;
	
	public int gameUniqueId;

	public string name;

	public int power;

	public string imageName;

	public bool sleep;

	public bool isPrivateInfo = false;

	public ZXCardZone zone;


    public ZXCard()
    {
    }

    public ZXCard(ZXCard card)
	{
		this.name = card.name;
		this.power = card.power;
		this.imageName = card.imageName;
		this.zone = card.zone;
		this.sleep = card.sleep;
		this.isPrivateInfo = card.isPrivateInfo;
		this.zone = card.zone;
	}
}
