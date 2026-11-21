# ChiliChek (C# / WPF)

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Platform](https://img.shields.io/badge/platform-Windows-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![UI](https://img.shields.io/badge/UI-WPF-5C2D91)](#)

Чекер на читы для **Rust** (WPF / .NET 8): локальные сканеры артефактов системы и SQLite-хранилище результатов.

> Pet-проект. Связанный Python/Electron вариант: [ChiliChekPY](https://github.com/JorniJave/ChiliChekPY) (private).

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

## Важно

- Локальные базы `*.db` и пользовательские логи **не коммитятся**
- Сторонние утилиты в `Tools/` (если есть бинарники) лучше держать локально / в Releases, не в исходниках без необходимости

## Лицензия

MIT (pet project)

