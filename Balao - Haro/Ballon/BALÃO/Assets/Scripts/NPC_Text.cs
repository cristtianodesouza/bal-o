
// Esse script e usado para dialogos,aqui so existe os textos de dialogos e o icone que aparece em cima ao chegar perto
// Ate 50 Caracteres Por Linha

using UnityEngine;
using System.Collections;

public class NPC_Text : MonoBehaviour {
	

	public Transform interact;
	public bool around;
	public string[] Dialog;


	private float plr_x;
	private float self_x;
	private Transform self_parent;
	private Transform plr_trns;
	
	// Use this for initialization
	void Start () {
		self_parent = GameObject.FindGameObjectWithTag("NPC").GetComponent<Transform>();
		plr_trns = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		plr_x = plr_trns.transform.position.x;
		self_x = transform.position.x;
		if (around) {
			if (plr_x < self_x){
				self_parent.transform.localScale = new Vector2 (-1,1);
			} else {
				self_parent.transform.localScale = new Vector2 (1,1);
			}
		}
	}
}
