# InkTime Agent Instructions

InkTime is an independent Unity game repository. It owns InkTime-specific game design, implementation, content, configuration, builds, and playable evidence.

## Source of truth

Read the smallest relevant evidence set in this order:

1. `README.md` for project identity, status, and routes.
2. `docs/design.md` for accepted InkTime game-design direction.
3. `docs/roadmap.md` and current GitHub Issues for planned work and dependencies.
4. Current Unity project configuration, code, assets, tests, and branch state for implementation claims.
5. YFramework for shared Polite Goblin/Loomlight terminology, cross-repository decisions, The Y Framework methodology, and status vocabulary.
6. Loomlight Flux for reusable Unity framework implementation and migration guidance.

Repository evidence overrides memory and previous conversations. Documentation does not prove implementation.

## Current evidence-based status

- InkTime's renewed product/design direction is **Accepted direction** and **Documented**.
- Continued development is **Planned** through the roadmap and Issues.
- The existing Unity project provides repository structure and historical code/assets, so the implementation should be treated conservatively as **Scaffolded** until an audit proves specific capabilities.
- Do not claim the renewed comic/IP workflow, AI authoring, manual authoring, PDF export, or Loomlight Flux integration as implemented until the owning evidence exists.

## Product boundary

InkTime is a game about creating and developing fictional comic IPs, characters, lore, stories, and publications. A strip is one publication format, not the central domain entity.

The canonical content hierarchy is conceptually:

`IP -> Series -> Story/Arc -> Publication -> Script -> Pages -> Panels`

The first vertical slice may implement only the subset needed to prove the loop.

## Authorship rules

- Support `Manual`, `AI`, and `Hybrid` authorship modes through the same structured script model.
- Do not create separate manual and AI production pipelines.
- AI assistance is a tool inside the game, not the definition of the game.
- Manual authorship must still participate in InkTime's production, composition, publication, continuity, and progression systems.
- Preserve human authority over final authorship and publication decisions.

## IP and continuity rules

Treat fictional IP, characters, relationships, and canon/lore facts as persistent game-domain entities, not prompt-only data. Published work may update canon, but continuity changes must remain inspectable and attributable to their source publication.

Start small. Do not build a giant lore encyclopedia before the vertical slice proves value.

## Publication and export rules

- `Strip` and longer-form `Comic` publications share the same underlying publication model where practical.
- The structured internal publication remains the source of truth.
- PDF is an export renderer, not the storage format.
- Initial PDF scope is digital reading/export. Do not claim print-ready output without explicit validation for bleed, trim, DPI, colour management, fonts, and related production requirements.

## Unity and framework rules

The repository currently targets Unity 6 and contains legacy YJack/YJackCore references. Loomlight Flux is the canonical successor framework, but migration must be evidence-driven.

Before framework changes:

- inventory current YJackCore dependencies and InkTime-specific coupling;
- inspect current Loomlight Flux `AGENTS.md`, package metadata, architecture, APIs, tests, and migration guidance;
- protect Unity serialization, GUIDs, `.meta` files, assembly boundaries, editor/runtime boundaries, and asset references;
- prefer small reviewable migration steps over broad replacements;
- do not claim migration complete until the project compiles and the relevant scenes/workflows are validated.

## Repository ownership

- The **game repository** (InkTime) owns all product decisions, gameplay rules, balance, content, AI prompts, scenes, save formats, and game-specific architecture.
- **Loomlight Flux** (located at `Assets/YJackCore/`) owns reusable framework architecture and cross-project utilities.

## Submodule policy

- `Assets/YJackCore/` is a read-only Git submodule (Loomlight Flux).
- **Never edit the Flux submodule for game-specific requirements.**
- Do not copy Loomlight Flux source code into the game project.
- Do not place Ink Through Time-specific gameplay, balance, content, AI prompts, scenes, or persistence formats inside the Loomlight Flux submodule.
- Preserve the submodule configuration and ensure recursive cloning works.
- Game-specific adapters and integrations belong in `Assets/InkThroughTime/`.

## Coding conventions

- **Search Flux before creating reusable helpers.** Check `Assets/YJackCore/` for an existing solution before writing new utility code.
- Keep all Unity changes compiling after each task — do not leave broken code in any committed state.
- Preserve asset and `.meta` file integrity — every asset file must have a matching `.meta` file.
- Prefer small, reviewable changes. One logical concern per commit.
- Use `develop` as the active development branch. Keep `main` stable and buildable.

## Implementation order

1. Build the complete **mock pipeline** before integrating local AI inference.
2. All AI stages must first use `MockComicAIService`.
3. `LocalComicAIService` and real inference are only introduced after the mock loop is verified end-to-end.
4. Do not add cloud AI APIs, accounts, telemetry services, or required network access.

## Architecture rules

- Use `InkGameRoot` as the game-specific composition root (a MonoBehaviour in the main scene).
- Keep authoritative simulation state in pure serializable C# classes under `Domain/`.
- Do not create a generic dependency-injection framework.
- Do not add new global singleton managers when a game-owned service referenced by `InkGameRoot` is sufficient.
- Runtime AI must never directly own cash, sales, progression, or bankruptcy decisions.

## Scope boundaries

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

## Package policy

- Do not introduce machine-specific absolute `file:` package paths.
- Do not add both `com.unity.sentis` and `com.unity.ai.inference` simultaneously — they are the same underlying package under different names.
- Do not make unrelated package upgrades.

## Engineering rules

- Prefer one coherent issue per user-visible or enabling outcome.
- Record dependencies, risks, acceptance criteria, and validation in Issues.
- Reuse existing project or Flux capabilities when evidence shows they fit; do not invent duplicate systems by default.
- Keep domain models explicit and serializable.
- Separate core data/state from UI, AI providers, render/export adapters, and Unity-specific presentation where practical.
- Treat external AI/provider APIs as adapters behind InkTime-owned contracts.
- Never commit credentials or provider secrets.

## Validation discipline

Never claim a test, build, migration, export, AI integration, or runtime behaviour ran unless it actually ran. For each completed roadmap item, record the evidence that moves it from Planned/Scaffolded to Prototyped or Validated.
