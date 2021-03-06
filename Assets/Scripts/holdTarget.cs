﻿using UnityEngine;
using System.Collections;

/*This script is the table leg holding script */

public class holdTarget : MonoBehaviour {

	private Transform _lookTarget;
	public GameObject _redSphere;
	public GameObject _greenSphere;
	public GameObject _mySprite;
    public GameObject _mySpriteTr;
	public float durationOfHold = 0.0f;
	private sequenceManager _sequenceManager;
    private EarthquakeController _earthquakeController;

    // Use this for initialization
    void Start () {
		_lookTarget = GameObject.Find("BullSkull").transform;
		//_redSphere = GameObject.Find("Hold Target/Red Sphere");
		//Debug.Log("redsphere = " + _redSphere);
		//_greenSphere = GameObject.Find("Green Sphere");
		_greenSphere.SetActive(false);
		_mySprite = GameObject.Find("sprite");
        _mySpriteTr = GameObject.Find("spriteTr");
		_sequenceManager = GameObject.Find("Sequence Manager").GetComponent<sequenceManager>();
        _earthquakeController = GameObject.Find("Earthquake Controller").GetComponent<EarthquakeController>();
    }
	
	// Update is called once per frame
	void Update () {
        if(_sequenceManager.isEnglish == true)
        {
            _mySpriteTr.SetActive(false);
        }

        if (_sequenceManager.isTurkish == true)
        {
            _mySprite.SetActive(false);
        }

        // angle UI to User's face
        transform.LookAt(_lookTarget, Vector3.up);

        /*if (_earthquakeController._shakeCamera == true)
        {
            if (_greenSphere.activeInHierarchy == true)
            {
                durationOfHold += Time.deltaTime;
                Debug.Log("Duration of hold: " + (int)durationOfHold);
            }
            else
            {
                durationOfHold = 0.0f;
            }
        }*/

    }

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Hand") {
			if (_redSphere.activeInHierarchy) 
			{
				Debug.Log("hand in target");
				
                if (_sequenceManager.isEnglish == true)
                {
                    _redSphere.SetActive(false);
                    _greenSphere.SetActive(true);
                    _mySprite.SetActive(false);
                    _sequenceManager._handOnHoldTarget = true;
                }

                if (_sequenceManager.isTurkish == true)
                {
                    _redSphere.SetActive(false);
                    _greenSphere.SetActive(true);
                    _mySpriteTr.SetActive(false);
                    _sequenceManager._handOnHoldTarget = true;
                }
				
				
				//ParticleSystemTable.SetActive(true);		// Particles On
			}
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Hand") {
			if (_greenSphere.activeInHierarchy) 
			{
				_greenSphere.SetActive(false);
				_redSphere.SetActive(true);
                if (_sequenceManager.isEnglish == true)
                {
                    _mySprite.SetActive(true);
                }

                if(_sequenceManager.isTurkish == true)
                {
                    _mySpriteTr.SetActive(true);
                }
				//ParticleSystemTable.SetActive(false);		// Particles off
			}
		}
	}
}
