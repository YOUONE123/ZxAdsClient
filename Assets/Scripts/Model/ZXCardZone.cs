using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZXCardZone{

	public List<ZXCard> cards;
	 
	public ZXCardZone()
	{
        cards = new List<ZXCard>();
    }
    public ZXCardZone(ZXCardZone cardZone)
    {
        cards = new List<ZXCard>(cardZone.cards);
    }
}
