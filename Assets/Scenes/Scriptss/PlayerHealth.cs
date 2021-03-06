﻿using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth = 100;
	public int curHealth = 100;
	public bool active = false;
	public float healthBarLenght;


	// Use this for initialization
	void Start () {
		healthBarLenght = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth (0);

	}
	void OnGUI() {
		if (active == true){
		GUI.Box(new Rect(10, 10, healthBarLenght, 30), curHealth + "/" + maxHealth);
		}


}
	public void AddjustCurrentHealth(int adj) {
		curHealth += adj; 
		if (curHealth < 0)
						curHealth = 0;
		if (curHealth == 0)
						Destroy (gameObject);
		if (curHealth > maxHealth) 
						curHealth = maxHealth;
		if (maxHealth < 1)
						maxHealth = 1;
		if (curHealth < maxHealth && GetComponent<HealerAI>()) {
			GameObject text = GameObject.Find("New Text");
			text.GetComponent<MeshRenderer>().enabled = true;
		}
		if (curHealth > 99 && GetComponent<HealerAI> ()) {
			GameObject text = GameObject.Find("New Text");
			text.GetComponent<MeshRenderer>().enabled = false;	
		}

		healthBarLenght = (Screen.width / 2) * (curHealth / (float)maxHealth);
		}
}	