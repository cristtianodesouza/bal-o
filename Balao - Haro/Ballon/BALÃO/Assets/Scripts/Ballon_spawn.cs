using UnityEngine;
using System.Collections;

public class Ballon_spawn : MonoBehaviour {

	public Sprite[] lequal;
	private Sprite final;
	private Sprite last_j;
	private float resize;
	private Transform self_parent;
	//GameObject[] obj;
	NPC_Dialogue npc_dial;
	Bal_Dialogue bal_dial;
	float tempo_criaçao;
	float tempo_intervalo = 1.5f;
	bool[] create = new bool[] {false,false,false,false};

	// Use this for initialization
	void Start () {
		resize = 0;
		tempo_criaçao = Time.time;
		//print (tempo_criaçao);


		self_parent = GameObject.FindGameObjectWithTag("NPC").GetComponent<Transform>();
		npc_dial = GameObject.FindGameObjectWithTag("Player").GetComponent<NPC_Dialogue>();
		bal_dial = GameObject.FindGameObjectWithTag("Dial").GetComponent<Bal_Dialogue>();
	}
	
	// Update is called once per frame
	void Update () {
		resize = Mathf.Lerp(resize,1,0.05f);
		if (resize >= 0.999f){
			resize = 1;
		}
		transform.localScale = new Vector2 (resize * -self_parent.transform.localScale.x,resize);

		if(tempo_intervalo < Time.time - tempo_criaçao &&!(create[0])){
			GameObject obj_1 = new GameObject();
			obj_1.AddComponent<SpriteRenderer>();
			obj_1.GetComponent<SpriteRenderer>().sprite = npc_dial.plr_bln;
			obj_1.transform.parent = transform;
			obj_1.transform.position = new Vector2 (transform.position.x + (0.8f * transform.localScale.x),transform.position.y + 1.6f);
			obj_1.transform.localScale = new Vector2 (1f,1f);
			create[0] = true;
		}
		if(tempo_intervalo*2 < Time.time - tempo_criaçao &&!(create[1])){
			GameObject obj_2 = new GameObject();
			obj_2.AddComponent<SpriteRenderer>();
			obj_2.GetComponent<SpriteRenderer>().sprite = bal_dial.npc_bln;
			obj_2.transform.parent = transform;
			obj_2.transform.position = new Vector2 (transform.position.x + (2.4f * transform.localScale.x),transform.position.y + 1.6f);
			obj_2.transform.localScale = new Vector2 (1f,1f);
			create[1] = true;
		}
		if(tempo_intervalo*3 < Time.time - tempo_criaçao &&!(create[2])){


			if ((npc_dial.plr_bln) == (bal_dial.npc_bln)){
				final = lequal[0];
				last_j = lequal[2];
			} else {
				final = lequal[1];
				last_j = lequal[3];
			}
			GameObject obj_3 = new GameObject();
			obj_3.AddComponent<SpriteRenderer>();
			obj_3.GetComponent<SpriteRenderer>().sprite = final;
			obj_3.transform.parent = transform;
			obj_3.transform.position = new Vector2 (transform.position.x + (1.6f * transform.localScale.x),transform.position.y + 1.6f);
			obj_3.transform.localScale = new Vector2 (1f,1f);

			GameObject obj_4 = new GameObject();
			obj_4.AddComponent<SpriteRenderer>();
			obj_4.GetComponent<SpriteRenderer>().sprite = last_j;
			obj_4.transform.parent = transform;
			obj_4.transform.position = new Vector2 (transform.position.x - (-1.6f * transform.localScale.x),transform.position.y);
			if (self_parent.transform.localScale.x < 0){
				obj_4.transform.localScale = new Vector2 (1f,1f);
			} else if (self_parent.transform.localScale.x > 0){
				obj_4.transform.localScale = new Vector2 (-1f,1f);
			}
			create[2] = true;
		}
		if(tempo_intervalo*4 < Time.time - tempo_criaçao &&!(create[3])){
			create[3] = true;
			npc_dial.judge = true;
		}
	}
}
