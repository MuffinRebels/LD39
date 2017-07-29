using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageWriter : MonoBehaviour {

    [SerializeField]
    private float _typeSpeed;

    [SerializeField]
    private string _message;

    [SerializeField]
    private AudioClip _typeSound;

    private float _typeTimer = 0;
    private int _charIndex = 0;

    private string _finalMessage;
	
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
        _finalMessage += _message[_charIndex];
        _charIndex++;

        Debug.Log(_finalMessage);
        // TODO: Play sound
        if (_typeSound != null)
            AudioSource.PlayClipAtPoint(_typeSound, Camera.main.transform.position);
    }

    public string GetMessage()
    {
        return _finalMessage;
    }
}
