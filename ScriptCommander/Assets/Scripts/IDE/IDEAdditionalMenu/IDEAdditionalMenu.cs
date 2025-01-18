using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AdditionalMenuItem
{
    public GameObject pref;
    public UnityAction click;
}

interface IIDEAdditionalMenuAPI
{
    public List<AdditionalMenuItem> GetItems();
}

public class IDEAdditionalMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GraphicRaycaster graphicRaycaster;
    [SerializeField] private EventSystem eventSystem;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData pointerData = new PointerEventData(eventSystem)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();

            graphicRaycaster.Raycast(pointerData, results);

            foreach (RaycastResult result in results)
            {
                IIDEAdditionalMenuAPI api = result.gameObject.GetComponent<IIDEAdditionalMenuAPI>();

                if (api != null)
                {
                    SetItems(api);
                }
            }
        }
    }

    private void SetItems(IIDEAdditionalMenuAPI api)
    {
        List<AdditionalMenuItem> items = api.GetItems();

        foreach (AdditionalMenuItem item in items)
        {
            GameObject pref = Instantiate(item.pref, menu.transform);

            Button button = pref.GetComponent<Button>();

            if (button != null)
            {
                button.onClick.AddListener(item.click);
            }
        }
    }
}
