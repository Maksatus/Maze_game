using System.Collections;
using UnityEngine;

public class MoveThorns : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float dist = 2;

    private void Start()
    {
        StartCoroutine(CoroutSample());
    }

    private IEnumerator CoroutSample()
    {
        while (true)
        {
            yield return StartCoroutine(Utils.MoveToTarget(EnemyPrefab.transform, new Vector3(EnemyPrefab.transform.position.x, EnemyPrefab.transform.position.y+dist, EnemyPrefab.transform.position.z)));
            yield return StartCoroutine(Utils.MoveToTarget(EnemyPrefab.transform, new Vector3(EnemyPrefab.transform.position.x, EnemyPrefab.transform.position.y - dist, EnemyPrefab.transform.position.z)));
            yield return new WaitForSeconds(2);
        }

    }
}
