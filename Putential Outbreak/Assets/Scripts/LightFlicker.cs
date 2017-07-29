using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightFlicker : MonoBehaviour {

    public float LightFlickerThreshold = 0.5f;
    public float LightFadeThreshold = 0.2f;
    public float FlickerTimeMin, FlickerTimeMax;

    private GameManager _gameManager;
    private Light _light;
    private float _flickerTimer = 0;
    private float _flickerTime = 0;
    private float _prevIntensity;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _light = GetComponent<Light>();
        _prevIntensity = _light.intensity;
    }

    private void Update()
    {
        if(_gameManager.Power <= LightFlickerThreshold)
        {
            if(_flickerTimer == 0 || _flickerTime >= _flickerTimer)
            {
                _light.intensity = _light.intensity > 0 ? 0 : _prevIntensity;
                _flickerTimer = Random.Range(FlickerTimeMin, FlickerTimeMax);
                _flickerTime = 0;
            }

            _flickerTime += Time.deltaTime;
        }
    }

    void FixedUpdate () {
		if(_gameManager.Power <= LightFadeThreshold)
        {
            _light.intensity -= 0.01f;
            _prevIntensity = _light.intensity;
        }
	}
}
