using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Effects : MonoBehaviour
{
    AudioSource audioSource;
    Animator animator;
    UnitController unitController;
    public Transform bulletPos;
    public GameObject bulletPrefab;
    public AudioClip swingSword;
    public AudioClip swordHit;
    public AudioClip smg;
    public AudioClip musketeer;
    public AudioClip machinegun;
    public AudioClip cannon;
    public ParticleSystem muzzleFlash;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        unitController = transform.parent.GetComponent<UnitController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AttackAnim()
    {
        animator.speed = 1 / unitController.attackSpeed;
        animator.SetBool("Attack", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Run", false);
    }

    public void IdleAnim()
    {
        animator.speed = 1;
        animator.SetBool("Idle", true);
        animator.SetBool("Run", false);
        animator.SetBool("Attack", false);
    }

    public void RunAnim()
    {
        animator.speed = 1;
        animator.SetBool("Run", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Attack", false);

    }

    public void SwingSwordEffect()
    {
        audioSource.PlayOneShot(swingSword);
    }
    public void SwordHitEffect()
    {
        audioSource.PlayOneShot(swordHit);
    }
    public void MusketeerEffect()
    {
        GameObject obj = Instantiate(bulletPrefab, bulletPos.position, transform.parent.transform.rotation);
        Destroy(obj, 2);
        audioSource.PlayOneShot(musketeer);
        muzzleFlash.Play();
    }
    public void SmgEffect()
    {
        GameObject obj = Instantiate(bulletPrefab, bulletPos.position, transform.parent.transform.rotation);
        Destroy(obj, 2);
        audioSource.PlayOneShot(smg);
        muzzleFlash.Play();
    }
    public void MachinegunEffect()
    {
        GameObject obj = Instantiate(bulletPrefab, bulletPos.position, transform.parent.transform.rotation);
        Destroy(obj, 2);
        audioSource.PlayOneShot(machinegun);
        muzzleFlash.Play();
    }

    public void CannonEffect()
    {
        GameObject obj = Instantiate(bulletPrefab, bulletPos.position, transform.parent.transform.rotation);
        Destroy(obj, 2);
        audioSource.PlayOneShot(cannon);
        muzzleFlash.Play();
    }
}
