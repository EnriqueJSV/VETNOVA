# VetNova

Sistema de gestión veterinaria desarrollado como proyecto académico utilizando una arquitectura en capas (PL, BLL y DAL) con C#, Windows Forms y SQL Server.

---

## Integrantes

- **Enrique Solórzano**
- **Ian Quesada**
- **Alan Vargas**

---

## Arquitectura

El proyecto está desarrollado siguiendo una arquitectura de tres capas:

```
VETNOVA
│
├── VETNOVA.DAL
│   ├── BD
│   └── Entidades
│
├── VETNOVA.BLL
│   ├── BD
│   └── Entidades
│
├── VETNOVA.PL
│   ├── Generales
│   ├── Propietarios
│   ├── Veterinarios
│   ├── Especies
│   ├── Mascotas
│   ├── Citas
│   ├── Consultas
│   └── Seguridad
│
└── BaseDatos
    ├── 01_BaseDeDatos
    ├── 02_Tablas
    ├── 03_Procedimientos
    ├── 04_DatosPrueba
    └── 05_Consultas
```

---

## Tecnologías utilizadas

- C#
- Windows Forms (.NET)
- SQL Server
- SQL Server Management Studio (SSMS)
- Visual Studio 2022
- Git
- GitHub

---

## Flujo de trabajo

El desarrollo del proyecto sigue el siguiente flujo de ramas:

```
main
│
└── develop
      │
      └── feature/*
```

- `main`: versiones estables del proyecto.
- `develop`: integración del desarrollo.
- `feature/*`: desarrollo individual de cada módulo.

Todo cambio deberá realizarse mediante **Pull Request** hacia la rama `develop`.

---

## Base de datos

Los scripts SQL se encuentran en la carpeta **BaseDatos** del repositorio.

El orden recomendado de ejecución se encuentra documentado en:

```
BaseDatos/README.md
```