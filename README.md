# Amara — Stays & Experiences

A fictional boutique resort website for an Application Development midterm, built with .NET 8 Blazor (Interactive Server) and MudBlazor 8.15.0.

## Run locally

From the repository root:

```powershell
dotnet restore Amara.csproj
dotnet build Amara.csproj
dotnet run --project Amara.csproj --launch-profile http
```

Open http://localhost:5130. Stop the server with Ctrl+C. No Node/npm or administrator installation is needed to run the app. SDK 8.0.400 is recorded in global.json with patch roll-forward enabled. Use the HTTP profile in the lab to avoid HTTPS certificate setup.

If your terminal cannot find the existing SDK:

```powershell
$env:Path = "C:\Program Files\dotnet;$env:Path"
dotnet --version
```

## Current stage

Increments 1-5: foundation, room browsing, reservations, booking management, experiences, and completed Home. The five routes, responsive navigation, Amara theme, locally hosted fonts/photo, shared page introductions/empty states, and branded error/not-found pages are implemented. Home includes date and guest search, featured rooms, and an Experiences path.

| Route        | Screen      |
| ------------ | ----------- |
| /            | Home        |
| /rooms       | Rooms       |
| /experiences | Experiences |
| /book        | Book a Stay |
| /bookings    | My Bookings |

Rooms now has six demo inventory units, date/guest/type/amenity filters, price sorting, availability, and a details dialog. Select an available room to review its stay summary. Guest details, live totals, reservation submission, and confirmation are implemented. Search, status filters, details, and cancellation are implemented. Experiences has six illustrative activities with search, category filters, and itinerary dialogs. All resort content is fictional; no real bookings or payments are made.

## Prototype boundaries and next phase

Amara currently uses fictional resort content, illustrative photography and rates, and in-memory room inventory and reservations. Reservations may disappear after a refresh, a new interactive session, or a server restart. The site does not collect payments, send confirmation emails, or book experiences. These implementation limits belong in project documentation; guest-facing pages use resort language while explaining the reservation and payment limits where they affect a booking decision.

The current refinement phase focuses on frontend behavior, accessibility, and visual polish. A later development phase will add a persistent database and the related reservation workflow before this can serve real guests. Real property details, inventory, pricing, and operational policies must also be supplied and verified before production use.

## Project references

- [Project plan and incremental checklist](PROJECT_PLAN.md)
- [Development instructions](AGENTS.md)
- [Product context](PRODUCT.md)
- [Design system](DESIGN.md)
- [Asset sources and font licenses](ASSETS.md)
- [Impeccable setup](IMPECCABLE_SETUP.md)

## Structure

- Components/Layout: shared navigation, layout, and MudBlazor theme.
- Components/Pages: routes.
- Components/Shared: reusable page introduction and empty state.
- wwwroot: local CSS, fonts, image, and favicon.

Models contains room inventory and validated search criteria. Services/BookingState.cs supplies scoped inventory and sample availability holds. Selection is carried in the booking URL and validated again on the summary page.

## Verification

Foundation compilation succeeded with zero warnings/errors. Headless Edge checks covered the five routes, a branded HTTP 404 fallback, local font/image loading, mobile menu open/close/navigation, and horizontal overflow at widths 390, 760, 960, 1280, and 1440. Screenshots and isolated browser tooling are under the gitignored .impeccable/ folder.

Impeccable's detector returned no findings for the changed UI, but its static parser could not resolve runtime-served Blazor/MudBlazor stylesheet URLs; this limits that detector's color/custom-property coverage. Browser verification complements that check.

## Increment 2 walkthrough

1. Open /rooms. All six demo rooms are shown; the default stay overlaps the Garden Room sample hold.
2. Apply a room type, guest count, name/amenity search, or available-only filter. Change price order with Sort by.
3. Change dates to compare availability. Sample holds are Garden Room: today + 2 through today + 4, Family Deluxe: today + 5 through today + 7. Departure/arrival on the boundary day is allowed.
4. Open Details, then Select room, or select directly on the card. Review the dates, guests, USD nightly rate, and total on /book.
5. Selecting a room does not reserve it. Complete the guest form and confirm a demo reservation. Avoid a full refresh after confirming: reservation records are stored only in the current interactive session.

Increment 2 verification passed in headless Edge, including invalid date/guest validation, combined filtering, empty/reset states, price ordering, overlap boundaries, dialog dismissal and selection, query validation, one/two-night totals, and responsive widths from 320 to 1440. Final build: zero warnings/errors. Browser evidence is saved under the ignored .impeccable/review/ directory.

## Increment 3 walkthrough

1. Select an available room on /rooms.
2. On /book, enter a sample name, email (for example guest@example.com), and phone. Optionally add special requests.
3. Edit dates/guests and check the updated price. Submit incomplete/invalid fields to inspect inline feedback.
4. Confirm the demo reservation. The receipt shows a unique reference, guest details, stay dates, quoted total, and optional requests. No payment is collected and no email is sent.
5. Navigate to My bookings and use View confirmation to reopen the receipt in the same session. Revisit Rooms: an overlapping stay for that unit is unavailable.
6. Full refresh/restart may clear reservations; missing receipt references have an explicit recovery message. Use My bookings to search, inspect, or cancel reservations with confirmation.

Final Increment 3 build passed with zero warnings/errors. Direct state checks covered invalid data, immutable quotes, duplicate submission IDs, overlapping/adjacent stays, and concurrent attempts. Edge checks covered form validation, live totals, successful confirmation, double clicks, receipt requests, keyboard focus, in-session links, availability updates/error recovery, fresh sessions, and widths 320–1440. Impeccable review approved the scoped implementation.

## Increment 4 walkthrough

1. Create one or more demo reservations without refreshing the page; navigate to My bookings.
2. Search by guest name, room, email, or reference. Combine search with Confirmed/Cancelled status, or clear the filters.
3. View details to inspect the guest, dates, requests, status, and original quote. Open receipt shows the full page; Close or Escape dismisses the dialog.
4. Cancel stay opens a confirmation. Keep reservation or Escape leaves the stay unchanged. Cancel reservation retains it in history with Cancelled status and releases its dates.
5. Return to Rooms: the cancelled unit can be selected again unless another confirmed stay or illustrative hold overlaps. A new booking has a new reference; the cancelled entry remains in history.

Final Increment 4 build passed with zero warnings/errors. Fifteen direct state checks covered history/quote preservation, repeat and unknown requests, current cancelled receipt replay, availability restoration, rebooking, independent holds, and concurrent cancellation. Eleven Edge checks covered search/status, details, safe dismissal, confirmed cancellation, feedback/counts, current receipts, and rebooking. Desktop/mobile dialog captures were taken after animations settled. Impeccable review approved the implementation. Records remain session-only; no payment/refund or email is processed.

## Increment 5 walkthrough

1. On Home, enter check-in, check-out, and guest count. Find rooms opens Rooms with those filters applied.
2. Browse the featured room previews or follow the Experiences link.
3. On Experiences, search by activity name or description and filter by Culture, Nature, or Adventure. Clear filters restores all six ideas; unmatched searches show an empty state.
4. Open View itinerary for duration, steps, inclusions, and preparation guidance. No activity booking is made.

Final Increment 5 build passed with zero warnings/errors. HTTP smoke checks confirmed Home and Experiences render, and Rooms receives selected dates and guest count. A browser was unavailable in this environment, so complete the interactive and responsive regression before presenting.
