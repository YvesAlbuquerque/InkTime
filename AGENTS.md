# Ink Through Time — Agent Guidelines

## Repository Ownership

- The **game repository** (InkTime) owns all product decisions, gameplay rules, balance, content, AI prompts, scenes, save formats, and game-specific architecture.
- **Loomlight Flux** (located at `Assets/YJackCore/`) owns reusable framework architecture and cross-project utilities.

## Submodule Policy

- `Assets/YJackCore/` is a read-only Git submodule (Loomlight Flux).
- **Never edit the Flux submodule for game-specific requirements.**
- Do not copy Loomlight Flux source code into the game project.
- Do not place Ink Through Time-specific gameplay, balance, content, AI prompts, scenes, or persistence formats inside the Loomlight Flux submodule.
- Preserve the submodule configuration and ensure recursive cloning works.
- Game-specific adapters and integrations belong in `Assets/InkThroughTime/`.

## Coding Conventions

- **Search Flux before creating reusable helpers.** Check `Assets/YJackCore/` for an existing solution before writing new utility code.
- Keep all Unity changes compiling after each task — do not leave broken code in any committed state.
- Preserve asset and `.meta` file integrity — every asset file must have a matching `.meta` file.
- Prefer small, reviewable changes. One logical concern per commit.
- Use `develop` as the active development branch. Keep `main` stable and buildable.

## Implementation Order

1. Build the complete **mock pipeline** before integrating local AI inference.
2. All AI stages must first use `MockComicAIService`.
3. `LocalComicAIService` and real inference are only introduced after the mock loop is verified end-to-end.
4. Do not add cloud AI APIs, accounts, telemetry services, or required network access.

## Architecture Rules

- Use `InkGameRoot` as the game-specific composition root (a MonoBehaviour in the main scene).
- Keep authoritative simulation state in pure serializable C# classes under `Domain/`.
- Do not create a generic dependency-injection framework.
- Do not add new global singleton managers when a game-owned service referenced by `InkGameRoot` is sufficient.
- Runtime AI must never directly own cash, sales, progression, or bankruptcy decisions.

## Scope Boundaries

The following remain **game-owned** even when Flux helpers are used:
- Simulation clock
- Employee Creativity system
- Production pipeline
- Publication scoring
- Bankruptcy rules
- IP catalogue
- Nostalgia opportunities
- AI job orchestration
- Generated image and comic artefact persistence
- All gameplay rules

## Package Policy

- Do not introduce machine-specific absolute `file:` package paths.
- Do not add both `com.unity.sentis` and `com.unity.ai.inference` simultaneously — they are the same underlying package under different names.
- Do not make unrelated package upgrades.
