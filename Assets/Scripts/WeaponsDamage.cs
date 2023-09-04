using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsDamage : MonoBehaviour
{
    public float damage;
    public float bulletSpeed;
    public ParticleSystem expolsion;
    AudioSource audioSource;
    public AudioClip expolsionSfx;
    bool isMoveing;
    bool once;

    private void Start()
    {
        if (transform.name != "cutter")
        {
            once = true;
            isMoveing = true;
        }

    }
    void Update()
    {
        if (isMoveing == true && transform.name != "cutter")
            transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.name != "cutter")
        {

            if (gameObject.tag == "PlayerWeapon" && other.gameObject.tag == "EnemyUnit")
            {
                // expolsion efekti sadece Top da var
                if (expolsion != null)
                {
                    if (once == true)
                    {
                        expolsion.Play();
                        audioSource = GetComponent<AudioSource>();
                        audioSource.PlayOneShot(expolsionSfx);
                        gameObject.GetComponent<MeshRenderer>().enabled = false;
                        //Top un etki edebileceði alan arttýrýldý
                        gameObject.GetComponent<SphereCollider>().radius = 4;
                        once = false;
                        isMoveing = false;
                    }
                    Destroy(gameObject, 4);
                }

                else
                    Destroy(gameObject);
            }

            if (gameObject.tag == "EnemyWeapon" && other.gameObject.tag == "PlayerUnit")
            {
                // expolsion efekti sadece Top da var
                if (expolsion != null)
                {
                    if (once == true)
                    {
                        expolsion.Play();
                        audioSource = GetComponent<AudioSource>();
                        audioSource.PlayOneShot(expolsionSfx);
                        gameObject.GetComponent<MeshRenderer>().enabled = false;
                        //Top un etki edebileceði alan arttýrýldý
                        gameObject.GetComponent<SphereCollider>().radius = 4;
                        once = false;
                        isMoveing = false;
                    }
                    Destroy(gameObject, 4);
                }

                else
                    Destroy(gameObject);
            }
        }

    }
}
