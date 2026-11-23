using UnityEngine;
using UnityEngine.Video;

// Tempel di VideoManager (di ARScene).
// Menampilkan status video Motherboard di layar HP (pojok kiri atas)
// supaya kelihatan apakah videonya jalan atau tidak.
// Tidak butuh setting apa-apa lagi — langsung Build And Run.
// Hapus script ini (dan komponennya) kalau sudah tidak dibutuhkan.
public class VideoStatus : MonoBehaviour
{
    VideoPlayer vp;
    string pesan = "Menunggu marker...";
    GUIStyle gaya;

    void Update()
    {
        if (vp == null)
        {
            // Cari VideoPlayer berdasarkan nama clip-nya,
            // tidak peduli nama clone-nya apa.
            VideoPlayer[] semua = FindObjectsOfType<VideoPlayer>();
            foreach (VideoPlayer v in semua)
            {
                if (v != null && v.clip != null && v.clip.name == "Video_Motherboard")
                {
                    vp = v;
                    break;
                }
            }
        }
        if (vp == null)
        {
            pesan = "Menunggu marker...";
            return;
        }
        pesan = "Video: " + (vp.isPlaying ? "JALAN" : "BERHENTI")
            + "\nWaktu: " + vp.time.ToString("F1") + " dtk"
            + "\nFrame: " + vp.frame
            + "\nClip: " + (vp.clip != null ? vp.clip.name : "TIDAK ADA");
    }

    void OnGUI()
    {
        if (gaya == null)
        {
            gaya = new GUIStyle(GUI.skin.label);
            gaya.fontSize = 36;
            gaya.normal.textColor = Color.yellow;
        }
        GUI.Label(new Rect(20, 20, 900, 250), pesan, gaya);
    }
}
