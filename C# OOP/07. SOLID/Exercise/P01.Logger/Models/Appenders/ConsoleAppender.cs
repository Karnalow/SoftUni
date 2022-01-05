using P01.Logger.Common;
using P01.Logger.IOManagment.Contracts;
using P01.Logger.Models.Contracts;
using P01.Logger.Models.Enumerations;
using System;

namespace P01.Logger.Models.Appenders
{
    public class ConsoleAppender : Appender
    {
        private readonly IWriter writer;
        public ConsoleAppender(ILayout layout, Level level)
            : base(layout, level)
        {
            this.writer = new ConsoleWriter();
        }

        public override void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedString = String.Format(format, dateTime.ToString(GlobalConstants.DateTimeFormat), level.ToString(), message);

            this.writer.WriteLine(formattedString);
            this.messagesAppended++;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
