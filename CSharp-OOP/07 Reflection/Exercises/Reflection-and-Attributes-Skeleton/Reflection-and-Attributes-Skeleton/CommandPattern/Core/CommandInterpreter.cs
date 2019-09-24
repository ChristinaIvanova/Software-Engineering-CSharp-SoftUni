using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandPostFix = "Command";

        public string Read(string args)
        {
            var cmdTokens = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var commandName = cmdTokens[0] + CommandPostFix;
            var commandArgs = cmdTokens.Skip(1).ToArray();

            var assembly = Assembly.GetCallingAssembly();
            var types = assembly.GetTypes();
            var typeToCreate = types.FirstOrDefault(t => t.Name == commandName);

            if (typeToCreate == null)
            {
                throw new InvalidOperationException("Invalid Command Type!");

            }

            Object instance = Activator.CreateInstance(typeToCreate);
            ICommand command = (ICommand)instance;

            var result = command.Execute(commandArgs);

            return result;
        }
    }
}
