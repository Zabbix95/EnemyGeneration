using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform[] _dotsSpawn;
    [SerializeField] private int EnemyCount = 0;
    [SerializeField] private Collider[] colliders;

    private void OnEnable()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        _dotsSpawn = gameObject.GetComponentsInChildren<Transform>();
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    private IEnumerator Spawn()
    {
        while (EnemyCount < 4)
        {
            Transform spawnPosition = _dotsSpawn[Random.Range(1, _dotsSpawn.Length)].GetComponent<Transform>();            
            Collider[] intersecting = Physics.OverlapSphere(spawnPosition.transform.position, 1f, 1 << 6);            
            if (intersecting.Length == 0)
            {                
                Instantiate(enemy, new Vector3(spawnPosition.position.x, 0f, spawnPosition.position.z), Quaternion.identity);
                EnemyCount++;
                yield return new WaitForSeconds(2f);                
            }            
        }
    }
}
