
// Esse script e usado para responder ao script NPC_Text,ele pega os textos de la e os reproduz

using UnityEngine;
using System.Collections;

public class NPC_Dialogue : MonoBehaviour {

	// publics
	public GUISkin Skin;
	public bool Win_Skin;
	public bool Ballon_Game;
	public bool judge;
	public Sprite plr_bln;
	public Transform think;

	// privates
	private bool OnInteract;
	private bool int_key;

	// comunicaçao dos scripts
	//NPC_Text npc_txt;
	PlayerMove plr_mov;
	Bal_Dialogue bln_txt;
	
	// Use this for initialization
	void Start () {
		judge = false;

		// Importa os componentes dos scripts
		//npc_txt = GameObject.FindGameObjectWithTag("Dial").GetComponent<NPC_Text>();
		bln_txt = GameObject.FindGameObjectWithTag("Dial").GetComponent<Bal_Dialogue>();
		plr_mov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
		int_key = ((Input.GetKeyDown (KeyCode.UpArrow)) || (Input.GetKeyDown (KeyCode.W)));
		if ((OnInteract) && (int_key) && (plr_mov.can_move)){
			Interaction();
		}
		if (judge) {
			Destroy (GameObject.FindWithTag("Icon"));
			plr_mov.can_move = true;
			judge = false;
		}
	}

	void OnTriggerEnter2D(Collider2D outro){
		OnInteract = true;
		bln_txt.around = true;
		Instantiate (think, new Vector3 (bln_txt.transform.position.x, bln_txt.transform.position.y + 1.5f), Quaternion.identity);
	}

	void OnTriggerExit2D(Collider2D outro){
		OnInteract = false;
		bln_txt.around = false;
		Destroy (GameObject.FindWithTag("Icon"));
		plr_mov.can_move = true;
	}


	void Interaction(){
		Destroy (GameObject.FindWithTag("Icon"));
		plr_mov.can_move = false;
		Instantiate (bln_txt.Ballon, new Vector3 (bln_txt.transform.position.x, bln_txt.transform.position.y + 0.5f), Quaternion.identity);
	}
}
