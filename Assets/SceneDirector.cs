using UnityEngine;
using System.Collections;

public class SceneDirector : MonoBehaviour {

	public GameObject dude;
	public GameObject chick;
	public Animator dudeGhost;
	public Animator chickGhost;

	private int conversationPoint;
	private bool isTalking;
	private AudioSource[] audioClips;
	public Animator dudeAnimations;
	public Animator chickAnimations;
	// Use this for initialization
	void Start () {
		AudioSource[] MarySources = chick.GetComponents<AudioSource>();
		AudioSource[] JohnSources = dude.GetComponents<AudioSource>();
		dudeAnimations = dude.GetComponent<Animator>();
		chickAnimations = chick.GetComponent<Animator>();
		ShuffleArrays(JohnSources, MarySources);
		isTalking = false;
		conversationPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isTalking) {
			StartCoroutine(PlayAudio());
		}
		if(Input.GetKeyDown(KeyCode.R)){
			conversationPoint = 0;
		}
	}

	void ShuffleArrays(AudioSource[] JohnSources, AudioSource[] MarySources) {
		audioClips = new AudioSource[JohnSources.Length * 2];
		int k = 0;
		for(int i = 0; i < JohnSources.Length; i++) {
			audioClips[k] = JohnSources[i];
			k++;
			audioClips[k] = MarySources[i];
			k++;
		}
	}

	IEnumerator PlayAudio() {
		isTalking = true;
		if(conversationPoint < audioClips.Length) {
			dudeAnimations.SetInteger("conversationPoint", conversationPoint);
			Debug.Log(dudeAnimations.GetInteger("conversationPoint"));
			dudeGhost.SetInteger("conversationPoint", conversationPoint);
			chickGhost.SetInteger("conversationPoint", conversationPoint);
			audioClips[conversationPoint].Play();
			while(audioClips[conversationPoint].isPlaying) {
				yield return null;
			}

			conversationPoint++;
			isTalking = false;
		}
	}
}
