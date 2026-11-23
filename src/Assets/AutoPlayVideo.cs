using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Video;

// Tempel di PrefabVideo gabungan (objek paling atas / root).
// Saat marker terdeteksi, otomatis menyalakan HP + video
// yang cocok dengan marker itu — tanpa perlu tekan tombol pill.
// Tombol pill tetap bisa dipakai untuk ganti video.
public class AutoPlayVideo : MonoBehaviour
{
    void OnEnable()
    {
        // Prefab ini dipasang sebagai anak dari gambar AR yang terdeteksi
        ARTrackedImage gambar = GetComponentInParent<ARTrackedImage>();
        if (gambar == null) return;

        string nama = gambar.referenceImage.name; // contoh: "Motherboard"
        Transform anak = transform.Find("PrefabVideo_" + nama);
        if (anak == null) return;

        Transform hp = anak.Find("HP");
        if (hp == null) return;

        hp.gameObject.SetActive(true);
        Transform layar = hp.Find("Layar");
        if (layar == null) return;
        VideoPlayer vp = layar.GetComponent<VideoPlayer>();
        if (vp != null && !vp.isPlaying) vp.Play();
    }
}
