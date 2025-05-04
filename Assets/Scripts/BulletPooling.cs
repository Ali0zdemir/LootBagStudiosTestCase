using UnityEngine;
using System.Collections.Generic;

public class BulletPooling : MonoBehaviour
{
    public static BulletPooling instance;
    private List<GameObject> pooledBullets = new List<GameObject>();
    private int amountToPool = 5;
    [SerializeField] private GameObject bulletPrefab;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        for(int i=0;i<amountToPool;i++){
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledBullets.Add(obj);
        }
    }

    public GameObject GetPooledBullet()
    {
        for(int i=0;i<pooledBullets.Count;i++){
            if(!pooledBullets[i].activeInHierarchy){
                return pooledBullets[i];
            }
        }
        
        return null;
    }
}
