using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {
    
    [Header("References")]
    [SerializeField] public GunData gunData;
    [SerializeField] public PlayerData playerData;
    private Transform cam;
    float timeSinceLastShot;
    public static Action shootInput;
    public static Action reloadInput;
    [SerializeField] public AudioSource gunShot;
    public float PlayerFireRate;
    public float PlayerDamage;
    public int PlayerAmmo;
    protected AudioSource emptyShot;
    
    private GameObject crosshair;
    private Texture2D crosshairImage;
    private Texture2D hitIndicator;

    private void Start() {
        shootInput += Shoot;
        reloadInput += StartReload;
        cam = GameObject.FindWithTag("MainCamera").transform;
        PlayerFireRate = (gunData.fireRate * playerData.FireRateModifier);
        PlayerDamage = (gunData.damage * playerData.PlayerDamageModifier);
        PlayerAmmo = (gunData.magSize * playerData.AmmoModifier);
        emptyShot = GameObject.FindWithTag("Player").GetComponent<PlayerStats>().emptyClip;

        crosshair = GameObject.FindWithTag("Crosshair");
        crosshairImage = crosshair.GetComponent<CrossHairHolder>().crosshair;
        hitIndicator = crosshair.GetComponent<CrossHairHolder>().onHit;
    
    }

    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (PlayerFireRate / 60f);

    public void Shoot() {
        if (gunData.currentAmmo == 0) {
            if(!emptyShot.isPlaying) emptyShot.Play();
        }

        if (gunData.currentAmmo > 0) {
            if (CanShoot()) {
                if (Physics.Raycast(cam.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance) && hitInfo.transform.tag == "Enemies") {
                    EnemyAI enemy = hitInfo.transform.GetComponent<EnemyAI>();
                    enemy?.TakeDamage(PlayerDamage);
                    StartCoroutine(showHitIndicator());
                }
                
                gunData.currentAmmo--;
                gunShot.PlayOneShot(gunShot.clip, 1f);
                timeSinceLastShot = 0;
                OnGunShot();
                cam.GetComponent<PlayerCam>().Recoil(gunData.recoilValue * 5);
            }
        }
    }

    private void StartReload() {
        Debug.Log("Reload Key pressed");
        if (gunData.currentAmmo < PlayerAmmo) {
            Debug.Log("Reloading");
            if (!gunData.reloading) {
                StartCoroutine(Reload());
            }
        }
    }

    private IEnumerator Reload() {
        gunData.reloading = true;
        yield return new WaitForSeconds(gunData.reloadTime);
        gunData.currentAmmo = PlayerAmmo;
        gunData.reloading = false;
    }

    private void Update() {
        if (Input.GetMouseButton(0)) {
            Shoot();
        }

        if (gunData.currentAmmo == 0) gunShot.Stop();

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

    IEnumerator showHitIndicator() {
        crosshair.GetComponent<RawImage>().texture = hitIndicator;
        crosshair.GetComponent<AudioSource>().PlayOneShot(crosshair.GetComponent<AudioSource>().clip, 1f);
        yield return new WaitForSeconds(0.2f);
        crosshair.GetComponent<RawImage>().texture = crosshairImage;

    }   
}   
