using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

class SpawnPoint
{
    public Vector2 point;
    public bool occupied;

    public SpawnPoint(int x, int y)
    {
        point = new Vector2(x, y);
        occupied = false;
    }
}

public class Board : MonoBehaviour
{
    public GameObject gridObject;
    public List<GameObject> Units;

    public int gridSizeX = 12;
    public int gridSizeY = 7;

    private float dx = 0.9f;
    private float dy = 0.6f;

    public HexTile[][] board;

    private List<SpawnPoint> spawnPoints;

    void Start()
    {
        board = new HexTile[gridSizeX][];
        var spawnStartPosition = transform.position;
        for (int i = 0; i < gridSizeX; ++i)
        {
            var tempArr = new HexTile[gridSizeY];
            for (int j = 0; j < gridSizeY; ++j)
            {
                var xcomponent = dx * i;
                int diff = 0;
                if (j % 2 != 0) //continue;
                {
                    xcomponent = (dx * i) + 0.43f;
                    diff = 1;
                }

                var ycomponent = -dy * j;

                var newTile = Instantiate(gridObject, spawnStartPosition
                                        + new Vector3(xcomponent, ycomponent, 0), gridObject.transform.rotation);
                tempArr[j] = newTile.GetComponent<HexTile>();
                newTile.GetComponent<HexTile>().gridX = 2 * i + diff;
                newTile.GetComponent<HexTile>().gridY = j;
                newTile.transform.parent = this.gameObject.transform;
                board[i] = tempArr;
            }
        }

        spawnPoints = new List<SpawnPoint>();
        spawnPoints.Add(new SpawnPoint(0, 1));
        spawnPoints.Add(new SpawnPoint(0, 5));
        spawnPoints.Add(new SpawnPoint(9, 1));
        spawnPoints.Add(new SpawnPoint(9, 5));
    }

    public void SpawnUnits(Player player)
    {
        foreach(var unitTag in player.units.units)
        {
            var unit = Units.Where(x => x.tag == unitTag).First();
            var spawnPoint = spawnPoints.Where(x => !x.occupied).First();
            spawnPoint.occupied = true;
            SpawnUnit(unit, spawnPoint.point, player.team);
        }
        player.units.unitsAlive = 2;
    }

    void SpawnUnit(GameObject unit, Vector2 coordinates, Team team)
    {
        var startPos = board[(int)coordinates.x][(int)coordinates.y];
        var newUnit = Instantiate(unit, startPos.transform.position, gridObject.transform.rotation);
        newUnit.GetComponent<UnitInfo>().teamSide = team;
        newUnit.transform.parent = startPos.gameObject.transform;

        if (newUnit.GetComponent<UnitInfo>().teamSide == Team.Enemy)
        {
            newUnit.GetComponent<SpriteRenderer>().flipX = true;
            newUnit.GetComponent<UnitControl>().faceRight = false;
            newUnit.GetComponent<SpriteRenderer>().sprite = newUnit.GetComponent<UnitInfo>().altSkin;
            newUnit.transform.GetChild(0).transform.localPosition = new Vector3(newUnit.transform.GetChild(0).transform.localPosition.x,
                                                                                newUnit.transform.GetChild(0).transform.localPosition.y, -7f);
            newUnit.transform.GetChild(1).transform.localPosition = new Vector3(newUnit.transform.GetChild(1).transform.localPosition.x,
                                                                                newUnit.transform.GetChild(1).transform.localPosition.y, -8f);
        }
    }
}
