
// Esse e o script de movimentaçao do personagem (meio obvio nao acha?)

using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	// Publics
	public float mov_speed;
	public float jmp_speed;
	public float max_speed;
	public bool can_move;
	public bool doble_jump;
	public bool from_axis;
	public string Importante;
	public float move_x;
	public float move_y;
	public float hsp;


	// Privates
	private bool OnGround;
	private float max_fall = -10.0f;
	private bool can_jump;
	private float key_left;
	private float key_right;
	private int lerp_fix;

	//PlayerAnimation plr_anim;

	// Use this for initialization
	void Start () {
		can_move = true;
		hsp = 0;
		move_x = 0;
		move_y = 0;
		//plr_anim = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimation>();
	}

	// Update is called once per frame
	void Update () {
		
		// Checando Colisões
		OnGround = Physics2D.Raycast(transform.position, -Vector2.up, 0.1f);

		// Pulo (se estiver no chao,apertar barra de espaço e poder se mover) porem,se pulo duplo estiver habilitado,pode pular +1x eu deixo

		if (doble_jump) {
			if (OnGround) {
				can_jump = true;
				if ((Input.GetKeyDown (KeyCode.Space)) && (can_move)) {
					rigidbody2D.velocity = new Vector2 (0, jmp_speed);
				}
			} else {
				if ((Input.GetKeyDown (KeyCode.Space)) && (can_move) && (can_jump)) {
					rigidbody2D.velocity = new Vector2 (0, jmp_speed);
					can_jump = false;
				}
			}
		} else {
			if ((OnGround) && (Input.GetKeyDown (KeyCode.Space)) && (can_move)) {
					rigidbody2D.velocity = new Vector2 (0, jmp_speed);
			}
		}

		// Gambiarra Temporaria

		if (!from_axis) {
			if (can_move) {
				TheAxis ();
			}
		} else {
			// Movimentaçao do Personagem
			if (can_move) {
				move_x = Input.GetAxis ("Horizontal");
				hsp = move_x * mov_speed;
				transform.position = new Vector2 (transform.position.x + hsp, transform.position.y);
			}
		}

		// velocidade maxima de queda
		move_y = rigidbody2D.velocity.y;
		if (move_y < max_fall) {
			rigidbody2D.velocity = new Vector2 (0, max_fall);
		}
	}

	// Gambiarra Temporaria,Por Favor Manter Distancia

	void TheAxis(){

		// Pegando os botoes pressionados
		if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow))){
			key_left = -1;
			lerp_fix = -1;
		} else {
			key_left = 0;
		}
		if ((Input.GetKey(KeyCode.D))|| (Input.GetKey(KeyCode.RightArrow))){
			key_right = 1;
			lerp_fix = 1;
		} else {
			key_right = 0;
		}

		move_x = key_left + key_right;
		if (move_x != 0){
			if (move_x > 0){

				// evitando deslise
				if (hsp < 0){
					hsp = 0;
				}
				// aki poderia ser resolvido com outra coisa,mas nao vem em minha mente
				if (hsp < max_speed){
					hsp += mov_speed;
				} else {
					hsp = max_speed;
				}
			}
			if (move_x < 0){

				// evitando deslise
				if (hsp > 0){
					hsp = 0;
				}
				// aki poderia ser resolvido com outra coisa,mas nao vem em minha mente #2
				if (hsp > -max_speed){
					hsp -= mov_speed;
				} else {
					hsp = -max_speed;
				}
			}
		} else {
			hsp = Mathf.Lerp(hsp,0,0.15f);
			if (lerp_fix > 0){
				if (hsp < 0.0001f){
					hsp = 0;
					lerp_fix = 0;
				}
			}
			if (lerp_fix < 0){
				if (hsp > -0.0001f){
					hsp = 0;
					lerp_fix = 0;
				}
			}
		}
		transform.position = new Vector2 (transform.position.x + hsp/10,transform.position.y);
	}
}
