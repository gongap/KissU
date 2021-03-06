﻿using System;

namespace KissU.CPlatform
{
    /// <summary>
    /// Identify.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class IdentifyAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentifyAttribute" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public IdentifyAttribute(CommunicationProtocol name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public CommunicationProtocol Name { get; set; }
    }
}