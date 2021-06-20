using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// マスの情報
/// </summary>
public enum MapStates
{
    Floor,
    Wall,
    Start,
    Goal,
    Path
}
/// <summary>
/// 検索したマスが開いているか判別するEnum
/// </summary>
public enum OponStates
{
    None,
    Open,
    Close
}
public class Astar : MonoBehaviour
{
    /// <summary>検索する際にマスが開いているか確認する変数</summary>
    private OponStates _openState = OponStates.None;
    /// <summary>推定コスト(障害物を無視したコスト)</summary>
    private int _estimatedCost;
    /// <summary>実コスト(スタートからこのマスまでのコスト)</summary>
    private int _realCost = 0;
    /// <summary>スコア(二つのコストの合計)</summary>
    private int _score = int.MaxValue;
    /// <summary>マスのステータス</summary>
    public MapStates MapState { get; set; }
    /// <summary>このマスをオープンしたマス</summary>
    public Cell BeforeMapData { get; set; }
    
    
}
