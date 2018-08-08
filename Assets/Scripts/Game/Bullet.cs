using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    public float bulletSpeed = 30;

    public float lifeTime = 3;

	
	
	

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }

    public void Atirar()
    {


        GameObject bullet = Instantiate(bulletPrefab);

        //Physics.IgnoreCollision(bullet.GetComponent<Collider>(), bulletSpawn.parent.GetComponent<Collider>());

        bullet.transform.position = bulletSpawn.position;

        var rot = bullet.transform.rotation.eulerAngles;

        bullet.transform.rotation = Quaternion.Euler(rot.x, transform.eulerAngles.y, rot.z);

        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
    }
}
