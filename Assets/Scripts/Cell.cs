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
    CellPosition _pos;

    /// <summary>
    /// 各マスの座標情報を保存しておくためのコンストラクタ
    /// </summary>
    public Cell(int x, int y)
    {
        _pos.x = x;
        _pos.y = y;
    }
}
