## English Version


# E-Commerce API

This project is a **RESTful API** application that performs basic e-commerce operations.  
It provides features such as managing users, products, categories, and orders.  
The project is built using **C# (.NET)**, **Entity Framework (Database First)**, and **SQL Server** technologies.

---

## 🚀 Features
- **User Management** (Registration, login, authentication with JWT token)
- **Product Management** (Add, update, delete, list)
- **Category Management**
- **Order Management**
- **API Documentation** with Swagger UI
- Endpoints tested with **Postman**

---

## 🛠 Technologies Used
- **C# (.NET 6)**
- **Entity Framework (Database First)**
- **SQL Server**
- **JWT Authentication**
- **Swagger**
- **Postman**

---

## 📦 Installation & Running
- After running the project, you can access the API documentation at:  
  http://localhost:5067/swagger/index.html

---

## 📌 API Endpoints

| Method | Endpoint                      | Description           |
| ------ | ------------------------------| --------------------- |
| POST   | /api/Auth/Register             | Register a new user   |
| POST   | /api/Auth/LoginUser            | User login            |
| GET    | /api/Product/GetAllProduct     | List all products     |
| POST   | /api/Product                   | Add a new product     |
| PUT    | /api/Product/{id}              | Update a product      |
| DELETE | /api/Product/{id}              | Delete a product      |
| GET    | /api/Category/GetAll           | List all categories   |
| POST   | /api/Orders                    | Create an order       |

---

### Example Requests & Responses

1. **POST** `/api/Auth/LoginUser` – User Login  
<img width="930" height="858" alt="image" src="https://github.com/user-attachments/assets/ac32b595-7be4-4d74-9624-079d4616509d" />

2. **POST** `/api/Auth/Register` – User Registration  
<img width="944" height="751" alt="image" src="https://github.com/user-attachments/assets/75ac5d1d-4774-4892-a299-945727f49753" />

3. **GET** `/api/Product/GetAllProduct` – List All Products  
<img width="1265" height="921" alt="image" src="https://github.com/user-attachments/assets/742f640a-036b-4396-9095-b04fb9e79900" />

4. **POST** `/api/Product` – Add a New Product  
<img width="1401" height="914" alt="image" src="https://github.com/user-attachments/assets/33c6ce30-c7ad-4a2f-983e-01ccd99e6dd4" />

5. **PUT** `/api/Product/{id}` – Update a Product  
<img width="948" height="795" alt="image" src="https://github.com/user-attachments/assets/4fd4667e-9417-4575-9682-1b54efb10001" />

6. **DELETE** `/api/Product/{id}` – Delete a Product  
<img width="1244" height="840" alt="image" src="https://github.com/user-attachments/assets/0bdf2ac8-5543-4fc7-af09-56629d607372" />

7. **GET** `/api/Category/GetAll` – List All Categories  
<img width="1254" height="920" alt="image" src="https://github.com/user-attachments/assets/f36b8e1d-41fd-4bbb-97b3-041733fd9831" />

8. **POST** `/api/Orders` – Create an Order  
<img width="1296" height="903" alt="image" src="https://github.com/user-attachments/assets/d6ac18f0-3daf-4b74-8ce7-baccb17657d0" />  

---

## 📷 Additional Swagger Screenshots
<img width="1650" height="1019" alt="image" src="https://github.com/user-attachments/assets/ac7c61dc-01e4-4761-a412-a6f256fcc9c6" />
<img width="1265" height="876" alt="image" src="https://github.com/user-attachments/assets/7f04d275-7069-477f-8590-770fbc1bf0aa" />
<img width="1233" height="740" alt="image" src="https://github.com/user-attachments/assets/a5405010-d2e7-481f-80af-2d001addbe35" />
<img width="1252" height="788" alt="image" src="https://github.com/user-attachments/assets/ce13b778-6bc2-4881-8a29-2c3747d06402" />
<img width="1262" height="747" alt="image" src="https://github.com/user-attachments/assets/beb3134f-6071-46d0-8af4-447d630213df" />
<img width="1220" height="778" alt="image" src="https://github.com/user-attachments/assets/ddae363a-354c-4db0-9665-c24cceba6442" />
<img width="1222" height="842" alt="image" src="https://github.com/user-attachments/assets/8fdaa3cd-ca1f-4d7e-a6e2-99c792f5a8e1" />
<img width="1241" height="338" alt="image" src="https://github.com/user-attachments/assets/e5b9d263-3736-481f-acdd-b3ac6f122dbf" />


---

---

## Türkçe Versiyon

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


1. POST   | /api/Auth/LoginUser    | Kullanıcı girişi     |
<img width="930" height="858" alt="image" src="https://github.com/user-attachments/assets/ac32b595-7be4-4d74-9624-079d4616509d" />

2. POST   | /api/Auth/Register     | Kullanıcı kaydı      |
<img width="944" height="751" alt="image" src="https://github.com/user-attachments/assets/75ac5d1d-4774-4892-a299-945727f49753" />

3. GET    | /api/Product/GetAllProduct   | Ürünleri listele     |
<img width="1265" height="921" alt="image" src="https://github.com/user-attachments/assets/742f640a-036b-4396-9095-b04fb9e79900" />

4.  POST   | /api/Product           | Yeni ürün ekle       |
<img width="1401" height="914" alt="image" src="https://github.com/user-attachments/assets/33c6ce30-c7ad-4a2f-983e-01ccd99e6dd4" />

5. PUT    | /api/Product/{id}      | Ürün güncelle        |
<img width="948" height="795" alt="image" src="https://github.com/user-attachments/assets/4fd4667e-9417-4575-9682-1b54efb10001" />

 6. DELETE | /api/Product/{id}      | Ürün sil   |
<img width="1244" height="840" alt="image" src="https://github.com/user-attachments/assets/0bdf2ac8-5543-4fc7-af09-56629d607372" />

7. GET    | /api/Category/GetAll    | Kategorileri listele |
<img width="1254" height="920" alt="image" src="https://github.com/user-attachments/assets/f36b8e1d-41fd-4bbb-97b3-041733fd9831" />

8. POST   | /api/Orders            | Sipariş oluştur      |
<img width="1296" height="903" alt="image" src="https://github.com/user-attachments/assets/d6ac18f0-3daf-4b74-8ce7-baccb17657d0" />  


##   Swagger Diğer Ekran Görüntüleri
<img width="1650" height="1019" alt="image" src="https://github.com/user-attachments/assets/ac7c61dc-01e4-4761-a412-a6f256fcc9c6" />
<img width="1265" height="876" alt="image" src="https://github.com/user-attachments/assets/7f04d275-7069-477f-8590-770fbc1bf0aa" />
<img width="1233" height="740" alt="image" src="https://github.com/user-attachments/assets/a5405010-d2e7-481f-80af-2d001addbe35" />
<img width="1252" height="788" alt="image" src="https://github.com/user-attachments/assets/ce13b778-6bc2-4881-8a29-2c3747d06402" />
<img width="1262" height="747" alt="image" src="https://github.com/user-attachments/assets/beb3134f-6071-46d0-8af4-447d630213df" />
<img width="1220" height="778" alt="image" src="https://github.com/user-attachments/assets/ddae363a-354c-4db0-9665-c24cceba6442" />
<img width="1222" height="842" alt="image" src="https://github.com/user-attachments/assets/8fdaa3cd-ca1f-4d7e-a6e2-99c792f5a8e1" />
<img width="1241" height="338" alt="image" src="https://github.com/user-attachments/assets/e5b9d263-3736-481f-acdd-b3ac6f122dbf" />























