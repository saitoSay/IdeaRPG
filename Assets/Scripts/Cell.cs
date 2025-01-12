﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cell : MonoBehaviour
{
    public struct CellPosition
    {
        public int x;
        public int y;
    }
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Sprite[] _sprites;
    CellPosition _pos;
    [SerializeField] MapStates _mapState;
    [SerializeField] int _roomId = 0;
    public bool Intersection { get; set; }
    public int RoomId
    { 
        get { return _roomId; }
        //set { _roomId = value; }
        set
        {
            _roomId = value;
            if (_roomId == 0)
            {
                _spriteRenderer.color = Color.white;
            }
            else if (_roomId == 1)
            {
                _spriteRenderer.color = Color.red;
            }
            else if (_roomId == 2)
            {
                _spriteRenderer.color = Color.blue;
            }
            else if(_roomId == 3)
            {
                _spriteRenderer.color = Color.green;
            }
            else if (_roomId == 4)
            {
                _spriteRenderer.color = Color.gray;
            }
            else if(_roomId == 5)
            {
                _spriteRenderer.color = Color.cyan;
            }
            else
            {
                _spriteRenderer.color = Color.yellow;
            }
        }
    }
    public MapStates MapState
    {
        get { return _mapState; }
        set 
        { 
            _mapState = value;
            OnCellStateChanged();
        }
    }

    /// <summary>
    /// 各マスの座標情報を保存しておくためのコンストラクタ
    /// </summary>
    public Cell(int x, int y)
    {
        _pos.x = x;
        _pos.y = y;
        _mapState = MapStates.Start;
        Intersection = false;
    }
    private void Start()
    {
        OnCellStateChanged();
    }
    private void OnCellStateChanged()
    {
        if (_mapState == MapStates.Floor)
        {
            _spriteRenderer.sprite = _sprites[1];
        }
        else if (_mapState == MapStates.Wall)
        {
            _spriteRenderer.sprite = _sprites[0];
        }
        else
        {
            _spriteRenderer.sprite = _sprites[2];
        }
    }
}
public class Room
{
    int MinX { get; set; }
    int MinY { get; set; }
    int MaxX { get; set; }
    int MaxY { get; set; }
    public Room(int minX, int minY, int maxX,  int maxY)
    {
        MinX = minX;
        MaxX = maxX;
        MinY = minY;
        MaxY = maxY;
    }
}
