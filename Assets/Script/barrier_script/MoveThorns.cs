using System.Collections;
using UnityEngine;

public class MoveThorns : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float Time = 2;
    public float dist = 2;
    [Header("по какой оси передвигать(true=x)")]
    public bool flagXorY = true;
    public bool flagZ = false;

    private void Start()
    {
        if (flagXorY)
        {
            StartCoroutine(MoveX());
        }
        else if (flagZ)
        {
            StartCoroutine(MoveZ());
        }
        else
        {
            StartCoroutine(MoveY());
        }
       
    }
    private IEnumerator MoveX()
    {
        while (true)
        {
            yield return StartCoroutine(Utils.MoveToTarget(EnemyPrefab.transform, new Vector3(EnemyPrefab.transform.position.x + dist, EnemyPrefab.transform.position.y , EnemyPrefab.transform.position.z)));
            yield return new WaitForSeconds(Time);
            yield return StartCoroutine(Utils.MoveToTarget(EnemyPrefab.transform, new Vector3(EnemyPrefab.transform.position.x - dist, EnemyPrefab.transform.position.y , EnemyPrefab.transform.position.z)));
            yield return new WaitForSeconds(Time);
        }
    }
    private IEnumerator MoveY()
    {
        while (true)
        {
            yield return StartCoroutine(Utils.MoveToTarget(EnemyPrefab.transform, new Vector3(EnemyPrefab.transform.position.x, EnemyPrefab.transform.position.y+dist, EnemyPrefab.transform.position.z)));
            yield return StartCoroutine(Utils.MoveToTarget(EnemyPrefab.transform, new Vector3(EnemyPrefab.transform.position.x, EnemyPrefab.transform.position.y - dist, EnemyPrefab.transform.position.z)));
            yield return new WaitForSeconds(Time);
        }
    }
    private IEnumerator MoveZ()
    {
        while (true)
        {
            yield return StartCoroutine(Utils.MoveToTarget(EnemyPrefab.transform, new Vector3(EnemyPrefab.transform.position.x, EnemyPrefab.transform.position.y , EnemyPrefab.transform.position.z + dist)));
            yield return StartCoroutine(Utils.MoveToTarget(EnemyPrefab.transform, new Vector3(EnemyPrefab.transform.position.x, EnemyPrefab.transform.position.y , EnemyPrefab.transform.position.z - dist)));
            yield return new WaitForSeconds(Time);
        }
    }
}
