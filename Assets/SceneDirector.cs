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
	// Use this for initialization
	void Start () {
		AudioSource[] MarySources = chick.GetComponents<AudioSource>();
		AudioSource[] JohnSources = dude.GetComponents<AudioSource>();
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
			Debug.Log(k);
			audioClips[k] = JohnSources[i];
			k++;
			Debug.Log(k);
			audioClips[k] = MarySources[i];
			k++;
		}
		for(int i = 0; i < audioClips.Length; i++) {
			Debug.Log(audioClips[i].clip);
		}
	}

	IEnumerator PlayAudio() {
		isTalking = true;
		if(conversationPoint < audioClips.Length) {
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
