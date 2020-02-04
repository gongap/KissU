﻿using System.Collections.Generic;

namespace KissU.Core.ServiceHosting.Extensions.Runtime
{
    /// <summary>
    /// Interface IBackgroundServiceEntryProvider
    /// </summary>
    public interface IBackgroundServiceEntryProvider
    {
        /// <summary>
        /// Gets the entries.
        /// </summary>
        /// <returns>IEnumerable&lt;BackgroundServiceEntry&gt;.</returns>
        IEnumerable<BackgroundServiceEntry> GetEntries(); 
    }
}
