# T.O.O.N. — The Office Of Nonsense — Agent Instructions

T.O.O.N. is an independent Unity game repository at `YvesAlbuquerque/TOON`. It owns T.O.O.N.-specific game design, implementation, content, configuration, builds, persistence, AI adapters/prompts, and playable evidence.

The project was formerly known as InkTime / Ink Through Time. Those names are legacy aliases only.

## Source of truth

Read the smallest relevant evidence set in this order:

1. `README.md` for project identity, status, and routes.
2. `docs/design.md` for accepted T.O.O.N. game-design direction.
3. `docs/roadmap.md` and current GitHub Issues for planned work and dependencies.
4. Current Unity project configuration, code, assets, tests, and branch state for implementation claims.
5. YFramework for shared Polite Goblin/Loomlight terminology, cross-repository decisions, The Y Framework methodology, status vocabulary, and accepted cross-repository naming.
6. Loomlight Flux for reusable Unity framework implementation and migration guidance.

Repository evidence overrides memory and previous conversations. Documentation does not prove implementation.

## Current evidence-based status

- **T.O.O.N. — The Office Of Nonsense** is the accepted current project/public name.
- The animation/cartoon-studio creative pivot is **Accepted direction** and **Documented**.
- Name clearance remains unresolved; a known exact `TOON` Steam-title collision is recorded as a commercial/legal risk.
- Continued development is **Planned**.
- Existing Unity implementation remains conservatively **Scaffolded** except where owning evidence proves more.
- Historical comic/jam-era classes and assets are not proof of the accepted T.O.O.N. production loop.

## Product boundary

T.O.O.N. is a game about running a characterful cartoon-animation studio, developing animated IPs, directing a recurring cast of studio professionals, making production decisions, and releasing animated work whose consequences persist.

Conceptual target hierarchy:

`IP -> Series/Project -> Production -> Script -> Storyboard -> Sequence -> Shot -> Animatic/Final Work`

Implement only the subset needed for the current proof.

## Studio/cast rules

- Studio professionals are recurring characters, not interchangeable worker resources.
- Anthropomorphic animal characters must have readable silhouettes, profession, personality, biography, and relationship promise.
- Species is not personality; avoid one-note animal stereotypes.
- Prefer bold macro-shapes, strong line of action, readable posing, and animation-friendly design.
- Do not copy protected Disney, Warner/Looney Tunes, Fleischer, or other studio/character identities.

## Authorship and AI rules

- Manual, AI-assisted, and Hybrid work must converge on shared game-owned production data.
- AI assistance is a tool inside the game, not the definition of the game.
- AI outputs are proposals until accepted by the player.
- Preserve human/player authority over final creative and release decisions.
- Runtime/provider choices remain adapters behind T.O.O.N.-owned contracts.
- Do not claim Game Studio or Nexus integration from the presence of AI features.

## Persistence rules

Treat studio identity, professionals, IPs, production history, relationships/canon where relevant, and proof-critical consequences as persistent game-domain state.

Legacy `InkTime` save/artifact directories must not be abandoned without a migration/fallback path.

## Unity and framework rules

The repository targets Unity 6. Loomlight Flux is the canonical reusable framework.

Before framework-sensitive changes:

- inspect current Flux evidence and the validated project pin;
- protect Unity serialization, GUIDs, `.meta` files, assembly boundaries, editor/runtime boundaries, and asset references;
- prefer small reviewable changes over broad rewrites;
- never claim migration/compile/build validation unless actually exercised.

## Repository ownership

- The **game repository** owns T.O.O.N.-specific gameplay, production rules, balance, content, scenes, saves, AI adapters/prompts, and game-specific architecture.
- **Loomlight Flux** at the legacy compatibility path `Assets/YJackCore/` owns reusable framework implementation.
- **YFramework** owns shared naming/routing/doctrine.
- **Loomlight Game Studio** may orchestrate work around T.O.O.N.; it does not own the game design/runtime.

## Legacy technical identifiers

The following may remain temporarily only as compatibility identifiers until a validated technical migration replaces them:

- `Assets/InkThroughTime/`;
- `InkThroughTime.*` namespaces and assemblies;
- `InkGameRoot`, `InkSaveService`, `IComicAIService`, and similar historical type names;
- historical documents, commits, and issue evidence.

Do not use these as the current game name in new user-facing text.

## Submodule policy

- `Assets/YJackCore/` is a legacy compatibility path containing pinned Loomlight Flux.
- Never edit the Flux submodule for game-specific requirements.
- Do not copy Flux source into the game project.
- T.O.O.N.-specific adapters/integration remain game-owned.

The exact validated framework pin is recorded in `docs/flux-upgrade-validation.md`.

## Coding conventions

- Search Flux before creating reusable helpers.
- Preserve asset/`.meta` integrity.
- Keep changes small and reviewable.
- Use `develop` as the active development branch.
- Keep authoritative simulation state explicit and serializable.
- Separate domain state from UI, provider adapters, render/output adapters, and Unity presentation where practical.

## Implementation order

1. Validate the accepted T.O.O.N. visual/studio/cast target.
2. Preserve/revalidate the minimum persistent IP foundation.
3. Add the minimum recurring professional model.
4. Define the smallest animation-production domain required by one short.
5. Prove the shared manual/mock production loop.
6. Add AI-assisted/Hybrid proposals only behind game-owned contracts.
7. Validate release -> persistent consequence -> save/reopen before broad simulation.

Historical `MockComicAIService` and comic-specific pipeline types are scaffold evidence, not automatically the target API.

## Scope boundaries

The following remain game-owned even when Flux helpers are used:

- studio simulation;
- professional/cast state;
- production pipeline;
- IP catalogue;
- production/release history;
- economy/progression where retained;
- AI job orchestration;
- generated/imported production artefact persistence;
- all gameplay rules.

## Package policy

- Do not introduce machine-specific absolute `file:` package paths.
- Do not add both `com.unity.sentis` and `com.unity.ai.inference`.
- Do not make unrelated package upgrades.

## Validation discipline

Never claim a test, build, migration, export, AI integration, runtime behaviour, save migration, or visual target was validated unless it actually ran or was reviewed with recorded evidence.
