using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterReference;

    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnedMonster;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters() {

        while ( true ) {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range( 0, monsterReference.Length );

            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if ( randomSide == 0 ) {    // left side
                spawnedMonster.transform.position = leftPos.position;   // puts the monster on the left
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);     // goes to right
            } else {    // right side
                spawnedMonster.transform.position = rightPos.position;  // puts the monster on the right
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);    // goes to left
                spawnedMonster.transform.localScale = new Vector3( -1f, 1f, 1f );
            }
        }   // while loop
    }   // IEnumerator

}   // class