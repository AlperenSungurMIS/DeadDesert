using UnityEngine;

public class MouseImlec : MonoBehaviour
{
    void Start()
    {
        // Mouse imlecini gizle
        Cursor.visible = false;
    }

    void OnDestroy()
    {
        // Mouse imlecini yeniden g�ster
        Cursor.visible = true;
    }
}
