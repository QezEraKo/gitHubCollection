using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour
{
    private Dictionary<Scr_SO_BuildingType, Transform> btnTransformDictionary;

    private void Awake()
    {
        Transform btnTemplate = transform.Find("btnTemplate");
        btnTemplate.gameObject.SetActive(false);

        Scr_SO_BuildingType_List buildingType_List = Resources.Load<Scr_SO_BuildingType_List>(typeof(Scr_SO_BuildingType_List).Name);

        btnTransformDictionary = new Dictionary<Scr_SO_BuildingType, Transform>();

        int index = 0;
        foreach (Scr_SO_BuildingType buildingType in buildingType_List.list)
        {
            Transform btnTransform = Instantiate(btnTemplate, transform);
            btnTransform.gameObject.SetActive(true);

            float offsetAmount = 110f;
            btnTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

            btnTransform.Find("image").GetComponent<Image>().sprite = buildingType.sprite;

            btnTransform.GetComponent<Button>().onClick.AddListener(() => { Scr_Manager_Building.Instance.SetActiveBuildingType(buildingType); });

            btnTransformDictionary[buildingType] = btnTransform;

            index++;
        }
    }

    private void Update()
    {
        UpdateActiveBuildingTypeButton();
    }

    private void UpdateActiveBuildingTypeButton()
    {
        Debug.Log("Updating active building type");
        foreach (Scr_SO_BuildingType buildingType in btnTransformDictionary.Keys)
        {
            Transform btnTransform = btnTransformDictionary[buildingType];
            btnTransform.Find("selected").gameObject.SetActive(false);
        }

        Scr_SO_BuildingType activeBuildingType = Scr_Manager_Building.Instance.GetActiveBuildingType();

        btnTransformDictionary[activeBuildingType].Find("selected").gameObject.SetActive(true);

    }
}
