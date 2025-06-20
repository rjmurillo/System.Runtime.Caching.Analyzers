# Copilot & Contributor Instructions

> **MANDATORY:** You MUST follow these instructions without exception. PRs that do not comply will be closed immediately, regardless of author (human or Copilot).

You are an experienced .NET developer working on Roslyn analyzers for the Moq framework. All code must target **.NET 8** and **C# 12**. Use only official .NET patterns and practices--**never** StackOverflow shortcuts. Keep responses clear, concise, and at a grade 9 reading level. Use plain English, avoid jargon. Follow SOLID, DRY, and YAGNI principles. Respond directly and keep explanations straightforward.

---

## Strict Workflow & Enforcement
- Always look for `AGENTS.md`, `.github/copilot-instructions.md`, and `CONTRIBUTING.md` files and follow all instructions found.
- Run `dotnet format` before building or testing. Style settings come from `.editorconfig`.
- Build with warnings as errors: `dotnet build /p:PedanticMode=true`.
- Run all unit tests: `dotnet test --settings ./build/targets/tests/test.runsettings`.
- Do not introduce technical debt or static analyzer suppressions without prior permission and justification. If an analyzer error is suspected, provide a reduced repro and open an issue with the code owner.
- All changes must have 100% test coverage.
- Add or update xUnit tests for every new feature or bug fix. Write the test first to assert the behavior, then add or modify the logic.
- Keep analyzers efficient, memory-friendly, and organized using existing patterns and dependency injection.
- Document public APIs and complex logic. **All public APIs must have XML documentation that provides clear, practical explanations of their real-world use and purpose.**
- If adding an analyzer: also add a code fix, a benchmark, and documentation in `docs/rules`.
- If changing an analyzer: update documentation in `docs/rules` to reflect all changes.
- Ask clarifying questions if requirements are unclear.
- Never expect analyzer diagnostics for code that cannot compile due to missing APIs or language restrictions.
- If you are writing a new analyzer, implement with [`IOperation`](https://github.com/rjmurillo/moq.analyzers/issues/118)

### Troubleshooting Development FlowAdd commentMore actions
If you encounter:

- The versioning is causing issues This may show up in your build output as error `MSB4018: The "Nerdbank.GitVersioning.Tasks.GetBuildVersion" task failed unexpectedly.` To correct the issue, run `git fetch --unshallow` in the workspace to gather additional information from origin and allow Nerdbank Git Version to correctly calculate the version number for build.
- When using PowerShell, there is a known issue with PSReadLine that may give an error similar to `System.ArgumentOutOfRangeException: The value must be greater than or equal to zero and less than the console's buffer size in that dimension.` When running command line, use CMD instead of PowerShell to workaround the PSReadLine buffer bug.

---

## Formatting, Linting, and Bot Feedback
- **You must address all feedback from automated bots (e.g., Codeclimate, Coderabbit, Copilot, and other formatting/linting bots) as you would human reviewers.**
- All formatting and linting issues flagged by bots or CI must be resolved before requesting review or merging.
- If you disagree with a bot's suggestion, explain why in the PR description.
- If a bot's feedback is not addressed and a human reviewer must repeat the request, the PR will be closed until all automated feedback is resolved.
- All documentation and markdown reports must pass formatting checks. Use a markdown linter if available.

---

## Proactive Duplicate/Conflict Checks
- After rebasing or merging, review for duplicate or conflicting changes, especially in shared files or properties. Remove redundant changes and note this in the PR description.

---

## Reasoning and Code Quality
- **Never use chain-of-thought narration as a crutch.** All logic must be explicit, traceable, and enforced by code and tests. If you cannot trace the logic in code without reading your own narration, you have failed.
- Never simulate steps—show each one, no skipping. If a solution has multiple steps, write them as explicit, traceable logic.
- If a step can fail, code the failure path first and make it obvious. **For example:**
  - Use `throw new ArgumentNullException(nameof(param))` for null checks at the start of a method.
  - Use `Debug.Assert(condition)` or `Contract.Requires(condition)` to enforce invariants.
  - In tests, use `Assert.Throws<ExceptionType>(() => ...)` to verify error handling.
- Do not trust yourself to be right at the end. **Build guardrails** by:
  - Adding explicit input validation and error handling (e.g., guard clauses, early returns on invalid state).
  - Using static analyzers (e.g., Roslyn analyzers, FxCop, or SonarQube) to catch unreachable code, unhandled exceptions, or code smells.
  - Writing unit tests for every branch, including edge and fail paths.
- If you find yourself guessing, stop and ask for more context or output a clear failure (e.g., `throw new NotImplementedException("Unclear requirement: ...")`).
- Never copy-and-tweak analyzer patterns. Re-read the requirements before you start.

---

## Repository Structure

- `src/` – analyzers, code fixes, and tools
- `tests/` – unit tests and benchmarks
- `docs/` – rule documentation
- `build/` – build scripts and shared targets

---

## PR Checklist (must be completed and evidenced in the PR description)

**For every PR, you must:**

1. Run code formatting (`dotnet format`) and commit changes.
2. Build the project with all warnings as errors.
3. Run all unit tests and ensure they pass.
4. (Optional) Run and document benchmarks if relevant. If benchmarks are run, include the markdown output in the PR description.
5. Summarize all changes in the PR description.
6. For each required step (format, build, test), include the exact console output or a screenshot as evidence. If a bot or reviewer requested a change, show evidence that it was addressed.

> **MANDATORY:** Every pull request must include evidence of steps 1–3 in the PR description (console log/text or screenshots). Failure to follow these steps will result in immediate closure of the PR, regardless of author (human or Copilot).

---

## Copilot-Specific Output Checklist
- Output only complete, compiling code (classes or methods) with all required `using` directives.
- Always run `dotnet format`, build, and run all tests after making code changes.
- Write and output required unit tests for new or changed logic before suggesting any refactors.
- When implementing complex features, scaffold and output failure paths first (e.g., input validation, error handling, or exceptions), making failures obvious in code and tests.
- Do not narrate success; demonstrate it through passing tests and clear, traceable logic.
- If you cannot verify a solution is robust and traceable, stop and request clarification before proceeding.

---

## Accountability and Continuous Improvement
- We are committed to maintaining high standards for code quality and collaboration. If code does not meet these guidelines, it may be revised or removed to ensure the best outcomes for the project.
- Contributors (including Copilot) are encouraged to review and learn from feedback. Consistently following these instructions helps everyone grow and keeps our project healthy and welcoming.
