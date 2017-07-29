using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageWriter : MonoBehaviour {

    [SerializeField]
    private float _typeSpeed;

    [SerializeField]
    private string _message;

    private float _typeTimer = 0;
    private int _charIndex = 0;

    public string Message;
	
	// Update is called once per frame
	void Update () {
		if(_typeTimer >= _typeSpeed && _charIndex < _message.Length)
        {
            Write();
            _typeTimer = 0;
        }

        _typeTimer += Time.deltaTime;
	}

    private void Write()
    {
        Message += _message[_charIndex];
        _charIndex++;

        // TODO: Play sound
    }
}
