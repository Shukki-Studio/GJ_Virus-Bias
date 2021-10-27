using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores every grid tile position and can give any tile position when asked.
/// Lane 0 is the most right lane
/// </summary>
public class GridPositioner : MonoBehaviour
{
    [Header("Grid information")]
    [SerializeField] private Vector2 _bottomRightTilePosition;
    [SerializeField] private Vector2 _offsetPerTile;
    [SerializeField] private Vector2 _offsetPerLane;
    [SerializeField] private int _totalTilesInLane = 6;
    [SerializeField] private int _totalLanes = 3;

    private List<List<Vector2>> _gridPositions = new List<List<Vector2>>();


    ///------------------------------------------------------------

    private void OnEnable()
    {
        ComputeGridPositions();
    }

    ///------------------------------------------------------------

    /// <summary>
    /// Returns asked tile position.
    /// If incorrect laneIndex or tileIndex, returns Vector2.negativeInfinity
    /// </summary>
    /// <param name="laneIndex"></param>
    /// <param name="tileIndex"></param>
    /// <returns></returns>
    public Vector2 GetTilePosition(int laneIndex, int tileIndex)
    {
        if (laneIndex < _gridPositions.Count && tileIndex < _gridPositions[laneIndex].Count)
            return _gridPositions[laneIndex][tileIndex];
        return Vector2.negativeInfinity;
    }

    ///------------------------------------------------------------

    /// <summary>
    /// Compute position for every grid tile and store it in _gridPosition
    /// </summary>
    private void ComputeGridPositions()
    {
        for (int laneIndex = 0; laneIndex < _totalLanes; laneIndex += 1)
        {
            List<Vector2> lanePositions = new List<Vector2>();
            Vector2 startLanePosition = _bottomRightTilePosition + (_offsetPerLane * laneIndex);

            for (int tileIndex = 0; tileIndex < _totalTilesInLane; tileIndex += 1)
            {
                lanePositions.Add(new Vector2(startLanePosition.x + (_offsetPerTile.x * tileIndex), startLanePosition.y + (_offsetPerTile.y * tileIndex)));
            }
            _gridPositions.Add(lanePositions);
        }
    }

    ///------------------------------------------------------------
}
