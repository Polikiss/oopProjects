using System;
using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CopyChain;

public class FileCopyHandler : ResponsibilityChainBase
{
    public override ParseResult Handle(Request request)
    {
        if (request.Arguments.Current.StartsWith("copy", StringComparison.Ordinal))
        {
            if (request.Arguments.MoveNext() is false)
                return new ParseResult.Fail("Missing Arguments");
            var builder = new FileCopyModel.Builder();
            var source = new SourcePathChainHandler();
            ParseArgumentResult result = source.Handle(request, builder);
            if (result is ParseArgumentResult.ParseArgumentFail sourceFail)
            {
                return new ParseResult.Fail(sourceFail.Message);
            }

            return new ParseResult.Success(new FileCopyCommand(builder.Build()));
        }

        return NextCommand is not null ? NextCommand.Handle(request) : new ParseResult.Fail("Unknown command");
    }
}