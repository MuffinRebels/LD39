using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float Power = 1.0f;

    [SerializeField]
    private float _timeToDecreasePower = 1.0f;

    [SerializeField]
    private float _powerDecreaseVal = 0.05f;

    private float _timer = 0;

    void Update()
    {
        if(Power <= 0)
        {
            _timer = 0;
            Power = 0;
            return;
        }

        _timer += Time.deltaTime;

        if (_timer >= _timeToDecreasePower)
        {
            Power -= _powerDecreaseVal;
            _timer = 0;
            Debug.Log("Power: " + Power);
        }
    }

}
