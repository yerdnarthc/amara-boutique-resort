# Amara product context
<!-- impeccable:product-schema 1 -->

## Platform
web

## Stack
User-approved plan: .NET 8 Blazor Web App, Interactive Server, MudBlazor 8.15.0, native C#/Razor and CSS. Preserve the installed SDK. Increments 1–3 are complete; booking management is the next increment.

## Users
Travelers exploring a fictional boutique resort and local experiences. The practical exam evaluates frontend functionality and design.

## Product Purpose
Let visitors discover rooms and experiences, then create and manage demonstration reservations. Five screens: Home, Rooms, Experiences, Book a Stay, My Bookings.

## Operating Context
Timed university lab practical on a Windows computer with administrator restrictions. PROJECT_PLAN.md is the approved scope and incremental workflow; AGENTS.md governs development.

## Capabilities and Constraints
The app supplies navigation, responsive layout, six fictional rooms, date/guest/type/search/availability filters, price sorting, room details, and a selected-stay summary. Guest form validation, editable stay details, reservation submission, and confirmation are implemented. Subsequent increments add search/cancellation management and tourism itineraries. Room selection alone does not reserve inventory. Rates use USD. Availability includes clearly illustrative date holds and confirmed session reservations. Submission is atomic and duplicate-protected; quoted prices are snapshotted. Confirmations are reachable in-session, but can be lost on a full refresh or restart. No payment or email is processed. Use mock data and scoped in-memory state only when needed. No accounts, real payments, database, or external backend. Reservations may reset on full refresh or restart.

## Brand Commitments
Amara — Stays & Experiences. User requested the local hospitality/tourism skills, Anthropic brand guidelines, and Impeccable. The approved palette and typography are in PROJECT_PLAN.md. Use clear, concrete copy and identify fictional/demo material.

## Evidence on Hand
No real property, commercial inventory, testimonials, ratings, or awards have been supplied. Do not fabricate these as real claims. Any sourced photography is illustrative and credited in ASSETS.md.

## Product Principles
- Complete required interactions before adding optional decoration.
- Keep prices, availability, and guest information clear.
- Preserve native keyboard and responsive navigation.
- Compile after meaningful increments.

## Open Decisions
Real property location, production deployment, and real inventory remain undecided. The demo uses USD for consistent price display.