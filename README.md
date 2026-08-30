[![](https://img.shields.io/nuget/v/soenneker.extensions.concurrentqueues.strings.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.concurrentqueues.strings/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.concurrentqueues.strings/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.concurrentqueues.strings/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.concurrentqueues.strings.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.concurrentqueues.strings/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.concurrentqueues.strings/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.concurrentqueues.strings/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.ConcurrentQueues.Strings

Reads the final string from a `ConcurrentQueue<string>` enumeration snapshot without copying the queue to an array.

## Installation

```bash
dotnet add package Soenneker.Extensions.ConcurrentQueues.Strings
```

## Usage

```csharp
using Soenneker.Extensions.ConcurrentQueues.Strings;

var queue = new ConcurrentQueue<string>();
queue.Enqueue("first");
queue.Enqueue("second");

string? tail = queue.GetTail(); // "second"
```

`GetTail()` enumerates a moment-in-time snapshot and returns its last item, or `null` when the snapshot is empty. It does not dequeue or otherwise mutate the queue.

The operation is O(n), not O(1). It avoids `ToArray()` and a full array copy, but the framework's snapshot enumerator may allocate and retains access to the observed queue segments for the duration of enumeration.

The result is observational only: another thread can dequeue that item immediately, and enqueues after snapshot creation are not reflected. Do not use it to make a check-then-act decision or to consume work. Use `TryPeek()` for the head, `TryDequeue()` for atomic consumption, or maintain separate synchronized state if frequent tail access is a requirement.

Although the queue is annotated for non-null strings, a null can still be inserted by unchecked or legacy code. In that case a null tail is indistinguishable from an empty queue through this API.
