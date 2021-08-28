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
                        SetID(minX, minY, xLineNum, maxY, cells, subSplitNum - splitNum);
                        CreateRoom(minX, minY, xLineNum, maxY, cells);
                        minX = xLineNum + 1;
                    }
                    else
                    {
                        SetID(xLineNum, minY, maxX, maxY, cells, subSplitNum - splitNum);
                        CreateRoom(xLineNum, minY, maxX, maxY, cells);
                        maxX = xLineNum - 1;
                    }
                }
                else
                {
                    yLineNum = (maxY - minY) / 2 + minY + rand;
                    if (maxY - yLineNum >= yLineNum - minY)
                    {
                        SetID(minX, minY, maxX, yLineNum, cells, subSplitNum - splitNum);
                        CreateRoom(minX, minY, maxX, yLineNum, cells);
                        minY = yLineNum + 1;
                    }
                    else
                    {
                        SetID(minX, yLineNum, maxX, maxY, cells, subSplitNum - splitNum);
                        CreateRoom(minX, yLineNum, maxX, maxY, cells);
                        maxY = yLineNum - 1;
                    }
                }
                splitNum--;
            }
            else
            {
                break;
            }
        }
        //TODO この処理で分割しきれなかったCellにIDを振ると、
        //部屋を作る際に座標を取ってくるのが大変なので分割中に処理したい
        foreach (var item in cells)
        {
            if (item.RoomId == 0)
            {
                item.RoomId = subSplitNum - splitNum;
            }
        }
    }
    public void CreateRoom(int minX, int minY, int maxX, int maxY, Cell[,] cells)
    {
        int xMinRand = Random.Range(minX + 1, maxX - minX / 2);
        int xMaxRand = Random.Range(maxX - minX / 2, maxX - 1);

        int yMinRand = Random.Range(minY + 1, maxY - minY / 2); 
        int yMaxRand = Random.Range(maxY - minY / 2, maxY - 1);

        //for (int y = yMinRand; y < yMaxRand; y++)
        //{
        //    for (int x = xMinRand; x < xMaxRand; x++)
        //    {
        //        cells[x, y].MapState = MapStates.Floor;
        //    }
        //}
        for (int y = minY + 1; y < maxY - 1 ; y++)
        {
            for (int x = minX + 1; x < maxX - 1; x++)
            {
                cells[x, y].MapState = MapStates.Floor;
            }
        }

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
