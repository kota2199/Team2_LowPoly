using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySporn : MonoBehaviour
{
    [SerializeField]
    private float maxX, minX, maxZ, minZ;

    private float posX, posZ;

    [SerializeField]
    private int spornInterval;

    [SerializeField]
    private int minEnemyJud, maxEnemyJudl;

    private int enemyJudge;

    private Vector3 spornPoint;

    [SerializeField]
    private GameObject arrowEnemy, punchEnemy;

    private GameObject spornedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Sporn");
        enemyJudge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spornPoint = new Vector3(posX, 0, posZ);
    }

    private IEnumerator Sporn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spornInterval);
            posX = Random.Range(minX,maxX);
            posZ = Random.Range(minZ,maxZ);
            enemyJudge = Random.Range(minEnemyJud,maxEnemyJudl);
            if (enemyJudge == 0)
            {
                spornedEnemy = punchEnemy;
            }
            if (enemyJudge == 1)
            {
                spornedEnemy = arrowEnemy;
            }
            Instantiate(spornedEnemy,spornPoint,Quaternion.identity);
        }
    }
}
