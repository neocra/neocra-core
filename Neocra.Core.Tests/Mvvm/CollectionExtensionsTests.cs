using System.Collections.Generic;
using System.Collections.ObjectModel;
using Neocra.Core.Mvvm;
using Neocra.Xunit.Extensions;
using Xunit;

namespace Neocra.Core.Tests.Mvvm;

public class CollectionExtensionsTests
{
    [NamedFact]
    public void Should_return_observable_collection_When_input_is_list()
    {
        var list = new List<int>
        {
            1, 2, 3
        };

        var result = list.ToObservable();

        Assert.IsType<ObservableCollection<int>>(result);
        Assert.Collection(result, 
            c=> Assert.Equal(1, c),
            c=> Assert.Equal(2, c),
            c=> Assert.Equal(3, c));
    }
    
    [NamedFact]
    public void Should_return_observable_collection_When_input_is_list_of_string()
    {
        var list = new List<string>
        {
            "1", "2", "3"
        };

        var result = list.ToObservable(int.Parse);

        Assert.IsType<ObservableCollection<int>>(result);
        Assert.Collection(result, 
            c=> Assert.Equal(1, c),
            c=> Assert.Equal(2, c),
            c=> Assert.Equal(3, c));
    }
}