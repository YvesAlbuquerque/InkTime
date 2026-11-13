# T.O.O.N. — The Office Of Nonsense

**T.O.O.N. — The Office Of Nonsense** is an independent historical creative-studio management game. The player builds one eccentric company across roughly 1900–2030, hires generations of strange professionals, develops persistent IPs, manages relationships and money, and adapts as media evolve from text and illustration through comics, animation, digital production and 3D.

The project was formerly known as **InkTime / Ink Through Time**. Those names are legacy aliases only and remain in historical or compatibility-sensitive technical evidence where rewriting them would falsify history or risk Unity/save compatibility.

## Current status

- **Public/project name:** **T.O.O.N. — The Office Of Nonsense** — **Accepted direction**, owner-selected on 2026-11-09.
- **Name clearance:** unresolved. The owner accepted the name with the known preliminary collision risk that another released Steam game uses the exact title `TOON`; this repository does not claim trademark/store clearance.
- **Creative direction:** **Accepted direction** — historical living-studio simulation spanning changing media, people, technology and persistent IPs.
- **Canonical design rewrite:** documented in [docs/design.md](docs/design.md).
- **Continued development:** **Planned** through [docs/roadmap.md](docs/roadmap.md) and GitHub Issues.
- **Target engine:** **Unreal Engine — Accepted direction; migration Planned.** The exact Unreal version remains TBD until bootstrap/validation.
- **Existing implementation:** conservatively **Scaffolded in legacy Unity form**. Historical Unity/comic/jam-era code and data are migration source evidence, not proof that the renewed Unreal game exists.
- **Persistent IP foundation:** a minimum persistent IP model has been merged; runtime validation remains bounded by its owning evidence.
- **Legacy Unity/Flux evidence:** the prior bounded host upgrade remains valid historical evidence for the Unity scaffold. Loomlight Flux is **not** the target runtime framework for the Unreal direction.
- **AI-heavy development:** accepted. AI may be used extensively for code, content, research, testing, tooling and iteration, while important technical decisions and validation remain human-owned and evidence-based.
- **Campaign-length target:** approximately **40 hours** for a full 1900–2030 run, including studio management and time spent reading/viewing/watching productions. This remains a design target until playtested.

See [Unreal + AI development strategy](docs/unreal-ai-development-strategy.md).

## Player fantasy

> Start with a room, a few strange people and a handful of ideas. Build T.O.O.N. across generations of media, survive the people and technologies that transform it, and leave behind a studio history that belongs to your campaign.

The game should create attachment to both:

1. the fictional properties being created; and
2. the recurring studio professionals who make them.

## Core direction

The intended long-term loop is:

`Build the studio -> develop an IP -> assemble/manage the crew -> shape a production -> resolve people/money/technology pressures -> release -> read/view/watch the finished work -> audience/business consequences -> studio/IP/cast evolves -> next production`

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

Loomlight Flux owns reusable Unity framework implementation but is now legacy migration context for T.O.O.N.; Unreal-specific implementation belongs in this game repository.

Loomlight Game Studio may orchestrate production work around the project but does not own this game's design or implementation.

## Technical rename boundary

The public/project rename is accepted. Technical identifiers are migrated only where compatibility is understood.

Repository routing is now canonical at `YvesAlbuquerque/TOON`. Remaining legacy identifiers can temporarily remain in:

- `Assets/InkThroughTime/`;
- `InkThroughTime.*` namespaces/assemblies;
- historical documents and commit/issue evidence;
- legacy save/artifact paths needed for migration.

They must be treated as compatibility identifiers, not as the current game name. See the technical rename work tracked from the creative reset issue before destructive namespace/folder/save migration.

## Canonical project documents

- [Design direction](docs/design.md)
- [Development roadmap](docs/roadmap.md)
- [Unreal + AI development strategy](docs/unreal-ai-development-strategy.md)
- [Agent instructions](AGENTS.md)
- [GitHub Issues](https://github.com/YvesAlbuquerque/TOON/issues)

## Immediate next step

Bootstrap the smallest reproducible Unreal project and prove one T.O.O.N.-owned C++/data/save interaction before porting broad gameplay. In parallel, validate one representative visual target for the historical living-studio direction.
