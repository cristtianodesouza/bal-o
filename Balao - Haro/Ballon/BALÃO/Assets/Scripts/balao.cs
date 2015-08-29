using UnityEngine;
using System.Collections;

public class balao : MonoBehaviour {

	NPC_Dialogue npc_dial;
	Bal_Dialogue bal_dial;
	public bool player;

	// Use this for initialization
	void Start () {
		npc_dial = GameObject.FindGameObjectWithTag("Player").GetComponent<NPC_Dialogue>();
		bal_dial = GameObject.FindGameObjectWithTag("Dial").GetComponent<Bal_Dialogue>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody2D.AddForce (new Vector2 (0, 50f));
		if (player) {
			this.GetComponent<SpriteRenderer> ().sprite = npc_dial.plr_bln;
		} else {
			this.GetComponent<SpriteRenderer> ().sprite = bal_dial.npc_bln;
		}
	}
}
