# VR-Shooting

## Mô tả dự án

**VR-Shooting** là một dự án game bắn súng được phát triển trên nền tảng Unity, tích hợp với kính thực tế ảo (VR). Dự án cung cấp một môi trường bắn súng thực tế với sự tương tác của các yếu tố như vũ khí, kẻ thù và các làn sóng tấn công (wave). Được thiết kế để tương thích với kính VR Pico.

---

## Yêu cầu hệ thống

### Phần cứng
- Máy tính chạy hệ điều hành Windows, macOS, hoặc Linux.
- Kính VR Pico (khuyến nghị phiên bản mới nhất).
- RAM tối thiểu: 8GB (khuyến nghị 16GB trở lên để phát triển mượt mà).
- CPU: Intel Core i5 hoặc AMD Ryzen 5 trở lên.
- GPU: Hỗ trợ DirectX 11 (NVIDIA GTX 1060 hoặc tương đương trở lên).

### Phần mềm
- Unity Editor (phiên bản Unity từ **2021.3.6 LTS** trở lên).
- .NET SDK (tích hợp C#) – cài đặt với Visual Studio Code hoặc Visual Studio.
- Kính Pico SDK for Unity.
- Visual Studio Code hoặc Visual Studio IDE (tích hợp với Unity).

---

## Hướng dẫn cài đặt

### 1. Cài đặt Unity
1. Truy cập trang [Unity Download](https://unity.com/download).
2. Tải xuống và cài đặt Unity Hub (khuyến nghị sử dụng Unity Hub để quản lý các phiên bản Unity dễ dàng).
3. Sau khi cài đặt Unity Hub, thêm phiên bản Unity Editor từ **2021.3.6 LTS** trở lên.
   - Đảm bảo thêm các mô-đun cần thiết trong quá trình cài đặt:
     - **Android Build Support** (bao gồm SDK, NDK, và OpenJDK).
     - **XR Plug-in Management** để hỗ trợ kính thực tế ảo.
   - Hướng dẫn chi tiết tại: [Unity Install Guide](https://unity.com/download).

### 2. Cài đặt C# và Visual Studio Code
1. Truy cập [Hướng dẫn cài đặt Visual Studio Code](https://learn.microsoft.com/en-us/shows/visual-studio-code/getting-started-with-csharp-dotnet-in-vs-code-official-beginner-guide) để cấu hình C# trong Visual Studio Code.
2. Cài đặt các tiện ích mở rộng (extensions) trong Visual Studio Code:
   - **C#** (dành cho Unity).
   - **Unity Tools**.
3. Nếu bạn dùng Visual Studio IDE thay vì Visual Studio Code:
   - Cài đặt Visual Studio (phiên bản Community hoặc cao hơn).
   - Khi cài đặt, thêm các workload sau:
     - **Game development with Unity**.
     - **.NET desktop development**.

### 3. Cài đặt môi trường lập trình với kính VR Pico
1. Truy cập [Developer Portal của Pico](https://developer.picoxr.com/document/unity/create-a-developer-account-organization-and-app) để tạo tài khoản và ứng dụng phát triển.
2. Tải và cài đặt **Pico SDK for Unity**.
3. Tích hợp Pico SDK vào dự án:
   - Tải xuống thư viện Pico Unity SDK từ trang chính thức hoặc [Thư mục Pico SDK](https://developer.picoxr.com).
   - Import tệp SDK vào dự án Unity bằng cách kéo thả vào cửa sổ **Assets** của Unity.

### 4. Tải và cài đặt dự án VR-Shooting
1. Tải thư mục dự án từ liên kết sau: [Thư mục cài đặt dự án](https://drive.google.com/file/d/15E49wmO8l0XECUnYQY8gTAwPnKRJijeq/view?usp=drive_link).
2. Giải nén tệp `.zip` vào thư mục mong muốn trên máy của bạn.
3. Mở Unity Hub:
   - Nhấn nút **Add Project**, chọn đường dẫn đến thư mục vừa giải nén.
   - Đảm bảo dự án chạy trên phiên bản Unity khuyến nghị (**2021.3.6 LTS** hoặc cao hơn).

### 5. Thiết lập XR Plug-in Management
1. Trong Unity Editor, đi đến **Edit > Project Settings > XR Plug-in Management**.
2. Tích chọn **PicoXR** cho nền tảng Android.
3. Cấu hình các tùy chọn khác liên quan đến kính Pico (nếu cần).

### 6. Xây dựng và chạy dự án trên kính Pico
1. Đảm bảo kính VR đã kết nối đúng cách với máy tính thông qua cáp USB.
2. Chọn **File > Build Settings** trong Unity Editor:
   - Đổi nền tảng sang **Android** (chọn Switch Platform).
   - Đảm bảo rằng thiết bị kết nối đã được nhận diện.
   - Nhấn nút **Build and Run** để biên dịch và triển khai ứng dụng trực tiếp lên kính.
3. Nếu cần biên dịch thành tệp APK, chọn **Build**, sau đó cài đặt tệp APK lên kính VR thông qua trình quản lý thiết bị.

---

## Lưu ý quan trọng
- Đảm bảo kích hoạt chế độ nhà phát triển (Developer Mode) trên kính Pico để có thể cài đặt ứng dụng tùy chỉnh.
- Đọc tài liệu chính thức của kính Pico nếu gặp bất kỳ vấn đề tương thích nào: [Pico Documentation](https://developer.picoxr.com/document).
- Nếu bạn cần chỉnh sửa mã nguồn, khuyến khích sử dụng IDE như Visual Studio để tận dụng IntelliSense và khả năng gỡ lỗi.

---

## Liên hệ và hỗ trợ
Nếu gặp bất kỳ vấn đề nào trong quá trình cài đặt hoặc phát triển dự án, vui lòng liên hệ qua:
- Email: kiennguyen.kris@gmail.com, kien.nt226110@sis.hust.edu.vn.
- Email thành viên hợp tác: minh.tq226092@sis.hust.edu.vn, minhfananime@gmail.com.

