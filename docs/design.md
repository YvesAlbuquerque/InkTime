# T.O.O.N. — The Office Of Nonsense — Design Direction

**Decision date:** 2026-11-09  
**Status:** Accepted direction; Documented  
**Former project names:** InkTime / Ink Through Time  
**Implementation status:** Do not infer implementation from this document. See code, tests, Issues, branch state, builds, and playable evidence.

## Product statement

**T.O.O.N. — The Office Of Nonsense** is a game about running a characterful cartoon-animation studio.

The player develops original animated IPs, works with a recurring cast of studio professionals, makes creative and production decisions, and turns ideas into shorts, episodes, and evolving animated worlds.

The game is not an animation-authoring application and is not defined by AI generation. It is a studio-management and creative-production game in which authorship, people, production pressure, persistent creative properties, and consequences reinforce one another.

## Naming decision

The owner selected **T.O.O.N. — The Office Of Nonsense** as the new game name on 2026-11-09.

The acronym and expansion are intentional:

- **T.O.O.N.** immediately evokes cartoon animation;
- **The Office** reinforces an organization/company with departments and professionals;
- **Of Nonsense** gives the institution a comic contradiction and authorial tone.

The name is **Accepted direction, not commercially cleared**. Preliminary research identified another released Steam game using the exact title `TOON`. That risk is recorded rather than averaged away or silently ignored.

## Creative pivot

The project retains the studio/company-management foundation but changes its dominant creative medium and identity.

### Preserve

- persistent creative IP identity;
- stable identifiers and versionable save data;
- recurring characters and relationships;
- continuity/canon where it supports long-term creative work;
- studio professionals and production responsibilities;
- production history and progression;
- Manual / AI-assisted / Hybrid authorship behind game-owned contracts;
- provider independence;
- player authority over final creative commitments;
- Loomlight Flux as reusable framework rather than project identity.

### Supersede or reinterpret

The following are no longer the target design merely because historical code/docs contain them:

- comic publication as the dominant medium;
- `Publication -> Script -> Pages -> Panels` as the permanent production hierarchy;
- Strip/Comic as the defining content formats;
- PDF export as a defining product promise;
- the fixed-three-panel jam scaffold;
- the historical 1980–2030 framing as the core fantasy;
- old InkTime / Ink Through Time public identity.

Historical code may be reused only where it supports the accepted T.O.O.N. direction.

## Player dream

> Run an eccentric cartoon-animation studio, develop original animated properties, direct a memorable crew of artists, and turn ideas into shorts, episodes, and evolving animated worlds.

The player should want to say:

- “this is **my studio**”;
- “these are **my people**”;
- “we made **that show/short**”;
- “this property has a history because of the choices we made.”

## Principal pillar

### Feeling — creative attachment

The main emotional target is attachment to the studio, its recurring professionals, and the properties they create.

**Seeing** is an important secondary pillar because the project should use a highly legible, authored cartoon visual language.

## Soul rule

> **The work and the people remember what the studio has made.**

Released productions should leave visible traces in the studio, IP history, relationships, reputation, opportunities, or later creative constraints. Staff and properties should not reset to anonymous state after each project.

## Core loop

Long-term target:

`Build studio -> develop IP -> form/assign crew -> shape story -> plan production -> storyboard/animate -> solve production problems -> release -> consequences -> studio/IP/cast evolves -> next production`

First proof:

`Open studio -> one IP -> small recurring crew -> one short -> script/storyboard/production decisions -> release -> visible consequence/history -> save/reopen`

## Domain model

### Studio

The persistent company-level entity.

Potential responsibilities include:

- studio identity;
- reputation;
- cash/resources where economy supports play;
- facilities/departments;
- recurring professionals;
- active productions;
- production archive;
- opportunities and consequences.

Historical economy fields may be reused only after they are tested against the new fantasy.

### Professional

A recurring studio worker and character, not a disposable stat card.

A professional may include:

- stable identity;
- species/visual identity;
- discipline/role;
- skills or strengths;
- temperament;
- relationships;
- preferences and creative tendencies;
- history with productions/IPs;
- current assignment/state;
- ambitions, frustrations, or development where useful.

The first slice should keep simulation bounded. Character depth should come from specific readable behaviour and history, not hundreds of attributes.

### IP

A persistent fictional property owned/developed by the studio.

Useful fields include:

- identifier;
- title;
- premise;
- tone;
- visual direction;
- recurring fictional characters;
- relevant relationships/canon;
- series/projects;
- released-production history.

The already merged minimum persistent IP work remains directionally compatible.

### Production

A concrete animated work being made by the studio.

Initial forms should be deliberately small, for example:

- short;
- pilot/episode;
- compact promotional or experimental piece if later useful.

Do not build a giant film/TV production simulator before one short production loop works.

### Production hierarchy

Conceptual target:

`IP -> Series/Project -> Production -> Script -> Storyboard -> Sequence -> Shot -> Animatic/Final Work`

Not every layer needs its own full editor or persistent entity in the first slice. The hierarchy exists to prevent comic page/panel assumptions from hardening into the new architecture.

### Script and storyboard

Manual, AI-assisted, and Hybrid work should converge on the same game-owned structured production representation.

The storyboard is an animation-production bridge: it can connect narrative beats to shots, staging, characters, timing notes, and later animatic/final output.

### Production history

Released work should become durable studio/IP history. The first implementation can be simple, but later productions must be able to refer to prior work without reconstructing history from prompts.

## Studio cast direction

The studio staff should feel like a cast of cartoon professionals.

Starting species territory includes:

- dog;
- cat;
- duck;
- rabbit;
- additional animals where silhouette, personality, role, and world fit justify them.

Species is not personality. Avoid “the dog is loyal”, “the cat is aloof”, and similar one-note mappings as the primary characterization.

Each important professional should communicate:

1. role/profession;
2. strong readable silhouette;
3. personality;
4. evidence of prior life/work;
5. relationship promise;
6. one or two memorable animation-friendly hooks.

## Art direction

### Target

A contemporary authored cartoon studio world informed by classic animation principles without copying one studio or protected character family.

Useful principles:

- bold primary shapes;
- readable silhouettes;
- expressive posing;
- squash and stretch;
- strong line of action;
- controlled exaggeration;
- clear focal hierarchy;
- animation-aware props and costume shapes;
- movement implied even in still poses;
- spaces that visibly support animation work and studio life.

The studio can use departments, signage, memos, stamps, boards, production walls, desks, review rooms, recording/animation paraphernalia, and other workplace language to reinforce **The Office Of Nonsense** identity.

### Anti-patterns

Avoid:

- direct Disney / Warner / Fleischer imitation;
- generic rubber-hose nostalgia as the entire style;
- generic cozy-office presentation with animal skins;
- animal stereotypes replacing characterization;
- “creator software disguised as a game”;
- AI-generator fantasy replacing studio management;
- sterile project-management UI as the dominant world;
- visual noise that damages silhouette/readability;
- nostalgia used instead of authorship.

## Relationship promise

The player should gradually know the studio staff as recurring creative collaborators.

A good professional can become:

- trusted specialist;
- difficult genius;
- reliable veteran;
- ambitious newcomer;
- rival within the team;
- mentor;
- comic foil;
- creative partner.

Relationships should create production texture and future decisions, not exist only as decorative lore.

## Authorship and AI

T.O.O.N. supports the direction of Manual, AI-assisted, and Hybrid creative work through shared game-owned structures.

AI outputs are proposals until accepted by the player.

Provider/runtime choices remain implementation adapters. They must not own:

- the game-domain model;
- studio progression;
- final authorship;
- release decisions;
- irreversible canon/production decisions.

## Persistence

Persistent state should support stable identifiers and schema/version migration.

The first renewed slice should preserve at least:

- studio identity/state needed for the proof;
- recurring professionals;
- one IP;
- one production and its relevant authored state;
- release/history record;
- one visible consequence that survives reload.

Existing legacy `InkTime` save locations must not be abandoned without an explicit migration/fallback path.

## First vertical slice

The minimum coherent target is:

1. open/create the studio;
2. have a small recurring cartoon crew;
3. create/open one animated IP;
4. start one short production;
5. author or select enough script/story material for the proof;
6. express that material through a minimal storyboard/shot flow;
7. assign/involve professionals in production;
8. surface at least one production decision/problem;
9. complete/release the work through a representative output;
10. record the release in studio/IP history;
11. show at least one visible persistent consequence;
12. save/reopen and preserve that consequence.

A vertical slice is not **Validated** until the complete exercised workflow and evidence are recorded.

## Explicit non-goals for the first slice

Do not require:

- feature-film-scale production simulation;
- a complete professional animation DCC;
- a large economy;
- deep fandom/community simulation;
- a giant lore database;
- autonomous creative authority;
- every historical InkTime class migrated before the proof;
- a particular external AI provider;
- proof that Loomlight Game Studio or Loomlight Collective integration exists;
- release/production readiness.

## Relationship to Polite Goblin and Loomlight

T.O.O.N. is an independent game.

- **YFramework** owns shared terminology, naming/routing, doctrine, The Y Framework methodology, and status vocabulary.
- **Loomlight Flux** owns reusable Unity framework implementation.
- **Loomlight Game Studio** may orchestrate production work around T.O.O.N.; it does not own the game's design or runtime.
- **Loomlight Collective** participation is optional and cannot be inferred from AI features.

## Validation questions

- Does the game read quickly as “run a cartoon-animation studio”?
- Do professionals feel like recurring characters rather than worker stats?
- Does one production feel like something the studio made rather than a generated artifact?
- Does the player care about both the IP and the people making it?
- Does a release leave a visible persistent trace?
- Can the loop work without AI?
- Can AI assistance remain editable and subordinate to player authority?
- Does the visual identity feel authored rather than a copy of a classic cartoon studio?
