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
  destination-photo: { rounded: "{rounded.surface}", width: "100%", height: "clamp(360px, 38vw, 540px)" }
---

# Design System: Amara

## Overview
**Creative North Star: "Room to unwind"**

Amara combines warm paper, charcoal type, restrained terracotta actions, and destination photography. The visual direction follows the approved Anthropic palette and Poppins/Lora pairing; it expresses a fictional hospitality brand through generous space and calm editorial composition.

Poppins gives headings and navigation a clear, contemporary voice. Lora makes descriptive copy feel unhurried. Thin rules and shared background tones organize the interface without decorative depth. This document records the implemented foundation, rather than future inventory or booking interfaces.

**Key Characteristics:**
- Warm paper surfaces with charcoal text.
- Regular-weight Poppins headings and Lora reading copy.
- Terracotta actions with dark, readable labels.
- Thin separators, gently rounded containers, and local photography.
- Responsive navigation and visible keyboard focus.

## Colors
Primary: Terracotta identifies actions, the wordmark dot, and active navigation; Terracotta Hover belongs to the booking link; Terracotta Ink provides readable accent text. Secondary: Sage is configured in MudBlazor; Sage Ink colors empty-state icons. Neutrals: Paper carries surfaces, Charcoal carries text, Muted Ink carries descriptions, and Hairline separates sections. Focus Brown and Validation Red are functional feedback colors. Approved blue and mid-gray options are not extracted foundation defaults.

**The Dark Label Rule.** Terracotta filled actions use charcoal labels, matching the configured primary contrast color.

## Typography
Poppins with Arial/sans-serif fallbacks serves headings and controls; Lora with Georgia/serif fallbacks serves reading copy. Fonts are local. Frontmatter records display, page headline, section title, body, link label, navigation, and button roles. Hero descriptions use 1.06rem/1.85 on desktop and 1rem on mobile; typical copy measures are 44ch in the hero and 65ch in page introductions. Empty-state headings use 1.4rem/1.5 at weight 400. At 760px and below, hero display becomes `clamp(2.5rem, 9vw, 3.8rem)`.

**The Two Voice Rule.** Use Poppins for headings and controls, and Lora for descriptive body copy.

## Layout
Header/main/footer share `min(1280px, calc(100% - 96px))`; at 960px and below, gutters become 24px per side. Inner page shells cap at 1040px. Minimum viewport width is 320px. Hero and welcome grids use `1.05fr 1fr` and a fluid 32px-80px gap. At 760px and below, grids stack with 28px gaps; main padding changes from 48px/72px to 32px/48px. Header minimum height changes from 112px to 90px; navigation opens vertically in document flow and footer content stacks. Empty-state padding reduces to 32px 20px.

## Elevation & Depth
Flat paper surfaces, hairlines, and whitespace provide structure. Filled MudBlazor actions explicitly disable drop shadows; photography supplies natural depth. Dialog/popover providers exist but have no implemented visual example. Reduced-motion preference suppresses animation and transition duration; no custom decorative animation is implemented.

**The Quiet Surface Rule.** Separate foundation sections with spacing and hairlines before introducing elevation.

## Shapes
Surface corners are gently rounded; controls use the smaller radius. Borders are single-pixel hairlines. Photos use `object-fit: cover`; preserve meaningful subjects when cropping.

## Components
- **Buttons:** MudBlazor primary actions use sentence case, dark labels, and no drop shadow. Hero action is large; empty-state actions use default size. Custom booking navigation uses the frontmatter control token, a 14px icon gap, and its dedicated hover color.
- **Navigation:** compact Poppins links use 30px gaps (18px at 960px), with terracotta bottom borders on hover/active. Below 760px, Menu toggles a vertical list and exposes its expanded state.
- **Empty state:** centered bordered paper container, Sage Ink SVG icon, regular heading, description capped at 54ch, and a primary action.
- **Text links:** underline offset .25em, optional SVG arrow with 10px gap, Terracotta Ink on hover.
- **Photography:** local, credited illustrative image with surface radius, fluid desktop height, 380px mobile height, and a muted caption 12px below.
- **Keyboard focus:** solid 3px Focus Brown outline with 5px offset. Preserve the skip link. No fields, chips, inventory cards, or reservation dialogs are implemented yet.

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
