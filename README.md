# TelephoneDirectory
## Telefon Rehberi Uygulaması

Basit bir telefon rehberi uygulaması oluşturulmuştur.

### İşlevler:
* Rehberde kişi oluşturma
* Rehberde kişi kaldırma
* Rehberdeki kişiye iletişim bilgisi ekleme
* Rehberdeki kişiden iletişim bilgisi kaldırma
* Rehberdeki kişilerin listelenmesi
* Rehberdeki bir kişiyle ilgili iletişim bilgilerinin de yer aldığı detay bilgilerin getirilmesi

---

### Teknik Tasarım
Kişiler: Sistemde teorik anlamda sınırsız sayıda kişi kaydı yapılabilir. Her kişiye bağlı iletişim bilgisi eklenebilir.

**Veri yapısındaki alanlar:**
* UUID
* Ad
* Soyad
* Firma
* İletişim Bilgisi Türü
* İletişim Bilgisi İçeriği

**Kullanılan Teknolojiler:**
* .NET Core
* Git
* MongoDB
* HTML
