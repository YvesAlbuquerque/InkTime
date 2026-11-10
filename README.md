# T.O.O.N. — The Office Of Nonsense

**T.O.O.N. — The Office Of Nonsense** is an independent Unity game about running a characterful cartoon-animation studio. The player develops original animated properties, directs a recurring crew of cartoon professionals, manages production, and turns ideas into shorts, episodes, and evolving animated worlds.

The project was formerly known as **InkTime / Ink Through Time**. Those names are legacy aliases only and remain in historical or compatibility-sensitive technical evidence where rewriting them would falsify history or risk Unity/save compatibility.

## Current status

- **Public/project name:** **T.O.O.N. — The Office Of Nonsense** — **Accepted direction**, owner-selected on 2026-11-09.
- **Name clearance:** unresolved. The owner accepted the name with the known preliminary collision risk that another released Steam game uses the exact title `TOON`; this repository does not claim trademark/store clearance.
- **Creative medium pivot:** **Accepted direction** — animation/cartoon-studio-first rather than comic-publication-first.
- **Canonical design rewrite:** documented in [docs/design.md](docs/design.md).
- **Continued development:** **Planned** through [docs/roadmap.md](docs/roadmap.md) and GitHub Issues.
- **Existing implementation:** conservatively **Scaffolded**. Historical comic/jam-era code and data are not evidence that the renewed animation-studio experience is implemented.
- **Persistent IP foundation:** a minimum persistent IP model has been merged; runtime validation remains bounded by its owning evidence.
- **Loomlight Flux host migration:** the bounded host upgrade recorded in repository evidence is complete; the project remains pinned to the actually validated Flux commit described in [docs/flux-upgrade-validation.md](docs/flux-upgrade-validation.md).

T.O.O.N. currently targets Unity `6000.3.13f1`.

## Player fantasy

> Run an eccentric cartoon-animation studio, develop original animated properties, direct a memorable crew of artists, and turn ideas into shorts, episodes, and evolving animated worlds.

The game should create attachment to both:

1. the fictional properties being created; and
2. the recurring studio professionals who make them.

## Core direction

The intended long-term loop is:

`Build the studio -> develop an IP -> shape characters/story -> plan a production -> storyboard/animate -> release -> audience/business consequences -> studio/IP evolves -> next production`

The first renewed vertical slice should prove a smaller coherent loop:

`Open one studio -> develop one IP -> assign a small recurring crew -> create one short production -> move through script/storyboard/production states -> release -> record consequences/history -> save/reopen`

## Domain direction

The animation-first production hierarchy is conceptually:

`IP -> Series/Project -> Production -> Script -> Storyboard -> Sequence -> Shot -> Animatic/Final Work`

This is the target design vocabulary. Existing comic-specific classes such as `PublishedComic`, `ComicPlan`, `IComicAIService`, and historical `Pages/Panels` structures are legacy scaffold evidence until explicitly migrated or replaced.

Persistent IP identity, characters, relationships, canon/lore, studio staff, production history, and save/versioning boundaries remain useful foundations.

## Studio cast and art direction

Studio professionals should read as a recurring **cast**, not interchangeable worker units.

The accepted starting direction is:

- original anthropomorphic cartoon professionals;
- species such as dog, cat, duck, rabbit, and other silhouette-friendly characters;
- strong graphic shapes, readable silhouettes, exaggerated posing, squash/stretch, and animation-aware motion;
- profession, competence, biography, ambition, relationships, and flaws beyond a single animal stereotype;
- classic-cartoon principles as structural inspiration without copying protected characters, studios, or one historical house style;
- a contemporary authored art direction rather than a generic nostalgia filter.

## Authorship and AI

Manual, AI-assisted, and Hybrid creative work should share game-owned structured production data.

AI is a tool inside T.O.O.N., not the identity of the game. Provider/runtime choices remain adapters behind game-owned contracts. The player retains authority over creative commitments and released work.

## Repository and framework boundaries

This repository owns T.O.O.N.-specific design, implementation, content, configuration, builds, save formats, AI adapters/prompts, and playable evidence.

YFramework owns shared Polite Goblin/Loomlight terminology, cross-repository naming/routing, The Y Framework methodology, and canonical status vocabulary.

Loomlight Flux owns reusable Unity gameplay-framework implementation. Flux is a framework dependency, not T.O.O.N.'s identity.

Loomlight Game Studio may orchestrate production work around the project but does not own this game's design or implementation.

## Technical rename boundary

The public/project rename is accepted. Technical identifiers are migrated only where compatibility is understood.

Legacy identifiers can temporarily remain in:

- the GitHub repository slug `InkTime`;
- `Assets/InkThroughTime/`;
- `InkThroughTime.*` namespaces/assemblies;
- historical documents and commit/issue evidence;
- legacy save/artifact paths needed for migration.

They must be treated as compatibility identifiers, not as the current game name. See the technical rename work tracked from the creative reset issue before destructive namespace/folder/save migration.

## Canonical project documents

- [Design direction](docs/design.md)
- [Development roadmap](docs/roadmap.md)
- [Agent instructions](AGENTS.md)
- [GitHub Issues](https://github.com/YvesAlbuquerque/InkTime/issues)

## Immediate next step

Convert the accepted animation-studio direction into one representative playable/visual target: a small T.O.O.N. studio space, a recurring cartoon crew, one animated-IP production, one meaningful production decision, and one visible post-release consequence. Use that proof before expanding the historical comic scaffold.
