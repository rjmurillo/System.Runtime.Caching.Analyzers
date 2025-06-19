# Diagnostics / rules

| ID                    | Category      | Title                                                  | Implementation File                                                                                        |
|-----------------------|---------------|--------------------------------------------------------|------------------------------------------------------------------------------------------------------------|
| [SRC1000](SRC1000.md) | Compatability | Avoid System.Runtime.Caching.MemoryCache in .NET Core+ | [SystemRuntimeCachingAnalyzer](../../src/System.Runtime.Caching.Analyzers/SystemRuntimeCachingAnalyzer.cs) |

## Guidance for Future Rules

### Categories

- **Compatability**: Rules that guide users to compatible solutions for their target framework

### Diagnostic ID Ranges

| Range        | Category      | Description                                      |
|--------------|---------------|--------------------------------------------------|
| SRC1000-1099 | Compatability | Ensures compatible solution for target framework |

- When adding new rules, assign the next available ID in the appropriate category range.
- Document new rules in this table, including their category, a concise title, and links to both documentation and implementation.
- For more, see the root [README.md](../../README.md).