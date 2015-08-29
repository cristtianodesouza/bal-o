/* Start{
 * Esse script e usado para : rescalonar o balao,e por seus correspondentes itens dentro dele
 * 
 * Este script esta anexado a: Prefab.BallonDialog.
 * 
 * Se comunica com os seguintes scripts :
 * 
 * - NPC_Dialog(npc_dial) > variaveis :
 *  º plr_bln
 *  º judge
 * 
 * - Bal_Dialogue(bal_dial) > variaveis :
 *  º npc_bln
 * 
 * Esse script e exportado para os seguintes scripts :
 * 
 * - Nenhum script no momento
 * 
 *  AVISO: Por favor,ao fazer mudanças,entenda que as variaveis que sao exportadas,podem alterar o valor de outras variaveis em outros
 *  scripts,entao tenha em mente que qualquer mudança nelas pode levar a erros.
 * } End
*/


using UnityEngine;
using System.Collections;

public class Ballon_spawn : MonoBehaviour {

	// publics
	public Sprite[] lequal;

	// privates
	private Sprite final;
	private Sprite last_j;
	private float resize;
	private Transform self_parent;
	//GameObject[] obj; - variavel que pode ser util futuramente,favor nao mecher
	float tempo_criaçao;
	float tempo_intervalo = 1.5f;
	bool[] create = new bool[] {false,false,false,false};

	// comunicaçao dos scripts
	NPC_Dialogue npc_dial;
	Bal_Dialogue bal_dial;

	// Use this for initialization
	void Start () {
		// Esta variavel tem seu valor atribuido aqui,pois pode causar erros (atualmente devera ficar em '0')
		resize = 0;

		// esta variavel pega o tempo atual na hora da criaçao do objeto
		tempo_criaçao = Time.time;

		// importa o script para assim comunicar-se com suas variaveis
		self_parent = GameObject.FindGameObjectWithTag("NPC").GetComponent<Transform>();
		npc_dial = GameObject.FindGameObjectWithTag("Player").GetComponent<NPC_Dialogue>();
		bal_dial = GameObject.FindGameObjectWithTag("Dial").GetComponent<Bal_Dialogue>();
	}
	
	// Update is called once per frame
	void Update () {

		// aqui e onde o balao de dialogo e criado e animado - inicio
		resize = Mathf.Lerp(resize,1,0.05f);
		if (resize >= 0.999f){
			resize = 1;
		}
		transform.localScale = new Vector2 (resize * -self_parent.transform.localScale.x,resize);
		// - fim

		// aqui criamos objetos novos apartir de sprites,esses objetos serao criados dentro do balao de dialogo
		// os objeto criados serao :
		// 1.balao do jogador
		if(tempo_intervalo < Time.time - tempo_criaçao &&!(create[0])){
			GameObject obj_1 = new GameObject();
			obj_1.AddComponent<SpriteRenderer>();
			obj_1.GetComponent<SpriteRenderer>().sprite = npc_dial.plr_bln;
			obj_1.transform.parent = transform;
			obj_1.transform.position = new Vector2 (transform.position.x + (0.8f * transform.localScale.x),transform.position.y + 1.6f);
			obj_1.transform.localScale = new Vector2 (1f,1f);
			create[0] = true;
		}
		// 2.balao do npc
		if(tempo_intervalo*2 < Time.time - tempo_criaçao &&!(create[1])){
			GameObject obj_2 = new GameObject();
			obj_2.AddComponent<SpriteRenderer>();
			obj_2.GetComponent<SpriteRenderer>().sprite = bal_dial.npc_bln;
			obj_2.transform.parent = transform;
			obj_2.transform.position = new Vector2 (transform.position.x + (2.4f * transform.localScale.x),transform.position.y + 1.6f);
			obj_2.transform.localScale = new Vector2 (1f,1f);
			create[1] = true;
		}
		// 3.comparaçao dos balao do npc e do balao do jogador,e seu julgamento
		if(tempo_intervalo*3 < Time.time - tempo_criaçao &&!(create[2])){
			// compara os 2 baloes
			if ((npc_dial.plr_bln) == (bal_dial.npc_bln)){
				final = lequal[0];
				last_j = lequal[2];
			} else {
				final = lequal[1];
				last_j = lequal[3];
			}
			// diz se e igual ou nao
			GameObject obj_3 = new GameObject();
			obj_3.AddComponent<SpriteRenderer>();
			obj_3.GetComponent<SpriteRenderer>().sprite = final;
			obj_3.transform.parent = transform;
			obj_3.transform.position = new Vector2 (transform.position.x + (1.6f * transform.localScale.x),transform.position.y + 1.6f);
			obj_3.transform.localScale = new Vector2 (1f,1f);

			// julgamento
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
		// aqui avisamos que terminou o dialogo,e destruimos o balao de dialogo
		if(tempo_intervalo*4 < Time.time - tempo_criaçao &&!(create[3])){
			create[3] = true;
			npc_dial.judge = true;
		}
	}
}
