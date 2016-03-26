using UnityEngine;
using System.Collections;

public class RevealGhost : MonoBehaviour {

	public GameObject ghost;
	private Renderer[] ghostRenderers;
	private float alphaBlend;
	// Use this for initialization
	void Start () {
		ghostRenderers = ghost.GetComponentsInChildren<Renderer>();
		for(int i = 0; i < ghostRenderers.Length; i++) {
			ghostRenderers[i].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		}
	}
	
	// Update is called once per frame
	void Update () {
		alphaBlend -= 0.01f;
		for(int i = 0; i < ghostRenderers.Length; i++) {
			Renderer renderer = ghostRenderers[i];
			for(int k = 0; k < renderer.materials.Length; k++) {
				Color materialColor = renderer.materials[k].color;
				materialColor.a = alphaBlend;
				renderer.materials[k].color = materialColor;
			}
		}
	}

	public void increaseAlpha() {
		alphaBlend += 0.02f;
	}

}
