using UnityEngine;
using DG.Tweening;

public class ShowObject : MonoBehaviour
{
    // speed for rotation
    public float speed = 55f;

    private GameObject objectForShowing;

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

        RotateThis();
    }

    /// <summary>
    /// Rotate this container and child object
    /// </summary>
    private void RotateThis()
    {
        // Rotate with tweening
         transform.DORotate(Vector3.up * 360f, 55f, RotateMode.FastBeyond360).SetLoops(-1).SetSpeedBased(true).SetEase(Ease.Linear);
    }

    /// <summary>
    /// Delete object form panel view
    /// </summary>
    public void ClearShowPanel()
    {
        Destroy(objectForShowing);
    }

    private void OnEnable()
    {
        ObjectInfoRow.selectRow += StopTweening;
    }

    /// <summary>
    /// Stop last rotation when player change object for showing
    /// </summary>
    /// <param name="obj"></param>
    private void StopTweening(ObjectInfoRow obj)
    {
        DOTween.Kill(this);
    }

    private void OnDestroy()
    {
        ObjectInfoRow.selectRow -= StopTweening;
    }
}
