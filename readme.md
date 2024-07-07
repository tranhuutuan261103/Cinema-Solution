# CinemaSolution Project Structure

## 1. Infrastructure (Hạ tầng)

- **CinemaSolution.Common.csproj**: Đây là một dự án chứa các thành phần dùng chung, như các tiện ích, lớp cơ sở, hoặc các thành phần không phụ thuộc vào dự án cụ thể nào khác.
- **CinemaSolution.ViewModels.csproj**: Dự án này chứa các lớp ViewModel, thường được sử dụng để truyền dữ liệu giữa các lớp UI và lớp logic nghiệp vụ.

## 2. Domain (Miền)

- **CinemaSolution.Data.csproj**: Dự án này chứa các lớp liên quan đến dữ liệu, chẳng hạn như các thực thể dữ liệu (Entities), các lớp ánh xạ đối tượng quan hệ (ORM) hoặc các lớp truy cập dữ liệu.
- **CinemaSolution.Application.csproj**: Dự án này chứa logic nghiệp vụ chính của ứng dụng, bao gồm các dịch vụ, quy trình nghiệp vụ và các trường hợp sử dụng (use cases).

## 3. Hosts (Máy chủ)

- **CinemaSolution.BackendApi.csproj**: Dự án này là API backend, cung cấp các dịch vụ web cho các ứng dụng khác hoặc giao diện người dùng.