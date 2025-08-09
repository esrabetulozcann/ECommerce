# E-Commerce API

Bu proje, temel e-ticaret işlemlerini gerçekleştiren bir **RESTful API** uygulamasıdır.  
Kullanıcı, ürün, kategori ve sipariş yönetimi gibi özellikler sunar.  
Proje **C# (.NET)**, **Entity Framework (Database First)** ve **SQL Server** teknolojileri kullanılarak geliştirilmiştir.

---

## 🚀 Özellikler
- **Kullanıcı Yönetimi** (Kayıt, giriş, JWT token ile kimlik doğrulama)
- **Ürün Yönetimi** (Ekleme, güncelleme, silme, listeleme)
- **Kategori Yönetimi**
- **Sipariş Yönetimi**
- **Swagger UI** ile API dokümantasyonu
- **Postman** ile test edilmiş endpointler

---

## 🛠 Kullanılan Teknolojiler
- **C# (.NET 6)**
- **Entity Framework (Database First)**
- **SQL Server**
- **JWT Authentication**
- **Swagger**
- **Postman**

---

## 📦 Kurulum ve Çalıştırma
- Çalıştırdıktan sonra API dokümantasyonuna şu adresten ulaşabilirsiniz: http://localhost:5067/swagger/index.html

---

| Method | Endpoint               | Açıklama             |
| ------ | --------------------   | -------------------- |
| POST   | /api/Auth/Register     | Kullanıcı kaydı      |
| POST   | /api/Auth/LoginUser    | Kullanıcı girişi     |
| GET    | /api/Product/GetAllProduct          | Ürünleri listele     |
| POST   | /api/Product           | Yeni ürün ekle       |
| PUT    | /api/Product/{id}      | Ürün güncelle        |
| DELETE | /api/Product/{id}      | Ürün sil             |
| GET    | /api/Category/GetAll        | Kategorileri listele |
| POST   | /api/Orders            | Sipariş oluştur      |



<img width="930" height="858" alt="image" src="https://github.com/user-attachments/assets/ac32b595-7be4-4d74-9624-079d4616509d" />   POST   | /api/Auth/LoginUser    | Kullanıcı girişi     |
<img width="944" height="751" alt="image" src="https://github.com/user-attachments/assets/75ac5d1d-4774-4892-a299-945727f49753" />   POST   | /api/Auth/Register     | Kullanıcı kaydı      |
<img width="1265" height="921" alt="image" src="https://github.com/user-attachments/assets/742f640a-036b-4396-9095-b04fb9e79900" />  GET    | /api/Product/GetAllProduct   | Ürünleri listele     |
<img width="1401" height="914" alt="image" src="https://github.com/user-attachments/assets/33c6ce30-c7ad-4a2f-983e-01ccd99e6dd4" />  POST   | /api/Product           | Yeni ürün ekle       |
<img width="948" height="795" alt="image" src="https://github.com/user-attachments/assets/4fd4667e-9417-4575-9682-1b54efb10001" />   PUT    | /api/Product/{id}      | Ürün güncelle        |
<img width="1244" height="840" alt="image" src="https://github.com/user-attachments/assets/0bdf2ac8-5543-4fc7-af09-56629d607372" />  DELETE | /api/Product/{id}      | Ürün sil             |
<img width="1254" height="920" alt="image" src="https://github.com/user-attachments/assets/f36b8e1d-41fd-4bbb-97b3-041733fd9831" />  GET    | /api/Category/GetAll        | Kategorileri listele |
<img width="1296" height="903" alt="image" src="https://github.com/user-attachments/assets/d6ac18f0-3daf-4b74-8ce7-baccb17657d0" />  POST   | /api/Orders            | Sipariş oluştur      |


##   Swagger Diğer Ekran Görüntüleri
<img width="1650" height="1019" alt="image" src="https://github.com/user-attachments/assets/ac7c61dc-01e4-4761-a412-a6f256fcc9c6" />
<img width="1265" height="876" alt="image" src="https://github.com/user-attachments/assets/7f04d275-7069-477f-8590-770fbc1bf0aa" />
<img width="1233" height="740" alt="image" src="https://github.com/user-attachments/assets/a5405010-d2e7-481f-80af-2d001addbe35" />
<img width="1252" height="788" alt="image" src="https://github.com/user-attachments/assets/ce13b778-6bc2-4881-8a29-2c3747d06402" />
<img width="1262" height="747" alt="image" src="https://github.com/user-attachments/assets/beb3134f-6071-46d0-8af4-447d630213df" />
<img width="1220" height="778" alt="image" src="https://github.com/user-attachments/assets/ddae363a-354c-4db0-9665-c24cceba6442" />
<img width="1222" height="842" alt="image" src="https://github.com/user-attachments/assets/8fdaa3cd-ca1f-4d7e-a6e2-99c792f5a8e1" />
<img width="1241" height="338" alt="image" src="https://github.com/user-attachments/assets/e5b9d263-3736-481f-acdd-b3ac6f122dbf" />























