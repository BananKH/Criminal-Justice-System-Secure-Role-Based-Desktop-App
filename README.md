# 🛡️ Criminal Justice System – Secure Role-Based Desktop App

A Windows Forms-based desktop application built in C# with a MySQL backend, designed for secure access and management of sensitive criminal justice data. The system supports multiple user roles with distinct permissions: Admin, Police Officer, Forensics, and Investigator.

## 🔐 Features

### User Authentication
- Secure login with passwords hashed and salted using **BCrypt**.
- All credentials are stored safely in the database.

### Role-Based Access Control (RBAC)
- Users only access features and data based on their assigned role.

### Password Reset
- Built-in password reset with:
  - Old password verification.
  - Strong password policy enforcement:
    - Uppercase, lowercase, number, special character, minimum 8 characters.
  - Secure hashing and salting for new passwords.

### Action Logging System
- All user actions are recorded in the `app_logs` table using a custom `Logger` class, tracking:
  - Username
  - Timestamp
  - Action performed

### Secure Coding Practices
- Uses parameterized queries to prevent SQL injection.
- Error handling and logging for maintainability and traceability.

## 🛠️ Tech Stack

- **Language**: C# (.NET Framework – Windows Forms)
- **Database**: MySQL
- **Libraries**:
  - `MySql.Data.MySqlClient`
  - `BCrypt.Net`
- **Tools**: Visual Studio, MySQL Workbench

## 🚀 How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/BananKH/Criminal-Justice-System-Secure-Role-Based-Desktop-App.git
   ```
2. Set your MySQL connection string in App.config under ConString and ConAdmin.
3. Run the project in Visual Studio.
   
   
