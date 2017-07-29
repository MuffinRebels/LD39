using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
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

    private Rigidbody2D _rigid;

	void Start () {
        _health = _maxHealth;
        _oxygen = _maxOxygen;
        _rigid = GetComponent<Rigidbody2D>();
    }
	
	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal") * _speed.x;
        float vertical = Input.GetAxis("Vertical") * _speed.y;

        _rigid.AddForce(new Vector2(horizontal, vertical));
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
