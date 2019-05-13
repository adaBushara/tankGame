using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{

    public GameObject GrassLeft;

    public GameObject GrassRight;

    public GameObject GrassMiddle;

    //this is the lower object (sand tiles)
    public GameObject SandTile;

    public Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTerrain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTerrain()
    {

        float minX, maxX;
        minX = -MainCamera.orthographicSize * MainCamera.aspect;
        maxX = minX * -1;
        Debug.Log(minX);
        int numBlocks = (int)(maxX * 2);
        Vector2 blockSize = SandTile.GetComponent<BoxCollider2D>().size;
        numBlocks = (int)(numBlocks / blockSize.x);
        float currentPos = minX;

        //grass row
        for (int i=-1; i <= numBlocks; i++)
        {
            GameObject sObject = Instantiate<GameObject>(GrassMiddle, MainCamera.transform);
            sObject.transform.localPosition = new Vector3(currentPos, 0, 10);
            currentPos += blockSize.x;
        }

        float minY = -MainCamera.orthographicSize;
        int numBlocksVert =(int)( minY * -1);
        numBlocksVert = Mathf.FloorToInt(numBlocksVert / blockSize.y);
        Vector2 blockpos = new Vector2(0, 0);
        for (int j = 0; j < numBlocksVert; j++)
        {
            blockpos.x = minX;
            blockpos.y -= blockSize.y;
            for (int i = -1; i <= numBlocks; i++)
            {
                GameObject sObject = Instantiate<GameObject>(SandTile, MainCamera.transform);
                sObject.transform.localPosition = new Vector3(blockpos.x, blockpos.y, 10);
                blockpos.x += blockSize.x;
            }
        }
       


    }
}
