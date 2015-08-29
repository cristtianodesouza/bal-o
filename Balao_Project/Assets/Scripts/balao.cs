/* Start{
 * Esse script e usado para : definir o sprite do balao,e deixa-lo flutuando ao redor do jogador
 * 
 * Este script esta anexado a: balao (dentro do prefab 'NPC').
 * 
 * Se comunica com os seguintes scripts :
 * 
 * - Bal_Dialogue(bal_dial) > variaveis :
 *  º npc_bln
 * 
 * - NPC_Dialogue(npc_dial) > variaveis :
 *  º plr_bln
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

public class balao : MonoBehaviour {

	// comunicaçao dos scripts
	NPC_Dialogue npc_dial;
	Bal_Dialogue bal_dial;

	// publics
	public bool player;

	// Use this for initialization
	void Start () {
		// importa o script para assim comunicar-se com suas variaveis
		npc_dial = GameObject.FindGameObjectWithTag("Player").GetComponent<NPC_Dialogue>();
		bal_dial = GameObject.FindGameObjectWithTag("Dial").GetComponent<Bal_Dialogue>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// aqui o balao e sempre forçado a ir pra cima (usando rigdbody ao invez de translaçao)
		rigidbody2D.AddForce (new Vector2 (0, 50f));
		// checa se esta atrelado ao jogador ou ao npc,e transforma o seu sprite de acordo
		if (player) {
			this.GetComponent<SpriteRenderer> ().sprite = npc_dial.plr_bln;
		} else {
			this.GetComponent<SpriteRenderer> ().sprite = bal_dial.npc_bln;
		}
	}
}
