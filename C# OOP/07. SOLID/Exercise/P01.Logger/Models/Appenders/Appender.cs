﻿using P01.Logger.Models.Contracts;
using P01.Logger.Models.Enumerations;

namespace P01.Logger.Models.Appenders
{
    public abstract class Appender : IAppender
    {
        protected int messagesAppended;
        protected Appender(ILayout layout, Level level)
        {
            Layout = layout;
            Level = level;
        }

        public ILayout Layout { get; }

        public Level Level { get; }

        public abstract void Append(IError error);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}";
        }
    }
}
