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

Increments 1–3: foundation, room browsing, and reservations. The five routes, responsive navigation, Amara theme, locally hosted fonts/photo, shared page introductions/empty states, and branded error/not-found pages are implemented. Home has an initial branded composition; its final content is scheduled for Increment 5.

| Route | Screen |
| --- | --- |
| / | Home |
| /rooms | Rooms |
| /experiences | Experiences |
| /book | Book a Stay |
| /bookings | My Bookings |

Rooms now has six demo inventory units, date/guest/type/amenity filters, price sorting, availability, and a details dialog. Select an available room to review its stay summary. Guest details, live totals, reservation submission, and confirmation are implemented. Search/cancellation management and experience itineraries remain in later increments. All resort content is fictional; no real bookings or payments are made.

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
6. Full refresh/restart may clear reservations; missing receipt references have an explicit recovery message. Cancellation/search will be added in Increment 4.

Final Increment 3 build passed with zero warnings/errors. Direct state checks covered invalid data, immutable quotes, duplicate submission IDs, overlapping/adjacent stays, and concurrent attempts. Edge checks covered form validation, live totals, successful confirmation, double clicks, receipt requests, keyboard focus, in-session links, availability updates/error recovery, fresh sessions, and widths 320–1440. Impeccable review approved the scoped implementation.