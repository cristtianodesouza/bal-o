using UnityEngine;
using System.Collections;

public class Ballon_spawn : MonoBehaviour {
	//intervalo de tempo para a instanciaçao dos simbolos no balao
	public float interval_time;

	//tres simbolos que surgiram no balao
	public GameObject first_symbol;
	public GameObject second_symbol;
	public GameObject third_symbol;

	//
	private float resize;
	private Transform self_parent;
	private float begin_time;
	private Transform teste;
	//bolleanos que determinam a criaçao das instancias
	private bool first_instantiate;
	private bool second_instantiate;
	private bool third_instantiate;

	//x e y de nascimento dos signos
	public Transform position_intantiate;
	// Use this for initialization
	void Start () {
		resize = 0;
		self_parent = GameObject.FindGameObjectWithTag("NPC").GetComponent<Transform>();

		begin_time = Time.time;
		first_instantiate = false;
		second_instantiate = false;
     	third_instantiate = false;

	}
	
	// Update is called once per frame
	void Update () {

		resize = Mathf.Lerp(resize,1,0.05f);
		if (resize >= 0.999f){
			resize = 1;
		}
		transform.localScale = new Vector2 (resize * -self_parent.transform.localScale.x,resize);


		if ((Time.time - begin_time > interval_time)&& !(first_instantiate)){
			print ("teste primeira instanciaçao");
			Instantiate (first_symbol,new Vector2(position_intantiate.position.x-0.8f,position_intantiate.position.y),Quaternion.identity);
			first_instantiate = true;
		}
		if ((Time.time - begin_time > interval_time+0.5f)&& !(second_instantiate)) {
			print ("teste segunda instanciaçao");
			Instantiate (second_symbol,new Vector2(position_intantiate.position.x,position_intantiate.position.y),Quaternion.identity);
			second_instantiate = true;
		}
		if ((Time.time - begin_time > interval_time+1.0f)&&!(third_instantiate)) {
			print ("teste terceira instanciaçao");
			Instantiate (third_symbol,new Vector2(position_intantiate.position.x+0.8f,position_intantiate.position.y),Quaternion.identity);;
			third_instantiate = true;
		}
	}
}
