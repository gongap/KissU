﻿using System.Collections.Generic;

namespace KissU.Grpc.Runtime
{
    /// <summary>
    /// Interface IGrpcServiceEntryProvider
    /// </summary>
    public interface IGrpcServiceEntryProvider
    {
        /// <summary>
        /// Gets the entries.
        /// </summary>
        /// <returns>List&lt;GrpcServiceEntry&gt;.</returns>
        List<GrpcServiceEntry> GetEntries();
    }
}