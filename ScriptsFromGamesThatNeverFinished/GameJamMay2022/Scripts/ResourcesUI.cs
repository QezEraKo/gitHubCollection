using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourcesUI : MonoBehaviour
{
    private Scr_SO_ResourceType_List resourceType_List;
    private Dictionary<Scr_SO_ResourceType, Transform> resourceTypeTransformDictionary;

    private void Awake()
    {
        resourceType_List = Resources.Load<Scr_SO_ResourceType_List>(typeof(Scr_SO_ResourceType_List).Name);

        resourceTypeTransformDictionary = new Dictionary<Scr_SO_ResourceType, Transform>();

        Transform resourceTemplate = transform.Find("resouceTemplate");
        resourceTemplate.gameObject.SetActive(false);


        int index = 0;
        foreach (Scr_SO_ResourceType resourceType in resourceType_List.list)
        {
            Transform resourceTransform = Instantiate(resourceTemplate, transform);
            resourceTransform.gameObject.SetActive(true);
            float offsetAmount = -160f;
            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

            resourceTransform.Find("image").GetComponent<Image>().sprite = resourceType.sprite;

            resourceTypeTransformDictionary[resourceType] = resourceTransform;

            index++;
        }
    }

    private void Start()
    {
        Scr_Manager_Resources.Instance.OnResourceAmountChanged += ResourceManager_OnResourceAmountChanged;
        UpdateResourceAmount();
    }

    private void ResourceManager_OnResourceAmountChanged(object sender, System.EventArgs e)
    {
        UpdateResourceAmount();
    }

    private void UpdateResourceAmount()
    {
        foreach (Scr_SO_ResourceType resourceType in resourceType_List.list)
        {
            Transform resourceTransform = resourceTypeTransformDictionary[resourceType];

            int resourceAmount = Scr_Manager_Resources.Instance.GetResourceAmount(resourceType);
            resourceTransform.Find("text").GetComponent<TextMeshProUGUI>().SetText(resourceAmount.ToString());
        }
    }
}
