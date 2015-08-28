using UnityEngine;
using System.Collections;

public class Ballon_spawn : MonoBehaviour {

	private float resize;
	private Transform self_parent;

	// Use this for initialization
	void Start () {
		resize = 0;
		self_parent = GameObject.FindGameObjectWithTag("NPC").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		resize = Mathf.Lerp(resize,1,0.05f);
		if (resize >= 0.999f){
			resize = 1;
		}
		transform.localScale = new Vector2 (resize * -self_parent.transform.localScale.x,resize);
	}
}
