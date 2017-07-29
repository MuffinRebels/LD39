using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public const string PLAYER_NAME = "Putin";

    [SerializeField]
    private Vector2 _speed;

    [SerializeField]
    private int _maxHealth = 100;

    [SerializeField]
    private int _maxOxygen = 100;

    private int _health;
    private int _oxygen;

	void Start () {
        _health = _maxHealth;
        _oxygen = _maxOxygen;
    }
	
	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
	}

    public int GetHealth()
    {
        return _health;
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    public void ModifyHealth(int newVal)
    {
        _health = (int)Mathf.Clamp(_health + newVal, 0, _maxHealth);
        if (_health == 0)
            Die();
    }

    private void Die()
    {
        // TODO: Implement Die() function
    }

}
