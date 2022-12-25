using AdventOfCode.Day5;
using AdventOfCode.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day5;

public class SupplyStacksTests
{
    private readonly ITestOutputHelper _outputHelper;

    public SupplyStacksTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Theory(DisplayName = "Can get top stacked crates after rearrangement using 'CrateMover 9000'")]
    [InlineData("supply-stacks.txt", "SHMSDGZVC", true)]
    [InlineData(@"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2", "CMZ", false)]
    public void GetTopCratesWithCrateMover9000(string inputData, string expected, bool readFromFile)
    {
        // given data
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;

        // extract data
        var extractor = new SupplyStacksExtractor(data);
        var cargo = extractor.ExtractCargo();
        var rearrangementProcedures = extractor.ExtractRearrangementProcedures();
        
        // using CrateMover 9000
        var crane = new CrateMover9000(cargo, rearrangementProcedures);
        var sut = new SupplyStacksService(crane);

        // when
        var actual = sut.RearrangeCrates();

        // then
        Assert.Equal(expected, actual);
        _outputHelper.WriteLine($"Crates stacked at the top of the cargo are {actual}");
    }
    
    [Theory(DisplayName = "Can get top stacked crates after rearrangement using 'CrateMover 9001'")]
    [InlineData("supply-stacks.txt", "VRZGHDFBQ", true)]
    [InlineData(@"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2", "MCD", false)]
    public void GetTopCratesWithCrateMover9001(string inputData, string expected, bool readFromFile)
    {
        // given data
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;

        // extract data
        var extractor = new SupplyStacksExtractor(data);
        var cargo = extractor.ExtractCargo();
        var rearrangementProcedures = extractor.ExtractRearrangementProcedures();
        
        // using CrateMover 9001
        var crane = new CrateMover9001(cargo, rearrangementProcedures);
        var sut = new SupplyStacksService(crane);

        // when
        var actual = sut.RearrangeCrates();

        // then
        Assert.Equal(expected, actual);
        _outputHelper.WriteLine($"Crates stacked at the top of the cargo are {actual}");
    }
}