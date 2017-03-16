using System;

namespace VerseGlow.CrashReport
{
    public interface ICrashReportSender
    {
        void Send(Exception exception);
    }

    class CrashReportSender : ICrashReportSender
    {
        public void Send(Exception exception)
        {
            // send to google docs, or better to WebService hosted on https://appharbor.com/
        }
    }
}