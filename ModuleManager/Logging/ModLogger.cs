﻿using System;

namespace ModuleManager.Logging
{
    public class ModLogger : IBasicLogger
    {
        private readonly string prefix;
        private readonly IBasicLogger logger;

        public ModLogger(string prefix, IBasicLogger logger)
        {
            if (string.IsNullOrEmpty(prefix)) throw new ArgumentNullException(nameof(prefix));
            this.prefix = $"[{prefix}] ";
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Log(ILogMessage message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            logger.Log(new LogMessage(message.LogType, prefix + message.Message));
        }
    }
}
