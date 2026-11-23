using UnityEngine;

// Membuat HP melayang selalu menghadap kamera,
// jadi video kelihatan dari arah mana pun marker dipegang
// (diletakkan datar di meja maupun dipegang tegak).
// Pasang script ini di tiap HP di dalam PrefabVideo gabungan.
public class HadapKamera : MonoBehaviour
{
    void LateUpdate()
    {
        if (Camera.main != null)
        {
            transform.LookAt(Camera.main.transform);
        }
    }
}
