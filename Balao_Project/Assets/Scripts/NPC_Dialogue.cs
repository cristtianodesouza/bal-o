/* Start{
 * Esse script e usado para : interagir com os npcs
 * 
 * Este script esta anexado a: Player.
 * 
 * Se comunica com os seguintes scripts :
 * 
 * - Bal_Dialogue(bln_txt) > variaveis :
 *  º Ballon
 *  º around
 * 
 * - PlayerMove(plr_mov) > variaveis :
 *  º can_move
 * 
 * Esse script e exportado para os seguintes scripts :
 * 
 * - Ballon_spawn > variaveis :
 *  º plr_bln
 *  º judge
 * 
 * - balao > variaveis : 
 *  º plr_bln
 * 
 *  AVISO: Por favor,ao fazer mudanças,entenda que as variaveis que sao exportadas,podem alterar o valor de outras variaveis em outros
 *  scripts,entao tenha em mente que qualquer mudança nelas pode levar a erros.
 * } End
*/

using UnityEngine;
using System.Collections;

public class NPC_Dialogue : MonoBehaviour {

	// publics
	public GUISkin Skin;
	public bool Win_Skin;
	public bool judge;
	public Sprite plr_bln;
	public Transform think;

	// privates
	private bool OnInteract;
	private bool int_key;

	// comunicaçao dos scripts
	PlayerMove plr_mov;
	Bal_Dialogue bln_txt;
	
	// Use this for initialization
	void Start () {
		// Esta variavel tem seu valor atribuido aqui,pois pode causar erros (atualmente devera ficar em 'false')
		judge = false;

		// importa o script para assim comunicar-se com suas variaveis
		bln_txt = GameObject.FindGameObjectWithTag("Dial").GetComponent<Bal_Dialogue>();
		plr_mov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {

		// Aqui pegamos as teclas 'seta para cima' ou  'W' , que retornaram 'true' ou 'false'
		int_key = ((Input.GetKeyDown (KeyCode.UpArrow)) || (Input.GetKeyDown (KeyCode.W)));

		// Aqui verificamos se o jogador esta dentro da area de interaçao(OnInteract),se apertou o botao de interaçao (int_key)
		// e se pode se mover (plr_mov.can_move)
		if ((OnInteract) && (int_key) && (plr_mov.can_move)){
			// aqui chamamos a funçao de interaçao,que esta na seçao de funçoes (la em baixo)
			Interaction();
		}

		// Aqui sabemos se o dialogo acabou (judge), destruimos o balao de dialogo e deixamos o jogador andar novamente
		if (judge) {
			Destroy (GameObject.FindWithTag("Icon"));
			plr_mov.can_move = true;
			judge = false;
		}
	}

	// Chamado quando jogador entra na caixa de colisao com trigger (lembrando,somente roda 1x,assim que entra)
	void OnTriggerEnter2D(Collider2D outro){

		// aqui dizemos que o jogador esta na area de interaçao (OnInteract), e avisamo que ele esta perto do npc (bln_txt)
		OnInteract = true;
		bln_txt.around = true;

		// aqui criamos a animaçao que fica acima da cabeça do npc
		Instantiate (think, new Vector3 (bln_txt.transform.position.x, bln_txt.transform.position.y + 1.5f), Quaternion.identity);
	}

	// Chamado quando jogador sai na caixa de colisao com trigger (lembrando,somente roda 1x,assim que sai)
	void OnTriggerExit2D(Collider2D outro){

		// aqui dizemos que o jogador saiu da area de interaçao, que ele saiu de perto do npc e destruimos a animaçao
		OnInteract = false;
		bln_txt.around = false;
		Destroy (GameObject.FindWithTag("Icon"));

		// por via das duvidas jogador pode se mover caso saia da area de interaçao
		plr_mov.can_move = true;
	}

	// essa e a funçao de interaçao (aqui onde a magica acontece haha)
	void Interaction(){

		// aqui destruimos a aniçao acima do npc,impossibilitamos e jogador de andar(plr_mov.can_move) e criamos o balao de dialogo (bln_txt.Ballon)
		Destroy (GameObject.FindWithTag("Icon"));
		plr_mov.can_move = false;
		Instantiate (bln_txt.Ballon, new Vector3 (bln_txt.transform.position.x, bln_txt.transform.position.y + 0.5f), Quaternion.identity);
	}
}
