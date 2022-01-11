using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectInfoRow : MonoBehaviour, IPointerClickHandler
{
    // Delegate click on this
    public static Action<ObjectInfoRow> selectRow;

    // text cells in table
    private Text idText;
    private Text nameText;

    /// <summary>
    /// Need to avoid formatting int to string
    /// </summary>
    private int objectId;

    void Start()
    {
        // Find all cells
        Text[] texts = GetComponentsInChildren<Text>();

        // Set it
        idText = texts[0];
        nameText = texts[1];
    }

    /// <summary>
    /// When click on this row
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        // delegate this click action
        selectRow?.Invoke(this);
    }

    /// <summary>
    /// Write id to text
    /// </summary>
    /// <param name="id"> Object ID in this row </param>
    public void SetId(int id)
    {
        idText.text = id.ToString();
        objectId = id;
    }

    /// <summary>
    /// Getter
    /// </summary>
    /// <returns> Object ID in this row </returns>
    public int GetId()
    {
        return objectId;
    }

    /// <summary>
    /// Write object name to text
    /// </summary>
    /// <param name="objectName"> Object name in this row </param>
    public void SetName(string objectName)
    {
        nameText.text = objectName;
    }

    /// <summary>
    /// Clear all texts in this row
    /// </summary>
    public void ClearRow()
    {
        idText.text = "";
        nameText.text = "";
    }
}
