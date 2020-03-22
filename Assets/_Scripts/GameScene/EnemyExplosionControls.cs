using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosionControls : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Destroyer());
    }

    IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
