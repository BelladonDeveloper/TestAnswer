using System.Collections.Generic;
using UnityEngine;

public class SelectionTable : MonoBehaviour
{
    /// <summary>
    /// Object in scene, responsible for showing selected object
    /// </summary>
    public ShowObject showObject;

    /// <summary>
    /// All rows in table
    /// </summary>
    public ObjectInfoRow[] rows;

    /// <summary>
    /// Samples to choose
    /// </summary>
    public GameObject[] prefabs;

    /// <summary>
    /// Current selected object
    /// </summary>
    private ObjectInfoRow selectedObjectInfo;

    /// <summary>
    /// List of all objects in table
    /// </summary>
    private List<HeroForSelection> heroes;

    private void Start()
    {
        // Get all rows from table
        rows = GetComponentsInChildren<ObjectInfoRow>();
        // Create list with known capacity
        heroes = new List<HeroForSelection>(rows.Length);

        // Connect method to delegate 
        ObjectInfoRow.selectRow += SelectObjectInTable;
    }

    /// <summary>
    /// Write to table valid data
    /// </summary>
    private void RefreshTable()
    {
        // write each item from list
        int rowsCounter = 0;
        foreach (var item in heroes)
        {
            rows[rowsCounter].SetId(item.objectInfo.Id);
            rows[rowsCounter].SetName(item.objectInfo.Name);
            rowsCounter++;
        }

        // Clear rows which have outdated texts
        for (; rowsCounter < rows.Length; rowsCounter++)
        {
            rows[rowsCounter].ClearRow();
        }
    }

    /// <summary>
    /// Add new random object to table
    /// 
    /// Method will be called by button
    /// </summary>
    public void AddRandomObject()
    {
        if (heroes.Count < rows.Length)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            HeroForSelection hero = prefabs[randomIndex].GetComponent<HeroForSelection>();

            heroes.Add(hero);

            RefreshTable();
        }
        else
        {
            print("Table is full");
        }
    }

    /// <summary>
    /// Select object which id`s showed in this row
    /// 
    /// Delegate method which responsive on row click
    /// </summary>
    /// <param name="objectInfoRow"> Row that was clicked </param>
    private void SelectObjectInTable(ObjectInfoRow objectInfoRow)
    {
        foreach (GameObject hero in prefabs)
        {
            if (hero.GetComponent<HeroForSelection>().objectInfo.Id == objectInfoRow.GetId())
            {
                showObject.SetObjectForShowing(hero);
                selectedObjectInfo = objectInfoRow;
            }
        }
    }

    /// <summary>
    /// Remove selected object from table
    /// 
    /// Method will be called by button
    /// </summary>
    public void RemoveSelected()
    {
        if (selectedObjectInfo)
        {
            heroes.RemoveAt(int.Parse(selectedObjectInfo.gameObject.name));
            selectedObjectInfo = null;
            RefreshTable();
            showObject.ClearShowPanel();
        }
        else
        {
            print("Select object");
        }
    }

    private void OnDestroy()
    {
        // Disconect method
        ObjectInfoRow.selectRow -= SelectObjectInTable;
    }
}
