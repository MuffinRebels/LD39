using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private bool _isOpened = false;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (_isOpened)
            return;

        AnimatorStateInfo info =_animator.GetCurrentAnimatorStateInfo(0);
        if(info.IsName("Door_Idle"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            _isOpened = true;
        }
	}

    public void Open()
    {
        _animator.SetBool("Powered", true);
    }

}
