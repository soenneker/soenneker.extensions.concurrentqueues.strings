[![](https://img.shields.io/nuget/v/soenneker.extensions.concurrentqueues.strings.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.concurrentqueues.strings/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.concurrentqueues.strings/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.concurrentqueues.strings/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.concurrentqueues.strings.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.concurrentqueues.strings/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.concurrentqueues.strings/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.concurrentqueues.strings/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.ConcurrentQueues.Strings

A helpful set of extension methods for concurrentqueue (string).

## Installation

```bash
dotnet add package Soenneker.Extensions.ConcurrentQueues.Strings
```

## Quick start

```csharp
using Soenneker.Extensions.ConcurrentQueues.Strings;

// Given an existing ConcurrentQueue<string> named queue:
var result = queue.GetTail();
```

## Common operations

- `GetTail()` - Gets the last element (tail) of the queue without allocating. Returns the last string in the queue if present; otherwise `null`.
