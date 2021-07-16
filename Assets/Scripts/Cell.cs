using System.Collections;
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
    MapStates _mapState;
    [SerializeField] int _roomId = 0;
    public int RoomId
    { 
        get { return _roomId; }
        set { _roomId = value; }
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
