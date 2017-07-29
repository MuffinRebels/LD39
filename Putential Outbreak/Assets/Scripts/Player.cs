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

    [SerializeField]
    private GameObject[] _weapons;

    private int _weaponIndex = 0;

    private int _health;
    private int _oxygen;

    private Rigidbody2D _rigid;

    private Weapon _weaponScript;
    private GameObject _weapon;

    void Start () {
        _health = _maxHealth - 10;
        _oxygen = _maxOxygen;
        _rigid = GetComponent<Rigidbody2D>();
        SwitchWeapon(_weapons[0]);
    }

    void Update()
    {
        if(_weaponScript.IsAuto && Input.GetMouseButton(0))
        {
            Shoot();
        }else if(!_weaponScript.IsAuto && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            NextWeapon();
        }
    }

    void Shoot()
    {
        if(_weaponScript != null)
        {
            _weaponScript.Shoot(transform);
        }
    }

    void Reload()
    {
        if (_weaponScript != null)
        {
            _weaponScript.Reload();
        }
    }

    public void SwitchWeapon(GameObject weapon)
    {
        if(_weapon != null)
            _weapon.SetActive(false);

        _weapon = weapon;
        _weapon.SetActive(true);
        _weaponScript = weapon.GetComponent<Weapon>();
    }

    private void NextWeapon()
    {
        int length = _weapons.Length;
        if (_weaponIndex + 1 == length)
            _weaponIndex = 0;
        else
            _weaponIndex++;
        
        SwitchWeapon(_weapons[_weaponIndex]);
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
