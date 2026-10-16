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

Increment 1: foundation. The five routes, responsive navigation, Amara theme, locally hosted fonts/photo, shared page introductions/empty states, and branded error/not-found pages are implemented. Home has an initial branded composition; its final content is scheduled for Increment 5.

| Route | Screen |
| --- | --- |
| / | Home |
| /rooms | Rooms |
| /experiences | Experiences |
| /book | Book a Stay |
| /bookings | My Bookings |

Room inventory/search, experience itineraries, reservation forms, and booking management are planned for later increments. Empty page shells deliberately describe the current state. All resort content is fictional; no real bookings or payments are made.

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

Models and shared booking state will be added when the corresponding increments need them.

## Verification

Foundation compilation succeeded with zero warnings/errors. Headless Edge checks covered the five routes, a branded HTTP 404 fallback, local font/image loading, mobile menu open/close/navigation, and horizontal overflow at widths 390, 760, 960, 1280, and 1440. Screenshots and isolated browser tooling are under the gitignored .impeccable/ folder.

Impeccable's detector returned no findings for the changed UI, but its static parser could not resolve runtime-served Blazor/MudBlazor stylesheet URLs; this limits that detector's color/custom-property coverage. Browser verification complements that check.