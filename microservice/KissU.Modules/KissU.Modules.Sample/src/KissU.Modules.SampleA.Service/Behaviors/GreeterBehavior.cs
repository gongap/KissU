﻿using Greet;
using KissU.Dependency;

namespace KissU.Modules.SampleA.Service.Behaviors
{
    /// <summary>
    /// GreeterBehavior.
    /// Implements the <see cref="Greet.Greeter.GreeterBase" />
    /// Implements the <see cref="IServiceBehavior" />
    /// </summary>
    /// <seealso cref="Greet.Greeter.GreeterBase" />
    /// <seealso cref="IServiceBehavior" />
    public class GreeterBehavior : Greeter.GreeterBase, IServiceBehavior
    {
    }
}