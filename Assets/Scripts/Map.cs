using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    [SerializeField] Cell cellPefab;
    int _mapMinX = 0;
    int _mapMinY = 0;
    [SerializeField] int _mapMaxX = 20;
    [SerializeField] int _mapMaxY = 20;
    const int _minRoomSpritNum = 4;
    [SerializeField] int _splitNum = 0;
    Cell[,] _cells = null;
    private void Start()
    {
        _cells = new Cell[_mapMaxX, _mapMaxY];
        for (int y = 0; y < _mapMaxY; y++)
        {
            for (int x = 0; x < _mapMaxX; x++)
            {
                var cell = Instantiate(cellPefab, this.transform);
                cell.MapState = MapStates.Wall;
                _cells[x, y] = cell;
                _cells[x, y].transform.position = new Vector3(x * 1.5f, y * 1.5f);
            }
        }
        SplitRoom(_mapMinX, _mapMinY, _mapMaxX, _mapMaxY, _splitNum, _cells);
    }
    public void SplitRoom(int minX, int minY, int maxX, int maxY, int splitNum, Cell[,] cells)
    {
        int xLineNum;
        int yLineNum;
        int subSplitNum = splitNum + 1;
        if (splitNum == 0) return;
        while (splitNum > 0)
        {
            if (maxX - minX > _minRoomSpritNum * 2 || maxY - minY > _minRoomSpritNum * 2)
            {
                int rand = Random.Range(-2, 3);
                if (maxX - minX >= maxY - minY)
                {
                    xLineNum = (maxX - minX) / 2 + minX + rand;
                    if(maxX - xLineNum >= xLineNum - minX)
                    {
                        minX = xLineNum;
                    }
                    else
                    {
                        maxX = xLineNum;
                    }
                    SetID(minX, minY, maxX, maxY, cells, subSplitNum - splitNum);
                    CreateRoom(minX, minY, maxX, maxY, cells);
                }
                else
                {
                    yLineNum = (maxY - minY) / 2 + minY + rand;
                    if (maxY - yLineNum >= yLineNum - minY)
                    {
                        minY = yLineNum;
                    }
                    else
                    {
                        maxY = yLineNum;
                    }
                    SetID(minX, minY, maxX, maxY, cells, subSplitNum - splitNum);
                    CreateRoom(minX, minY, maxX, maxY, cells);
                }
                splitNum--;
            }
            else
            {
                break;
            }
        }
        foreach (var item in cells)
        {
            if (item.RoomId == 0)
            {
                item.RoomId = subSplitNum - splitNum;
            }
        }
    }
    public void CreateRoom(int minX, int minY, int maxX, int maxY, Cell[,] soruceCells)
    {

    }
    public void SetID(int minX, int minY, int maxX, int maxY, Cell[,] soruceCells, int id)
    {
        for (int y = minY; y < maxY; y++)
        {
            for (int x = minX; x < maxX; x++)
            {
                soruceCells[x,y].RoomId = id;
            }
        }
    }
    public void CreateRoad()
    {

    }
}
