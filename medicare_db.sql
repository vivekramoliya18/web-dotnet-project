-- MediCareWeb database schema for XAMPP MariaDB / MySQL
-- Import this file using phpMyAdmin > Import.
CREATE DATABASE IF NOT EXISTS medicare_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE medicare_db;

CREATE TABLE IF NOT EXISTS Patients (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Phone VARCHAR(30) NOT NULL,
    Email VARCHAR(255) NULL,
    Gender VARCHAR(20) NOT NULL,
    DateOfBirth DATE NOT NULL
);

CREATE TABLE IF NOT EXISTS Doctors (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Specialty VARCHAR(80) NOT NULL,
    Phone VARCHAR(30) NULL,
    Email VARCHAR(255) NULL
);

CREATE TABLE IF NOT EXISTS Appointments (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    PatientName VARCHAR(100) NOT NULL,
    DoctorName VARCHAR(100) NOT NULL,
    AppointmentDate DATE NOT NULL,
    AppointmentTime VARCHAR(10) NOT NULL,
    Reason VARCHAR(500) NULL,
    Status VARCHAR(20) NOT NULL DEFAULT 'Scheduled',
    Diagnosis VARCHAR(1000) NULL,
    VisitNotes TEXT NULL,
    CompletedAt DATETIME NULL,
    INDEX idx_appointment_date (AppointmentDate),
    INDEX idx_appointment_status (Status)
);

-- Note: This schema creates the database tables. The current sample MVC controllers
-- keep demo records in memory; EF Core database integration is a separate next step.
