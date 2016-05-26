using UnityEngine;
using System.Collections;

public class DanceLayerDemo : MonoBehaviour {

	Animator myAnimator;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)) {
			myAnimator.SetLayerWeight(1, 1.0f);

		}
		else {
			myAnimator.SetLayerWeight(1, 0.0f);
		}
	}
}
