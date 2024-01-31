using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    public Transform inkSpawnPoint;
    public GameObject inkPrefab;
    public float inkSpeed = 1;
    public float minFireRate = 0.5f; // Mínimo intervalo de tiempo entre las balas
    public float maxFireRate = 2.0f; // Máximo intervalo de tiempo entre las balas

    private void Start()
    {
        StartCoroutine(FireInkRandomly());
    }

    private IEnumerator FireInkRandomly()
    {
        while (true)
        {
            // Espera un tiempo aleatorio entre balas
            yield return new WaitForSeconds(Random.Range(minFireRate, maxFireRate));

            // Llama al método FireBullet() para instanciar una bala
            FireBullet();
        }
    }

    private void FireBullet()
    {
        var bullet = Instantiate(inkPrefab, inkSpawnPoint.position, inkSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = inkSpawnPoint.up * inkSpeed;
    }
}