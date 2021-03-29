using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DojoDDD.Domain
{
    public class Result
    {
        protected Result()
        {
            Messages = new HashSet<string>();
        }

        protected Result(string message)
            : this()
        {
            Messages.Add(message);
        }

        protected Result(IEnumerable<string> messages)
            : this()
        {
            Messages.UnionWith(messages);
        }

        public ISet<string> Messages { get; }

        public bool IsSuccess() => !Messages.Any();

        public static Result Ok() => new Result();

        public static Result Fail(string message) => new Result(message);

        public static Result Fail(IEnumerable<string> messages) => new Result(messages);
    }

    public class Result<TValue> : Result
    {
        private Result(string messages)
            : base(messages)
        {
        }

        private Result(IEnumerable<string> messages)
            : base(messages)
        {
        }

        public Result(TValue value)
        {
            Value = value;
        }

        public TValue Value { get; }

        public static Result<TValue> Ok(TValue value) => new Result<TValue>(value);

        new public static Result<TValue> Fail(string messsage) => new Result<TValue>(messsage);

        new public static Result<TValue> Fail(IEnumerable<string> messages) => new Result<TValue>(messages);
    }
}
