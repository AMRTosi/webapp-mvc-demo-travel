# Graph Report - .  (2026-06-18)

## Corpus Check
- Corpus is ~6,182 words - fits in a single context window. You may not need a graph.

## Summary
- 168 nodes · 198 edges · 28 communities (23 shown, 5 thin omitted)
- Extraction: 96% EXTRACTED · 4% INFERRED · 1% AMBIGUOUS · INFERRED: 7 edges (avg confidence: 0.86)
- Token cost: 0 input · 0 output

## Community Hubs (Navigation)
- [[_COMMUNITY_Flights Controller Flow|Flights Controller Flow]]
- [[_COMMUNITY_Launch Profiles Config|Launch Profiles Config]]
- [[_COMMUNITY_Flight Repository Layer|Flight Repository Layer]]
- [[_COMMUNITY_Airport Repository Layer|Airport Repository Layer]]
- [[_COMMUNITY_Docs And Feature Scope|Docs And Feature Scope]]
- [[_COMMUNITY_JSON Data Service|JSON Data Service]]
- [[_COMMUNITY_Architecture Principles|Architecture Principles]]
- [[_COMMUNITY_Flight Repository Interface|Flight Repository Interface]]
- [[_COMMUNITY_Home Controller Actions|Home Controller Actions]]
- [[_COMMUNITY_Airport Repository Interface|Airport Repository Interface]]
- [[_COMMUNITY_Json Service Interface|Json Service Interface]]
- [[_COMMUNITY_Third Party Licenses|Third Party Licenses]]
- [[_COMMUNITY_Flight Domain Models|Flight Domain Models]]
- [[_COMMUNITY_Project Target Framework|Project Target Framework]]
- [[_COMMUNITY_Graphify Usage Guidance|Graphify Usage Guidance]]
- [[_COMMUNITY_Flight Details View|Flight Details View]]
- [[_COMMUNITY_Flight Results View|Flight Results View]]
- [[_COMMUNITY_Flight Search View|Flight Search View]]
- [[_COMMUNITY_Error View Model|Error View Model]]
- [[_COMMUNITY_Razor View Imports|Razor View Imports]]

## God Nodes (most connected - your core abstractions)
1. `FlightsController` - 9 edges
2. `AirportRepository` - 9 edges
3. `FlightRepository` - 9 edges
4. `Architecture Document` - 9 edges
5. `HomeController` - 6 edges
6. `http` - 6 edges
7. `https` - 6 edges
8. `JsonDataService` - 6 edges
9. `Project README` - 6 edges
10. `Clean Architecture` - 6 edges

## Surprising Connections (you probably didn't know these)
- `MVC Project Folder Structure` --semantically_similar_to--> `Clean Architecture`  [INFERRED] [semantically similar]
  README.md → docs/architecture.md
- `Source Application Examples Path` --conceptually_related_to--> `MVC Project Folder Structure`  [AMBIGUOUS]
  docs/coding-guidelines.md → README.md
- `Repository and Service Pattern` --conceptually_related_to--> `Clean Architecture`  [INFERRED]
  docs/coding-guidelines.md → docs/architecture.md
- `MIT License for jQuery Validation Unobtrusive` --semantically_similar_to--> `MIT License for jQuery Validation`  [INFERRED] [semantically similar]
  wwwroot/lib/jquery-validation-unobtrusive/LICENSE.txt → wwwroot/lib/jquery-validation/LICENSE.md
- `MIT License for jQuery Validation` --semantically_similar_to--> `MIT License for jQuery`  [INFERRED] [semantically similar]
  wwwroot/lib/jquery-validation/LICENSE.md → wwwroot/lib/jquery/LICENSE.txt

## Import Cycles
- None detected.

## Hyperedges (group relationships)
- **Architecture Principles Bundle** — docs_architecture_clean_architecture, docs_architecture_solid_principles, docs_architecture_ddd_basic, docs_architecture_cqrs_pattern [EXTRACTED 1.00]
- **Quality and Operability Constraints** — docs_architecture_testing_coverage_80, docs_architecture_observability_opentelemetry, docs_architecture_application_insights [EXTRACTED 1.00]
- **Travel Search Capabilities** — readme_flight_search_epic, readme_hotel_search_feature, readme_results_visualization_epic [EXTRACTED 1.00]

## Communities (28 total, 5 thin omitted)

### Community 0 - "Flights Controller Flow"
Cohesion: 0.19
Nodes (11): FlightSearchCriteria, IActionResult, IAirportRepository, IFlightRepository, ILogger, Task, FlightsController, TravelSearchApp.Controllers (+3 more)

### Community 1 - "Launch Profiles Config"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 2 - "Flight Repository Layer"
Cohesion: 0.24
Nodes (10): IFlightRepository, Flight, FlightSearchCriteria, IEnumerable, IJsonDataService, ILogger, List, Task (+2 more)

### Community 3 - "Airport Repository Layer"
Cohesion: 0.26
Nodes (9): IAirportRepository, AirportRepository, Airport, IEnumerable, IJsonDataService, ILogger, List, Task (+1 more)

### Community 4 - "Docs And Feature Scope"
Cohesion: 0.19
Nodes (13): Coding Guidelines, English Code Language, No Generic Exception Catch Without Handling, PascalCase and camelCase Naming Conventions, Repository and Service Pattern, Source Application Examples Path, Project README, ASP.NET Core 9 MVC Stack (+5 more)

### Community 5 - "JSON Data Service"
Cohesion: 0.22
Nodes (8): IJsonDataService, IWebHostEnvironment, IEnumerable, ILogger, T, Task, JsonDataService, TravelSearchApp.Services

### Community 6 - "Architecture Principles"
Cohesion: 0.31
Nodes (10): Application Insights, Clean Architecture, CQRS Pattern, Basic Domain-Driven Design, Architecture Document, OpenTelemetry Observability, OIDC Azure AD Authentication, Role-Based Authorization (+2 more)

### Community 7 - "Flight Repository Interface"
Cohesion: 0.31
Nodes (6): IFlightRepository, TravelSearchApp.Repositories.Interfaces, Flight, FlightSearchCriteria, IEnumerable, Task

### Community 8 - "Home Controller Actions"
Cohesion: 0.28
Nodes (5): Controller, IActionResult, ILogger, HomeController, ResponseCache

### Community 9 - "Airport Repository Interface"
Cohesion: 0.36
Nodes (5): IAirportRepository, TravelSearchApp.Repositories.Interfaces, Airport, IEnumerable, Task

### Community 10 - "Json Service Interface"
Cohesion: 0.32
Nodes (5): IJsonDataService, TravelSearchApp.Services.Interfaces, IEnumerable, T, Task

### Community 11 - "Third Party Licenses"
Cohesion: 0.33
Nodes (6): jQuery License, MIT License for jQuery, jQuery Validation License, MIT License for jQuery Validation, jQuery Validation Unobtrusive License, MIT License for jQuery Validation Unobtrusive

### Community 12 - "Flight Domain Models"
Cohesion: 0.33
Nodes (5): Airport, Flight, FlightSearchCriteria, FlightSearchResult, TravelSearchApp.Models

### Community 13 - "Project Target Framework"
Cohesion: 0.50
Nodes (3): net10.0, Microsoft.NET.Sdk.Web, TravelSearchApp

### Community 14 - "Graphify Usage Guidance"
Cohesion: 0.67
Nodes (3): Copilot Instructions, Graphify Query-First Workflow, Scoped Graph Navigation

## Ambiguous Edges - Review These
- `MVC Project Folder Structure` → `Source Application Examples Path`  [AMBIGUOUS]
  docs/coding-guidelines.md · relation: conceptually_related_to

## Knowledge Gaps
- **55 isolated node(s):** `TravelSearchApp.Controllers`, `IFlightRepository`, `IAirportRepository`, `ILogger`, `HttpPost` (+50 more)
  These have ≤1 connection - possible missing edges or undocumented components.
- **5 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **What is the exact relationship between `MVC Project Folder Structure` and `Source Application Examples Path`?**
  _Edge tagged AMBIGUOUS (relation: conceptually_related_to) - confidence is low._
- **Why does `FlightsController` connect `Flights Controller Flow` to `Home Controller Actions`?**
  _High betweenness centrality (0.014) - this node is a cross-community bridge._
- **Why does `Clean Architecture` connect `Architecture Principles` to `Docs And Feature Scope`?**
  _High betweenness centrality (0.010) - this node is a cross-community bridge._
- **What connects `TravelSearchApp.Controllers`, `IFlightRepository`, `IAirportRepository` to the rest of the system?**
  _55 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Launch Profiles Config` be split into smaller, more focused modules?**
  _Cohesion score 0.13333333333333333 - nodes in this community are weakly interconnected._