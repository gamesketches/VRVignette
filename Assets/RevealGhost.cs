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
		Debug.Log(alphaBlend);
		alphaBlend -= 0.01f;
		alphaBlend = alphaBlend < 0f ? 0f : alphaBlend;
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
		alphaBlend += 0.1f;
		alphaBlend = alphaBlend > 1.0f ? 1f : alphaBlend;
		Debug.Log("Increase Alpha");
	}

}
