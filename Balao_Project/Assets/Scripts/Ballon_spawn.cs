using UnityEngine;
using System.Collections;

public class Ballon_spawn : MonoBehaviour {

	private float resize;
	private Transform self_parent;
	private float begin_time;
	public float interval_time;
	private bool first_instantiate;
	private bool second_instantiate;
	private bool third_instantiate;
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
			first_instantiate = true;
		}
		if ((Time.time - begin_time > interval_time+0.5f)&& !(second_instantiate)) {
			print ("teste segunda instanciaçao");
			second_instantiate = true;
		}
		if ((Time.time - begin_time > interval_time+1.0f)&&!(third_instantiate)) {
			print ("teste terceira instanciaçao");
			third_instantiate = true;
		}
	}
}
