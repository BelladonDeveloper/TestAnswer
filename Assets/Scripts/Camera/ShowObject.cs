using UnityEngine;

public class ShowObject : MonoBehaviour
{
    // speed for rotation
    public float speed = 0.9f;

    private GameObject objectForShowing;

    private void FixedUpdate()
    {
        transform.rotation *= Quaternion.Euler(Vector3.up * speed);
    }

    /// <summary>
    /// Show new object at panel view
    /// </summary>
    /// <param name="showedObject"></param>
    public void SetObjectForShowing(GameObject showedObject)
    {
        // If last object alive
        if (objectForShowing)
        {
            // delete last object
            ClearShowPanel();
        }
        // Create new object form prefab
        objectForShowing = Instantiate(showedObject, transform);

        // Start rotation with forward
        transform.rotation = Quaternion.identity;
    }

    /// <summary>
    /// Delete object form panel view
    /// </summary>
    public void ClearShowPanel()
    {
        Destroy(objectForShowing);
    }
}
