using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Soenneker.Extensions.ConcurrentQueues.Strings;

/// <summary>
/// Provides observation helpers for concurrent queues of strings.
/// </summary>
public static class ConcurrentQueueStringExtension
{
    /// <summary>
    /// Gets the final element in the queue's enumeration snapshot.
    /// </summary>
    /// <param name="queue">The queue to inspect.</param>
    /// <returns>
    /// The last string in the queue if present; otherwise <see langword="null"/>.
    /// </returns>
    /// <remarks>
    /// This method performs an O(n) enumeration of a moment-in-time snapshot. The returned item may be removed immediately by
    /// another thread, and items enqueued after snapshot creation are not included.
    /// </remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? GetTail(this ConcurrentQueue<string> queue)
    {
        if (queue is null)
            throw new ArgumentNullException(nameof(queue));

        string? last = null;

        using IEnumerator<string> enumerator = queue.GetEnumerator();

        while (enumerator.MoveNext())
            last = enumerator.Current;

        return last;
    }
}
