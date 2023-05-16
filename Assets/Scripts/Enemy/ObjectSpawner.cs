using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Enemies
{
    public class ObjectSpawner : MonoBehaviour
    {


        [SerializeField] private Transform[] Spawners;


        [SerializeField] private EnemyStorage ObjectStorage;
        [SerializeField] private GameObject Boss;

        
        private float SpawnTime = 3f;

        public int MaximumLevelDeathCount;
        public static int EnemyDeathCount;




        private void OnEnable()
        {
            for (int i = 0; i < ObjectStorage.Enemies.Length; i++)
            {
                GameObject _enemies = Instantiate(ObjectStorage.Enemies[i]);

                _enemies.transform.SetParent(gameObject.transform);

                _enemies.SetActive(false);
            }



            InvokeRepeating("SpawnEnemies", 1f, SpawnTime);
        }

        private void Update()
        {
            if(EnemyDeathCount >= MaximumLevelDeathCount)
            {
                int RandomSpawner = Random.Range(0, Spawners.Length);

                GameObject NewBoss = Instantiate(Boss);

                NewBoss.transform.SetParent(gameObject.transform);
                NewBoss.transform.position = Spawners[RandomSpawner].transform.position;

                EnemyDeathCount = 0;
            }
        }






        private void SpawnEnemies()
        {
            int RandomMonster = Random.Range(0, ObjectStorage.Enemies.Length);
            int RandomSpawner = Random.Range(0, Spawners.Length);


            bool MonsterActiveInScene = gameObject.transform.GetChild(RandomMonster).gameObject.activeInHierarchy;

            if (!MonsterActiveInScene)
            {
                transform.GetChild(RandomMonster).gameObject.SetActive(true);
                transform.GetChild(RandomMonster).position = Spawners[RandomSpawner].position;
            }
        }

      

     
     

        

        
    }
}
