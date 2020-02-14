using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Simulator
{
    public interface ISimulator
    {
        string Output { get; }

        /// <summary>
        /// Execute input command
        /// </summary>
        /// <param name="input">The command</param>
        /// <returns>Returns true iff command is executed, false otherwise</returns>
        bool Do(string input);
    }
}