using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public Vector3 moverOffset;

    public GameObject[] PossibleCells;

    public int[] Cells;

    GameObject moverObject;
    // Start is called before the first frame update
    void Start()
    {
        Cells = new int[2];

        Cells[0] = 0;
        Cells[1] = 1;

        moverOffset = new Vector3(0, 0, 10);

        moverObject = Instantiate(PossibleCells[0], Vector3.zero, Quaternion.identity);
        transform.position = moverObject.transform.position + moverOffset;
        transform.SetParent(moverObject.transform, true);
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = mover.transform.position + moverOffset;
    }
}
