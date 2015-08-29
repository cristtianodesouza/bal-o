/* Start{
 * Esse script e usado para : 
 * 
 * Este script esta anexado a: 
 * 
 * Se comunica com os seguintes scripts :
 * 
 * - Nenhum script no momento
 * 
 * Esse script e exportado para os seguintes scripts :
 * 
 * - NPC_Dialog > variaveis :
 *  º Ballon
 *  º around
 * 
 * - Ballon_spawn > variaveis :
 *  º npc_bln
 * 
 * - balao > variaveis :
 *  º npc_bln
 * 
 *  AVISO: Por favor,ao fazer mudanças,entenda que as variaveis que sao exportadas,podem alterar o valor de outras variaveis em outros
 *  scripts,entao tenha em mente que qualquer mudança nelas pode levar a erros.
 * } End
*/

using UnityEngine;
using System.Collections;

public class Bal_Dialogue : MonoBehaviour {
	
	public Transform Ballon;
	public bool around;
	public Sprite npc_bln;

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
