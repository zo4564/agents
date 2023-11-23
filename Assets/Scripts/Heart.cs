using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using UnityEditor.Experimental.GraphView;
using System.Linq;

public class Heart : MonoBehaviour
{
    public Vector3 originOffset;

    public GameObject[] PossibleCells;

    public int[,] Cells;

    public int size;

    GameObject centerObject;

    GameObject newCell;

    public bool hasMover = false;
    // Start is called before the first frame update
    void Start()
    {

        Cells = new int[size, size];
        GenerateCells();
       

    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = mover.transform.position + moverOffset;
    }

    void RandomSpawn(float width, float height)
    {
        Vector3 minPosition = new Vector3(-width, 0f, -height);
        Vector3 maxPosition = new Vector3(width, 0f, height);

        float randomX = UnityEngine.Random.Range(minPosition.x, maxPosition.x);
        float randomZ = UnityEngine.Random.Range(minPosition.z, maxPosition.z);

        transform.position = new Vector3(randomX, 0, randomZ);
    }

    void PlaceHeart()
    {

    }
    void GenerateCells()
    {
        Random rnd = new Random();

        //place heart
        int xHeart = rnd.Next(0, size);
        int yHeart = rnd.Next(0, size);
        Cells[xHeart, yHeart] = 99;

        //set heart as center (parent) cell
        (int xIndex, int yIndex) centerCell = (xHeart, yHeart);

        //generate rest of the cells
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                if (!(x == xHeart && y == yHeart))
                {
                    if (x >= xHeart - 1 && x <= xHeart + 1 && y >= yHeart - 1 && y <= yHeart + 1)
                    {
                        Cells[x, y] = rnd.Next(0, PossibleCells.Length + 1);
                    }
                    else Cells[x, y] = 0;



                }
            }
        }

        //count movers
        List<(int, int)> movers = new List<(int, int)>();
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                if (Cells[x, y] == 4)
                {
                    hasMover = true;
                    (int xIndex, int yIndex) mover = (x, y);
                    movers.Add(mover);
                    Debug.Log(mover);
                }
            }
        }
        int howManyMovers = movers.Count;

        //set one mover to be center cell and remove other movers
        if (howManyMovers > 0)
        {
            centerCell = movers[rnd.Next(0, howManyMovers)];
            foreach ((int xIndex, int yIndex) mover in movers)
            {
                if (mover != centerCell)
                {
                    Cells[mover.xIndex, mover.yIndex] = rnd.Next(0, PossibleCells.Length);
                    Debug.Log("bum");
                }
            }
        }

        //spawn center (parent) cell
        if (hasMover)
        {
            centerObject = Instantiate(PossibleCells[3], Vector3.zero, Quaternion.identity);
            originOffset = new Vector3((xHeart - centerCell.xIndex) * 10, 0, (yHeart - centerCell.yIndex) * 10);
            transform.position = centerObject.transform.position + originOffset;
            transform.SetParent(centerObject.transform, true);
        }
        else
        {
            centerObject = this.gameObject;
            RandomSpawn(380, 210);
        }

        //spawn rest of cells
       for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                if (Cells[x, y] == 0) break;
                int xIndex = centerCell.xIndex;
                int yIndex = centerCell.yIndex;
                if(!(x == xIndex && y == yIndex) && (!(x == xHeart && y == yHeart)))
                {
                    originOffset = new Vector3((x - xIndex) * 10, 0, (y - yIndex) * 10);
                    Debug.Log(Cells[x, y] - 1);
                    newCell = Instantiate(PossibleCells[Cells[x, y] - 1], Vector3.zero, Quaternion.identity);
                    newCell.transform.position = centerObject.transform.position + originOffset;
                    newCell.transform.SetParent(centerObject.transform, true);
                }
            }
        }
    }
}
