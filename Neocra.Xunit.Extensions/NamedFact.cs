using System.Runtime.CompilerServices;
using Humanizer;
using Xunit;

namespace Neocra.Xunit.Extensions;

public class NamedFact : FactAttribute
{
    private string displayName;

    public NamedFact([CallerMemberName] string displayName = null!)
    {
        this.displayName = displayName.Humanize();
    }

    public override string DisplayName
    {
        get => this.displayName;
        set => this.displayName = value.Humanize();
    }
}