# UTS AR - Pengenalan Hardware Komputer (Kelompok 3)

Mata Kuliah: Desain Realitas Berimbuh / Realitas Visual (A)
Topik: Pengenalan Perangkat Keras (Hardware) Komputer

## Anggota

| Nama | NIM | Tugas utama |
|---|---|---|
| Dirli Dwi Putra | F55124022 | RAM + Storage, script `GantiVideo.cs` + prefab video |
| Anisa Aulia Febrina A Yunda | F55124005 | PSU + GPU, UI + laporan cara kerja |
| Alifa Nursintia Marsya | F55124011 | Motherboard + CPU, set up Unity |
| Nadia | F55124033 | Cooling Fan, build APK + uji + laporan akhir |

## Cara kerja

Aplikasi AR Image Tracking. Scan 7 gambar marker dengan HP, video penjelasan muncul di atas gambar:

| No | Marker | Video |
|---|---|---|
| 1 | Motherboard: Jantung Komputer | Fungsi motherboard sebagai papan pusat |
| 2 | CPU: Otak Komputer | Peran CPU memproses data dan menjalankan perintah |
| 3 | RAM: Memori Sementara | Fungsi RAM menyimpan data sementara |
| 4 | Storage: Penyimpanan Permanen | Harddisk / SSD untuk sistem, dokumen, dan aplikasi |
| 5 | PSU: Penyuplai Daya Listrik | PSU mengubah AC jadi DC |
| 6 | GPU: Pengolah Tampilan Grafis | VGA merender gambar, video, dan game |
| 7 | Cooling System: Pendingin Sistem | Menjaga suhu supaya tidak overheating |

## HP untuk download dan uji

**HP utama: Samsung Galaxy A17 5G — SM-A176B/DS**

- Android 15, One UI 7
- Punya giroskop, jadi AR bisa jalan
- Ada di daftar resmi perangkat yang didukung ARCore Google, dan mendukung Depth API
- Sudah terbukti dipakai Alifa untuk uji AR pada Oktober 2026

**HP cadangan: Galaxy A23** (punya giroskop, juga didukung ARCore).

**Jangan pakai Galaxy A15** — tidak punya giroskop, AR tidak stabil.

Sebelum install, di HP A17:
1. Buka Play Store, cari **Google Play Services for AR**, pastikan sudah ter-install dan update.
2. Charge HP di atas 50%.

## Cara install APK di HP A17

1. Download file APK dari folder `build/` di repo ini, atau dari link yang dikirim kelompok.
2. Di HP, buka file APK itu (di folder Download).
3. Kalau muncul "Install dari sumber tak dikenal", ketuk **Izinkan** untuk aplikasi Files / Chrome yang dipakai download.
4. Ketuk **Install**, tunggu selesai.
5. Buka aplikasi, ketuk **Izinkan** saat diminta izin Kamera.
6. Print 7 marker di folder `Marker/`, letakkan di meja, arahkan HP dari jarak sekitar 30 cm di tempat terang.

## Cara build dari Unity (untuk anggota kelompok)

1. Install Unity **2022.3 LTS** + modul Android Build Support (SDK, NDK, OpenJDK).
2. Buka Unity Hub, buka project di `src/ARHardwareKelompok3`.
3. File > Build Settings > Android > Build And Run.
4. Simpan APK sebagai `build/ARHardwareKelompok3.apk`.
5. Uji di HP Galaxy A17 5G (SM-A176B/DS).

Pengaturan penting di Player Settings:
- Package Name: `com.kelompok3.arhardware`
- Minimum API Level: 24 (Android 7.0)
- Scripting Backend: IL2CPP, Target Architectures: ARM64 saja
- Graphics APIs: OpenGLES3 saja, hapus Vulkan

## Struktur repo

```
uts-ar-hardware-kelompok-3/
  README.md
  .gitignore
  src/ARHardwareKelompok3/   <- project Unity
    Assets/
      Scenes/ARScene.unity
      Scripts/GantiVideo.cs
      Prefabs/PrefabVideo.prefab
      Materials/MatVideo.mat
      Videos/Video_Motherboard.mp4 (dan 6 video lain)
      LibraryHardware.asset
  Marker/                    <- 7 gambar marker untuk di-print (A5)
    Motherboard.jpg, CPU.jpg, RAM.jpg, Storage.jpg, PSU.jpg, GPU.jpg, CoolingFan.jpg
  docs/                      <- storyboard dan laporan
  build/                     <- APK hasil build
```

## Aturan commit

Format pesan commit, salin persis:

```
[Nama] kata kerja + apa yang diubah
```

Contoh benar:
- `[Alifa] Project Unity kosong + Player Settings Android`
- `[Dirli] tambah script GantiVideo dan prefab video`
- `[Nadia] perbaiki video CPU tidak bersuara setelah uji`

Jangan pakai: `update`, `fix`, `final`, `punya Alifa`.

Sebelum commit, cek dulu di cmd (di folder repo):

```
git config user.name
git config user.email
```

Harus nama dan email GitHub kamu sendiri. Kalau masih nama teman, atur dulu:

```
git config --local user.name "Nama Kamu"
git config --local user.email "email-github-kamu@contoh.com"
```

Tutorial lengkap ada di file `Tutorial_UTS_AR_Hardware_Kelompok_3.md`.
