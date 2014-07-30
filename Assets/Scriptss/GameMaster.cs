﻿using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public GameObject playerCharacter;
	public Camera mainCamera;
	public float zOffset;
	public float yOffset;
	public float xRotOffset;

	public GameObject gameSettings;
	private GameObject _pc;
	private PlayerCharacter _pcScript;

	// Use this for initialization
	void Start (){
				_pc = Instantiate (playerCharacter, Vector3.zero, Quaternion.identity) as GameObject;

				_pcScript = _pc.GetComponent<PlayerCharacter> ();

				zOffset = -2.5f;
				yOffset = 2.5f;
				xRotOffset = 22.5f;

				mainCamera.transform.position = new Vector3 (_pc.transform.position.x, _pc.transform.position.y + yOffset, _pc.transform.position.z + zOffset);
				mainCamera.transform.Rotate (xRotOffset, 0, 0); 
	
		}
	public void LoadCharacter (){
		GameObject gs = GameObject.Find ("__Game Settings");
		if (gs == null) {
		Instantiate(gameSettings, Vector3.zero, Quaternion.identity);
			gs.name = "gameSettings";
		}

		GameSettings gsScript = GameObject.Find("__Game Settings").GetComponent<GameSettings>();

	
		//Loading

		gsScript.LoadCharacterData();


	}
}
