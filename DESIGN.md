---
name: Amara
description: Stays and experiences in a warm, restrained resort setting.
colors:
  terracotta: "#d97757"
  terracotta-hover: "#cc6b4c"
  terracotta-ink: "#9b4b31"
  sage: "#788c5d"
  sage-ink: "#5b6c43"
  paper: "#faf9f5"
  charcoal: "#141413"
  muted-ink: "#56564e"
  hairline: "#e8e6dc"
  field-border: "#b0aea5"
  focus-brown: "#6b432b"
  validation-red: "#9b3027"
typography:
  display: { fontFamily: "Poppins, Arial, sans-serif", fontSize: "clamp(2.8rem, 4.4vw, 4.6rem)", fontWeight: 400, lineHeight: 1.15, letterSpacing: "-.04em" }
  headline: { fontFamily: "Poppins, Arial, sans-serif", fontSize: "clamp(2rem, 4vw, 3.3rem)", fontWeight: 400, lineHeight: 1.25, letterSpacing: "-.035em" }
  title: { fontFamily: "Poppins, Arial, sans-serif", fontSize: "clamp(1.5rem, 2.2vw, 2rem)", fontWeight: 400, lineHeight: 1.4, letterSpacing: "-.025em" }
  body: { fontFamily: "Lora, Georgia, serif", fontSize: "1rem", fontWeight: 400, lineHeight: 1.7 }
  label: { fontFamily: "Poppins, Arial, sans-serif", fontSize: ".84rem", fontWeight: 400, lineHeight: 1.6 }
  navigation: { fontFamily: "Poppins, Arial, sans-serif", fontSize: ".82rem", fontWeight: 400 }
  button: { fontFamily: "Poppins, Arial, sans-serif", fontWeight: 500, letterSpacing: "normal" }
rounded:
  control: "8px"
  surface: "12px"
spacing:
  compact: "8px"
  small: "12px"
  regular: "16px"
  medium: "20px"
  gutter: "24px"
  section: "32px"
  generous: "48px"
  broad: "64px"
components:
  booking-action: { backgroundColor: "{colors.terracotta}", textColor: "{colors.charcoal}", rounded: "{rounded.control}", padding: "13px 20px", typography: "{typography.navigation}" }
  booking-action-hover: { backgroundColor: "{colors.terracotta-hover}" }
  menu-toggle: { backgroundColor: "{colors.paper}", textColor: "{colors.charcoal}", rounded: "{rounded.control}", padding: "10px 12px" }
  empty-state: { backgroundColor: "{colors.paper}", textColor: "{colors.charcoal}", rounded: "{rounded.surface}", padding: "48px 32px" }
  text-link: { textColor: "{colors.charcoal}", typography: "{typography.label}" }
  text-link-hover: { textColor: "{colors.terracotta-ink}" }
  native-field: { backgroundColor: "{colors.paper}", textColor: "{colors.charcoal}", rounded: "{rounded.control}", padding: "10px 12px" }
  room-card: { rounded: "{rounded.surface}", padding: "24px" }
  selected-stay: { rounded: "{rounded.surface}" }
  destination-photo: { rounded: "{rounded.surface}", width: "100%", height: "clamp(360px, 38vw, 540px)" }
---

# Design System: Amara

## Overview
**Creative North Star: "Room to unwind"**

Amara combines warm paper, charcoal type, restrained terracotta actions, and destination photography. The visual direction follows the approved Anthropic palette and Poppins/Lora pairing; it expresses a fictional hospitality brand through generous space and calm editorial composition.

Poppins gives headings and navigation a clear, contemporary voice. Lora makes descriptive copy feel unhurried. Thin rules and shared background tones organize the interface without decorative depth. Room browsing, reservation forms, and confirmation receipts extend this foundation with quiet native fields, photographic cards, a focused details dialog, and clear written feedback.

**Key Characteristics:**
- Warm paper surfaces with charcoal text.
- Regular-weight Poppins headings and Lora reading copy.
- Terracotta actions with dark, readable labels.
- Thin separators, gently rounded containers, and local photography.
- Responsive navigation and visible keyboard focus.

## Colors
Primary: Terracotta identifies actions, the wordmark dot, and active navigation; Terracotta Hover belongs to the booking link; Terracotta Ink provides readable accent text. Secondary: Sage is configured in MudBlazor; Sage Ink colors empty-state and confirmation icons, available-room status, Confirmed reservation status, and success feedback; Validation Red identifies unavailable rooms, invalid fields, Cancelled status, cancelled receipt icons and notes, and destructive actions. Destructive filled confirmation uses a Paper label. Status text accompanies color. Neutrals: Paper carries surfaces, Charcoal carries text, Muted Ink carries descriptions, and Hairline separates sections. Focus Brown and Validation Red are functional feedback colors. Approved Anthropic mid gray supplies Field Border for native inputs and selects. Blue remains unused.

**The Dark Label Rule.** Terracotta filled actions use charcoal labels, matching the configured primary contrast color.

## Typography
Poppins with Arial/sans-serif fallbacks serves headings and controls; Lora with Georgia/serif fallbacks serves reading copy. Fonts are local. Frontmatter records display, page headline, section title, body, link label, navigation, and button roles. Hero descriptions use 1.06rem/1.85 on desktop and 1rem on mobile; typical copy measures are 44ch in the hero and 65ch in page introductions. Empty-state headings use 1.4rem/1.5 at weight 400. At 760px and below, hero display becomes `clamp(2.5rem, 9vw, 3.8rem)`.

**The Two Voice Rule.** Use Poppins for headings and controls, and Lora for descriptive body copy.

## Layout
Header/main/footer share `min(1280px, calc(100% - 96px))`; at 960px and below, gutters become 24px per side. The header sticks at the top of the viewport with a paper surface and hairline divider so navigation remains available as visitors scroll. Inner page shells cap at 1040px. Minimum viewport width is 320px. Hero and welcome grids use `1.05fr 1fr` and a fluid 32px-80px gap. At 760px and below, grids stack with 28px gaps; main padding changes from 48px/72px to 32px/48px. Header minimum height changes from 112px to 90px; navigation opens vertically in document flow and footer content stacks. Empty-state padding reduces to 32px 20px. Room cards form two columns with 32px gaps, becoming one column with 24px gaps at 760px. Filters use five columns, two at 960px with search spanning both, and one at 390px. The reservation form and room summary use 1.3fr/1fr columns with a 40px gap; at 960px they become 1.15fr/1fr with a 24px gap and guest fields collapse from two columns to one. At 760px the layout stacks with the summary first and no sticky positioning. Desktop summaries stick 24px from the top and use a 200px-high photo. Stay facts and amenities use two columns, then one at 390px; receipt facts stack at 760px. Receipts cap at 820px with 32px padding, reduced to 24px on mobile. Booking management filters use search/status/clear columns (2fr/1fr/auto) with 20px gaps, stacking with 16px gaps at 760px. Reservation rows use three columns (1.2fr/2fr/auto), two at 960px with actions spanning the row, and one at 760px. Row facts use three columns, then two at 760px; action groups change from vertical to horizontal at 960px and wrap on mobile.

## Elevation & Depth
Flat paper surfaces, hairlines, and whitespace provide structure. Filled MudBlazor actions explicitly disable drop shadows; photography supplies natural depth. Room details use the existing MudBlazor dialog surface and backdrop; no custom dialog shadow token is introduced. Reduced-motion preference suppresses animation and transition duration; no custom decorative animation is implemented.

**The Quiet Surface Rule.** Separate foundation sections with spacing and hairlines before introducing elevation.

## Shapes
Surface corners are gently rounded; controls use the smaller radius. Container borders are single-pixel hairlines; fields use the stronger Field Border. Room cards and selected-stay containers use the surface radius; native fields use the control radius. Photos use `object-fit: cover`; preserve meaningful subjects when cropping.

## Components
- **Buttons:** MudBlazor primary actions use sentence case, dark labels, and no drop shadow. Hero action is large; empty-state actions use default size. Custom booking navigation uses the frontmatter control token, a 14px icon gap, and its dedicated hover color.
- **Navigation:** compact Poppins links use 30px gaps (18px at 960px), with terracotta bottom borders on hover/active. Below 760px, Menu toggles a vertical list and exposes its expanded state.
- **Empty state:** centered bordered paper container, Sage Ink SVG icon, regular heading, description capped at 54ch, and a primary action.
- **Text links:** underline offset .25em, optional SVG arrow with 10px gap, Terracotta Ink on hover.
- **Photography:** local, credited illustrative image with surface radius, fluid desktop height, 380px mobile height, and a muted caption 12px below.
- **Keyboard focus:** solid 3px Focus Brown outline with 5px offset. Preserve the skip link. Native input, select, textarea, and checkbox controls retain this focus treatment. After successful confirmation, focus moves to the page heading. Chips and reservation-submission dialogs are not implemented.

- **Room filters and fields:** labeled native date, number, search, and select controls use a 46px minimum height, paper background, Field Border, control radius, and Poppins (.82rem/1.5). Labels use .78rem/1.5; invalid borders and inline messages use Validation Red. The availability checkbox is 18px with Terracotta Ink accent. Apply filters commits the form; Reset filters restores defaults. The sort select shares field styling and updates immediately.
- **Room cards:** clipped surface-radius containers use a 3:2 photo, 24px body padding (20px at 960px), a regular Poppins title (1.45rem/1.4), muted description, and compact amenities. A hairline separates the tabular-number nightly price from Details and filled Select room actions. Unavailable rooms retain Details and disable selection; availability is written in text. Prices use weight 600.
- **Room details dialog:** full-width MudBlazor dialog capped at Small, titled with the room name. A 240px-high cropped photo precedes description, definition-list facts, amenities, and availability copy. Close, the close icon, and Escape dismiss; Select room is disabled when unavailable.
- **Guest form:** labeled native contact, date, and guest-count inputs reuse room-filter fields. Full name, guest count, and optional requests span both guest-field columns; the resizable textarea has a 100px minimum height and written helper text. Required labels, inline Validation Red messages and borders, and a live validation summary explain errors; reservation failures use a bordered Validation Red alert with 16px padding and control radius. Confirm demo reservation becomes disabled with progress wording during submission.
- **Room summary:** bordered photo/content container with 24px content padding, room metadata, definition-list dates and guests, and a hairline-separated nightly-rate calculation and total. Invalid dates or guest count replace the total with written guidance. Before confirmation, state explicitly that selection does not hold the room and availability is checked again.
- **Confirmation receipt:** flat bordered surface with a Sage Ink check-circle icon for Confirmed or a Validation Red cancel icon for Cancelled, always with written status, room heading, hairline-separated reservation reference, guest contacts, dates and guest count, optional requests, and nightly-rate calculation and total. Long references and contact values wrap; requests preserve line breaks. Keep session-only demonstration copy beneath the total, then My bookings and Explore more rooms actions. A cancelled receipt adds a Validation Red note that its dates have been released and current availability depends on other reservations; the original nightly-rate calculation remains visible. Confirmation has its own focused page heading and does not repeat the pre-confirmation selection warning.
- **Booking management:** labeled native search and status fields share the existing field style; Clear filters resets both. Search matches name, room, email, or reference as typed; status offers All reservations, Confirmed, and Cancelled. A polite live count reports matches. Flat rows use 28px vertical padding and hairline separators, pairing room/reference/guest with dates, Total (Original quote for cancelled stays), written status, outlined View details, and a red Cancel stay action. Cancelled actions are disabled and read Cancelled. Empty collections and no-match results use the established empty-state container; successful cancellation uses Sage Ink status feedback, and failures reuse the red alert.
- **Reservation details dialog:** the Small full-width MudBlazor dialog reuses the receipt without a nested border, radius, padding, or receipt navigation. Open receipt navigates to the receipt page; Close details, the close icon, and Escape dismiss.
- **Cancellation dialog:** identify the room, guest, reference, and stay dates before explaining that cancellation releases dates and preserves history. Keep reservation dismisses; Cancel reservation is a flat Validation Red filled action with a Paper label. Close and Escape dismiss; backdrop clicks do not confirm or dismiss. State plainly that no payment was collected.

## Do's and Don'ts
### Do:
- **Do** keep warm paper and charcoal as the dominant surface and text pairing.
- **Do** use Poppins for headings and controls, and Lora for descriptive copy.
- **Do** retain dark labels on terracotta filled actions.
- **Do** preserve the shared container, mobile stacking, and visible keyboard outlines.
- **Do** use real SVG icons and credited local illustrative photography.

### Don't:
- **Don't** replace the approved palette or typography when adding a screen.
- **Don't** add decorative gradients, heavy shadows, or unnecessary animation to this restrained foundation.
- **Don't** document unimplemented inputs, cards, or dialogs as established patterns.
- **Don't** use muted decorative brand colors for low-contrast body text.

## Home and experiences

Home uses the flat paper and hairline system for a validated stay search, two photographic room previews, and an Experiences invitation. The headline “A good place to stay awhile.” uses Sage Ink emphasis. Search criteria carry into Rooms. Experiences uses two-column flat cards with a consistent MudBlazor icon per activity, written category and duration, and a text action. Search and category controls share the existing field style. At 760px, cards and Home previews stack; at 390px, experience filters become one column. Itinerary dialogs use the Small MudBlazor dialog with separated itinerary, inclusions, and preparation sections.
