using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Scr_Manager_Building : MonoBehaviour
{
    public static Scr_Manager_Building Instance { get; private set; }

    private Camera mainCamera;
    private Scr_SO_BuildingType_List buildingTypeList;
    private Scr_SO_BuildingType activeBuildingType;
    private Vector3 tilePosition;

    private void Awake()
    {
        Instance = this;

        buildingTypeList = Resources.Load<Scr_SO_BuildingType_List>(typeof(Scr_SO_BuildingType_List).Name);
        activeBuildingType = buildingTypeList.list[0];
    }

    private void Start()
    {
        Debug.Log("BM Script Starting");
        mainCamera = Camera.main;

        Debug.Log("BM Script Started");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Click!");
            SpawnTower();
        }
    }

    private void SpawnTower()
    {
        Vector3 towerSpawnPosition = Utils.GetMouseWorldPosition();
        // ValidateWorldGridPosition(towerSpawnPosition);
        Instantiate(activeBuildingType.prefab, towerSpawnPosition, Quaternion.identity);

        // if (GetAbilitiyToBuild())
        // {
        //     Debug.Log("Abilitiy to build is true");
        //     tilePosition = GetTilePosition();
        //     Instantiate(activeBuildingType.prefab, tilePosition, Quaternion.identity);
        //     ChangeAbilitiyToBuild();
        // }
    }

    private void ValidateWorldGridPosition(Vector3 position)
    {

    }

    private bool GetAbilitiyToBuild()
    {
        Debug.Log("GetAbilitiyToBuild called");
        Vector3 mousePosition = Utils.GetMouseWorldPosition();
        Debug.Log("mousePosition found, about to check if tile is buildable");
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        // Debug.Log(hit.collider.name);
        Debug.Log("raycast has been cast, hit has been calculated");
        if (hit.collider.tag == "BuildableTile")
        {
            Debug.Log("Tile is buildable, returning true");
            return true;
        }

        else
        {
            Debug.Log("Tile is NOT buildable, returning false");
            return false;
        }
    }

    private void ChangeAbilitiyToBuild()
    {
        Debug.Log("ChangeAbilitiyToBuild called");
        Vector3 mousePosition = Utils.GetMouseWorldPosition();
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        hit.collider.gameObject.tag = "NotBuildable";
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }


    private Vector3 GetTilePosition()
    {
        Vector3 mousePosition = Utils.GetMouseWorldPosition();
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        tilePosition = hit.collider.transform.position;

        return tilePosition;
    }

    public void SetActiveBuildingType(Scr_SO_BuildingType buildingType)
    {
        activeBuildingType = buildingType;
    }

    public Scr_SO_BuildingType GetActiveBuildingType()
    {
        return activeBuildingType;
    }

}
