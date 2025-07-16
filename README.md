# 💼 SalaryManagementAPI

Đây là một RESTful API cho hệ thống quản lý lương, được xây dựng bằng **ASP.NET Core** và sử dụng **PostgreSQL** làm cơ sở dữ liệu. API hỗ trợ quản lý nhân viên, phòng ban, chức vụ, hợp đồng, bảo hiểm, thuế TNCN, phụ cấp, thưởng phạt và hệ thống phân quyền.

## 🚀 Demo Online

🔗 API Production:  
👉 [salarymanagementapi-production.up.railway.app](https://salarymanagementapi-production.up.railway.app/swagger/index.html)


> Truy cập trực tiếp vào link trên sẽ được redirect đến trang Swagger để test API.

---

## 🧰 Công nghệ sử dụng

- ASP.NET Core 8.0
- PostgreSQL (hosted on Railway)
- Entity Framework Core
- JWT Authentication
- AutoMapper
- Swagger (Swashbuckle)
- Railway (cloud deployment)

---

## 🔐 Chức năng chính

- Đăng nhập, phân quyền theo vai trò (Admin, Nhân sự, Kế toán, Nhân viên)
- Quản lý:
  - Nhân viên, phòng ban, chức vụ
  - Hợp đồng lao động
  - Bảo hiểm, phụ cấp, thuế TNCN
  - Tính lương, chi tiết lương
- Đổi mật khẩu, cấp tài khoản mới
- Token-based Authentication (JWT)

---
