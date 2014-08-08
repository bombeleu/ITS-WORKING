﻿using UnityEngine;


public class Jewelry : BuffItem {
	private JewelrySlot _slot; //slot the piece of jewelry is gonna be in


	public Jewelry(){
		_slot = JewelrySlot.PocketItem;
	}
	public Jewelry (JewelrySlot slot){
		_slot = slot;
	}
	public JewelrySlot Slot {
		get { return _slot;}
		set {_slot = value;}
	}

}

public enum JewelrySlot {
	EarRings,
	Necklaces,
	Bracelets,
	Rings,
	PocketItem
}