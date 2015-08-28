using UnityEngine;
using System.Collections;

public class balao : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//print (rigidbody2D.velocity.x);
		//if (Mathf.Abs(rigidbody2D.velocity.x) > 0.1f) {
			rigidbody2D.AddForce (new Vector2 (0, 50f));
		//}
	}
}
