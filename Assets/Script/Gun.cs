using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour {
    [Header("References")]
    [SerializeField] public GunData gunData;
    private Transform cam;

    float timeSinceLastShot;

    public static Action shootInput;
    public static Action reloadInput;
    [SerializeField] public AudioSource gunShot;
    private void Start() {
        shootInput += Shoot;
        reloadInput += StartReload;
        cam = GameObject.FindWithTag("MainCamera").transform;
    }

    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    public void Shoot() {
        
        if (gunData.currentAmmo > 0) {
            if (CanShoot()) {
                if (Physics.Raycast(cam.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance)) {
                    Debug.DrawRay(cam.position, transform.forward, Color.blue, 30);
                    EnemyAI enemy = hitInfo.transform.GetComponent<EnemyAI>();
                    enemy?.TakeDamage(gunData.damage);
                }
                

                gunData.currentAmmo--;
                gunShot.Play();
                timeSinceLastShot = 0;
                OnGunShot();
                cam.GetComponent<PlayerCam>().Recoil(gunData.recoilValue * 5);
            }
        }
    }

    private void StartReload() {
        Debug.Log("Reload Key pressed");
        if (gunData.currentAmmo < gunData.magSize) {
            Debug.Log("Reloading");
            if (!gunData.reloading) {
                StartCoroutine(Reload());
            }
        }
    }

    private IEnumerator Reload() {
        gunData.reloading = true;
        yield return new WaitForSeconds(gunData.reloadTime);
        gunData.currentAmmo = gunData.magSize;
        gunData.reloading = false;
    }

    private void Update() {
        if (Input.GetMouseButton(0)) {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            StartReload();
        }

        timeSinceLastShot += Time.deltaTime;
        Debug.DrawRay(cam.position, cam.forward * gunData.maxDistance);

        if (Input.GetKeyDown(KeyCode.R)) {
            reloadInput?.Invoke();
        }

        if(gunData.reloading) {
            transform.localRotation = Quaternion.Euler(-45,0,0);
        }
        else {
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
    }

    private void OnGunShot() {
        Debug.Log("Fired Gun");
    }
}
