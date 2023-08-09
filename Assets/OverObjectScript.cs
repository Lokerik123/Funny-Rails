
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OverObjectScript : MonoBehaviour
{
    [SerializeField] private Text descriptionText;
    // Update is called once per frame
    void Update()
    {
        descriptionText.text = string.Empty;
            IsPointerOverUIElement(GetEventSystemRaycastResults());
        
    }
  


    //Returns 'true' if we touched or hovering on Unity UI element.
    private void IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.GetComponent<DescScript>() != null)
            {
                descriptionText.text = curRaysastResult.gameObject.GetComponent<DescScript>().description;
                if(Input.GetMouseButtonDown(0)) { GameObject.Find("Main Camera").GetComponent<GameScript>().OnClickSound(); }
            }

               
        }
    }
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
}
