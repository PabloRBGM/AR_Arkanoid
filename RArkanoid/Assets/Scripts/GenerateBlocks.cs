using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlocks : MonoBehaviour
{
    public GameObject block;

    private BlocksSamples blocksSamples;
    private Blocks level;
    //int nb;
    //int lvl;
    private void Awake()
    {
        blocksSamples = new BlocksSamples(); 
        //nb = 0;
        //lvl = 0;
    }

    //private void Update()
    //{
       
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        lvl = (lvl + 1) % 10;
    //        clearBlocks(lvl, ref nb);
    //        Debug.Log(nb);
    //    }
    //}
    public void generateBlocks(int lvl, ref int nblocks)
    {
        level = blocksSamples.samples[lvl];
        nblocks = level.nItems;
        for (int i = 0; i < level.mat.GetLength(0); i++)
        {
            for (int j = 0; j < level.mat.GetLength(1); j++)
            {
                if (level.mat[i,j] == 1)
                {
                    GameObject go = Instantiate(block, transform, false);
                    go.transform.localPosition = new Vector3(j, 0, -i * 0.5f);
                }
            }
        }

    }

    public void clearBlocks(int lvl, ref int nblocks)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        generateBlocks(lvl, ref nblocks);
    }
}
