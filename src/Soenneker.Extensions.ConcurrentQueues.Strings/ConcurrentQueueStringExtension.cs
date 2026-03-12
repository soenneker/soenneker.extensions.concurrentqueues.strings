using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Soenneker.Extensions.ConcurrentQueues.Strings;

/// <summary>
/// A helpful set of extension methods for concurrentqueue (string)
/// </summary>
public static class ConcurrentQueueStringExtension
{
    /// <summary>
    /// Gets the last element (tail) of the queue without allocating.
    /// </summary>
    /// <param name="queue">The queue to inspect.</param>
    /// <returns>
    /// The last string in the queue if present; otherwise <see langword="null"/>.
    /// </returns>
    /// <remarks>
    /// This method enumerates the queue snapshot to retrieve the final element.
    /// No allocations occur and no array copy is created.
    /// </remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? GetTail(this ConcurrentQueue<string> queue)
    {
        if (queue is null)
            throw new ArgumentNullException(nameof(queue));

        string? last = null;

        var enumerator = queue.GetEnumerator(); // struct, no boxing

        while (enumerator.MoveNext())
            last = enumerator.Current;

        //enumerator.Dispose(); // exists, but is a no-op for ConcurrentQueue's enumerator
        return last;
    }
}
