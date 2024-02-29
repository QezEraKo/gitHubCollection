using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Mover_Enemy : MonoBehaviour
{
    // [SerializeField] List<Scr_Coords_Waypoint> enemyPath = new List<Scr_Coords_Waypoint>();
    [SerializeField][Range(0f, 5f)] private float moveSpeed = 1f;

    List<Scr_Coords_Waypoint> levelPath;

    private Vector3 currentPosition;
    private Vector3 nextPosition;
    private float travelPercent;


    private void Start()
    {
        levelPath = LevelPathHolder.Instance.enemyPath;
        Debug.Log("Mover_Enemy Starting");
        StartCoroutine(MoveEnemy());
    }

    private IEnumerator MoveEnemy()
    {
        foreach (Scr_Coords_Waypoint waypoint in levelPath)
        {
            currentPosition = this.transform.position;
            nextPosition = waypoint.transform.position;
            travelPercent = 0f;

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * moveSpeed;
                this.transform.position = Vector3.Lerp(currentPosition, nextPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }

}
