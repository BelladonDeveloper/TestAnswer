using UnityEngine;

public class HeroForSelection : MonoBehaviour
{
    // Scriptable object with needed parameters
    public ObjectInfoSO objectInfo;

    // Code below will be needed to display this parameters in the next scene
    #region CodeForFuture
    public int id;
    public string thisName;

    void Start()
    {
        id = objectInfo.Id;
        thisName = objectInfo.Name;
    }
    #endregion
}
