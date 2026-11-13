# T.O.O.N. — The Office Of Nonsense — Development Roadmap

**Rebased:** 2026-11-13  
**Design dependency:** [T.O.O.N. Design Direction](design.md)  
**Roadmap status:** Planned  
**Former project names:** InkTime / Ink Through Time

This roadmap preserves validated/recovered technical work while rebasing future game work around the accepted historical living-studio direction.

## Sequencing principles

- Preserve evidence already earned; do not pretend the repository started over.
- Treat the studio as the long-lived protagonist.
- Do not expand historical comic-specific architecture merely because scaffold code exists.
- Re-evaluate useful legacy calendar, employee, economy, equipment, and era concepts against the new design instead of automatically discarding them.
- Keep persistent IP and save compatibility where useful.
- Treat professionals as recurring agents with careers, relationships, demands, outside lives, and explicit longevity models.
- New media expand the studio's options; they do not automatically obsolete old media.
- Validate one characteristic studio/people/production interaction before attempting a full 1900–2030 campaign.
- Preserve Unity serialization, GUIDs, `.meta` files, assembly boundaries, and legacy save migration.
- Never claim implementation or validation from documentation alone.

## Phase 0 — Recovered technical baseline

### 0.1 Reproducible Unity baseline — completed evidence

Issue #2 / associated merged work established the current Unity baseline and documented historical limitations.

### 0.2 Loomlight Flux audit — completed evidence

Issue #3 / PR #25 documented the host/framework boundary.

### 0.3 Scoped Flux host upgrade — completed evidence

Issue #4 / PR #26 validated the bounded host upgrade at the recorded Flux pin. This does not validate T.O.O.N. gameplay.

## Phase 1 — Creative identity and representative proof

### 1.1 Accepted concept

Accepted direction now includes:

- **T.O.O.N. — The Office Of Nonsense** as current project/public name;
- studio/company fantasy as the primary frame;
- campaign target approximately 1900–2030;
- media evolution from text/illustration through strips/comics, animation, digital and 3D/realtime-era production;
- persistent IPs that can cross media;
- recurring professionals with agency, relationships and outside lives;
- mixed character longevity, including mortal, long-lived, cartoon-static and rule-bound existence models;
- management of people, productions, studio/economy and technology as coupled systems;
- historical archive/legacy as a major campaign payoff.

Commercial/legal name clearance remains unresolved and separate.

### 1.2 Representative visual target

Minimum visual target:

- one small early-era T.O.O.N. office;
- 3–4 distinct professionals;
- at least one immortal/static cartoon and one mortal character;
- visible relationship tension or affinity;
- one active production;
- a production board/decision surface;
- institutional **Office** language plus visible **Nonsense**;
- one retained historical object/trace suggesting future continuity.

**Exit evidence:** owner-reviewed visual/interactive artifact with recorded corrections.

## Phase 2 — Persistent studio and people foundation

### 2.1 Revalidate persistent IP foundation

The merged minimum IP model remains directionally useful. Revalidate it against:

- cross-media adaptation history;
- persistent characters/properties;
- production/release history;
- long campaign timescale.

### 2.2 Minimal Professional model

Implement the smallest serializable professional model needed for the proof:

- stable identity;
- role/discipline;
- visual/species/archetype identity reference;
- compact skill representation;
- morale;
- creative energy;
- discipline;
- wildness/experimentation;
- current assignment/state;
- salary/credit expectations where gameplay requires them;
- longevity/existence model;
- career/history hooks.

### 2.3 Minimal Relationship model

Prove a directional relationship representation with only the dimensions needed for the first slice.

Candidate dimensions:

- affection;
- trust;
- tension;
- rivalry;
- fear;
- attraction where appropriate.

The proof must show one relationship affecting a production decision or outcome.

### 2.4 Outside-life hooks

Implement a bounded event source for off-screen life without simulating a full city.

First proof should support one outside-life condition affecting attendance, energy, relationship or production state.

### 2.5 Versioned persistence/migration

Protect existing saves and legacy `InkTime` storage during the domain transition.

**Exit evidence:** representative migration fixture or explicit compatibility result; do not infer from a version field alone.

## Phase 3 — First production-management proof

### 3.1 Medium-neutral Production model

Avoid hard-coding the first proof exclusively around animation.

The minimum production representation should support:

- medium/type;
- IP reference;
- crew;
- schedule;
- budget;
- creative/quality state;
- release/result;
- persistent consequences.

Detailed media-specific structures should be adapters or submodels introduced only when required.

### 3.2 One people/production conflict

Implement one causally legible production problem driven by people.

Examples:

- creative disagreement;
- predatory/prey tension;
- demand for credit;
- salary dispute;
- exhaustion from outside life;
- refusal to work with another employee;
- highly talented but unreliable employee;
- sudden absence.

### 3.3 Player tradeoff

The player must receive at least two materially different responses that trade among:

- schedule;
- money;
- morale;
- creative potential;
- relationship state;
- risk of departure;
- production quality.

### 3.4 Release and durable consequence

Completing the production should alter at least one of:

- studio state;
- professional state;
- relationship state;
- IP history;
- future opportunity.

Save/reopen must preserve it.

## Phase 4 — Historical time and generations

### 4.1 Calendar/era reinterpretation

Audit the legacy calendar/era scaffold.

Do not restore old fixed-era behaviour blindly. Keep only patterns that support the new campaign.

The calendar must eventually support:

- long-form year progression;
- era/media availability;
- staff aging where applicable;
- retirement/death where applicable;
- immortality/static-age models;
- historical archive timestamps.

### 4.2 Career progression

Prove bounded career progression such as:

`Recruit -> Junior -> Experienced -> Veteran -> Legend -> Retired`

Not every character uses every stage. Immortal/static cartoons may accumulate influence and history without aging normally.

### 4.3 Mortality and longevity

Implement existence rules as explicit data/behaviour, not species hard-coding.

Minimum models to prove:

- Mortal;
- Cartoon-static.

Later candidates:

- Long-lived;
- Conditional/rule-bound.

### 4.4 Succession and institutional memory

Demonstrate one long-term consequence in which:

- one employee leaves/retires/dies; and/or
- one immortal/static employee persists;

and the studio retains their influence through history, relationships, IP credit, mentorship or archive evidence.

## Phase 5 — Media evolution

### 5.1 First media transition

Do not attempt the whole history.

Prototype one transition, for example:

`text/illustration -> strip`

or:

`comic -> early animation`

The transition should require at least one meaningful change in:

- staffing;
- equipment/facility;
- cost;
- workflow;
- opportunity;
- creative possibility.

### 5.2 Technology adoption choice

Prove one early-vs-late adoption tradeoff.

New technology should carry advantages and costs rather than a flat upgrade.

### 5.3 Cross-media IP adaptation

Adapt one persistent IP into a second medium and preserve the relationship between versions.

**Exit evidence:** archive/history can show both works as part of one property lineage.

## Phase 6 — Studio economy and organization

### 6.1 Economy

Re-evaluate legacy cash/salary/bankruptcy ideas.

The first renewed economy should support production and people choices without becoming a spreadsheet-only game.

Candidate pressures:

- salaries;
- equipment investment;
- facility expansion;
- production budget;
- training;
- technology adoption;
- failed releases.

### 6.2 Departments and facilities

Grow from one-room office toward specialized departments only after the first production proof works.

Facilities should change what the studio can do, not exist as decorative unlocks.

### 6.3 Employee bargaining and agency

Introduce:

- raises;
- promotions;
- credit;
- role requests;
- refusals;
- resignations;
- return/re-hire opportunities.

The studio should have to retain talent rather than simply own it.

## Phase 7 — Presentation and historical continuity

### 7.1 Evolving studio world

Validate visible studio transformation across at least two time periods.

### 7.2 Character presentation

Validate:

- strong silhouettes;
- profession;
- personality;
- relationship promise;
- longevity distinction;
- era-sensitive presentation without flattening identity.

### 7.3 Institutional history

Use:

- boards;
- posters;
- awards;
- photographs/portraits;
- archived productions;
- retired equipment;
- renamed rooms;
- memorials or preserved desks;
- employee credits;

to make past decisions visible in the present.

## Phase 8 — Integrated vertical-slice validation

Required workflow:

`Open studio -> recurring crew -> one relationship pressure -> one IP -> one production -> assignment/tradeoff -> release -> durable consequence -> save/reopen`

The first integrated slice does **not** need to span the full campaign.

Record:

- Unity/editor version;
- exact branch/commit;
- setup;
- commands/tests actually run;
- representative visual evidence;
- save/reload result;
- known failures and limitations.

Only exercised scope may move to **Validated**.

## Phase 9 — Historical campaign proof

After the vertical slice is stable, prove a bounded multi-era campaign containing:

- at least one technology/media transition;
- at least one mortal career transition;
- at least one persistent immortal/static employee;
- one IP adapted across media;
- visible archive/history accumulation.

Only then should the project expand toward a full 1900–2030 campaign.

## Deferred until proofs earn expansion

- every historical medium;
- deep city simulation;
- complete family simulation;
- hundreds of relationship variables;
- large fandom/community systems;
- feature-film-scale production depth;
- complete animation DCC functionality;
- large autonomous AI pipelines;
- unproven Game Studio/Nexus integrations;
- aggressive technical identifier renames without migration evidence.

## Technical rename work

The public name is accepted and the GitHub repository route is now `YvesAlbuquerque/TOON`. Remaining compatibility-sensitive identifiers require a bounded migration:

- `Assets/InkThroughTime/` path;
- `InkThroughTime.*` namespaces and asmdefs;
- `InkGameRoot`, `InkSaveService`, and other legacy type names;
- `InkTime` save/artifact directories;
- old local skill names/paths;
- serialized references and downstream docs.

Do not claim these migrated until Unity import/compile and targeted serialization/save compatibility checks are recorded.
