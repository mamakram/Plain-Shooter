using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public EnemySpawner enemySpawner;


    // Update is called once per frame
    protected override void Died()
    {
        base.Died();
        enemySpawner.BossDied();
    }

    public void SetSpawner(EnemySpawner e)
    {
        enemySpawner = e;
    }
}
