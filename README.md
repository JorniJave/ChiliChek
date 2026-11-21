# ChiliChek (C# / WPF)

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Platform](https://img.shields.io/badge/platform-Windows-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![UI](https://img.shields.io/badge/UI-WPF-5C2D91)](#)

Чекер на читы для **Rust** — десктоп-утилита на **WPF (.NET 8)** для локальных проверок системы: сканеры, просмотр артефактов, SQLite.

> Pet-проект. Python-вариант: [ChiliChekPY](https://github.com/JorniJave/ChiliChekPY) (private).

## Стек

- C# / WPF (`net8.0-windows`)
- Microsoft.Data.Sqlite / System.Data.SQLite

## Запуск

```bash
dotnet restore
dotnet run --project ChiliChek
```

Или откройте `ChiliChek.sln` в Visual Studio 2022+.

## Важно

- Локальные базы `*.db` и логи **не коммитятся**
- Сторонние утилиты в `Tools/` — локально / Releases, не в исходниках без необходимости

## Лицензия

MIT (pet project)
