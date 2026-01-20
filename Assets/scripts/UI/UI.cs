
using UnityEngine;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public string ButtonName;
    private bool active = false;

    [SerializeField]private GameObject Quit;
    [SerializeField]private GameObject Continue;
    [SerializeField]private GameObject Options;
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        UIArrow(ButtonName);
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        UIArrow(ButtonName);
    }
    private void UIArrow(string button)
    {
        if (button == "Quit")
        {
            if (active == false)
            {
                Quit.SetActive(true);
                active = true;
            }
            else
            {
                Quit.SetActive(false);
                active = false;
            }
        }
        if (button == "Continue")
        {
            if (active == false)
            {
                Continue.SetActive(true);
                active = true;
            }
            else
            {
                Continue.SetActive(false);
                active = false;
            }

        }
        if (button == "Options")
        {
            if (active == false)
            {
                Options.SetActive(true);
                active = true;
            }
            else
            {
                Options.SetActive(false);
                active = false;
            }
        }
    }
}
