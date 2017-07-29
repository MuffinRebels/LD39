using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightFlicker : MonoBehaviour {

    public float LightFlickerThreshold = 0.5f;

    private GameManager _gameManager;
    private Light _light;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update () {
		if(_gameManager.Power <= LightFlickerThreshold)
        {
            _light.intensity -= 0.01f;
        }
	}
}
