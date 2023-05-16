using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Enemies
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject[] Enemies;
        [SerializeField] private Transform[] Spawners;

        private float StartingTime = 1f;
        private float SpawnTimeBuffer = 3f;

        private void OnEnable()
        {
            for(int i = 0; i < Enemies.Length; i++)
            {

                GameObject _enemies = Instantiate(Enemies[i]);

                _enemies.transform.SetParent(transform);

                _enemies.SetActive(false);


            }


            InvokeRepeating("SpawnEnemies", StartingTime, SpawnTimeBuffer);

        }

        private void SpawnEnemies()
        {
            int RandomEnemy = Random.Range(0, Enemies.Length);
            int RandomSpawner = Random.Range(0, Spawners.Length);

            bool MonsterActiveInHierachy = transform.GetChild(RandomEnemy).gameObject.activeInHierarchy;

            if (!MonsterActiveInHierachy)
            {
                transform.GetChild(RandomEnemy).gameObject.SetActive(true);

                transform.GetChild(RandomEnemy).transform.position = Spawners[RandomSpawner].position;

            }

        }




    }
}
