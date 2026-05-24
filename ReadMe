# Bele Shop Backend

Backend API cho hệ thống thương mại điện tử Bele Shop, xây dựng bằng ASP.NET Core 8.0 theo kiến trúc Clean Architecture.

## Mục lục

- [Tổng quan](#tổng-quan)
- [Kiến trúc](#kiến-trúc)
- [Công nghệ sử dụng](#công-nghệ-sử-dụng)
- [Tính năng](#tính-năng)
- [Cấu trúc dự án](#cấu-trúc-dự-án)
- [Yêu cầu hệ thống](#yêu-cầu-hệ-thống)
- [Cài đặt và chạy](#cài-đặt-và-chạy)
- [Cấu hình](#cấu-hình)
- [API Endpoints](#api-endpoints)
- [Phân quyền](#phân-quyền)
- [Dữ liệu mẫu](#dữ-liệu-mẫu)

## Tổng quan

Bele Shop Backend là REST API phục vụ cho website bán lẻ thời trang nam, cung cấp đầy đủ các chức năng quản lý sản phẩm, đơn hàng, khách hàng và thanh toán trực tuyến.

## Kiến trúc

Dự án áp dụng **Clean Architecture** với 3 tầng:

```
PrBeleBackend.sln
├── PrBeleBackend.API          # Tầng trình bày (Presentation Layer)
├── PrBeleBackend.Core         # Tầng nghiệp vụ (Business Logic Layer)
└── PrBeleBackend.Infrastructure  # Tầng dữ liệu (Data Access Layer)
```

- **API**: Controllers, Filters, Startup extensions
- **Core**: Domain entities, DTOs, Service contracts & implementations
- **Infrastructure**: EF Core DbContext, Repositories, Seed data

## Công nghệ sử dụng

| Công nghệ | Phiên bản | Mục đích |
|---|---|---|
| ASP.NET Core | 8.0 | Framework chính |
| Entity Framework Core | 9.0 | ORM |
| SQL Server | - | Cơ sở dữ liệu |
| JWT Bearer | 8.0.11 | Xác thực |
| Cloudinary | 1.27.1 | Lưu trữ ảnh |
| VNPay | - | Thanh toán trực tuyến |
| Swashbuckle (Swagger) | 6.4.0 | Tài liệu API |
| MemoryCache | - | Cache OTP |
| SMTP (Gmail) | - | Gửi email |

## Tính năng

### Admin Panel
- Quản lý sản phẩm: thêm/sửa/xóa, thuộc tính (màu sắc, kích cỡ), biến thể sản phẩm
- Quản lý danh mục: phân cấp cha-con
- Quản lý tài khoản nhân viên, vai trò và phân quyền chi tiết
- Quản lý khách hàng
- Quản lý đơn hàng: xem, cập nhật trạng thái
- Quản lý mã giảm giá
- Quản lý đánh giá (duyệt/phản hồi)
- Quản lý liên hệ
- Quản lý thẻ (tags) sản phẩm
- Dashboard thống kê
- Cài đặt hệ thống
- Đăng nhập Google OAuth

### Khách hàng (Client)
- Đăng ký, đăng nhập, đăng xuất
- Quên mật khẩu qua OTP email
- Xem sản phẩm, tìm kiếm, lọc theo danh mục/thuộc tính
- Giỏ hàng
- Checkout: thanh toán **COD** hoặc **VNPay**
- Xem và hủy đơn hàng
- Đánh giá sản phẩm
- Quản lý địa chỉ giao hàng
- Cập nhật thông tin cá nhân
- Danh sách yêu thích (WishList)
- Đọc blog

## Cấu trúc dự án

```
PrBeleBackend.API/
├── Areas/Admin/Controllers/    # API admin (prefix: /api/admin)
│   ├── AuthController          # Đăng nhập admin
│   ├── AccountController       # Quản lý nhân viên
│   ├── ProductController       # Quản lý sản phẩm
│   ├── CategoryController      # Quản lý danh mục
│   ├── OrderController         # Quản lý đơn hàng
│   ├── DiscountController      # Quản lý giảm giá
│   ├── CustomerController      # Quản lý khách hàng
│   ├── RateController          # Quản lý đánh giá
│   ├── RoleController          # Quản lý vai trò & quyền
│   ├── ContactController       # Quản lý liên hệ
│   ├── AttributeController     # Quản lý thuộc tính
│   ├── VariantController       # Quản lý biến thể
│   ├── TagController           # Quản lý tags
│   ├── SettingController       # Cài đặt hệ thống
│   ├── DashboardController     # Thống kê
│   └── GoogleController        # Google OAuth
├── Controllers/                # API client (prefix: /api)
│   ├── AuthController          # Đăng nhập/đăng ký khách hàng
│   ├── ProductController       # Xem sản phẩm
│   ├── CategoryController      # Xem danh mục
│   ├── CartController          # Giỏ hàng
│   ├── CheckoutController      # Thanh toán (COD & VNPay)
│   ├── OrderController         # Đơn hàng khách hàng
│   ├── RateController          # Đánh giá sản phẩm
│   ├── AddressController       # Địa chỉ giao hàng
│   ├── CustomerController      # Thông tin khách hàng
│   ├── ContactController       # Gửi liên hệ
│   ├── BlogController          # Xem blog
│   ├── TagController           # Tags
│   ├── VariantController       # Biến thể sản phẩm
│   ├── AttributeController     # Thuộc tính
│   └── SettingController       # Cài đặt hiển thị
├── Filters/
│   └── PermissionAuthorizeFilter.cs  # Custom permission filter
└── StartupExtensions/
    └── ServiceConfigureExtension.cs  # DI & service registration

PrBeleBackend.Core/
├── Domain/
│   ├── Entities/               # Domain models
│   └── RepositoryContracts/   # Repository interfaces
├── DTO/                        # Data Transfer Objects
└── Services/                   # Service implementations & contracts

PrBeleBackend.Infrastructure/
├── DbContexts/
│   └── BeleStoreContext.cs    # EF Core context
├── Repositories/              # Repository implementations
└── Seeder/
    └── SeedData.cs            # Dữ liệu khởi tạo
```

## Yêu cầu hệ thống

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (Express hoặc bất kỳ phiên bản nào)
- Tài khoản [Cloudinary](https://cloudinary.com/) (lưu trữ ảnh)
- Tài khoản VNPay Sandbox (thanh toán)
- Gmail App Password (gửi OTP)

## Cài đặt và chạy

### 1. Clone repository

```bash
git clone <repository-url>
cd bele-shop-backend
```

### 2. Cấu hình appsettings

Mở file `PrBeleBackend.API/appsettings.json` và cập nhật các giá trị (xem phần [Cấu hình](#cấu-hình)).

### 3. Tạo database và chạy migration

```bash
cd PrBeleBackend.API
dotnet ef database update
```

### 4. Chạy ứng dụng

```bash
dotnet run --project PrBeleBackend.API
```

Swagger UI sẽ có tại: `https://localhost:7056/swagger`

> Dữ liệu mẫu sẽ được tự động seed vào database khi khởi động lần đầu.

## Cấu hình

Cập nhật `PrBeleBackend.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnect": "Data Source=<SERVER>;Database=BeleStore;Integrated Security=True;..."
  },
  "Jwt": {
    "Issuer": "https://localhost:7056",
    "Audience": "https://localhost:7056",
    "EXPIRATION_MINUTES": 15,
    "Key": "<secret-key-32-chars-for-admin>",
    "KeyClient": "<secret-key-32-chars-for-client>"
  },
  "Cloudinary": {
    "CloudName": "<cloudinary-cloud-name>",
    "ApiKey": "<cloudinary-api-key>",
    "ApiSecret": "<cloudinary-api-secret>"
  },
  "NetMail": {
    "Email": "<gmail-address>",
    "Password": "<gmail-app-password>"
  },
  "Vnpay": {
    "TmnCode": "<vnpay-tmn-code>",
    "HashSecret": "<vnpay-hash-secret>",
    "BaseUrl": "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html",
    "Command": "pay",
    "CurrCode": "VND",
    "Version": "2.1.0",
    "Locale": "vn"
  },
  "PaymentCallBack": {
    "ReturnUrl": "https://localhost:7056/api/Checkout/PaymentCallbackVnpay"
  },
  "TimeZoneId": "SE Asia Standard Time"
}
```

> **Lưu ý**: Nếu không dùng Windows OS, thay `TimeZoneId` thành `"Asia/Bangkok"`.

## API Endpoints

### Admin API (`/api/admin`)

| Module | Endpoint | Mô tả |
|---|---|---|
| Auth | `POST /api/admin/Auth/Login` | Đăng nhập admin |
| Auth | `POST /api/admin/Auth/RefreshToken` | Làm mới token |
| Auth | `GET /api/admin/Auth/GetMe` | Thông tin tài khoản hiện tại |
| Auth | `GET /api/admin/Auth/Logout` | Đăng xuất |
| Account | `GET /api/admin/Account` | Danh sách nhân viên |
| Account | `POST /api/admin/Account` | Thêm nhân viên |
| Product | `GET /api/admin/Product` | Danh sách sản phẩm |
| Product | `POST /api/admin/Product` | Thêm sản phẩm |
| Category | `GET /api/admin/Category` | Danh sách danh mục |
| Order | `GET /api/admin/Order` | Danh sách đơn hàng |
| Discount | `GET /api/admin/Discount` | Danh sách giảm giá |
| Dashboard | `GET /api/admin/Dashboard` | Thống kê |
| Role | `GET /api/admin/Role` | Danh sách vai trò & quyền |

### Client API (`/api`)

| Module | Endpoint | Mô tả |
|---|---|---|
| Auth | `POST /api/Auth/Login` | Đăng nhập khách hàng |
| Auth | `POST /api/Auth/Register` | Đăng ký |
| Auth | `POST /api/Auth/GetOTP` | Gửi OTP quên mật khẩu |
| Auth | `POST /api/Auth/ValidateOTP` | Xác thực OTP |
| Auth | `POST /api/Auth/CreateNewPassword` | Đặt lại mật khẩu |
| Auth | `GET /api/Auth/GetMe` | Thông tin khách hàng hiện tại |
| Product | `GET /api/Product` | Danh sách sản phẩm |
| Product | `GET /api/Product/{id}` | Chi tiết sản phẩm |
| Cart | `GET /api/Cart` | Xem giỏ hàng |
| Cart | `PUT /api/Cart` | Cập nhật giỏ hàng |
| Checkout | `POST /api/Checkout/COD` | Thanh toán tiền mặt |
| Checkout | `POST /api/Checkout/VNPAY` | Thanh toán VNPay |
| Checkout | `DELETE /api/Checkout/Cancel/{id}` | Hủy đơn hàng |
| Order | `GET /api/Order` | Danh sách đơn hàng của tôi |
| Rate | `POST /api/Rate` | Đánh giá sản phẩm |
| Address | `GET /api/Address` | Danh sách địa chỉ |
| Address | `POST /api/Address` | Thêm địa chỉ |

## Phân quyền

Hệ thống có **hai luồng xác thực riêng biệt**:

### Admin (Account)
- JWT ký bằng `Jwt:Key`
- Role claim: `Admin` hoặc tên role khác
- Phân quyền chi tiết qua `[PermissionAuthorize("Permission Code")]`
- Danh sách permissions: Product (CRUD), Category (CRUD), Order (RUD), Customer (RUD), Discount (CRUD), Account (CRUD), Rate (CRUD), Contact (RUD), Dashboard (R), Setting (RU), Permission Management

### Khách hàng (Customer)
- JWT ký bằng `Jwt:KeyClient`
- Role claim: `Client`
- Sử dụng `[Authorize(Roles = "Client")]`

## Dữ liệu mẫu

Khi chạy lần đầu, hệ thống tự động tạo:

| Dữ liệu | Số lượng |
|---|---|
| Danh mục | 21 danh mục (3 cấp cha, 18 cấp con) |
| Sản phẩm | 24 sản phẩm (áo, quần, tất) |
| Biến thể | 96 biến thể (4 biến thể/sản phẩm) |
| Thuộc tính | 2 loại: Color, Size |
| Mã giảm giá | 6 chương trình khuyến mại |
| Tài khoản admin | 6 tài khoản |
| Khách hàng | 10 khách hàng |
| Đơn hàng | 4 đơn hàng mẫu |
| Tags | 3 tags: New, Outlet, Đáng mua |

### Tài khoản admin mặc định

| Email | Vai trò |
|---|---|
| `bele@gmail.com` | Admin (toàn quyền) |

> Mật khẩu tài khoản admin mặc định: `Admin@123` (đã hash)
