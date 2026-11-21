# ChiliChek (C# / WPF)

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Platform](https://img.shields.io/badge/platform-Windows-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![UI](https://img.shields.io/badge/UI-WPF-5C2D91)](#)
[![Game](https://img.shields.io/badge/Rust-cheat_checker-cd412b)](#)

Чекер на читы для **Rust** — десктоп-утилита на **WPF (.NET 8)** для локального анализа артефактов системы (процессы, реестр, USB, файлы и связанные следы).

**Назначение:** инструмент для **модераторов** и проверки игроков на читы (локальный аудит машины по согласию / на доверенном ПК).

Python-вариант с более полным UI сканеров: [ChiliChekPY](https://github.com/JorniJave/ChiliChekPY) (private).

## Для кого

- Модераторы серверов / комьюнити Rust  
- Проверка машины перед допуском или после жалобы  
- Локальный разбор артефактов с сохранением результатов в SQLite  

## Что делает

- Локальная проверка **своей** или **доверенной** машины (по согласию проверяемого)  
- Просмотр артефактов: процессы, реестр, USB, файлы и связанные следы  
- Сохранение результатов проверки в SQLite  

## Что это не делает

- Не обходит серверный античит  
- Не предназначен для атак на чужие ПК без согласия  
- Не заменяет официальные античиты Facepunch / EAC  

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
- сторонние `.exe` в `Tools/` (локально или Releases)  

## Ветки

`main` · `develop`

## Лицензия

MIT
