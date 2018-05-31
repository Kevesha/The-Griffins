using System;
using Nancy.Hosting.Self;
using Nancy.Testing;
using Nancy.TinyIoc;
using TaskExecutor;
using TaskExecutor.Nancy;
using TaskExecutorBoundry;

namespace TaskExecutorApp
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var parser = new OptionsParser();
            return parser.ParseOptionArguments(args);
        }
    }
}
