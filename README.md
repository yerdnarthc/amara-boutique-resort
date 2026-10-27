# Amara — Stays & Experiences

A responsive boutique resort demo built with Blazor. Visitors can explore rooms and local experiences, search for a stay, and create or manage sample reservations.

![Amara lettermark](wwwroot/favicon.svg)

## Features

- **Find a stay:** Search by dates and guest count, then filter rooms by type, name, amenities, and availability. Sort by nightly price and inspect room details.
- **Book a room:** Review the stay and total, enter guest details with validation, and receive a reservation reference and confirmation.
- **Manage bookings:** Search reservations, view details and receipts, and cancel a stay with confirmation. Cancellation releases the room's dates.
- **Explore experiences:** Search and filter six illustrative cultural, nature, and adventure activities, with itinerary and preparation details.
- **Use any screen size:** Responsive navigation and layouts support desktop and mobile browsing.

## Tech stack

- .NET 8 Blazor Web App with Interactive Server rendering
- C# and Razor components
- MudBlazor 8.15.0 and project CSS
- Locally hosted fonts and images

## Run locally

Install the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0), then run from the repository root:

```powershell
dotnet restore Amara.csproj
dotnet run --project Amara.csproj --launch-profile http
```

Open <http://localhost:5130>. The SDK version is pinned in [`global.json`](global.json) to the 8.0.400 feature band with patch roll-forward. Run `dotnet build Amara.csproj` to check compilation.

## Pages

| Route | Page | Main task |
| --- | --- | --- |
| `/` | Home | Explore the resort and begin a room search |
| `/rooms` | Rooms | Filter, sort, and select a room |
| `/experiences` | Experiences | Browse activities and view itineraries |
| `/book` | Book a Stay | Enter guest details and confirm a sample reservation |
| `/bookings` | My Bookings | Find, inspect, and cancel sample reservations |

## Demo scope

Amara is a fictional resort prototype. Rooms, rates, availability holds, experiences, and photography are illustrative. Reservations are stored in scoped memory and can disappear after a refresh, a new interactive session, or a server restart. The app does not process payments, send emails, or book experiences; it has no database or guest accounts. Do not enter real personal information.

## Project layout

```text
Components/   Razor pages, layout, shared UI, and dialogs
Models/       Room, search, experience, and reservation models
Services/     In-memory booking state and sample inventory
wwwroot/      Styles, fonts, images, and favicon
```

Photo sources and font licenses are listed in [`ASSETS.md`](ASSETS.md). The interface rules are recorded in [`DESIGN.md`](DESIGN.md).
