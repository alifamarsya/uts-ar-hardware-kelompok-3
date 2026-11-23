using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

// Mengganti video yang tampil sesuai tombol pill yang ditekan.
// Mencari VideoPlayer berdasarkan nama clip (tidak peduli nama clone),
// jadi tetap bekerja walau nama salinan prefab di scene berbeda.
public class VideoSwitcher : MonoBehaviour
{
    public void TampilkanMotherboard() { Tampilkan("Motherboard"); }
    public void TampilkanCPU() { Tampilkan("CPU"); }
    public void TampilkanRAM() { Tampilkan("RAM"); }
    public void TampilkanStorage() { Tampilkan("Storage"); }
    public void TampilkanPSU() { Tampilkan("PSU"); }
    public void TampilkanGPU() { Tampilkan("GPU"); }
    public void TampilkanCoolingFan() { Tampilkan("CoolingFan"); }

    public void TutupSemua()
    {
        foreach (VideoPlayer vp in SemuaVideo())
        {
            if (vp == null) continue;
            vp.Stop();
            Transform hp = vp.transform.parent;
            if (hp != null) hp.gameObject.SetActive(false);
        }
    }

    void Tampilkan(string nama)
    {
        string namaClip = "Video_" + nama;
        VideoPlayer target = null;

        foreach (VideoPlayer vp in SemuaVideo())
        {
            if (vp == null || vp.clip == null) continue;
            if (vp.clip.name == namaClip)
            {
                target = vp;
            }
            else
            {
                vp.Stop();
                Transform hpLain = vp.transform.parent;
                if (hpLain != null) hpLain.gameObject.SetActive(false);
            }
        }

        if (target == null) return;

        Transform hp = target.transform.parent;
        if (hp != null) hp.gameObject.SetActive(true);
        target.Play();
    }

    // Semua VideoPlayer di scene (termasuk yang HP-nya sedang nonaktif).
    VideoPlayer[] SemuaVideo()
    {
        VideoPlayer[] semua = FindObjectsByType<VideoPlayer>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        // Saring hanya yang benar-benar ada di scene (bukan aset prefab).
        List<VideoPlayer> hasil = new List<VideoPlayer>();
        foreach (VideoPlayer vp in semua)
        {
            if (vp != null && vp.gameObject.scene.IsValid())
                hasil.Add(vp);
        }
        return hasil.ToArray();
    }
}
