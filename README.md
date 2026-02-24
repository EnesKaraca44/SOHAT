# SOHAT - Sağlık Otomasyonu Hasta Takip Sistemi

SOHAT (**S**ağlık **O**tomasyonu **H**asta **T**akip **S**istemi), bir **okul projesi (ödevi)** kapsamında geliştirilmiş olup, genel amaçlı hastaneler ve poliklinikler için tasarlanmış kapsamlı bir masaüstü bilgi yönetim sistemidir. N-Katmanlı mimari (N-Tier Architecture) kullanılarak C# (Windows Forms) dili ile geliştirilmiş olup, veritabanı olarak PostgreSQL kullanmaktadır.

## 🚀 Özellikler

- **Bireysel Oturum Açma (Login):** Kullanıcı rolüne ve yetkisine göre farklılaşan, güvenli ve kişiselleştirilmiş bir giriş sistemi (Örn: Yönetici, Doktor, Kayıt Personeli).
- **Hasta Kabul ve Kayıt:** Hastaların güncel ve demografik temel bilgilerinin detaylı bir şekilde veritabanına kaydedilmesi ve takibi.
- **Poliklinik İşlemleri:** İlgili polikliniğe ve doktora hasta yönlendirme yapabilme, sevk süreçleri ve işleyişin düzenlenmesi.
- **Muayene ve İşlem Takibi:** Hastalara uygulanan tüm poliklinik işlemlerinin, tahlillerin ve muayene verilerinin sisteme işlenmesi.
- **Taburcu ve Hesap Kesim:** Hastaların çıkış işlemlerinin tamamlanması ve sunulan hizmetlerin faturalandırılması süreci.
- **Dinamik Raporlama:** Hastalara ve birimlere ait işlemlerin, dosyaların kullanıcı dostu arayüzlerden (UI) detaylı incelenip listelenebilmesi işlevi.

## 🛠️ Kullanılan Teknolojiler

- **Programlama Dili:** C# (.NET Framework Windows Forms)
- **Yazılım Mimarisi:** N-Katmanlı Mimari
- **Veritabanı Yönetim Sistemi:** PostgreSQL
- **Veritabanı Paketleri:** Npgsql (Veri Sağlayıcısı)

## 📁 Proje - Katmanlı Mimari Yapısı

Yazılım geliştirme standartlarına uygunluk, daha rahat genişletilebilirlik ve sürdürülebilirlik için proje farklı katmanlara bölünmüştür:

1. **VarlikKatmani (Entity Layer):** Veritabanındaki tabloların nesnel anlamda (OOP) C# sınıfları halinde soyutlandığı katmandır (Örn: `Kullanici.cs`, `Hasta.cs`, `Poliklinik.cs`).
2. **VeriErisimKatmani (DAL Layer):** PostgreSQL veritabanı ile direkt iletişime geçilen, Veri Transfer Okuyucu (Reader), Veri Çerçevesi Ekle-Sil-Kayıt-Güncelleme (CRUD işlemlerinin) ve bütün temel SQL sorgularının bulunduğu ve veri çekim merkezi olarak kullanılan katmandır. (Örn: `PoliklinikDAL.cs`)
3. **SunumKatmani (Presentation Layer):** Kullanıcıların verileri göreceği, komutları vereceği Windows Forms ortamını (Son kullanıcı arayüzünü) içeren katmandır.

## ⚙️ Kurulum ve Bilgisayarda Çalıştırma

1. Projeyi sisteminize kopyalayın (klonlayın):
   ```bash
   git clone https://github.com/EnesKaraca44/SOHAT.git
   ```
2. Tüm işlemlerin kusursuz çalışması için, makinenizde PostgreSQL veritabanı sunucusu kurulu ve yürütülüyor olmalıdır.
3. Proje içerisindeki veritabanı bağlantı yolunuzu kendi PostgreSQL yapılandırmanıza göre; `VeriErisimKatmani\VeritabaniBaglanti.cs` class'ı içerisindeki Connection String verileri ile güncelleyerek değiştirmeyi unutmayın.
4. Gerekli tüm SQL Tablo şemalarını (Projede bulunuyorsa) PostgreSQL Veritabanınıza ekleyin.
5. C# Çözüm (.sln) dosyasını Microsoft Visual Studio editörünüzle açıp, paketi derleyebilir ve uygulamayı çalıştırabilirsiniz (Start).
