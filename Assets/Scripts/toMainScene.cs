﻿using UnityEngine;
using System.Collections;
using NewtonVR;
using UnityEngine.SceneManagement;

public class toMainScene : MonoBehaviour {

	public string _loadScene;
	public GameObject _earthquakeBookEN;
	public GameObject _earthquakeBookTR;
	private bool _triggered;
	private float _duration;
	private float _elapsedTime;

	void Start () {
	
		_duration = this.GetComponent<ScreenFadeOut> ().fadeTime;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (_earthquakeBookEN.GetComponent<NVRInteractableItem> ().IsAttached || Input.GetKeyDown(KeyCode.Space)) {
		

			_triggered = true;
		
		}

		/*if (_earthquakeBookTR.GetComponent<NVRInteractableItem> ().IsAttached) {


			_triggered = true;

		}*/

		if (_triggered) {
			this.GetComponent<ScreenFadeOut> ().enabled = true;

			StartCoroutine (StartFade ());

		
		}



	}

	IEnumerator StartFade(){
	
		yield return new WaitForSeconds (_duration);


		SceneManager.LoadScene (_loadScene);

	//	Debug.Log ("bitti");
	}
}
