/* MIT License (MIT)
 *
 * Copyright (c) 2020 Marc Roßbach
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IgnitionDX.Utilities
{
    public enum LogChannel
    {
        Info,
        Warning,
        Error
    }

    public static class Logger
    {
        public delegate void LogHandler(LogChannel channel, object sender, string message);
        public static event LogHandler Log;

        public static void LogInfo(object sender, string message)
        {
            OnLog(LogChannel.Info, sender, message);
        }

        public static void LogWarning(object sender, string message)
        {
            OnLog(LogChannel.Warning, sender, message);
        }

        public static void LogError(object sender, string message)
        {
            OnLog(LogChannel.Error, sender, message);
        }

        private static void OnLog(LogChannel channel, object sender, string message)
        {
            if (Log != null)
            {
                Log(channel, sender, message);
            }
        }
    }
}
