using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public string WeaponName;
    public float Damage;
    public GameObject Bullet;
    public AudioClip ShootAudio, ReloadAudio, EmptyAudio;
    public Transform BulletExit;
    public bool IsAuto = false;

    [SerializeField]
    private float _shootSpeed = 0.2f;

    // We have this so we can make shotguns for example
    [SerializeField]
    private int _ammoPerShot = 1;

    [SerializeField]
    private float _shotSpread = 0.1f;

    [SerializeField]
    private float _reloadTime = 0.5f;

    [SerializeField]
    private int _clipSize = 10;
    
    private int _ammo = 30, _ammoInClip;
    private float _reloadTimer = 0, _shotTimer = 0;
    private bool _isReloading = false;
    
    void Start()
    {
        _ammoInClip = _clipSize;
    }

    public void Shoot(Transform shooter)
    {
        if(_shotTimer >= _shootSpeed && _ammoInClip > 0 && !_isReloading)
        {
            for(int i = 0; i < _ammoPerShot; i++)
            {
                if (_ammoInClip == 0)
                    break;

                float angle = Random.Range(-_shotSpread, _shotSpread);
                Quaternion rotation = shooter.rotation;
                rotation.z += angle;
                
                Instantiate(Bullet, BulletExit.position, rotation, null);
                _ammoInClip--;
            }
            PlaySound(ShootAudio);
            _shotTimer = 0;
        }else if(_ammoInClip == 0 && _shotTimer >= _shootSpeed && !_isReloading)
        {
            PlaySound(EmptyAudio);
            _shotTimer = 0;
        }
    }

    public void Reload()
    {
        _isReloading = true;
        PlaySound(ReloadAudio);
    }

    private void PlaySound(AudioClip clip)
    {
        if(clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
    }

    void Update()
    {
        if(_isReloading)
        {
            if(_reloadTimer >= _reloadTime)
            {
                if(_ammo > _clipSize)
                {
                    int ammoToAdd = _clipSize - _ammoInClip;
                    _ammoInClip = _clipSize;
                    _ammo -= ammoToAdd;
                }else
                {
                    int ammoToAdd = _clipSize - _ammoInClip;
                    if(_ammo > ammoToAdd)
                    {
                        _ammoInClip += ammoToAdd;
                        _ammo -= ammoToAdd;
                    }else
                    {
                        _ammoInClip += _ammo;
                        _ammo = 0;
                    }
                }
                _reloadTimer = 0;
                _isReloading = false;
            }
            _reloadTimer += Time.deltaTime;
        }

        if (_shotTimer < _shootSpeed)
            _shotTimer += Time.deltaTime;
    }

}
