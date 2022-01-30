using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticleInAnimation : MonoBehaviour
{
    public GameObject esspressoPourParticle;
    public Transform spawnLocation;
    public void SpawnParticleEffect()
    {
        var pour = Instantiate(esspressoPourParticle, spawnLocation.position, Quaternion.identity);
        float destroyTimer = 2f;
        Destroy(pour, destroyTimer);
    }
}
