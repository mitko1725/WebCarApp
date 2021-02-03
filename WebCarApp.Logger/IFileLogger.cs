using System;
using System.Collections.Generic;
using System.Text;

namespace WebCarApp.Logger
{
    public interface IFileLogger
    {
        void WriteSmtpLog(string message);
        void WriteProgramLog(string message);
        void WriteErrorLog(string message);
    }


