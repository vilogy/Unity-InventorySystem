using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    [SerializeField] GameObject tooltip;
    TextMeshProUGUI tooltipTextMesh;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        tooltipTextMesh = tooltip.GetComponentInChildren<TextMeshProUGUI>();
    }



    public void ShowTooltip(Vector3 position, string text)
    {
        tooltip.gameObject.SetActive(true);

        // Determine which corner of the screen is closest to the mouse position
        Vector2 corner = new Vector2(
            ((position.x > (Screen.width / 2f)) ? 1f : 0f),
            ((position.y > (Screen.height / 2f)) ? 1f : 0f)
        );

        (tooltip.transform as RectTransform).pivot = corner;
        tooltip.transform.position = position;
        tooltipTextMesh.text = text;

    }

    public void HideTooltip()
    {
        tooltip.gameObject.SetActive(false);
    }
}
