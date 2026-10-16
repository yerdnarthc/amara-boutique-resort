# Amara — Stays & Experiences

## Purpose and project context

This file is the persistent implementation reference for the Application Development midterm practical. Read it alongside AGENTS.md before continuing work.

- Assigned theme: Hospitality/Tourism.
- Proposed concept: a fictional boutique resort website where travelers browse rooms, explore local experiences, and make and manage reservations.
- Brand: Amara — Stays & Experiences.
- Audience: travelers planning a resort stay.
- Objective: build a polished, functional frontend within a timed university practical.
- Planned scope: five screens, implemented incrementally.
- The features below are our chosen project scope, not additional requirements stated by the professor. Adapt if further exam requirements arrive.

## Priorities

1. Reliable compilation and required functionality.
2. Fast implementation with readable C# and native Blazor patterns.
3. Clear, responsive UI with meaningful interactions.
4. Visual polish after the core booking journey works.

Keep architecture lightweight. Use mock/in-memory data. Add persistence, authentication, payments, backend APIs, or administration only if later requirements justify them.

## Current environment and status

- Verified SDK: .NET 8.0.400.
- No Blazor application or .csproj existed when this plan was created.
- MudBlazor 8.15.0 is installed and configured; Radzen is not used.
- Increment 1 is implemented: .NET 8 Blazor foundation, responsive shell, and five working routes.
- Increments 1–3 are implemented: foundation, room browsing, guest form, reservation submission, and confirmation. Next: Increment 4, booking management.
- The lab computer has administrator restrictions; prefer user-accessible tooling and existing installations.

## Skill references

These project-local skills were read when planning:

- [Hospitality expert](.agents/skills/hospitality-expert/SKILL.md): reservation concepts, room capacity, availability, guest details, and reservation status.
- [Property management reference](.agents/skills/hospitality-expert/references/PROPERTY_MANAGEMENT_SYSTEM.md): date overlap and reservation calculations.
- [Adventure tourism plan](.agents/skills/adventure-tourism-plan/SKILL.md): structured experience planning and preparation guidance.
- [Adventure tourism strategy](.agents/skills/adventure-tourism-strategy/SKILL.md): tourism experience organization.
- [Cultural tourism guide](.agents/skills/cultural-tourism-guide/SKILL.md): cultural experience content and itineraries.
- [Anthropic brand guidelines](.agents/skills/brand-guidelines/SKILL.md): palette and typography applied to the fictional Amara identity.

Keep implementation in C#/Blazor even where skill examples use another language. Use relevant domain guidance without expanding the exam scope into a full property management system.

## Five screens

| Screen | Route | Content and layout | Interactions |
| --- | --- | --- | --- |
| Home | `/` | Resort introduction, destination image, date/guest search, featured rooms and experiences | Select dates and guests; navigate to matching rooms |
| Rooms | `/rooms` | Room cards with nightly rate, capacity, amenities, and availability | Filter by type/capacity, sort by price, view details in a dialog, select a room |
| Experiences | `/experiences` | Cultural, nature, and adventure activity cards | Search/filter by category; view itinerary, duration, inclusions, and preparation guidance |
| Book a Stay | `/book` | Guest form and reservation summary | Validate guest details, dates, capacity, and availability; calculate total; submit and show confirmation |
| My Bookings | `/bookings` | Reservations with reference, dates, room, total, and status | Search, view details, cancel with confirmation, show an empty state |

Details and confirmation use dialogs or inline states within these screens. Experience browsing is part of the core scope; separate experience reservations are outside the initial scope.

## Brand and visual design

| Element | Specification |
| --- | --- |
| Brand name | Amara — Stays & Experiences |
| Background | Warm ivory `#faf9f5` |
| Main text | Charcoal `#141413` |
| Borders/subtle surfaces | Light gray `#e8e6dc` |
| Secondary decorative elements | Mid gray `#b0aea5`; avoid low-contrast body text |
| Primary accent | Terracotta `#d97757` |
| Supporting accents | Sage `#788c5d`, blue `#6a9bcc`, used sparingly |
| Headings | Poppins with Arial fallback |
| Body | Lora with Georgia fallback |

Use generous spacing, clear hierarchy, consistent rounded corners, restrained borders, and destination photography stored locally under wwwroot/images. Keep font fallbacks functional without requiring font installation or external connectivity. Check text/background contrast, including buttons and status indicators.

Use responsive grids and flexible layouts. Provide visible focus states, readable labels, validation feedback, useful empty states, and clear primary actions. Avoid fixed-width layouts, excessive gradients, shadows, animations, and decorative complexity.

## Technical decisions

- Framework: .NET 8 Blazor Web App.
- Interactivity: Interactive Server rendering so forms, dialogs, filtering, and shared session state work.
- Primary UI library: MudBlazor. Do not mix in Radzen without a concrete need.
- Planned package: MudBlazor 8.15.0, confirmed compatible with .NET 8 during planning. It is a deliberate compatible version, not a claim that it is the latest release.
- Setup: register MudBlazor services; add Razor imports, CSS and JavaScript assets; configure theme, dialog, snackbar, and popover providers.
- Forms: native Blazor EditForm and DataAnnotations validation where appropriate, with component-level business validation.
- Data: seeded mock inventory and in-memory reservations.
- State: one scoped BookingState service because room availability, booking submission, and My Bookings need shared data. Keep filters and dialog state local.
- Session limitation: data may reset on a full refresh, new interactive session, or restart. Display that limitation clearly in the demo.
- Preserve the installed SDK/framework; do not upgrade .NET without instruction.

References:

- [MudBlazor 8.15.0 package compatibility](https://www.nuget.org/packages/MudBlazor/8.15.0)
- [MudBlazor installation guidance](https://mudblazor.com/getting-started/installation)

Follow documentation matching the pinned package version when APIs differ from current examples.

## Minimal models

### Room

Identity, name/type, capacity, nightly rate, amenities, description, and image path. For the initial availability model, each Room represents one individually reservable inventory unit.

### Experience

Identity, title, category, duration, description, itinerary, inclusions, preparation guidance, and image path.

### Reservation

Unique reference, selected room identity, guest name/email/contact, check-in/check-out dates, guest count, quoted nightly rate, total, and status (Confirmed or Cancelled).

Use C# decimal for money. Demo room rates use USD consistently. Prices are illustrative and do not represent a real property.

## Booking rules

- Check-in cannot be in the past.
- Checkout must follow check-in; at least one night is required.
- Guest count must be positive and within room capacity.
- Required guest details and email must pass validation.
- Nights = checkout date minus check-in date.
- Total = nights × quoted nightly rate. Do not invent taxes or additional charges.
- Two stays overlap when newCheckIn < existingCheckOut AND newCheckOut > existingCheckIn.
- Confirmed overlapping reservations block the same room.
- Same-day checkout and check-in are allowed.
- Recheck availability when submitting, not only when listing rooms.
- Store the quoted rate in the reservation so its total stays consistent.
- Successful submission produces a reference and clear confirmation; prevent duplicate submission.
- Cancellation requires confirmation, changes status, and releases availability.
- Show a useful message if the booking page is opened without a valid room selection.
- Identify prices and confirmations as demonstration data; no real payment is collected.

## Proposed lightweight structure

Follow the .NET 8 template's Components/Pages convention. Create folders only when their contents are needed.

```text
Components/
  Layout/
  Pages/
    Home.razor
    Rooms.razor
    Experiences.razor
    Book.razor
    Bookings.razor
  Shared/
  Dialogs/
Models/
Services/
  BookingState.cs
wwwroot/
  images/
  app.css
```

Useful components include RoomCard, ExperienceCard, EmptyState, and reservation/detail dialogs. Extract components where reuse or readability justifies it; avoid splitting every small element.

## Incremental implementation checklist

| Increment | Deliverable | Completion check |
| --- | --- | --- |
| 1. Foundation | Blazor project, MudBlazor setup, Amara theme, responsive navigation, five routes | Build succeeds; every route opens; interactive controls respond |
| 2. Room browsing | Models, mock inventory, room cards, filters, sorting, detail dialog | Filters and sorting work; selection carries into booking; availability uses dates |
| 3. Reservation flow | Guest form, validation, price summary, confirmation | Valid booking completes; invalid input is explained; duplicate submission is prevented |
| 4. Booking management | Shared reservation list, search, details, cancellation | New reservations appear; cancelled bookings release availability |
| 5. Tourism and polish | Experience catalog, itineraries, completed Home, responsive/empty states | Complete guest journey and experience browsing work across all five screens |

- [x] Increment 1 complete
- [x] Increment 2 complete
- [x] Increment 3 complete
- [ ] Increment 4 complete
- [ ] Increment 5 complete

Build after each meaningful increment. Inspect and fix compilation errors before adding optional polish. Update this checklist and record material decisions below as implementation progresses.

## Final verification and demonstration

Primary journey: Home date/guest search → Rooms → select a room → Book a Stay → confirmation → My Bookings → view details → cancel.

Also demonstrate experience category filtering and an itinerary dialog.

Verify:

- All five routes and navigation work, including direct navigation.
- Invalid dates, missing guest details, invalid email, and excess guests produce feedback.
- Nights and totals update correctly.
- Overlapping reservations are rejected; adjacent stays are accepted.
- Cancelling restores availability.
- Search, filtering, sorting, empty results, and empty bookings behave correctly.
- Pages remain usable on common desktop and narrower screen sizes.
- Final dotnet build succeeds; do not claim browser behavior was checked unless it was actually checked.

## Decision and progress log

- Initial plan: five-screen resort booking and local experience website, using .NET 8, MudBlazor, mock data, and Anthropic-inspired palette/typography.
- Increment 1 complete on feature/amara-foundation. Build: zero warnings/errors. Edge checks: five routes, 404 fallback, local assets, responsive overflow, mobile menu. Next: Increment 2, room browsing.

## Impeccable design guidance

The full official Impeccable skill is installed at [.agents/skills/impeccable/SKILL.md](.agents/skills/impeccable/SKILL.md). Use it for design, UI/UX, accessibility, responsive behavior, and clear interface copy throughout the increments above. Its quality guidance complements the existing hospitality skills and the selected Anthropic brand identity; preserve this plan's C#/Blazor stack and exam scope.

See [IMPECCABLE_SETUP.md](IMPECCABLE_SETUP.md) for the pinned source revision, all included commands, Windows launcher usage, Codex hook activation, verification, and limitations. Before the first UI implementation, initialize its product context from this plan and follow its new-work guidance. PRODUCT.md now records the approved product context; DESIGN.md records the implemented foundation design system.

### Increment 2 completion

- Branch: feature/amara-room-browsing.
- Added Room/RoomType and RoomSearch models, scoped BookingState inventory, RoomCard, and RoomDetailsDialog.
- Six individually reservable demo rooms with local illustrative photographs; rates use USD.
- Filters apply as a validated snapshot: dates, guest capacity, type, name/amenity search, and available-only. Price sorting applies immediately.
- Sample availability holds: Garden Room from today + 2 to today + 4; Family Deluxe from today + 5 to today + 7. These are illustrative date holds, not customer reservations. Same-day checkout/check-in is allowed.
- Selecting a room carries its ID, ISO dates, and guest count in the booking URL. The summary revalidates parameters and availability, shows nights/rate/total, and survives refresh. Selecting does not reserve inventory.
- Verification: build zero warnings/errors; Edge checks passed combined filters, sort directions, empty/reset states, invalid dates/guests, date overlaps/adjacent boundaries, dialog Escape/selection, one/two-night totals, URL tampering, refreshed selection, and widths 320/390/760/960/1440. No browser errors.
- Impeccable review: ship within Increment 2 scope. Static detector advisories include standalone Razor stylesheet-resolution limits and an approved brand border color, documented in the design-system extension.
- Next: Increment 3 guest form, validation, submission, and confirmation. Integrate real in-memory reservations with the availability calculation; retain sample holds as clearly labeled demo data or replace them consistently.
### Increment 3 completion

- Branch: feature/amara-reservation-flow.
- Added ReservationForm with DataAnnotations and cross-field date validation, plus immutable Reservation snapshots.
- Book a Stay now accepts lead guest name, email, phone, optional requests, editable dates, and guest count. Its summary updates nights and total as valid values change.
- Submission validates the model and room capacity again in BookingState. Availability checking and insertion use one lock; a per-form submission ID returns the original receipt on repeated events.
- Confirmed session reservations are included in room availability, alongside the illustrative sample holds. Quoted rates and guest details are copied into the receipt.
- Confirmation includes reference, guest/contact details, dates, requests, status, nightly rate, and total. Keyboard focus moves to the success heading. No email or payment is processed.
- Minimal My Bookings links keep confirmations reachable within the same interactive session. Search, richer management, and cancellation remain Increment 4.
- Full refresh/new session can clear reservations. An unavailable confirmation reference shows a recovery message rather than recreating or pretending to restore a reservation. Guest details are never placed in the URL.
- Verification: final build zero warnings/errors. Fifteen direct state checks passed validation, snapshot pricing, repeated events, overlaps, adjacent dates, atomic concurrent attempts, and session isolation. Edge checks passed required fields/contact/capacity/date validation, live totals, double-click protection, receipt requests, in-session navigation, room availability updates, recoverable availability rechecks, fresh-session behavior, focus, and widths 320–1440.
- Impeccable finish review: ship within Increment 3 scope. Only known standalone Razor stylesheet-resolution advisories appeared in the detector.
- Next: Increment 4 reservation search, details/management, confirmation before cancellation, and releasing cancelled room availability.