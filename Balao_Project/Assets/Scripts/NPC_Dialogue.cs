
// Esse script e usado para responder ao script NPC_Text,ele pega os textos de la e os reproduz

using UnityEngine;
using System.Collections;

public class NPC_Dialogue : MonoBehaviour {

	// publics
	public GUISkin Skin;
	public bool Win_Skin;
	public bool Ballon_Game;
	public Transform plr_bln;

	// privates
	private bool Display_Dialog;
	private bool Display_Box;
	private bool int_key;
	private bool OnInteract;
	private float fnt_size;
	private float Top;
	private float Left;
	private float Widht;
	private float Height;
	private int n;

	// comunicaçao dos scripts
	NPC_Text npc_txt;
	PlayerMove plr_mov;
	Bal_Dialogue bln_txt;
	
	// Use this for initialization
	void Start () {

		// Importa os componentes dos scripts
		npc_txt = GameObject.FindGameObjectWithTag("Dial").GetComponent<NPC_Text>();
		bln_txt = GameObject.FindGameObjectWithTag("Dial").GetComponent<Bal_Dialogue>();
		plr_mov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
		int_key = ((Input.GetKeyDown (KeyCode.UpArrow)) || (Input.GetKeyDown (KeyCode.W)));
		if (OnInteract){
			//Interaction();

		}
	}

	void OnTriggerEnter2D(Collider2D outro){
		Instantiate (bln_txt.Ballon, new Vector3 (bln_txt.transform.position.x, bln_txt.transform.position.y + 0.5f), Quaternion.identity);
		OnInteract = true;
		bln_txt.around = true;
	}

	void OnTriggerExit2D(Collider2D outro){
		OnInteract = false;
		bln_txt.around = false;
		Destroy (GameObject.FindWithTag("Icon"));
	}

	/*
	// aqui verifica se o jogador entrou na area de interaçao
	void OnTriggerEnter2D(Collider2D outro){
		npc_txt.around = true;
		Instantiate (npc_txt.interact, new Vector3 (npc_txt.transform.position.x, npc_txt.transform.position.y + 2), Quaternion.identity);
		OnInteract = true;
	}

	// aqui verifica se o jogador ainda esta dentro da area de interaçao
	void OnTriggerStay2D(Collider2D outro){
		
	}
	
	// aqui verifica se o personagem saiu da area de interaçao
	void OnTriggerExit2D(Collider2D outro){
		Display_Dialog = false;
		Display_Box = false;
		npc_txt.around = false;
		OnInteract = false;
		Destroy (GameObject.FindWithTag("Icon"));
	}
*/



	void OnGUI() {
		if (Display_Box) {
			if (Win_Skin){
				GUI.skin = Skin;
				Top = Screen.width/100;
				Left = Screen.height/1.4f;
				Widht = Screen.width - (Screen.width/100) * 2;
				Height = Screen.height/3.5f - Screen.height/100;
				fnt_size =  (Height - Top)/4;
				GUI.skin.box.fontSize =  (int)fnt_size;
			}
			GUI.Box (new Rect(Top,Left,Widht,Height),npc_txt.Dialog[n]);
		}
	}
	
	void Interaction(){
		if (int_key) {
			// Aqui e onde o personagem nao pode mais andar e o dialogo segue
			plr_mov.move_x = 0;
			plr_mov.hsp = 0;
			if(Display_Dialog){
				plr_mov.can_move = false;
				if (n != npc_txt.Dialog.Length - 1){
					n++;
					Display_Box = true;
				} else {
					if (Display_Box){
						Display_Box = false;
						Display_Dialog = false;
						plr_mov.can_move = true;
					} else {
						Display_Box =  true;
					}
				} 
			} else {
				Display_Box =  true;
				Display_Dialog = true;
				plr_mov.can_move = false;
			}
		}
	}
}
