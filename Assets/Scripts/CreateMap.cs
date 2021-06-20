using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    int _mapMinX;
    int _mapMinY;
    int _mapMaxX;
    int _mapMaxY;
    int _splitNum;
    Cell[,] _cells = null;
    private void Start()
    {
        
    }
    public void CreateRoom(int minX, int minY, int maxX, int maxY, int splitNum, Cell[,] cells)
    {
        if (maxX - minX > maxY - minY)
        {

        }
        else
        {

        }
    }
}
