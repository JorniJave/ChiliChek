# ChiliChek (C# / WPF)

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Platform](https://img.shields.io/badge/platform-Windows-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![UI](https://img.shields.io/badge/UI-WPF-5C2D91)](#)
[![Game](https://img.shields.io/badge/Rust-cheat_checker-cd412b)](#)

Чекер на читы для **Rust** — десктоп-утилита на **WPF (.NET 8)** для локального анализа артефактов системы (процессы, реестр, USB, файлы и связанные следы).

> Pet-проект. Python-вариант с более полным UI сканеров: [ChiliChekPY](https://github.com/JorniJave/ChiliChekPY) (private).

## Для чего

- Локальная проверка **своей** или доверенной машины перед/после сессии  
- Просмотр артефактов и сохранение результатов в SQLite  
- Не предназначен для обхода серверного античита или атак на других игроков  

## Стек

- C# / WPF (`net8.0-windows`)  
- Microsoft.Data.Sqlite / System.Data.SQLite  

## Запуск

```bash
# нужен .NET 8 SDK
dotnet restore
dotnet run --project ChiliChek
```

Или откройте `ChiliChek.sln` в Visual Studio 2022+.

## Структура

```
ChiliChek/
├── ChiliChek.sln
└── ChiliChek/
    ├── App.xaml(.cs)
    ├── MainWindow.xaml(.cs)
    └── ChiliChek.csproj
```

## Что не коммитится

- `bin/`, `obj/`, `*.user`  
- `*.db`, логи  
- сторонние `.exe` в `Tools/` (при необходимости — локально или Releases)  

## Ветки

`main` · `develop`

## Лицензия

MIT (pet project)
