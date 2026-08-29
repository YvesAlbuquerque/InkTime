# Ink Through Time — Game Design Document (GDD)

> [!WARNING]
> **Legacy scaffold document — superseded.** This file describes the pre-renewal 1980–2030 light-management / fixed-three-panel concept used to create part of the current scaffold. It is retained only as historical implementation context. Do not use it as current game-design authority or as a feature backlog. Current authority is `README.md`, `docs/design.md`, `docs/roadmap.md`, `AGENTS.md`, and current GitHub Issues. Existing code that reflects this document remains **Scaffolded** until it is explicitly audited against the renewed design.

## Overview

**Title:** Ink Through Time  
**Genre:** Light management simulation / generative comic creator  
**Platform:** PC (Windows standalone)  
**Engine:** Unity 6+  
**Playable Range:** 1980–2030  

The player runs a one-room comic studio that spans five decades. Employees write and illustrate three-panel comics, losing Creativity while working and recovering while idle or resting. The player manages cash, monthly costs, publications, owned intellectual property, first prints, and late-game nostalgia opportunities.

---

## Setting and Theme

A small, intimate comic studio that evolves visually and mechanically through five eras:

| Era | Years | Theme |
|-----|-------|-------|
| 1980s | 1980–1989 | Handmade pencil and ink |
| 1990s | 1990–1999 | Photocopy and zine production |
| 2000s | 2000–2009 | Early digital art |
| 2010s | 2010–2019 | Polished online production |
| 2020s | 2020–2029 | Generative abundance and authenticity backlash |
| 2030 | 2030 | Retrospective only, no production |

Each era introduces era-specific production equipment and changes the reception formula for published comics.

---

## Core Loop

1. Assign employees to Writing, Drawing, or Rest stations (or leave Idle).
2. Writers spend Creativity to generate a comic script (three-panel plan).
3. Artists spend Creativity to draw the panels based on the plan.
4. The finished comic is published: scored and sold.
5. Revenue arrives; monthly costs (salaries, equipment upkeep) are deducted.
6. Time advances. Three consecutive month-ends below zero cash → bankruptcy.

---

## Employees

Each employee has the following attributes:

| Attribute | Range | Notes |
|-----------|-------|-------|
| Writing Skill | 0–100 | Quality of generated scripts |
| Art Skill | 0–100 | Quality of drawn panels |
| Speed | 0–100 | Affects project completion time |
| Adaptability | 0–100 | Bonus in new eras |
| Authenticity | 0–100 | Affects reception score |
| Creativity | 0–100 | Drained by work; recovered by rest |

### Assignments

- **Idle** — employee does nothing; Creativity recovers slowly.
- **Writing** — employee works on a script project; drains Creativity.
- **Drawing** — employee works on an art project; drains Creativity.
- **Resting** — employee uses the rest station; Creativity recovers faster than Idle.

The writing desk and art desk can operate on different projects concurrently.

---

## Project Lifecycle

```
Drafting → GeneratingScript → AwaitingArt → Drawing → GeneratingPanels → Assembling → Evaluating → Published
                                                                                              └→ Cancelled / Failed
```

For Milestone 1, all AI stages use `MockComicAIService`.

---

## Comic Format

Each publication contains exactly **three panels**.

- Panel image assets must not contain generated lettering.
- Unity overlays: title, captions, dialogue, panel borders, speech bubbles.

### Comic Record

| Field | Description |
|-------|-------------|
| Project ID | Unique identifier |
| IP ID | Linked intellectual property |
| Era | Era of production |
| Writer | Employee reference |
| Artist | Employee reference |
| Equipment | Equipment used |
| Creativity Snapshots | Writer and artist Creativity at key moments |
| Comic Plan | Script (three-panel plan) |
| Panel Image Paths | Three asset paths |
| Evaluation | AI or mock evaluation result |
| Score Breakdown | Weighted components |
| Sales | Units sold |
| Publication Month | Calendar month |
| Economy | Revenue and cost snapshot |

---

## Publication Reception Formula

| Component | Weight | Source |
|-----------|--------|--------|
| Era Interest | 30% | How well the content fits the current era |
| Quality | 30% | Skill-based production quality |
| Creativity | 20% | Creativity snapshot average |
| Evaluation | 20% | Mock or AI evaluation score |

---

## Economy

- **Cash** — primary resource; tracks gains and losses.
- **Reputation** — long-term score; affects era bonuses.
- **Monthly salaries** — fixed cost per employee.
- **Equipment purchase costs** — one-time cost.
- **Equipment upkeep** — monthly recurring cost.
- **Consecutive negative months** — counter; reaches 3 → bankruptcy.
- Returning to ≥ 0 cash resets the counter.

### Bankruptcy

Three consecutive month-ends below zero cash trigger a bankruptcy game-over. The player may see their archive of published work before the session ends.

---

## Intellectual Property (IP)

- The studio can own IP for comic series.
- IP recognition grows with repeated publications in the same series.
- First-print ownership adds collectible value tracked in the archive.

---

## Archive Wall

All published comics are stored permanently in the in-game archive. The 2030 retrospective reviews the entire catalogue, scores the studio's legacy, and presents nostalgia opportunities.

---

## 2030 Retrospective

The final era is retrospective only — no new production occurs. The player reviews their archive, receives legacy scores based on the full publication history, and resolves outstanding nostalgia opportunities (reprint rights, collector auctions, etc.).

---

## Stations (Room Layout)

| Station | Function |
|---------|---------|
| Writing Station | Writers produce scripts here |
| Art Station | Artists draw panels here |
| Rest Station | Employees recover Creativity faster |
| Publication Area | Completed comics are submitted here |
| Archive Wall | All published comics are displayed here |
| HUD | Cash, calendar, reputation, Creativity bars |

---

## First Milestone Scope

The first playable milestone must include:

- [ ] One studio scene
- [ ] Two employees
- [ ] Writing, drawing, idle, and rest assignments
- [ ] Creativity drain and recovery
- [ ] One writing project
- [ ] One queued script
- [ ] One art project
- [ ] Mock comic generation
- [ ] Publication result
- [ ] Cash changes
- [ ] Monthly costs
- [ ] Bankruptcy
- [ ] Era transition (1980s → 1990s)
- [ ] Archive
- [ ] 2030 retrospective stub

Runtime image generation and multimodal evaluation are **not** in Milestone 1 scope.
