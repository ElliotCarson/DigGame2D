using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnerScript : MonoBehaviour {


    public GameObject grass;
    public GameObject dirt;
    public GameObject stone;
    public GameObject coal;
    public GameObject copper;
    public GameObject iron;
    public GameObject gold;
    public GameObject diamond;
    public GameObject platnium;
    public GameObject uranium;
    int rowLength = 30;
    int depth = 0;
    Rigidbody2D rb;
    float maxPlayerDepth = 0;
    int STONE_SPAWN_PERCENT = 60;

    // Use this for initialization
    void Start()
    {
        rb = player_controller.instance.rb;
        for(int i = 0; i < 30; i++)
        {
            SpawnRow();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 tempPos = rb.position;
        if (tempPos.y < maxPlayerDepth)
        {
            maxPlayerDepth = tempPos.y;
        }
        if((int)maxPlayerDepth < -(depth-20))
        {
            SpawnRow();
        }
    }

    void SpawnRow()
    {
        Vector3 currentPos = Vector3.zero;
        currentPos.y = (float)4.5 - depth;
        currentPos.x = (float)0.5;
        currentPos.z = 150;

        if (depth == 0)
        {
            for (int i = 0; i < rowLength; i++)
            {
                //transf.position = currentPos;
                Instantiate(grass, currentPos, Quaternion.identity);
                currentPos.x++;
            }
        }
        // Spawn Row of dirt below grass
        /*else if (depth == 1)
        {
            for (int i = 0; i < rowLength; i++)
            {
                //transf.position = currentPos;
                Instantiate(dirt, currentPos, Quaternion.identity);
                currentPos.x++;
            }
        }
        */
        else if (depth < 4)
        {
            for (int i = 0; i < rowLength; i++)
            {
                if (Random.Range(0, 100) > 50)
                {
                    Instantiate(dirt, currentPos, Quaternion.identity);
                }
                else
                {
                    Instantiate(stone, currentPos, Quaternion.identity);
                }
                currentPos.x++;
            }
        }
        /*
        else if (depth < 8)
        {
            for (int i = 0; i < rowLength; i++)
            {
                //transf.position = currentPos;
                Instantiate(stone, currentPos, Quaternion.identity);
                currentPos.x++;
            }
        }
        */
        else if (depth < 10)
        {
            for (int i = 0; i < rowLength; i++)
            {
                //if true spawn ore
                if (Random.Range(0, 100) > 90)
                {
                    //50-50 coal/copper
                    if (Random.Range(0, 100) > 50)
                    {
                        Instantiate(coal, currentPos, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(copper, currentPos, Quaternion.identity);
                    }
                }
                //spawn stone
                else
                {
                    Instantiate(stone, currentPos, Quaternion.identity);
                }
                currentPos.x++;
            }
        }
        else if (depth < 20)
        {
            for (int i = 0; i < rowLength; i++)
            {
                //if true spawn ore
                if (Random.Range(0, 100) > STONE_SPAWN_PERCENT)
                {
                    //45-45-10 coal/copper/Iron
                    int tempRand = Random.Range(0, 100);
                    if (tempRand < 45)
                    {
                        Instantiate(coal, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 90)
                    {
                        Instantiate(copper, currentPos, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(iron, currentPos, Quaternion.identity);
                    }
                }
                //spawn stone
                else
                {
                    Instantiate(stone, currentPos, Quaternion.identity);
                }
                currentPos.x++;
            }
        }
        else if (depth < 40)
        {
            for (int i = 0; i < rowLength; i++)
            {
                //if true spawn ore
                if (Random.Range(0, 100) > STONE_SPAWN_PERCENT)
                {
                    //33-33-34 coal/copper/Iron
                    int tempRand = Random.Range(0, 100);
                    if (tempRand < 33)
                    {
                        Instantiate(coal, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 66)
                    {
                        Instantiate(copper, currentPos, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(iron, currentPos, Quaternion.identity);
                    }
                }
                //spawn stone
                else
                {
                    Instantiate(stone, currentPos, Quaternion.identity);
                }
                currentPos.x++;
            }
        }
        else if (depth < 70)
        {
            for (int i = 0; i < rowLength; i++)
            {
                //if true spawn ore
                if (Random.Range(0, 100) > STONE_SPAWN_PERCENT)
                {
                    //10-45-45 coal/copper/Iron
                    int tempRand = Random.Range(0, 100);
                    if (tempRand < 10)
                    {
                        Instantiate(coal, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 55)
                    {
                        Instantiate(copper, currentPos, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(iron, currentPos, Quaternion.identity);
                    }
                }
                //spawn stone
                else
                {
                    Instantiate(stone, currentPos, Quaternion.identity);
                }
                currentPos.x++;
            }
        }
        else if (depth < 80)
        {
            for (int i = 0; i < rowLength; i++)
            {
                //if true spawn ore
                if (Random.Range(0, 100) > STONE_SPAWN_PERCENT)
                {
                    //5-40-40-8-7 coal/copper/iron/gold/platnium
                    int tempRand = Random.Range(0, 100);
                    if (tempRand < 5)
                    {
                        Instantiate(coal, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 45)
                    {
                        Instantiate(copper, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 85)
                    {
                        Instantiate(iron, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 93)
                    {
                        Instantiate(gold, currentPos, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(platnium, currentPos, Quaternion.identity);
                    }
                }
                //spawn stone
                else
                {
                    Instantiate(stone, currentPos, Quaternion.identity);
                }
                currentPos.x++;
            }
        }
        else if (depth < 110)
        {
            for (int i = 0; i < rowLength; i++)
            {
                //if true spawn ore
                if (Random.Range(0, 100) > STONE_SPAWN_PERCENT)
                {
                    //5-5-30-30-30 coal/copper/iron/gold/platnium
                    int tempRand = Random.Range(0, 100);
                    if (tempRand < 5)
                    {
                        Instantiate(coal, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 10)
                    {
                        Instantiate(copper, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 40)
                    {
                        Instantiate(iron, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 70)
                    {
                        Instantiate(gold, currentPos, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(platnium, currentPos, Quaternion.identity);
                    }
                }
                //spawn stone
                else
                {
                    Instantiate(stone, currentPos, Quaternion.identity);
                }
                currentPos.x++;
            }
        }
        else if (depth < 120)
        {
            for (int i = 0; i < rowLength; i++)
            {
                //if true spawn ore
                if (Random.Range(0, 100) > STONE_SPAWN_PERCENT)
                {
                    //5-5-25-25-25 coal/copper/iron/gold/platnium/diamond/uranium
                    int tempRand = Random.Range(0, 100);
                    if (tempRand < 5)
                    {
                        Instantiate(coal, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 10)
                    {
                        Instantiate(copper, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 35)
                    {
                        Instantiate(iron, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 60)
                    {
                        Instantiate(gold, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 85)
                    {
                        Instantiate(platnium, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 95)
                    {
                        Instantiate(diamond, currentPos, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(uranium, currentPos, Quaternion.identity);
                    }
                }
                //spawn stone
                else
                {
                    Instantiate(stone, currentPos, Quaternion.identity);
                }
                currentPos.x++;
            }
        }
        else
        {
            for (int i = 0; i < rowLength; i++)
            {
                //if true spawn ore
                if (Random.Range(0, 100) > STONE_SPAWN_PERCENT)
                {
                    //5-5-25-25-25 coal/copper/iron/gold/platnium/diamond/uranium
                    int tempRand = Random.Range(0, 100);
                    if (tempRand < 5)
                    {
                        Instantiate(coal, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 10)
                    {
                        Instantiate(copper, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 35)
                    {
                        Instantiate(iron, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 60)
                    {
                        Instantiate(gold, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 85)
                    {
                        Instantiate(platnium, currentPos, Quaternion.identity);
                    }
                    else if (tempRand < 95)
                    {
                        Instantiate(diamond, currentPos, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(uranium, currentPos, Quaternion.identity);
                    }
                }
                //spawn stone
                else
                {
                    Instantiate(stone, currentPos, Quaternion.identity);
                }
                currentPos.x++;
            }
        }
        SpawnRowSides();
        depth++;
    }

    // Spawn Blocks that are out of bounds
    void SpawnRowSides()
    {
        Vector3 currentPos = Vector3.zero;
        currentPos.y = (float)4.5 - depth;
        currentPos.x = (float)-4.5;
        currentPos.z = 150;

        //Spawn blocks on the left side of the screen
        for (int i = 0; i < 5; i++)
        {
            Instantiate(stone, currentPos, Quaternion.identity); //change stone to special edge block
            currentPos.x++;
        }
        currentPos.x += rowLength;
        //spawn blocks on the right side of the screen
        for (int i = 0; i < 5; i++)
        {
            Instantiate(stone, currentPos, Quaternion.identity); //change stone to special edge block
            currentPos.x++;
        }
    }

}
