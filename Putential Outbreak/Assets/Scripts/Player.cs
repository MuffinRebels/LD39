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

    [SerializeField]
    private float _rotationHardness = 0.3f;

    private int _health;
    private int _oxygen;

    private Rigidbody2D _rigid;

	void Start () {
        _health = _maxHealth;
        _oxygen = _maxOxygen;
        _rigid = GetComponent<Rigidbody2D>();
    }
	
	void FixedUpdate () {

        // Moving
        float horizontal = Input.GetAxis("Horizontal") * _speed.x;
        float vertical = Input.GetAxis("Vertical") * _speed.y;

        _rigid.AddForce(new Vector2(horizontal, vertical));

        // Looking at mouse
        Vector3 mousePosScreen = Input.mousePosition;
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePosScreen.x, mousePosScreen.y, 1));

        float angle = (180 / Mathf.PI) * Mathf.Atan2(mousePosWorld.y - transform.position.y, mousePosWorld.x - transform.position.x);

        _rigid.rotation = Mathf.LerpAngle(_rigid.rotation, angle, _rotationHardness);
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

        if (newVal > 0)
            OnHeal();
        else
            OnDamage();

        OnHealthChanged();
    }

    private void OnHealthChanged()
    {
        // TODO: Implement OnHealthChanged() function
    }

    private void OnHeal()
    {
        // TODO: Implement OnHeal() function
    }

    private void OnDamage()
    {
        // TODO: Implement OnDamage() function
    }

    private void Die()
    {
        // TODO: Implement Die() function
    }

}
