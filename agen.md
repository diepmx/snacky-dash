# Agent Instructions

This repository is a Unity game project. Follow these rules for every change in this workspace.

## Project Context

- Unity Editor version: `6000.2.10f1`
- Unity executable: `C:\Program Files\Unity\Hub\Editor\6000.2.10f1\Editor\Unity.exe`
- Main project folders: `Assets`, `Packages`, `ProjectSettings`
- Scenes currently present: `Assets/Scenes/Boot.unity`, `Assets/Scenes/Main.unity`, `Assets/Scenes/Game.unity`

## Working Rules

- Read the existing code and assets before editing. Prefer the project's current patterns over new abstractions.
- Keep edits scoped to the requested gameplay, UI, data, or build behavior.
- Do not overwrite or revert unrelated user changes. Check `git status --short` before broad edits.
- Prefer editing C# source and package/project settings with text patches. Avoid manual YAML edits to scenes, prefabs, and ScriptableObjects unless the exact serialized change is understood.
- Preserve Unity `.meta` files. When adding assets, add the asset and its `.meta` together when Unity generates one.
- Do not delete `Library`, `Temp`, `ProjectSettings`, `Packages`, or generated Unity metadata as a cleanup shortcut.
- Avoid changing third-party plugin code under `Assets/Plugins` unless the requested fix directly requires it.

## Unity Verification

- Use the installed Unity version for project checks.
- For compile validation, prefer Unity batchmode with this project path:

```powershell
& "C:\Program Files\Unity\Hub\Editor\6000.2.10f1\Editor\Unity.exe" -batchmode -quit -projectPath "D:\Snacky Dash_ Food Maze Puzzle_1.5.1_APKPure\Snacky dash" -logFile "Logs\codex-unity-compile.log"
```

- After a Unity batchmode run, inspect `Logs\codex-unity-compile.log` for compiler errors and relevant warnings.
- If a change affects gameplay flow, movement, save data, ads, economy, or level loading, identify the affected scene or entry point and state what was verified.

## Code Style

- Keep C# changes simple and explicit.
- Use existing namespaces, dependency injection patterns, serialization attributes, and naming conventions.
- Do not introduce new packages unless the task requires them and the package is compatible with Unity `6000.2.10f1`.
- Add comments only for non-obvious logic or Unity serialization constraints.

## Communication

- Report changed files and verification results clearly.
- If Unity cannot complete a check because of editor licensing, missing modules, or project import issues, include the exact blocker and the log path.
