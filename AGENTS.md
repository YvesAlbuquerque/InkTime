# T.O.O.N. — The Office Of Nonsense — Agent Instructions

T.O.O.N. is an independent game repository at `YvesAlbuquerque/TOON`. It owns T.O.O.N.-specific game design, implementation, content, configuration, builds, persistence, AI adapters/prompts, and playable evidence.

The project was formerly known as InkTime / Ink Through Time. Those names are legacy aliases only.

## Source of truth

Read the smallest relevant evidence set in this order:

1. `README.md` for project identity, status, and routes.
2. `docs/design.md` for accepted T.O.O.N. game-design direction.
3. `docs/roadmap.md` and current GitHub Issues for planned work and dependencies.
4. Current implementation evidence in the owning engine/project files for runtime claims.
5. `docs/unreal-ai-development-strategy.md` for the accepted Unreal target and AI-heavy development rules.
6. YFramework for shared Polite Goblin/Loomlight terminology, cross-repository decisions, The Y Framework methodology, status vocabulary, and accepted cross-repository naming.
7. Loomlight Flux only as legacy Unity migration evidence.

Repository evidence overrides memory and previous conversations. Documentation does not prove implementation.

## Current evidence-based status

- **T.O.O.N. — The Office Of Nonsense** is the accepted current project/public name.
- The historical living-studio direction (roughly 1900–2030, cross-media production, people, place and historical context) is **Accepted direction** and **Documented**.
- Name clearance remains unresolved; a known exact `TOON` Steam-title collision is recorded as a commercial/legal risk.
- Continued development is **Planned**.
- **Unreal Engine** is the accepted target engine; migration remains **Planned** until an Unreal project is actually bootstrapped and validated.
- Existing Unity implementation remains conservatively **Scaffolded legacy evidence** except where owning evidence proves more.
- Historical comic/jam-era classes and assets are not proof of the accepted T.O.O.N. production loop.

## Product boundary

T.O.O.N. is a historical creative-studio management game about building one eccentric company across roughly 1900–2030. The studio, recurring professionals, persistent IPs, relationships, physical workplace, historical context, productions and archive evolve together across changing media.

Canonical production core:

`IP -> Production -> Medium -> Crew -> Stages -> Release -> Reception -> Legacy`

Media-specific structures such as panels, storyboard/shots or 3D asset stages are bounded submodels. Do not promote any one medium's pipeline into the permanent game-wide hierarchy.

Implement only the subset needed for the current proof.

## Studio/cast rules

- Studio professionals are recurring characters, not interchangeable worker resources.
- The cast may include humans, anthropomorphic animals, creatures, living objects and other original cartoon archetypes.
- Appearance/species is separate from personality and from longevity/existence model.
- Characters need readable silhouettes, profession, personality, history and relationship promise.
- Avoid one-note stereotypes.
- Prefer bold macro-shapes, strong line of action, readable posing, and animation-friendly design.
- Do not copy protected Disney, Warner/Looney Tunes, Fleischer, or other studio/character identities.

## Authorship and AI rules

- Development-time AI and runtime/player-facing AI are separate concerns.
- Runtime production intent, generated outputs and accepted history converge on game-owned data.
- AI may be a major content-generation mechanism; provider SDK/schema must still remain behind T.O.O.N.-owned contracts.
- Preserve human/player authority over creative direction, acceptance/rejection where exposed, and release decisions.
- Do not require feature-complete manual DCC authoring solely to demonstrate provider independence; use deterministic fixtures/fallbacks for validation where appropriate.
- Do not claim Game Studio or Nexus integration from the presence of AI features.

## Persistence rules

Treat studio identity, professionals, relationships, IPs, productions, historical/archive state and proof-critical consequences as persistent game-domain state.

Legacy `InkTime` saves/artifacts are migration evidence, not a shipped-player compatibility promise. Preserve representative fixtures or extract useful data where valuable; do not make full Unity-save compatibility a blocker for the Unreal game without explicit evidence that it is needed.

## Engine and migration rules

The accepted target engine is **Unreal Engine**. The exact Unreal version remains TBD until bootstrap/validation.

The current Unity 6 + Loomlight Flux implementation is legacy migration source evidence, not the target runtime architecture.

Before destructive migration work:

- inventory reusable domain/data concepts separately from Unity-specific implementation;
- preserve historical evidence and compatibility knowledge;
- do not build new game architecture on Flux after the Unreal direction;
- prefer small reviewable migration steps;
- never claim Unreal bootstrap, compile, package, migration, or runtime validation unless actually exercised.

## Repository ownership

- The **game repository** owns T.O.O.N.-specific gameplay, production rules, balance, content, scenes, saves, AI adapters/prompts, and game-specific architecture.
- **Loomlight Flux** at the legacy compatibility path `Assets/YJackCore/` owns only the reusable Unity framework implementation present in legacy migration evidence; it is not the target T.O.O.N. runtime framework.
- **YFramework** owns shared naming/routing/doctrine.
- **Loomlight Game Studio** may orchestrate work around T.O.O.N.; it does not own the game design/runtime.

## Legacy technical identifiers

The following may remain temporarily only as compatibility identifiers until a validated technical migration replaces them:

- `Assets/InkThroughTime/`;
- `InkThroughTime.*` namespaces and assemblies;
- `InkGameRoot`, `InkSaveService`, `IComicAIService`, and similar historical type names;
- historical documents, commits, and issue evidence.

Do not use these as the current game name in new user-facing text.

## Legacy Unity/Flux policy

- `Assets/YJackCore/` is a legacy compatibility path containing pinned Loomlight Flux.
- Never edit Flux to satisfy new Unreal-specific requirements.
- Do not port Flux source wholesale into Unreal.
- Reuse only domain ideas that earn their place after engine-neutral review.
- Preserve the exact validated historical pin in `docs/flux-upgrade-validation.md` as evidence.

## Coding conventions

- Keep changes small and reviewable.
- Use `develop` as the active development branch.
- Keep authoritative simulation state explicit and serializable.
- Prefer Unreal C++ for core game-owned systems when that improves clarity, testability, persistence, or professional evidence; use Blueprints where they improve iteration/presentation.
- Do not introduce Unreal frameworks such as GAS, Mass, replication, or complex plugin stacks solely for résumé breadth.
- Separate domain state from UI, provider adapters, render/output adapters, and engine presentation where practical.
- Preserve legacy Unity asset/`.meta` integrity until migration explicitly removes them.

## Implementation order

1. Bootstrap and validate the smallest reproducible Unreal project.
2. Create one T.O.O.N.-owned C++ module and one serializable/saveable studio-state proof.
3. Revalidate/port only the minimum persistent IP concepts required by the new design.
4. Add the minimum recurring professional + relationship models.
5. Prove one people/production decision with a persistent consequence.
6. Validate save/reopen and one representative visual interaction.
7. Add broader historical/media systems only after the proof works.
8. Add runtime AI-assisted/Hybrid proposals only behind game-owned contracts.

Historical `MockComicAIService` and comic-specific pipeline types are scaffold evidence, not automatically the target API.

## Scope boundaries

The following remain game-owned regardless of whether ideas are ported from legacy Unity/Flux evidence:

- studio simulation;
- professional/cast state;
- production pipeline;
- IP catalogue;
- production/release history;
- economy/progression where retained;
- AI job orchestration;
- generated/imported production artefact persistence;
- all gameplay rules.

## AI-heavy development rules

AI may be used extensively for research, code drafting, tests, debugging hypotheses, content, visual exploration, tooling, documentation, and repetitive production work.

- Generated output is not proof of correctness.
- Important systems must remain understandable, debuggable, maintainable, and evidence-backed.
- Preserve human/owner authority over architecture, releases, public claims, and irreversible decisions.
- Separate development-time AI from runtime/player-facing AI.
- Runtime providers must remain adapters behind T.O.O.N.-owned contracts.
- For portfolio-critical Unreal work, preserve enough technical evidence to show what was designed, reviewed, compiled, tested, profiled, or debugged.

## Validation discipline

Never claim a test, build, migration, export, AI integration, runtime behaviour, save migration, or visual target was validated unless it actually ran or was reviewed with recorded evidence.
